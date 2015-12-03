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

namespace QuanLiNhanSu
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private SqlConnection con;
        DataTable dt;
        private SqlDataAdapter da = new SqlDataAdapter();
        private void connect()
        {
            try
            {
                con = new SqlConnection(ConnectDATA.getconnect());
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể kết nối cơ sở dữ liệu");
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            connect();
        }
        private void DangNhap()
        {
            string query = "QuanLiDangNhap";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tk", txtTaiKhoan.Text.ToString());
            cmd.Parameters.AddWithValue("@mk", txtMatKhau.Text.ToString());
            SqlParameter pa = new SqlParameter("@kq", SqlDbType.Int);
            pa.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pa);
            cmd.ExecuteNonQuery();
            string kq = pa.Value.ToString();
            if (kq == "0") MessageBox.Show("Tài khoản không tồn tại");
            else
                if (kq == "1") MessageBox.Show("Mật khẩu không đúng");
                else
                {
                    MessageBox.Show("Đăng nhập thành công");
                    frmMenu menu = new frmMenu();
                    Hide();
                    menu.Show();
                }
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                DangNhap();
            }
        }
       
    }
}
