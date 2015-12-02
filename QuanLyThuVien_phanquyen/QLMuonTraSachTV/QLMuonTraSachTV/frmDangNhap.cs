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
using KETNOI_MUONTRA;

namespace QLMuonTraSachTV
{
    public partial class frmDangNhap : DevComponents.DotNetBar.Office2007Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        Connect cn = new Connect();
        public static string id = "";
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnDangNhat;
            txtUser.Text = "admin";
            txtPass.Text = "";
        }

        private void btnDangNhat_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text; 
            cmd.CommandText=   @"select *from TaiKhoan
                            where ID =@ID AND PASS=@PASS";
            cmd.Parameters.Add(new SqlParameter("@ID",SqlDbType.VarChar,10)).Value = txtUser.Text;
            cmd.Parameters.Add(new SqlParameter("@PASS", SqlDbType.VarChar, 50)).Value = txtPass.Text;
            da.SelectCommand = cmd;
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                id = txtUser.Text;
                if (txtPass.Text == "admin")
                {
                    frmMenu fm = new frmMenu();
                    fm.Show();
                    this.Hide();
                }
                else
                {
                    frmSach_DG fs = new frmSach_DG();
                    fs.Show();
                    this.Hide();
                }
            }
            else
                if (MessageBox.Show("Đăng nhập thất bại, bạn có muốn đăng nhập lại không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    txtUser.Focus();
                    txtUser.Clear();
                    txtPass.Clear();
                }
                else
                {
                    Close();
                    System.Windows.Forms.Application.Exit();
                }
            con.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Thoát?", "Thông báo", MessageBoxButtons.OK) == DialogResult.OK)
            {
                Close();
                System.Windows.Forms.Application.Exit();
            }
        }
        
        //private void txtUser_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        //{
        //    if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
        //    {
        //        e.Handled = true;
        //    }
        //}

      
    }
}
