using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using KetNoiDB;
using BangKhachSan;
namespace BangKhachSan
{
    public class TimKiem
    {
        // Tìm kiếm Phòng theo mã
        public DataTable TKPhong_MaPhong(string MaPhong)
        {
            string sql = "SELECT * FROM tblPhong WHERE MaPhong LIKE N'%' + @MaPhong + '%'";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(KetNoi.connect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Parameters.AddWithValue("@MaPhong", MaPhong);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;

        }

        // Tìm kiếm phòng theo tên
        public DataTable TKPhong_TenPhong(string TenPhong)
        {
            string sql = "SELECT * FROM tblPhong WHERE TenPhong LIKE N'%' + @TenPhong + '%'";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(KetNoi.connect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Parameters.AddWithValue("@TenPhong", TenPhong);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
        // Tìm kiếm phòng theo loại
        public DataTable TKPhong_LoaiPhong(string LoaiPhong)
        {
            string sql = "SELECT * FROM tblPhong WHERE LoaiPhong LIKE N'%' + @LoaiPhong + '%'";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(KetNoi.connect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Parameters.AddWithValue("@LoaiPhong", LoaiPhong);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
        //Show đồ dùng trong phòng theo mã
        public DataTable ShowDoDung_Ma(string MaPhong)
        {
            string sql = "SELECT * FROM tblPhong WHERE MaPhong=@MaPhong";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(KetNoi.connect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Parameters.AddWithValue("@MaPhong", MaPhong);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
    }
}
