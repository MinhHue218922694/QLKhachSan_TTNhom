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
    class LoaisanphamController
    {
        private static SqlConnection conn = new SqlConnection(DataConfig.connectionString);
        public static List<LoaiSanPham> ViewAll()
        {
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            SqlCommand sc = new SqlCommand("Loaisanpham_ProcViewAll", conn);
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = sc.ExecuteReader();
            List<LoaiSanPham> lstLsp = new List<LoaiSanPham>();
            while (reader.Read())
            {
                LoaiSanPham lsp = new LoaiSanPham();
                lsp.Tenloaisanpham = (reader["Tenloaisanpham"] != null ? reader["Tenloaisanpham"].ToString() : "");
                lsp.LoaisanphamID = (reader["LoaisanphamID"] != null ? int.Parse(reader["LoaisanphamID"].ToString()) : 0);
                lstLsp.Add(lsp);
            }
            reader.Close();
            conn.Close();
            return lstLsp;
        }
    }
}
