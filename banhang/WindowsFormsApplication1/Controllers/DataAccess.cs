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
    class DataAccess
    {
        private static SqlConnection conn = new SqlConnection(DataConfig.connectionString);
        public static DataTable ViewForGridView(string Query)
        {
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            SqlCommand sc = new SqlCommand(Query, conn);
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static DataTable ViewForGridView(string Query,params SqlParameter[] sp)
        {
            List<SanPham> lst = new List<SanPham>();
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            SqlCommand sc = new SqlCommand(Query, conn);
            sc.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter p in sp) { sc.Parameters.Add(new SqlParameter(p.ParameterName, p.Value)); }
            SqlDataAdapter da = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static DataTable GetsingleData(string Query, params SqlParameter[] sp)
        {
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            SqlCommand sc = new SqlCommand(Query, conn);
            sc.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter p in sp)
                sc.Parameters.Add(new SqlParameter(p.ParameterName, p.Value));
            SqlDataAdapter da = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;

        }
        public static void ExecuteNonQuery(string Query, params SqlParameter[] sp)
        {
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            SqlCommand sc = new SqlCommand(Query, conn);
            sc.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter p in sp)
                sc.Parameters.Add(new SqlParameter(p.ParameterName, p.Value));
            sc.ExecuteNonQuery();
            conn.Close();
        }
    }
}
