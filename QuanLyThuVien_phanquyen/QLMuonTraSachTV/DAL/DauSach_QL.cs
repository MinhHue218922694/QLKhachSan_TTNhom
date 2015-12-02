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
    public class DauSach_QL
    {
        Connect cn = new Connect();
        
        public DataTable HienThi_DauSach()
        {
            string sql = "sp_TTDauSach";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;            
            da.Fill(dt);           
            return dt;
        }
      

       


        public string Insert_DauSach(string _TenDauSach, string _MaTg, string _MaTl, string _MaNXB, DateTime _NamXB, long _Gia, int _SoLuong)
        {
            
                string str = "";
                string sql = "sp_InsertDauSach_QL";
                SqlConnection con = new SqlConnection(Connect.GetConnect());
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tendausach", _TenDauSach);
                cmd.Parameters.AddWithValue("@matg", _MaTg);
                cmd.Parameters.AddWithValue("@matl", _MaTl);
                cmd.Parameters.AddWithValue("@manxb", _MaNXB);
                cmd.Parameters.AddWithValue("@namxb", _NamXB);
                cmd.Parameters.AddWithValue("@gia", _Gia);
                cmd.Parameters.AddWithValue("@soluong", _SoLuong);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                str = dt.Rows[0].ItemArray[0].ToString();
                cmd.Dispose();
                con.Close();
                return str;          
        }
        public void UpDate_DauSach(string _MaDauSach,string _TenDauSach, string _MaTg, string _MaTl, string _MaNXB, DateTime _NamXB, long _Gia,int _SoLuong)
        {
            string sql = "sp_UpdateDauSach_QL";
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@madausach", _MaDauSach);
            cmd.Parameters.AddWithValue("@tendausach", _TenDauSach);
            cmd.Parameters.AddWithValue("@matg", _MaTg);
            cmd.Parameters.AddWithValue("@matl", _MaTl);
            cmd.Parameters.AddWithValue("@manxb", _MaNXB);
            cmd.Parameters.AddWithValue("@namxb", _NamXB);
            cmd.Parameters.AddWithValue("@gia", _Gia);
            cmd.Parameters.AddWithValue("@soluong", _SoLuong);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void DeleteDauSach(string madausach)
        {
            string sql = "sp_DeleteDauSach_QL";
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@madausach", madausach);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
    }
}
