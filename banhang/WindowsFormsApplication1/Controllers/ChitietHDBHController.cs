using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBanHang.Models;
using System.Data.SqlClient;
using System.Data;
using HTDFramework.Data;

namespace QLBanHang.Controllers
{
    class ChitietHDBHController
    {
        private static SqlConnection conn = new SqlConnection(DataConfig.connectionString);
        public static void Insert(ChitietHDBH ct)
        {
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            SqlCommand sc = new SqlCommand("CTHoadonbanhang_ProcInsert", conn);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.Add(new SqlParameter("@HoadonbanhangID", ct.HoadonbanhangID));
            sc.Parameters.Add(new SqlParameter("@SanphamID", ct.SanphamID));
            sc.Parameters.Add(new SqlParameter("@Soluong", ct.Soluong));
            sc.Parameters.Add(new SqlParameter("@Dongia", ct.Dongia));
            sc.ExecuteNonQuery();
            conn.Close();
        }
    }
}
