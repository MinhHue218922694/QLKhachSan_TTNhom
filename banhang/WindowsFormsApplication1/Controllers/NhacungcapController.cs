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
    class NhacungcapController
    {
        private static SqlConnection conn = new SqlConnection(DataConfig.connectionString);
        public static List<Nhacungcap> ViewAll()
        {
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
            SqlCommand sc = new SqlCommand("Nhacungcap_ProcViewAll", conn);
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = sc.ExecuteReader();
            List<Nhacungcap> lstNcc = new List<Nhacungcap>();
            while (reader.Read())
            {
                Nhacungcap ncc = new Nhacungcap();
                ncc.NhacungcapID = (reader["NhacungcapID"] != null ? int.Parse(reader["NhacungcapID"].ToString()) : 0);
                ncc.Tennhacungcap = (reader["Tennhacungcap"] != null ? reader["Tennhacungcap"].ToString() : "");
                ncc.Diachi = (reader["Diachi"] != null ? reader["Diachi"].ToString() : "");
                ncc.Dienthoai = (reader["Dienthoai"] != null ? reader["Dienthoai"].ToString() : "");
                lstNcc.Add(ncc);
            }
            reader.Close();
            conn.Close();
            return lstNcc;
        }
    }
}
