using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLogic
{
    public class KetNoiDB
    {
        SqlConnection cn = new SqlConnection();
        static public String getconnect()
        {
<<<<<<< HEAD
            return (@"Data Source=KHANHCON-PC;Initial Catalog=Bai6_BanHangSieuThi;Integrated Security=True");
=======
            return (@"Data Source=KHANHCON-PC;Initial Catalog=Bai6_BanHangSieuThi;Integrated Security=True");
>>>>>>> dcb7d6d6c4ac40a052b4accf298b0a784f01f445
        }
    }
}
