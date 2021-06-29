using System;
using System.Windows.Forms;

namespace File_Transfer.WinForm
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Show()
        {
            Help_RTB.Text = "1.本软件适用于局域网内文件传输，传输文件不包括文件夹类型的文件，\n"
                            + "2.主界面有本机IP地址。\n"
                            + "3.本软件集服务器与客户端为一体，分别为接受文件和传输文件。\n"
                            + "4.传输文件时需要输入对方IP地址。\n"
                            + "5.端口号为固定的3344。\n"
                            + "6.保存文件时，如果文件存在，则会提示是否覆盖，选择否时会直接退出传输";


        }

        private void Help_Load(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}
