using QLBanHang.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTDFramework.Data;

namespace QLBanHang.Controllers
{
    class SanphamController
    {
        private static SqlConnection conn = new SqlConnection(DataConfig.connectionString);
        public static DataTable ViewForGridView()
        {
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            SqlCommand sc = new SqlCommand("Sanpham_ProcViewAll", conn);
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static List<SanPham> ViewAll()
        {
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            SqlCommand sc = new SqlCommand("Sanpham_ProcViewAll", conn);
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = sc.ExecuteReader();
            List<SanPham> lstSp = new List<SanPham>();
            while (reader.Read())
            {
                SanPham sp = new SanPham();
                sp.SanphamID = (reader["SanphamID"]!=null ? int.Parse(reader["SanphamID"].ToString()):0);
                sp.Tenloaisanpham = (reader["Tenloaisanpham"] != null ? reader["Tenloaisanpham"].ToString() : "");
                sp.Tensanpham = (reader["Tensanpham"] != null ? reader["Tensanpham"].ToString() : "");
                sp.Tennhacungcap = (reader["Tennhacungcap"] != null ? reader["Tennhacungcap"].ToString() : "");
                sp.Donvitinh = (reader["Donvitinh"] != null ? reader["Donvitinh"].ToString() : "");
                sp.Giaban = (reader["Giaban"] != null ? double.Parse(reader["Giaban"].ToString()) : 0);
                sp.Soluong = (reader["Soluong"] != null ? int.Parse(reader["Soluong"].ToString()) : 0);
                sp.NhacungcapID = (reader["NhacungcapID"] != null ? int.Parse(reader["NhacungcapID"].ToString()) : 0);
                sp.LoaisanphamID = (reader["LoaisanphamID"] != null ? int.Parse(reader["LoaisanphamID"].ToString()) : 0);
                lstSp.Add(sp);
            }
            reader.Close();
            conn.Close();
            return lstSp;
        }
        public static List<SanPham> View(int PageSize, int PageNumber)
        {
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            SqlCommand sc = new SqlCommand("Sanpham_ProcView", conn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.Add(new SqlParameter("@PageSize", PageSize));
            sc.Parameters.Add(new SqlParameter("@PageNumber", PageNumber));
            SqlDataReader reader = sc.ExecuteReader();
            List<SanPham> lstSp = new List<SanPham>();
            while (reader.Read())
            {
                SanPham sp = new SanPham();
                sp.SanphamID = (reader["SanphamID"] != null ? int.Parse(reader["SanphamID"].ToString()) : 0);
                sp.Tenloaisanpham = (reader["Tenloaisanpham"] != null ? reader["Tenloaisanpham"].ToString() : "");
                sp.Tensanpham = (reader["Tensanpham"] != null ? reader["Tensanpham"].ToString() : "");
                sp.Tennhacungcap = (reader["Tennhacungcap"] != null ? reader["Tennhacungcap"].ToString() : "");
                sp.Donvitinh = (reader["Donvitinh"] != null ? reader["Donvitinh"].ToString() : "");
                sp.Giaban = (reader["Giaban"] != null ? double.Parse(reader["Giaban"].ToString()) : 0);
                sp.Soluong = (reader["Soluong"] != null ? int.Parse(reader["Soluong"].ToString()) : 0);
                sp.NhacungcapID = (reader["NhacungcapID"] != null ? int.Parse(reader["NhacungcapID"].ToString()) : 0);
                sp.LoaisanphamID = (reader["LoaisanphamID"] != null ? int.Parse(reader["LoaisanphamID"].ToString()) : 0);

                lstSp.Add(sp);
            }
            conn.Close();
            reader.Close();
            return lstSp;
        }

        public static List<SanPham> Search(string content, string lsp, string ncc, bool isNum)
        {
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            SqlCommand sc = new SqlCommand("Sanpham_ProcSearch", conn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.Add(new SqlParameter("@ContentSearch", content));
            sc.Parameters.Add(new SqlParameter("@Loaisanpham", lsp));
            sc.Parameters.Add(new SqlParameter("@Nhacungcap", ncc));
            sc.Parameters.Add(new SqlParameter("@IsNumeric", isNum));
            SqlDataReader reader = sc.ExecuteReader();
            List<SanPham> lstSp = new List<SanPham>();
            while (reader.Read())
            {
                SanPham sp = new SanPham();
                sp.SanphamID = (reader["SanphamID"] != null ? int.Parse(reader["SanphamID"].ToString()) : 0);
                sp.Tenloaisanpham = (reader["Tenloaisanpham"] != null ? reader["Tenloaisanpham"].ToString() : "");
                sp.Tensanpham = (reader["Tensanpham"] != null ? reader["Tensanpham"].ToString() : "");
                sp.Tennhacungcap = (reader["Tennhacungcap"] != null ? reader["Tennhacungcap"].ToString() : "");
                sp.Donvitinh = (reader["Donvitinh"] != null ? reader["Donvitinh"].ToString() : "");
                sp.Giaban = (reader["Giaban"] != null ? double.Parse(reader["Giaban"].ToString()) : 0);
                sp.Soluong = (reader["Soluong"] != null ? int.Parse(reader["Soluong"].ToString()) : 0);
                sp.NhacungcapID = (reader["NhacungcapID"] != null ? int.Parse(reader["NhacungcapID"].ToString()) : 0);
                sp.LoaisanphamID = (reader["LoaisanphamID"] != null ? int.Parse(reader["LoaisanphamID"].ToString()) : 0);
                lstSp.Add(sp);
            }
            reader.Close();
            conn.Close();
            return lstSp;
        }
        //public static int CountRecord(int LoaisanphamID)
        //{
        //    conn.Open();
        //    SqlCommand sc = new SqlCommand("Sanpham_ProcCountRecord", conn);

        //}
    }
}
