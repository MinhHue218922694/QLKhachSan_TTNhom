using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KETNOI_MUONTRA;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class TheLoai
    {
        Connect cn = new Connect();

        public DataTable HienThi_TheLoai()
        {
            string sql = "sp_TTTheLoai";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
        public string Insert_TheLoai(string _TenTl)
        {

            string str = "";
            string sql = "sp_InserTheLoai_QL";
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TenTl", _TenTl);           
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            str = dt.Rows[0].ItemArray[0].ToString();
            cmd.Dispose();
            con.Close();
            return str;
        }
        public void UpDate_TheLoai(string _MaTL, string _TenTl)
        {
            string sql = "sp_UpdateTheLoai_QL";
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaTL", _MaTL);
            cmd.Parameters.AddWithValue("@TenTl", _TenTl); 
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void DeleteTheLoai(string MaTL)
        {
            string sql = "sp_DeleteTL_QL";
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaTL", MaTL);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
    }
}
