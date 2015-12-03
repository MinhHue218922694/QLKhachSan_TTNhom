using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace QuanLiNhanSu
{
    class XoaNV
    {
        public string XoaNhanVien(string manv)
        {
            string kq = "false";
            try
            {
                string str = "XoaNhanVien";
                SqlConnection con = new SqlConnection(ConnectDATA.getconnect());
                con.Open();
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@manv", manv);
                cmd.Parameters["@manv"].Direction = ParameterDirection.Input;
                SqlParameter para = new SqlParameter("@kq", SqlDbType.Int);
                para.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(para);
                cmd.ExecuteNonQuery();
                kq = para.Value.ToString();
                con.Close();
                cmd.Dispose();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            return kq;
        }

    }
}