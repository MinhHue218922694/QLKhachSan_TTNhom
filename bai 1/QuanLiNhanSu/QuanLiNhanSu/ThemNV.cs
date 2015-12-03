using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace QuanLiNhanSu
{
    public class ThemNV
    {
        public string ThemNhanVien(string tennv, string ngaysinh, string gioitinh, string quequan, string luong, string macv, string mapb)
        {
            string str = "ThemNhanVien";
            SqlConnection con = new SqlConnection(ConnectDATA.getconnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ten", tennv);
            cmd.Parameters["@ten"].Direction = ParameterDirection.Input;
            cmd.Parameters.Add("@ns", Convert.ToDateTime(ngaysinh));
            cmd.Parameters["@ns"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@gt", gioitinh);
            cmd.Parameters["@gt"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@qq", quequan);
            cmd.Parameters["@qq"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@l", luong);
            cmd.Parameters["@l"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@macv", macv);
            cmd.Parameters["@macv"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@mapb", mapb);
            cmd.Parameters["@mapb"].Direction = ParameterDirection.Input;
            SqlParameter para = new SqlParameter("@kq", SqlDbType.Int);
            para.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(para);
            cmd.ExecuteNonQuery();
            string kq = para.Value.ToString();
            con.Close();
            cmd.Dispose();
            return kq;
        }
    }
}
