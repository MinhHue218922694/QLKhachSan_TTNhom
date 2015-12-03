using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBanHang.Models;
using System.Data;
using HTDFramework.Data;

namespace QLBanHang.Controllers
{
    class KhachhangController
    {
        private static SqlConnection conn = new SqlConnection(DataConfig.connectionString);
        public static void Insert(Khachhang kh)
        {
            if(conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            SqlCommand sc = new SqlCommand("Khachhang_ProcInsert", conn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.Add(new SqlParameter("@Tenkhachhang", kh.Tenkhachhang));
            sc.Parameters.Add(new SqlParameter("@Ngaysinh", kh.Ngaysinh));
            sc.Parameters.Add(new SqlParameter("@Gioitinh", kh.Gioitinh));
            sc.Parameters.Add(new SqlParameter("@Sodienthoai", kh.Sodienthoai));
            sc.Parameters.Add(new SqlParameter("@Diachi", kh.Diachi));
            sc.ExecuteNonQuery();
            conn.Close();
        }
        public static int GetKhachhangID(Khachhang kh)
        {
            int ID = 0;
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            SqlCommand sc = new SqlCommand("Khachhang_ProcGetKhachhangID", conn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.Add(new SqlParameter("@Tenkhachhang", kh.Tenkhachhang));
            sc.Parameters.Add(new SqlParameter("@Gioitinh", kh.Gioitinh));
            sc.Parameters.Add(new SqlParameter("@Sodienthoai", kh.Sodienthoai));
            sc.Parameters.Add(new SqlParameter("@Diachi", kh.Diachi));
            SqlDataReader reader = sc.ExecuteReader();
            while (reader.Read())
            {
                ID = int.Parse(reader["KhachhangID"].ToString());
            }
            reader.Close();
            conn.Close();
            return ID;
        }
         
    }
}
