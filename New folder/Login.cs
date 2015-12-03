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

namespace QLBMT_TTNhom
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public static string ConnectString = @"Data Source=admin;Initial Catalog=QLBH_MayTinh;Integrated Security=True";
        SqlConnection conn;
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Close();
            }
            this.Hide();
            Form1 f = new Form1();
            f.battat(true);
            f.ShowDialog();
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            DataTable user = new DataTable();
            SqlCommand cmd = new SqlCommand();
            conn = new SqlConnection(ConnectString);
            cmd.Connection = conn;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            conn.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select UserName,Pass from tblUser where (UserName=@UserName) and(Pass=@Pass)";
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50).Value = txtDangNhap.Text;
            cmd.Parameters.Add("@Pass", SqlDbType.NChar, 10).Value = txtMK.Text;
            //đổ vào bảng người dùng
            adapter.Fill(user);
            if (user.Rows.Count > 0)
            {
                if (txtDangNhap.Text == "admin")
                {
                    MessageBox.Show("Bạn đã đăng nhập thành công!", "Thành công");
                    this.Hide();

                    Form1 f = new Form1();
                    f.BatTatMenu(true);
                    f.ShowDialog();
                }
                if (txtDangNhap.Text == "nhân viên")
                {
                    MessageBox.Show("Bạn đã đăng nhập thành công!", "Thành công");
                    this.Hide();
                    txtDangNhap.Enabled = false;
                    txtMK.Enabled = false;
                    btnNhap.Enabled = false;
                    Form1 frm = new Form1();
                    frm.battatnv(true);
                    frm.ShowDialog();
                }
                if (txtDangNhap.Text == "khách hàng")
                {
                    MessageBox.Show("bạn đã đăng nhập thành công", "Thành công");
                    this.Hide();
                    txtDangNhap.Enabled = false;
                    txtMK.Enabled = false;
                    btnNhap.Enabled = false;
                    Form1 f = new Form1();
                    f.BatTatMenuKH(true);
                    f.ShowDialog();
                }
            }
            else
            {
                if (txtDangNhap.Text == "" || txtMK.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ dữ liệu");
                }
                if (MessageBox.Show(" Đăng Nhập Thất Bại, bạn có muốn đăng nhập Lại Hay Không ", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    txtDangNhap.Focus();
                }
                else
                {
                    Application.Exit();
                }
            }
            conn.Close();
        }

        private void txtDangNhap_TextChanged(object sender, EventArgs e)
        {
            if (txtDangNhap.Text != "")
                txtMK.Enabled = true;
        }

        private void txtMK_TextChanged(object sender, EventArgs e)
        {
            if (txtMK.Text != "")
                btnNhap.Enabled = true;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtMK.Enabled = false;
        }

    }
}
