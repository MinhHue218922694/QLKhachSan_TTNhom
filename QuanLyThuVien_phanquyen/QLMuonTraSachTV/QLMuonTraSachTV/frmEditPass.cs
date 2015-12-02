using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace QLMuonTraSachTV
{
    public partial class frmEditPass : DevComponents.DotNetBar.Office2007Form
    {
        public frmEditPass()
        {
            InitializeComponent();
        }
       
        private void buttonX1_Click(object sender, EventArgs e)
        {
            SqlConnection Conn = new SqlConnection("Data Source =NGUYENHUE-PC\\SQLEXPRESS;Initial Catalog =LAMLAI; Integrated Security=True");
            Conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter();
            DataTable dt = new DataTable("TaiKhoan");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT *FROM TaiKhoan
                                Where(ID = @ID)
                                And(PASS = @Pass)";
            cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar, 10)).Value = frmDangNhap.id;
            cmd.Parameters.Add(new SqlParameter("@Pass", SqlDbType.VarChar, 50)).Value = txtOldPass.Text;
            adap.SelectCommand = cmd;
            adap.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                if (txtNewPass.Text == txtRenewPas.Text)
                {
                    SqlDataAdapter adap1 = new SqlDataAdapter();
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = Conn;
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = @"UPDATE TaiKhoan SET PASS = @Pass
                                Where ID = @ID";
                    cmd1.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar, 10)).Value = frmDangNhap.id;
                    cmd1.Parameters.Add(new SqlParameter("@Pass", SqlDbType.VarChar, 50)).Value = txtRenewPas.Text;
                    adap1.SelectCommand = cmd1;
                    adap1.Fill(dt);
                    MessageBox.Show("Bạn Đã Đổi Mật Khẩu Thành Công!", "Thông báo", MessageBoxButtons.OK);
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Hai Mật Khẩu Mới Phải Trùng Nhau", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Mật Khẩu bạn nhập vào sai", "Thông báo", MessageBoxButtons.OK);
                txtOldPass.Clear();
            }
            //frmDangNhap ft = new frmDangNhap();
            //ft.Show();
            Conn.Close();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
