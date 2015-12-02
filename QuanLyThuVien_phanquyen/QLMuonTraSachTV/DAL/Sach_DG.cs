using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using KETNOI_MUONTRA;
using DAL;
namespace DAL
{
    public class Sach_DG
    {
        
        Connect kn = new Connect();
       public  DataView dv;
        public DataTable HienThi()
        {
            string sql = "sp_TTSach_DG";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            dv = new DataView(dt);
            return dt;
        }


       
    }
}
