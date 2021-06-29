using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace File_Transfer.CF
{
    class GHI
    {
        #region 为空判断
        public bool NVJ(string Num,string Text)
        { 
            if (Num != string.Empty)
                return true;
            MessageBox.Show(Text+"为空", "提示", MessageBoxButtons.OK);
            return false;           
        } 
        #endregion
        #region 获取主机信息
        /// <summary>
        ///获取主机信息
        /// </summary>
        /// <returns></returns>
        public ComputerInformation GetHostInformation()
        {
            ComputerInformation CI=new ComputerInformation();/*定义计算机环境变量*/
            string s = "";
            IPAddress[] addressList = Dns.GetHostAddresses(Dns.GetHostName());/*根据主机名获取主机IP地址*/
            foreach (IPAddress AL in addressList)
            {
                if(AL.AddressFamily==AddressFamily.InterNetwork)/*获取IPV4*/
                s += AL.ToString();
            }
            CI.ComputerI(s, Environment.GetEnvironmentVariable("ComputerName"));/*给环境边梁赋值IP*/
            return CI;
        }
        #endregion
    }
}
