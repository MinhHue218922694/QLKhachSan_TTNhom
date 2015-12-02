using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KETNOI_MUONTRA;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
     public class MuonSach
    {
        Connect kn = new Connect();
        public DataTable HienThi_SachMuon()
        {
            string sql = "sp_TTMUON";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
        //public string Insert_Muon(string _MaDG, string _MaSach, DateTime _NgayMuon,DateTime _NgayHenTra)
        //{
        //    string str = "";
        //    string sql = "sp_InsertSachMuon";
        //    SqlConnection con = new SqlConnection(Connect.GetConnect());
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@MaDG", _MaDG);
        //    cmd.Parameters.AddWithValue("@MaSach", _MaSach);
        //    cmd.Parameters.AddWithValue("@NgayMuon", _NgayMuon );
        //    cmd.Parameters.AddWithValue("@NgayHenTra", _NgayHenTra);
            
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(dt);
        //    str = dt.Rows[0].ItemArray[0].ToString();
        //    cmd.Dispose();
        //    con.Close();
        //    return str;
        //}
        public void Insert_Muon(string _MaDG, string _MaSach, DateTime _NgayMuon, DateTime _NgayHenTra)
        {
          //  string str = "";
            string sql = "sp_InsertSachMuon";
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaDG", _MaDG);
            cmd.Parameters.AddWithValue("@MaSach", _MaSach);
            cmd.Parameters.AddWithValue("@NgayMuon", _NgayMuon);
            cmd.Parameters.AddWithValue("@NgayHenTra", _NgayHenTra);

            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
         //   da.Fill(dt);
            cmd.ExecuteNonQuery();
           // str = dt.Rows[0].ItemArray[0].ToString();
            cmd.Dispose();
            con.Close();
         //   return str;
        }
        public void UpDate_MuonSach(string _MaDG, string _MaSach, DateTime _NgayMuon, DateTime _NgayHenTra)
        {
            string sql = "sp_UpdateMonTra";
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaDG", _MaDG);
            cmd.Parameters.AddWithValue("@MaSach", _MaSach);
            cmd.Parameters.AddWithValue("@NgayMuon", _NgayMuon);
            cmd.Parameters.AddWithValue("@NgayHenTra", _NgayHenTra);
          
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void DeleteSachMuon(string MaSach)
        {
            string sql = "sp_DeletMuon_QL";
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaSach", MaSach);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public DataTable ShowMuonTHeoNgay(DateTime date1, DateTime date2)
        {
            DataTable dt = new DataTable();
            string sql = "sp_ShowMuon_time";
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@date1", date1);
            cmd.Parameters.AddWithValue("@date2", date2);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            con.Close();
            cmd.Dispose();
            return dt;
        }

    }
}
