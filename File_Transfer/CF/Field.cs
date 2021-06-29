using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace File_Transfer.CF
{
    class Field
    {
    }

    class ComputerInformation
    {
        public string ipAddress { get; set; }
        public string computerName{ get; set; }
        public void ComputerI(string H_IPAddress,string Computer)
        {
            ipAddress = H_IPAddress;
            computerName = Computer;
        }
    }

    class TD
    {
        public string filename { get; set; }
        public int total { get; set; }
        public BinaryReader reader { get; set; }
        public Thread worker { get; set; }
    }
}
