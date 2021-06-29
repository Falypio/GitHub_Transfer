using File_Transfer.CF;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace File_Transfer.WinForm
{
    public partial class Receive_File : Form
    {
        #region 初始化 
        GHI ghi = new GHI();/*函数调用*/
        //string saveAs = null;
        Thread worker;/*线程字段定义*/
        const int port = 3344;/*定义字段常量*/

        private int DR = 0;
        //private long total;
        //private BinaryReader reader;
        //private string filename;
        //private Task TK;
        private TcpListener tcpListener;/*定义TCP协议侦听字段*/
        //private FileStream fs;
        //private static bool Singel = true;
        public Receive_File()
        {
            InitializeComponent();/*初始化*/
            CheckForIllegalCrossThreadCalls = false; /*使控件可以接受线程值*/
        }
        #endregion

        #region 开启监听功能
        /// <summary>
        /// 开始按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartListen_Click(object sender, System.EventArgs e)
        {
            Start_BT.Enabled = false;/*控件不能再使用*/
            worker = new Thread(new ThreadStart(Start))
            {
                IsBackground = true/*设置为后台线程*/
            };/*线程调用无参函数*/
            worker.Start();/*启用线程*/
        }
        #endregion

        #region 绑定套接字并开启侦听功能     
        private void Start()
        {
            tcpListener = new TcpListener(IPAddress.Any, port);/*TCP套接字绑定IP和接口，IP为任意IP*/
            this.Invoke((EventHandler)(delegate
                {
                    tlblState.Text = "状态：开始监听中...";
                }));/*委托，tlblState.Text显示当前状态*/
            Thread TD = new Thread(new ThreadStart(TwoThead));/*定义线程并调用无参函数*/
            TD.Start(); /*启用线程*/
        }
        #endregion

        #region 开启侦听功能并开始
        void TwoThead()
        {
            try
            {


                tcpListener.Start(); /*TCP字段启动侦听*/
                while (true)
                {
                    while (!tcpListener.Pending()) /*检测连接状态*/
                        Thread.Sleep(100); /*等待连接*/
                    TcpClient TC = this.tcpListener.AcceptTcpClient(); /*创建TCP客户端变量并等待链接*/
                    Thread TK = new Thread(new ParameterizedThreadStart(OneThead)); /*定义线程并调用有参函数*/
                    TK.Start((object) TC); /*启动线程并传递tcpclient字段*/
                }
            }
            catch (Exception)
            {
               
            }
            finally
            {
                tcpListener.Stop();
            }
        }
        #endregion

        #region 开始侦听并读取保存数据
        void OneThead(object TL)
        {
            long total, a = 0, b = 0, c = 0;/*定义变量a是文件接收的数据字节，b为接收的文件字节总数，total和c是文件总字节数*/
            int dr = DR;
            string saveAs = null;/*定义状态变量*/
            FileStream fs;/*定义文件流变量*/
            TcpClient tcpClient = (TcpClient)TL;/*定义TCp客户端连接变量并把传递过来的TCp客户端连接变量TL转换成TCp客户端连接变量*/

            tcpClient.NoDelay = true;/*取消延迟*/
            tcpClient.ReceiveTimeout = 30000;/*设定接受时长*/
            BinaryReader reader = new BinaryReader(tcpClient.GetStream());/*读取数据*/

            #region 保存文件
            try
            {
                String filename = reader.ReadString();/*文件名称*/
                total = reader.ReadInt64();/*文件大小*/
                dataGridView1.Rows.Add(filename, SizeConversion(total)/*datagridview控件添加文件数据*/
                    , "正在接收文件中", tcpClient.Client.RemoteEndPoint.ToString().Split(':')[0].ToString(), 0);
                DR++;/*文件数量加一*/
                c = total;
                SaveFileDialog sfd = new SaveFileDialog
                {
                    FileName = filename
                };/*定义文件保存控件*/
                ;/*文件名称*/
                if (sfd.ShowDialog(this) == DialogResult.OK)/*确认保存*/
                    saveAs = sfd.FileName;
                else
                    saveAs = null;
                if (saveAs == null) /*取消保存*/
                {
                    this.Invoke((EventHandler)(delegate
                    {
                        this.Invoke((EventHandler)(delegate { dataGridView1[2, dr].Value = "状态：你拒绝了该文件"; }));/*datagridview修改状态*/
                    }));/*委托，tlblState.Text显示当前状态*/
                }

                else
                {
                    this.Invoke((EventHandler)(delegate
                    {
                        dataGridView1[2, dr].Value = "文件接收中...";/*datagridview修改状态*/
                    }));

                    fs = File.Create(saveAs);/*定义写入文件流*/
                    try
                    {
                        byte[] buffer = new byte[8192];/*定义文件缓冲区*/
                        int len;
                        while (total > 0)
                        {
                            len = reader.Read(buffer, 0, 8192);/*读取文件长度并返回文件二进制流buffer*/
                            if (len == 0)
                            {
                                this.Invoke((EventHandler)(delegate { dataGridView1[2, dr].Value = "对方终止连接！"; }));/*datagridview修改状态*/
                                worker.Abort();
                                return;
                            }
                            fs.Write(buffer, 0, len); /*文件流写入*/
                            a = a + len;
                            b = a;
                            dataGridView1[4, dr].Value = Convert.ToInt32(b * 100 / c);/*进度条*/
                            Application.DoEvents();/*使应用处理当前消息，防止窗口卡顿*/
                            total -= len;
                        }
                        this.Invoke((EventHandler)(delegate { dataGridView1[2, dr].Value = "状态：文件接收完成！"; }));/*datagridview修改状态*/
                    }
                    catch (Exception)
                    {
                        this.Invoke((EventHandler)(delegate { dataGridView1[2, dr].Value = "状态：文件接收中途出错！"; }));/*datagridview修改状态*/
                    }
                    finally
                    {
                        fs.Close();
                    }
                }
            }
            catch (Exception)/*异常捕获*/
            {
                if (this.IsDisposed)
                    this.Invoke((EventHandler)(delegate { dataGridView1[2, dr].Value = "状态：文件接收中途出错！"; }));/*datagridview修改状态*/
            }
            finally/*关闭连接*/
            {
                reader.Close();
                tcpClient.Close();
            }
            #endregion
        }
        #endregion

        #region 大小换算
        private string SizeConversion(double a)
        {
            int i = 0;
            string[] b = new string[4] { "B", "KB", "MB", "GB" };
            bool singl = true;
            while (singl && !a.Equals(""))
            {
                if (a > 1024 && i < 3)
                {
                    a = a / 1024;
                }
                else
                {
                    singl = false;
                    return (a.ToString("0.00") + b[i]);
                }
                i++;
            }
            return "";
        }
        #endregion

        #region MyRegion               
        private void Receive_File_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tcpListener != null)
                tcpListener.Stop();

        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion
    }

}

