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
    class LuutruController
    {
        private static SqlConnection conn = new SqlConnection(DataConfig.connectionString);
        public static List<Luutru> ViewByID(int ID)
        {
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            SqlCommand sc = new SqlCommand("Luutru_ProcViewByID", conn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.Add(new SqlParameter("@SanphamID", ID));
            SqlDataReader reader = sc.ExecuteReader();
            List<Luutru> lstLT = new List<Luutru>();
            while (reader.Read())
            {
                Luutru lt = new Luutru();
                lt.SanphamID = ID;
                lt.KhoID = (reader["KhoID"] != null ? int.Parse(reader["KhoID"].ToString()) : 0);
                lt.Tenkho = (reader["Tenkho"] != null ? reader["Tenkho"].ToString() : "");
                lt.Soluong = (reader["Soluong"] != null ? int.Parse(reader["Soluong"].ToString()) : 0);
                lstLT.Add(lt);
            }
            reader.Close();
            conn.Close();
            return lstLT;
        }
    }
}
