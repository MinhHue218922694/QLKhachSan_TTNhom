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
    public class DocGia
    {
        Connect cn = new Connect();

        public DataTable HienThi_DocGia()
        {
            string sql = "sp_TTDocGia";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
        public string Insert_DocGia(string _TenDG, DateTime _NgaySinh , string _Lop, string _ChucVu, string _Sdt, string _GioiTinh)
        {

            string str = "";
            string sql = "sp_InserDocGia_QL";
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TenDG", _TenDG);
            cmd.Parameters.AddWithValue("@NgaySinh", _NgaySinh);
            cmd.Parameters.AddWithValue("@Lop",_Lop);
            cmd.Parameters.AddWithValue("@ChucVu", _ChucVu);
            cmd.Parameters.AddWithValue("@Sdt", _Sdt);
            cmd.Parameters.AddWithValue("@GioiTinh", _GioiTinh);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            str = dt.Rows[0].ItemArray[0].ToString();
            cmd.Dispose();
            con.Close();
            return str;
        }
        public void UpDate_DocGia(string _MaDG, string _TenDG, DateTime _NgaySinh, string _Lop, string _ChucVu, string _Sdt, string _GioiTinh)
        {
            string sql = "sp_UpdateDocGia_QL";
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaDG", _MaDG);
            cmd.Parameters.AddWithValue("@TenDG", _TenDG);
            cmd.Parameters.AddWithValue("@NgaySinh", _NgaySinh);
            cmd.Parameters.AddWithValue("@Lop", _Lop);
            cmd.Parameters.AddWithValue("@ChucVu", _ChucVu);
            cmd.Parameters.AddWithValue("@Sdt", _Sdt);
            cmd.Parameters.AddWithValue("@GioiTinh", _GioiTinh);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void DeleteDocGia(string MaDG)
        {
            string sql = "sp_DeleteDocGia_QL";
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaDG",MaDG);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
    }
}
