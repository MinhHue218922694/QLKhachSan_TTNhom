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
     public class TimKiem
    {
        Connect cn = new Connect();
        //tìm kiếm sách theo tên tác giả
        public DataTable TKTen_TacGia(string TenTg)
        {
            string sql = "sp_TK_TenTg";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TenTg", TenTg);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
         //tìm kiếm sách theo tên thể loại
        public DataTable TKTen_TheLoai(string TheLoai)
        {
            string sql = "sp_TK_TheLoai";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@theloai", TheLoai);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
         //tìm kiếm theo đầu sách ở sách độc giả
        public DataTable TKTen_DauSach(string TenDauSach)
        {
            string sql = "sp_TK_DauSach";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TenDauSach", TenDauSach);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
         //tìm kiếm theo tên đầu sách của người quản lý
        public DataTable TK_TenDauSach(string TenDauSach)
        {
            string sql = "sp_TK_TenDauSach";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TenDauSach", TenDauSach);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
         //tim kiem ma sach trong bang sach
        public DataTable TK_MaSach(string MaSach)
        {
            string sql = "sp_TK_QuyenSach";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaSach", MaSach);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
         //tim kiem theo số thẻ trong bảng Muon
        public DataTable TK_SoThe(string MaDG)
        {
            string sql = "sp_TK_MuonST";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaDG",MaDG);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
         //tk theo ma sách trong bag mượn trả
        public DataTable TK_MaSach_MT(string MaSach)
        {
            string sql = "sp_TK_Muon";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaSach", MaSach);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
        //tk theo ma doc gia trong bangr doc gia
        public DataTable TK_MaDG(string MaDG)
        {
            string sql = "sp_TK_MaDG";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaDG", MaDG);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
         //tk theo ten dgia trong bangr doc gia
        public DataTable TK_TenDG(string TenDG)
        {
            string sql = "spTK_TenDG";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TenDG", TenDG);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
         //tk theo ten nxb
        public DataTable TK_TenNXB(string TenNXB)
        {
            string sql = "sp_TK_TenNXB";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TenNXB", TenNXB);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
         //tk theo dia chi
        public DataTable TK_DiaChi(string DiaChi)
        {
            string sql = "sp_TK_DiaChiNXB";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DiaChi", DiaChi);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
         //tk theo email
        public DataTable TK_Email(string Email)
        {
            string sql = "sp_TK_Email";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", Email);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
         //tk ten tac gia o bang tbltacgia
        public DataTable TK_TenTg1(string TenTg)
        {
            string sql = "sp_TK_TenTg_TACGIA";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TenTg", TenTg);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
         //tk the loai theo ten
        public DataTable TK_TenTl(string TenTl)
        {
            string sql = "sp_TK_TenTL";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TenTl", TenTl);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
         //tkiem theo mã sách của mượn trả
        public DataTable TK_MaSach_Tra(string MaSach)
        {
            string sql = "sp_TK_MaSach";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaSach", MaSach);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
         //tkieem theo ma độc giả
        public DataTable sp_TK_MaDG(string MaDG)
        {
            string sql = "sp_TK_MaDG_tra";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaDG", MaDG);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
    }
}
