using File_Transfer.CF;
using File_Transfer.WinForm;
using System;
using System.Threading;
using System.Windows.Forms;
using Help = File_Transfer.WinForm.Help;

namespace File_Transfer
{
    public partial class Form1 : Form
    {
        //ComputerInformation CI = new ComputerInformation();
        GHI ghi = new GHI();
        public Form1()
        {
            InitializeComponent();
            IP_Lab.Text = "本机IP:" + ghi.GetHostInformation().ipAddress;
        }

        public void ThreadProc1()
        {
            SendForm RF = new SendForm();
            RF.ShowDialog();
        }
        public void ThreadProc2()
        {
            Receive_File RF = new Receive_File();
            RF.ShowDialog();
        }
        public void ThreadProc3()
        {
            Help RF = new Help();
            RF.ShowDialog();
        }



        private void Rec_But_Click(object sender, EventArgs e)
        {
            Thread T = new Thread(new ThreadStart(ThreadProc2));
            T.Start();
        }

        private void Sen_But_Click(object sender, EventArgs e)
        {
            ThreadProc1();

        }

        private void Help_BT_Click(object sender, EventArgs e)
        {
            Thread T = new Thread(new ThreadStart(ThreadProc3));
            T.Start();
        }
    }
}
