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
     public class QuyenSach_QL
    {
         Connect kn = new Connect();
         public DataTable HienThi_QuyenSach()
         {
             string sql = "sp_TTQuyenSach";
             SqlDataAdapter da = new SqlDataAdapter();
             DataTable dt = new DataTable();
             SqlConnection con = new SqlConnection(Connect.GetConnect());
             SqlCommand cmd = new SqlCommand(sql, con);
             cmd.CommandType = CommandType.StoredProcedure;
             da.SelectCommand = cmd;
             da.Fill(dt);            
             return dt;
         }
         public string Insert_Sach( string _MaDauSach , string _TinhTrang, string _TrangThai)
         {

             string str = "";
             string sql = "sp_InserQuyenSach_QL";
             SqlConnection con = new SqlConnection(Connect.GetConnect());
             con.Open();
             SqlCommand cmd = new SqlCommand(sql, con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@MaDauSach", _MaDauSach);
             cmd.Parameters.AddWithValue("@TinhTrang", _TinhTrang);
             cmd.Parameters.AddWithValue("@TrangThai", _TrangThai);           
             DataTable dt = new DataTable();
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             da.Fill(dt);
             str = dt.Rows[0].ItemArray[0].ToString();
             cmd.Dispose();
             con.Close();
             return str;
         }
         public void UpDate_QuyenSach( string _MaSach, string _MaDauSach, string _TinhTrang, string _TrangThai)
         {
             string sql = "sp_UpdateQuyenSach_QL";
             SqlConnection con = new SqlConnection(Connect.GetConnect());
             con.Open();
             SqlCommand cmd = new SqlCommand(sql, con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@MaSach", _MaSach);
             cmd.Parameters.AddWithValue("@MaDauSach", _MaDauSach);
             cmd.Parameters.AddWithValue("@TinhTrang", _TinhTrang);
             cmd.Parameters.AddWithValue("@TrangThai", _TrangThai); 
             cmd.ExecuteNonQuery();
             cmd.Dispose();
             con.Close();
         }
         public void DeleteQuyenSach(string MaSach)
         {
             string sql = "sp_DeleteQuyenSach_QL";
             SqlConnection con = new SqlConnection(Connect.GetConnect());
             con.Open();
             SqlCommand cmd = new SqlCommand(sql, con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@MaSach",MaSach);

             cmd.ExecuteNonQuery();
             cmd.Dispose();
             con.Close();
         }
    }
}
