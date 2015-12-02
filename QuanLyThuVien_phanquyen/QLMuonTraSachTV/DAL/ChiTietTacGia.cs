using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using KETNOI_MUONTRA;

namespace DAL
{
    public class ChiTietTacGia
    {
        Connect kn = new Connect();
        public DataTable HienThi_ChiTietTG()
        {
            string sql = "sp_TTTacGia";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
        public string Insert_TG(string _TenTg, string _DiaChi, string _GioiTinh)
        {

            string str = "";
            string sql = "sp_InserTacGia_QL";
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TenTg", _TenTg);
            cmd.Parameters.AddWithValue("@DiaChi", _DiaChi);
            cmd.Parameters.AddWithValue("@GioiTinh", _GioiTinh);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            str = dt.Rows[0].ItemArray[0].ToString();
            cmd.Dispose();
            con.Close();
            return str;
        }
        public void UpDate_TG(string _MaTg, string _TenTg, string _DiaChi, string _GioiTinh)
        {
            string sql = "sp_UpdateTacGia_QL";
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaTg", _MaTg);
            cmd.Parameters.AddWithValue("@TenTg", _TenTg);
            cmd.Parameters.AddWithValue("@DiaChi", _DiaChi);
            cmd.Parameters.AddWithValue("@GioiTinh", _GioiTinh);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void DeleteTG(string MaTg)
        {
            string sql = "sp_DeleteTG_QL";
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaTg", MaTg);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

       

    }
}
