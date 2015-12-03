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
    class HoadonbanhangController
    {
        private static SqlConnection conn = new SqlConnection(DataConfig.connectionString);
        public static int GetHoadonID(Hoadonbanhang hd)
        {
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            SqlCommand sc = new SqlCommand("Hoadonbanhang_ProcGetHoadonID", conn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.Add(new SqlParameter("@Ngayviet", hd.Ngayviet));
            sc.Parameters.Add(new SqlParameter("@KhachhangID", hd.KhachhangID));
            sc.Parameters.Add(new SqlParameter("@NhanvienID", hd.NhanvienID));
            int ID = 0;
            SqlDataReader reader = sc.ExecuteReader();
            while (reader.Read())
            {
                ID = int.Parse(reader["HoadonbanhangID"].ToString());
            }
            reader.Close();
            conn.Close();
            return ID;
        }
        public static void Insert(Hoadonbanhang hd)
        {
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            SqlCommand sc = new SqlCommand("Hoadonbanhang_ProcInsert", conn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.Add(new SqlParameter("@Ngayviet", hd.Ngayviet));
            sc.Parameters.Add(new SqlParameter("@KhachhangID", hd.KhachhangID));
            sc.Parameters.Add(new SqlParameter("@NhanvienID", hd.NhanvienID));
            sc.ExecuteNonQuery();
            conn.Close();
        }
    }
}
