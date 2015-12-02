using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace KETNOI_MUONTRA
{
    public class Connect
    {
        SqlConnection cn = new SqlConnection();
        public static string GetConnect()
        {
            return (@"Data Source=NGUYENHUE-PC\SQLEXPRESS;Initial Catalog=LAMLAI;Integrated Security=True");
       
        }
    }
}
