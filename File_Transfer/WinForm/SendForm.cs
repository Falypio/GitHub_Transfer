using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using File_Transfer.CF;

namespace File_Transfer.WinForm
{
    public partial class SendForm : Form
    {
        #region 初始化        
        private Thread worker;//这是一个工作线程
        private string filename;
        GHI ghi = new GHI();
        private const int port = 3344;
        public SendForm()
        {
            InitializeComponent();           
        }
        #endregion

        #region 启动数据发送功能
        private void Send_Click(object sender, EventArgs e)
        {
            Cancel_BT.Enabled = true;
            Choice_BT.Enabled = false;
            Send_BT.Enabled = false;

            worker = new Thread(new ThreadStart(Start))
            {
                IsBackground = true
            };
            worker.Start();
        }
        #endregion

        #region 文件选择功能
        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = "c:/",
                Filter = "所有文件|*.*",
                FilterIndex = 1
            };

            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                File_TB.Text = ofd.SafeFileName;
                filename = ofd.FileName;
            }
            if (!File.Exists(filename))
            {
                MessageBox.Show("文件不存在！");
                return;
            }
            Send_BT.Enabled = true;
        }
        #endregion

        #region 数据发送功能
        private void Start()
        {
            try
            {
                this.Invoke((EventHandler)(delegate
                {
                    ST.Text = "状态：正在连接...";
                    PB.Minimum = 0;
                }));
                TcpClient tcpClient = new TcpClient
                {
                    NoDelay = true,
                    SendTimeout = 30000
                };

                #region 传输连接            
                try
                {
                    if(ghi.NVJ(Rece_IP.Text,"IP地址"))
                        tcpClient.Connect(Rece_IP.Text, port);/*根据指定IP地址和端口连接指定主机*/
                    else
                    {
                        throw new ArgumentNullException("");/*抛出IP为空异常*/
                    }
                }
                catch (Exception)
                {
                    this.Invoke((EventHandler)(delegate
                    {
                        ST.Text = "状态：连接出错...";
                        Cancel_BT.Enabled = false;
                        Send_BT.Enabled = true;
                        Choice_BT.Enabled = true;
                    }));
                    worker = null;
                    return;
                }
                #endregion

                #region 数据发送 
                BinaryWriter writer = new BinaryWriter(tcpClient.GetStream());/*定义读取文件数据变量*/
                try
                {
                    this.Invoke((EventHandler)(delegate
                    {
                        ST.Text = "状态：开始发送文件信息...";
                    }));
                    FileInfo fi = new FileInfo(filename);/*定义文件信息变量并根据*/
                  
                    writer.Write(fi.Name);/*给读取文件变量赋值--文件名*/
                    writer.Write(fi.Length);/*给读取文件变量赋值--文件长度*/

                    this.Invoke((EventHandler)(delegate
                    {
                        PB.Maximum = Convert.ToInt32(fi.Length);/*进度条赋值*/
                        ST.Text = "状态：正在发送文件内..";
                    }));
                    FileStream fs = fi.OpenRead();/*读取文件数据*/

                    #region 数据发送循环                   
                    try
                    {
                        byte[] buffer = new byte[8192];
                        int len;
                        while ((len = fs.Read(buffer, 0, 8192)) != 0)
                        {
                            writer.Write(buffer, 0, len);
                            this.Invoke((EventHandler)(delegate
                            {
                                PB.Value += len;
                            }));
                        }
                        this.Invoke((EventHandler)(delegate
                        {
                            PB.Value = 0;
                            ST.Text = "状态：文件内容发送完成!";
                            Cancel_BT.Enabled = false;
                            Send_BT.Enabled = true;
                        }));
                    }
                    finally
                    {
                        this.Invoke((EventHandler)(delegate
                        {
                            Choice_BT.Enabled = true;
                            fs.Close();
                        }));
                    }
                    #endregion
                }               
                catch (Exception)
                {
                    this.Invoke((EventHandler)(delegate
                    {
                        PB.Value = 0; 
                        ST.Text = "状态：文件发送过程出现错误!";
                        Cancel_BT.Enabled = false;
                        Send_BT.Enabled = true;
                    }));
                }
                #endregion
            }
            catch (Exception)
            {
                this.Invoke((EventHandler)(delegate
                {
                    PB.Value = 0;
                    ST.Text = "状态：用户中断!";
                    Cancel_BT.Enabled = false;
                    Send_BT.Enabled = true;
                }));
            }
            finally
            {
                worker = null;
            }

        }
        #endregion

        #region 取消按钮
        private void Cancel_But_Click(object sender, EventArgs e)
        {
            worker.Abort();/*发送线程处于终止状态*/
            ST.Text = "状态：取消发送!";
            Cancel_BT.Enabled = false;
            Send_BT.Enabled = true;
        }
        #endregion

        private void SendForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.Rece_IP;
            Rece_IP.Focus();
            Send_BT.Enabled = false;
            Cancel_BT.Enabled = false;
        }
    }
}
