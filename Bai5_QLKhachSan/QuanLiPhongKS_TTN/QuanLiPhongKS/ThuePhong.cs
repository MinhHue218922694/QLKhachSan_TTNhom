using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace QLPhongKS
{
    public partial class frmThuePhong : Form
    {
        ThuePhongKS tp = new ThuePhongKS();
        private string txtr;
        public frmThuePhong()
        {
            InitializeComponent();
        }

        private void ThuePhong_Load(object sender, EventArgs e)
        {

        }

        private void bntLayPhong_Click(object sender, EventArgs e)
        {
            dtgThuePhong.DataSource = tp.LayPhongTrong();
        }
        private void KhoaKH()
        {
            txtCMND.Enabled = false;
            txtQueQuan.Enabled = false;
            txtQuocTich.Enabled = false;
            txtSDT.Enabled = false;
            txtTenKH.Enabled = false; cbxGT.Enabled = true;
        }
        private void Init()
        {
            txtTenKH.Clear();txtTenKH.Enabled=true;
            txtCMND.Clear();txtCMND.Enabled=true;
            txtQueQuan.Clear();txtQuocTich.Enabled=true;
            txtQuocTich.Clear();txtQueQuan.Enabled=true;
            txtSDT.Clear();txtSDT.Enabled=true;
            cbxGT.Text = ""; cbxGT.Enabled = true;
        }

        private void bntThêmKH_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            string kq = kh.ThemKhachHang(txtTenKH.Text, dTPNS.Text, cbxGT.Text, txtQueQuan.Text, txtCMND.Text, txtSDT.Text, txtQuocTich.Text);
            if (kq == "0")
                MessageBox.Show("Chưa nhập tên khách hàng");
            else
                if (kq == "1")
                    MessageBox.Show("Chứng minh thư đã có người dùng");
                else
                    if (kq == "2")
                    {
                        MessageBox.Show("Thêm khách hàng thành công");
                        KhoaKH();
                        bntLayPhong.Enabled = true;
                    }
        }
        private void ThucHienThue()
        {
            if (dtgThuePhong.RowCount == 0) return;
            string makh = tp.LayMaKH(txtCMND.Text);
            if (makh == null)
            {
                MessageBox.Show("Không có khách hàng.yêu cầu kiểm tra lại");
                return;
            }
            try
            {
                KetNoi kn = new KetNoi();
                KhachHang kh = new KhachHang();
                SqlConnection con = new SqlConnection(kn.GetConnect());
                for (int i = 0; i < dtgThuePhong.RowCount; i++)
                {
                    if (dtgThuePhong[0, i].Selected == true)
                    {
                        string sophong = dtgThuePhong[1, i].Value.ToString();
                        string kq = tp.ThuePhong(makh, Convert.ToInt32(sophong), dTPTGBD.Text, dTPTGKT.Text, Convert.ToInt32(txtTienThue.Text));
                        if (kq == "1")
                            MessageBox.Show("Phòng không đảm bảo chất lượng");
                        else
                            MessageBox.Show("Đăng kí thuê thành công");
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void txtTienThue_TextChanged(object sender, EventArgs e)
        {
            string tmp = txtTienThue.Text;
            bool ok = true;
            foreach (char c in tmp)
                if (c > '9' || c < '0' || c==null) ok = false;
            if (ok==false)
            {
                bntThue.Enabled = false;
                lblBaoLoi.Visible = true;
                lblBaoLoi.Text = "Phải nhập số ở đây";
            }
            else
            {
                bntThue.Enabled = true;
                lblBaoLoi.Visible = false;
            }
        }

        private void bntThue_Click(object sender, EventArgs e)
        {
            ThucHienThue();
        }

        private void txtCMND_TextChanged(object sender, EventArgs e)
        {
            string tmp = txtCMND.Text;
            bool ok = true;
            foreach (char c in tmp)
                if (c > '9' || c < '0') ok = false;
            if (ok == false)
            {
                bntThêmKH.Enabled = false;
                lblBaoLoicmnd.Visible = true;
                lblBaoLoicmnd.Text = "Phải nhập số ở đây";
            }
            else
            {
                bntThêmKH.Enabled = true;
                lblBaoLoicmnd.Visible = false;
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            string tmp = txtSDT.Text;
            bool ok = true;
            foreach (char c in tmp)
                if (c > '9' || c < '0') ok = false;
            if (ok == false)
            {
                bntThêmKH.Enabled = false;
                lblBaoLoiSDT.Visible = true;
                lblBaoLoiSDT.Text = "Phải nhập số ở đây";
            }
            else
            {
                bntThêmKH.Enabled = true;
                lblBaoLoiSDT.Visible = false;
            }
        }
    }
}
