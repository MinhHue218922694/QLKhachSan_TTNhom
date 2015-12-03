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

namespace QUANLY_HS_GV
{
    public partial class Login : Form
    {
        Connect con = new Connect();
        public string str = @"select *from Login";

        public Login()
        {
            InitializeComponent();
        }

        private void Dangnhap()
        {
            SqlDataAdapter da = new SqlDataAdapter(str, Connect.getconnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bool check = false;
            foreach (DataRow row in dt.Rows)
            {
                if (row[0].ToString() == txtTaikhoan.Text && row[1].ToString() == txtMatkhau.Text)
                {
                    check = true;
                    break;
                }
                else
                {
                    check = false;
                }
            }
            if (check == true)
            {
                MessageBox.Show("Đăng nhập thành công");
                txtMatkhau.ReadOnly = txtTaikhoan.ReadOnly = true;
                txtTaikhoan.Visible = true;
                txtMatkhau.Visible = true;                
                frmMain mo = new frmMain();
                this.Hide();
                mo.ShowDialog();
                this.Close();
                //Login.Enabled = true;
            }
            else
            {
                MessageBox.Show("Tài khoản không hợp lệ");
                txtTaikhoan.Text = txtMatkhau.Text = string.Empty;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Dangnhap();            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
