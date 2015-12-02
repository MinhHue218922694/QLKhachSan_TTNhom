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
    public class ChiTietNXB
    {
        Connect kn = new Connect();
        public DataTable HienThi_ChiTietNXB()
        {
            string sql = "sp_TTNXB";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
        public string Insert_NXB(string _TenNXB, string _DienThoai, string _DiaChi, string _Email)
        {

            string str = "";
            string sql = "sp_InsertNXB_QL";
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TenNXB", _TenNXB);
            cmd.Parameters.AddWithValue("@DienThoai", _DienThoai);
            cmd.Parameters.AddWithValue("@DiaChi", _DiaChi);
            cmd.Parameters.AddWithValue("@Email", _Email);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            str = dt.Rows[0].ItemArray[0].ToString();
            cmd.Dispose();
            con.Close();
            return str;
        }
        public void UpDate_NXB(string _MaNXB, string _TenNXB, string _DienThoai, string _DiaChi, string _Email)
        {
            string sql = "sp_UpdateNXB_QL";
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MaNXB", _MaNXB);
            
            cmd.Parameters.AddWithValue("@TenNXB", _TenNXB);
            cmd.Parameters.AddWithValue("@DienThoai", _DienThoai);
            cmd.Parameters.AddWithValue("@DiaChi", _DiaChi);
            cmd.Parameters.AddWithValue("@Email", _Email);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void DeleteNXB(string MaNXB)
        {
            string sql = "sp_DeleteNXB_QL";
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaNXB", MaNXB);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
      
    }
}
