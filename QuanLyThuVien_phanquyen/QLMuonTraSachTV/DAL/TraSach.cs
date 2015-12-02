using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using KETNOI_MUONTRA;
namespace DAL
{
    public class TraSach
    {
        Connect kn = new Connect();
        public DataTable HienThi_SachMuon()
        {
            string sql = "sp_TTTra";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
        
        }
    }

