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
    class NhanvienController
    {
        private static SqlConnection conn = new SqlConnection(DataConfig.connectionString);
        public static Nhanvien View(int ID)
        {
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            SqlCommand sc = new SqlCommand("Nhanvien_ProcView", conn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.Add(new SqlParameter("@NhanvienID", ID));
            SqlDataReader reader = sc.ExecuteReader();
            Nhanvien nv = new Nhanvien();
            while (reader.Read())
            {
                nv.NhanvienID = (reader["NhanvienID"] != null ? int.Parse(reader["NhanvienID"].ToString()) : 0);
                nv.Hoten = (reader["Hoten"] != null ? reader["Hoten"].ToString() : "");
            }
            reader.Close();
            conn.Close();
            return nv;
        }
    }
}
