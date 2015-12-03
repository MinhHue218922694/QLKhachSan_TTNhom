using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Management;
namespace QuanLiNhanSu
{
    class ConnectDATA
    {
        public static string getconnect()
        {
            string str = ConfigurationManager.ConnectionStrings["ConnectQLNS"].ToString();
            return str;
        }
    }
}
