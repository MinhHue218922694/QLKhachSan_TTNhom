using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using KETNOI_MUONTRA;
using System.Data;


namespace BangQL_Class
{
    public class Sach_DG
    {
        Connect kn = new Connect();
        public DataTable HienThi()
        {
            string sql = "sp_TTSach_DG";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(sql);
            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.CommandType = CommandType.StoredProcedure;           
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }

        public object HienThiDal()
        {
            throw new NotImplementedException();
        }
    }
}
