using File_Transfer.CF;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Transfer.WinForm
{
    public partial class Receive_File : Form
    {
        GHI ghi = new GHI();
        string saveAs = null;
        Thread worker;
        int port;
        private long total;
        private BinaryReader reader;
        private string filename;
        private Task TK;
        private FileStream fs;
        private static bool Singel = true;         
        public Receive_File()
        {
            InitializeComponent();

        }

        #region 开始监听             
        private void btnStartListen_Click(object sender, System.EventArgs e)
        {
            if (ghi.NVJ(Port_TB.Text, "端口"))
                port = int.Parse(Port_TB.Text);
            else
                return;
            Singel = true;
            Start_BT.Enabled = false;
            worker = new Thread(new ThreadStart(Start));
            worker.IsBackground = true;/*设置为后台线程*/
            worker.Start();

        }
        #endregion

        #region 接收功能       
        private void Start()
        {
            try
            {
                this.Invoke((EventHandler)(delegate
                {
                    tlblState.Text = "状态：开始监听中...";
                }));
                TcpListener tcpListener = new TcpListener(IPAddress.Any, port);

                try
                {
                    tcpListener.Stop();
                    tcpListener.Start();
                }
                catch (Exception)
                {
                    if (this.IsDisposed)
                        this.Invoke((EventHandler)(delegate
                   {
                       tlblState.Text = "状态：监听端口出错！";

                   }));

                    Start_BT.Enabled = true;
                    worker.Abort();
                    return;
                }

                try
                {
                    this.Invoke((EventHandler)(delegate
                    {
                        progressBar1.Minimum = 0;
                        tlblState.Text = "状态：监听中......！";
                    }));

                    while (Singel)
                    {
                        FN_LB.Text = "文件名";
                        S_LB.Text = "大小";

                        //下面的循环作用是等待新的连接请求到来
                        while (!tcpListener.Pending()&&Singel)/*检测连接状态*/
                            Thread.Sleep(100);/*等待连接*/


                        this.Invoke((EventHandler)(delegate
                        {
                            progressBar1.Minimum = 0;
                            tlblState.Text = "状态：开始接收文件！";
                        }));


                        Control.CheckForIllegalCrossThreadCalls = false; /*使控件可以接受线程值*/
                        TcpClient tcpClient = tcpListener.AcceptTcpClient();/*定义TCP变量并连接对方*/
                        IP_TB.Text = tcpClient.Client.RemoteEndPoint.ToString().Split(':')[0];/*获取对方IP信息*/
                        tcpClient.NoDelay = true;/*取消延迟*/
                        tcpClient.ReceiveTimeout = 30000;/*设定接受时长*/

                        reader = new BinaryReader(tcpClient.GetStream());/*读取数据*/
                        try
                        {
                            filename = reader.ReadString();/*文件名称*/
                            total = reader.ReadInt64();/*文件大小*/
                            progressBar1.Maximum = Convert.ToInt32(total);/*设置进度条的最大值*/


                            FN_LB.Text = "文件名：" + filename;
                            S_LB.Text = "大小：" + SizeConversion(total);

                            Action A = new Action(SvaeFile);/*定义保存文件的委托并调用保存文件的方法*/
                            TK = Task.Run(A);/*定义任务并调用委托以启动保存文件的方法*/
                            TK.Wait();/*任务等待，等待任务执行完成*/
                        }
                        catch (Exception)/*异常捕获*/
                        {
                            if (this.IsDisposed)
                                this.Invoke((EventHandler)(delegate
                            {
                                tlblState.Text = "状态：文件接收中途出错！";
                                Start_BT.Enabled = true;
                            }));
                        }
                        finally/*关闭连接*/
                        {
                            TK.Dispose();
                            reader.Close();
                            tcpClient.Close();
                        }
                    }
                }
                finally/*关闭连接*/
                {
                    tcpListener.Stop();
                }
            }
            catch (Exception)/*异常捕获*/
            {
                if(this.IsDisposed)
                this.Invoke((EventHandler)(delegate
                {
                    Start_BT.Enabled = true;
                    tlblState.Text = "状态：用户中断！";

                }));
            }
            finally/*关闭连接*/
            {
                worker = null;
            }
        }
        #endregion

        #region 保存文件
        /*保存文件*/
        private void SvaeFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();/*定义文件保存控件*/
            sfd.FileName = filename;/*文件名称*/
            if (sfd.ShowDialog(this) == DialogResult.OK)/*确认保存*/
                saveAs = sfd.FileName;
            else
                saveAs = null;

            if (saveAs == null) /*取消保存*/
            {
                this.Invoke((EventHandler)(delegate
                {
                    tlblState.Text = "状态：你拒绝了该文件！";
                }));
            }

            else
            {
                this.Invoke((EventHandler)(delegate
                {
                    tlblState.Text = "状态：文件接收中...";
                }));

                fs = File.Create(saveAs);/*定义写入文件流*/
                try
                {
                    byte[] buffer = new byte[8192];
                    int len;
                    while (total > 0)
                    {
                        len = reader.Read(buffer, 0, 8192);
                        if (len == 0)
                        {
                            this.Invoke((EventHandler) (delegate { tlblState.Text = "状态：对方终止连接！"; }));
                            worker.Abort();
                            return;
                        }

                        fs.Write(buffer, 0, len);
                        progressBar1.Value += len;

                        Application.DoEvents();
                        total -= len;
                    }

                    this.Invoke((EventHandler) (delegate { tlblState.Text = "状态：文件接收完成！"; }));
                    progressBar1.Value = 0;
                }
                catch (Exception)
                {
                    this.Invoke((EventHandler)(delegate { tlblState.Text = "状态：未接收到文件！"; }));
                }
                finally
                {
                    FN_LB.Text = "文件名";
                    S_LB.Text = "大小";
                    fs.Close();
                }
            }
        }
        #endregion

        #region 控件获取焦点              
        private void Receive_File_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.Port_TB;          
            Port_TB.Focus();
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

        private void Receive_File_FormClosing(object sender, FormClosingEventArgs e)
        {
            Singel = false;
        }
      
    }
}
