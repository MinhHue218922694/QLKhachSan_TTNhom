using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLPhongKS
{
    public class KhachHang
    {
        KetNoi kn = new KetNoi();
        public DataTable ShowKhachHang()
        {
            string str = @"select MaKH as [Mã khách hàng], TenKH as [Tên khách hàng],NgaySinh as [Ngày Sinh],
                    GioiTinh as [Giới tính],QueQuan as [Quê quán],CMND as[Số CMND],
                    SDT as[Số điện thoại],QuocTich as [Quốc tịch] from tblKhachHang";
            SqlConnection con = new SqlConnection(kn.GetConnect());
            SqlDataAdapter ad = new SqlDataAdapter(str, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
        public string SuaKhachHang(string id,string tenkh,string ns, string qq, string gt, string cmnd, string sdt, string quoctich)
        {
            string str = "SuaKhachHang";
            SqlConnection con = new SqlConnection(kn.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idkh", id);
            cmd.Parameters.AddWithValue("@tenkh", tenkh);
            cmd.Parameters.AddWithValue("@ns",Convert.ToDateTime(ns));
            cmd.Parameters.AddWithValue("@gt", gt);
            cmd.Parameters.AddWithValue("@qq", qq);
            cmd.Parameters.AddWithValue("@cmnd", cmnd);
            cmd.Parameters.AddWithValue("@sdt", sdt);
            cmd.Parameters.AddWithValue("@quoctich", quoctich);
            cmd.Parameters.Add("@kq", SqlDbType.Int);
            cmd.Parameters["@kq"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            string kq = cmd.Parameters["@kq"].Value.ToString();
            con.Close();
            cmd.Dispose();
            return kq;
        }
        public DataTable TimKiemKH(string idkh, string cmnd, string tenkh, int chose)
        {
            string str = "TimKiemKH";
            SqlConnection con = new SqlConnection(kn.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idkhach", idkh);
            cmd.Parameters.AddWithValue("@cmnd", cmnd);
            cmd.Parameters.AddWithValue("@tenkh", tenkh);
            cmd.Parameters.AddWithValue("@chose", chose);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            cmd.Dispose();
            con.Close();
            return dt;
        }
        public string ThemKhachHang(string ten, string ns, string gt, string qq, string cmnd, string sdt, string quoctich)
        {
            string str = "ThemKH";
            SqlConnection con = new SqlConnection(kn.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tenkhach", ten);
            cmd.Parameters.AddWithValue("@ns",Convert.ToDateTime(ns));
            cmd.Parameters.AddWithValue("@gioitinh", gt);
            cmd.Parameters.AddWithValue("@quequan", qq);
            cmd.Parameters.AddWithValue("@cmnd",Convert.ToInt32(cmnd));
            cmd.Parameters.AddWithValue("@sdt", Convert.ToInt32(sdt));
            cmd.Parameters.AddWithValue("@quoctich", quoctich);
            cmd.Parameters.Add("@kq", SqlDbType.Int);
            cmd.Parameters["@kq"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            string kq = cmd.Parameters["@kq"].Value.ToString();
            con.Close();
            cmd.Dispose();
            return kq;
        }
    }
}
