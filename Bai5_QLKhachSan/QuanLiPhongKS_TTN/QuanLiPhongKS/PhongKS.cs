using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QLPhongKS
{
    public class PhongKS
    {
        KetNoi kn = new KetNoi();
        public DataTable ShowPhong()
        {
            string str = @"select SoPhong as [Số phòng],MaPLoai as [Mã loại phòng],TinhTrang as [Tình trạng],
                        HienTrang as [Hiện trạng],SoDT as [Số điện thoại] from tblPhong";
            SqlConnection con = new SqlConnection(kn.GetConnect());
            SqlDataAdapter ad = new SqlDataAdapter(str, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
        public DataTable ShowMaLPhong()
        {
            string str = @"select MaPLoai as [malphong] from tblLoaiPhong";
            SqlConnection con = new SqlConnection(kn.GetConnect());
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(str, con);
            ad.Fill(dt);
            con.Close();
            return dt;
        }
        public string ThemPhong(string maloai, string tinhtrang, string hientrang, string sodt)
        {
            string str = "ThemPhong";
            SqlConnection con = new SqlConnection(kn.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maploai", maloai);
            cmd.Parameters.AddWithValue("@tinhtrang", tinhtrang);
            cmd.Parameters.AddWithValue("@hientrang", hientrang);
            cmd.Parameters.AddWithValue("@sodt", sodt);
            SqlParameter para = new SqlParameter("@kq", SqlDbType.Int);
            para.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(para);
            cmd.ExecuteNonQuery();
            string kq = para.Value.ToString();
            con.Close();
            cmd.Dispose();
            return kq;
        }
        public string SuaPhong(string id, string id_loai, string tinhtrang, string hientrang, string sdt)
        {
            string str = "SuaPhong";
            SqlConnection con = new SqlConnection(kn.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_phong", Convert.ToInt32(id));
            cmd.Parameters.AddWithValue("@ma_ploai", id_loai);
            cmd.Parameters.AddWithValue("@tinhtrang", tinhtrang);
            cmd.Parameters.AddWithValue("@hientrang", hientrang);
            cmd.Parameters.AddWithValue("@so_dt", sdt);
            SqlParameter para = new SqlParameter("@kq", SqlDbType.Int);
            para.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(para);
            cmd.ExecuteNonQuery();
            string kq = para.Value.ToString();
            cmd.Dispose();
            con.Close();
            return kq;
        }

        public string XoaPhong(int idphong)
        {
            string str = "XoaPhong";
            SqlConnection con = new SqlConnection(kn.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idphong", Convert.ToInt32(idphong));
            SqlParameter para = new SqlParameter("@kq", SqlDbType.Int);
            para.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(para);
            cmd.ExecuteNonQuery();
            string kq = para.Value.ToString();
            cmd.Dispose();
            con.Close();
            return kq;
        }
        public DataTable Timkiem(int idphong, string idlphong, string tinhtrang, string hientrang, int chose)
        {
            string str = "TKPhong";
            SqlConnection con = new SqlConnection(kn.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idphong", Convert.ToInt32(idphong));
            cmd.Parameters.AddWithValue("@idploai", idlphong);
            cmd.Parameters.AddWithValue("@tinhtrang", tinhtrang);
            cmd.Parameters.AddWithValue("@hientrang", hientrang);
            cmd.Parameters.AddWithValue("@chose", chose);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        internal string XoaPhong(string p)
        {
            throw new NotImplementedException();
        }
    }
}
