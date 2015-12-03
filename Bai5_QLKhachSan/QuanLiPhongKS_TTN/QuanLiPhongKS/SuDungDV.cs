using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QLPhongKS
{
    public class SuDungDV
    {
        KetNoi kn = new KetNoi();
        public DataTable ShowSDDV()
        {
            SqlConnection con = new SqlConnection(kn.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"select sophong as [Mã Phòng],MaDV as [Mã Dịch vụ],
    soluong as [Số Lượng],ngaysd as [Ngày Sử dụng] from tblSuDungDV";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
        public DataTable ShowPhongThue()
        {
            SqlConnection con = new SqlConnection(kn.GetConnect());
            con.Open();
            SqlCommand cmd= new SqlCommand();
            cmd.CommandText = "Select SoPhong as SP from tblThuePhong";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            SqlDataAdapter ad=new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            ad.Fill(dt);
            return dt;
        }
        public DataTable ShowDichVu()
        {
            SqlConnection con = new SqlConnection(kn.GetConnect());
            con.Open();
            SqlCommand cmd= new SqlCommand();
            cmd.CommandText = "Select MaDV as DV from tblDichVuPhong";
            cmd.CommandType = CommandType.Text;
            cmd.Connection=con;
            SqlDataAdapter ad=new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            ad.Fill(dt);
            return dt;
        }
        public string ThemSDDV(string idphong, string iddv, string sl, string ngaysd)
        {
            string str = "ThemSDDV";
            SqlConnection con = new SqlConnection(kn.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_phong", Convert.ToInt32(idphong));
            cmd.Parameters.AddWithValue("@id_dv", iddv);
            cmd.Parameters.AddWithValue("@soluong", Convert.ToInt32(sl));
            cmd.Parameters.AddWithValue("@ngaysd", Convert.ToDateTime(ngaysd));
            SqlParameter para = new SqlParameter("@kq", SqlDbType.Int);
            para.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(para);
            cmd.ExecuteNonQuery();
            string kq = para.Value.ToString();
            cmd.Dispose();
            con.Close();
            return kq;
        }
        public string SuaSDDV(int idphong, string madv, string soluong, string ngaysd)
        {
            string str = "SuaSDDV";
            SqlConnection con = new SqlConnection(kn.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idphong", Convert.ToInt32(idphong));
            cmd.Parameters.AddWithValue("@iddv", madv);
            cmd.Parameters.AddWithValue("@soluong",Convert.ToInt32(soluong));
            cmd.Parameters.AddWithValue("@ngaysd", Convert.ToDateTime(ngaysd));
            SqlParameter para = new SqlParameter("@kq", SqlDbType.Int);
            para.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(para);
            cmd.ExecuteNonQuery();
            string kq = para.Value.ToString();
            cmd.Dispose();
            con.Close();
            return kq;
        }
        public string XoaSDDV(int idphong, string iddv, string ngaysd)
        {
            string str = "XoaSDDV";
            SqlConnection con = new SqlConnection(kn.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_phong", Convert.ToInt32(idphong));
            cmd.Parameters.AddWithValue("@id_dv", iddv);
            cmd.Parameters.AddWithValue("@ngaysd", Convert.ToDateTime(ngaysd));
            SqlParameter para = new SqlParameter("@kq", SqlDbType.Int);
            para.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(para);
            cmd.ExecuteNonQuery();
            string kq = para.Value.ToString();
            cmd.Dispose();
            con.Close();
            return kq;
        }
        public DataTable TimKiemSDDV(string idphong, string iddv, string ngaysd, int chose)
        {
            string str = "TimKiemSDDV";
            SqlConnection con = new SqlConnection(kn.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idphong",Convert.ToInt32(idphong));
            cmd.Parameters.AddWithValue("@iddv", iddv);
            cmd.Parameters.AddWithValue("@ngaysd", Convert.ToDateTime(ngaysd));
            cmd.Parameters.AddWithValue("@chose", chose);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            cmd.Dispose();
            con.Close();
            return dt;
        }

        internal string SuaSDDV(string p1, string p2, string p3, string p4)
        {
            throw new NotImplementedException();
        }

        internal string XoaSDDV(string p1, string p2, string p3)
        {
            throw new NotImplementedException();
        }
    }
}
