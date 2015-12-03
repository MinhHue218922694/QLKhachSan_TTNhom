using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QLPhongKS
{
    public class ThuePhongKS
    {
        public string LayMaKH(string cmnd)
        {
            KetNoi kn=new KetNoi();
            string query = string.Format("Select distinct dbo.[LayIDKH]({0}) from tblPhong",cmnd);
            SqlConnection con = new SqlConnection(kn.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(query,con);
            string makh = cmd.ExecuteScalar().ToString();
            return makh;
        }
        public DataTable LayPhongTrong()
        {
            KetNoi kn=new KetNoi();
            string query = string.Format("Select * from LayPhongTrong()");
            SqlConnection con = new SqlConnection(kn.GetConnect());
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
        public string ThuePhong(string makh, int sophong, string tgthue, string tgtra, int tiendc)
        {
            KetNoi kn = new KetNoi();
            SqlConnection con = new SqlConnection(kn.GetConnect());
            con.Open();
            string str = "ThemThuePhong";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idkhach", makh);
            cmd.Parameters.AddWithValue("@idphong", Convert.ToInt32(sophong));
            cmd.Parameters.AddWithValue("@tgbd",Convert.ToDateTime(tgthue));
            cmd.Parameters.AddWithValue("@tgtp",Convert.ToDateTime(tgtra));
            cmd.Parameters.AddWithValue("@tiendc", tiendc);
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
