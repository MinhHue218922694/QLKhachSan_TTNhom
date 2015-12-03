using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QuanLiNhanSu
{
    public class SuaNV
    {
        public string SuaNhanVien(string manv, string tennv, string ngaysinh, string gioitinh, string quequan, string luong, string macv, string mapb)
        {
            string str = "SuaNhanVien";
            SqlConnection con = new SqlConnection(ConnectDATA.getconnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@manv", manv);
            cmd.Parameters.AddWithValue("@ten", tennv);
            cmd.Parameters.AddWithValue("@ns",Convert.ToDateTime(ngaysinh));
            cmd.Parameters.AddWithValue("@gt", gioitinh);
            cmd.Parameters.AddWithValue("@qq", quequan);
            cmd.Parameters.AddWithValue("@l", luong);
            cmd.Parameters.AddWithValue("@macv", macv);
            cmd.Parameters.AddWithValue("@mapb", mapb);
            SqlParameter para = new SqlParameter("@kq", SqlDbType.Int);
            para.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(para);
            cmd.ExecuteNonQuery();
            string kq = para.Value.ToString();
            cmd.Dispose();
            con.Close();
            return kq;
        }
    }
}
