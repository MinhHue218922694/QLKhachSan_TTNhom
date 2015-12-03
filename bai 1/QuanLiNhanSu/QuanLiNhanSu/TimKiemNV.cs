using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLiNhanSu
{
    public class TimKiemNV
    {
        public DataTable TimKiem(string manv,string tennv,string macv,int chose)
        {
            string str = "TimKiemNhanVien";
            SqlConnection con = new SqlConnection(ConnectDATA.getconnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@manv", manv);
            cmd.Parameters["@manv"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@ten", tennv);
            cmd.Parameters["@ten"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@macv", macv);
            cmd.Parameters["@macv"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@chose", chose);
            cmd.Parameters["@chose"].Direction = ParameterDirection.Input;
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
    }
}
