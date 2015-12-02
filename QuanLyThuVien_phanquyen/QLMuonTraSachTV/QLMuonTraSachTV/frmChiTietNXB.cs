using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KETNOI_MUONTRA;
using DAL;
using System.Data.SqlClient;

namespace QLMuonTraSachTV
{
    public partial class frmChiTietNXB : Form
    {
        public int temp = 0;
        ChiTietNXB ds = new ChiTietNXB();
        TimKiem tk = new TimKiem();
        public frmChiTietNXB()
        {
            InitializeComponent();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            frmDauSach_QL fd = new frmDauSach_QL();
            fd.Show();
            this.Hide();
        }

        private void frmChiTietNXB_Load(object sender, EventArgs e)
        {
            dtGirdChiTietNXB.DataSource = ds.HienThi_ChiTietNXB();

        }

        private void txtTK_TenNXB_TextChanged(object sender, EventArgs e)
        {
            dtGirdChiTietNXB.DataSource = tk.TK_TenNXB(txtTK_TenNXB.Text);
        }

        private void txtTK_DiaChi_TextChanged(object sender, EventArgs e)
        {
            dtGirdChiTietNXB.DataSource = tk.TK_DiaChi(txtTK_DiaChi.Text);
        }

        private void txtTK_Email_TextChanged(object sender, EventArgs e)
        {
            dtGirdChiTietNXB.DataSource = tk.TK_Email(txtTK_Email.Text);
        }
        public void MoDieuKhien(bool bl)
        {
            txtDiaChi.Enabled = txtDienThoai.Enabled = txtEmail.Enabled = txtMaNXB.Enabled = txtTenNXb.Enabled = bl;
        }
        public void SetNull()
        {
            txtTenNXb.Text = txtMaNXB.Text = txtEmail.Text = txtDienThoai.Text = txtDiaChi.Text = "";
        }

        private void dtGirdChiTietNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            MoDieuKhien(false);
            try
            {
                txtMaNXB.Text = dtGirdChiTietNXB.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenNXb.Text = dtGirdChiTietNXB.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDiaChi.Text = dtGirdChiTietNXB.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDienThoai.Text = dtGirdChiTietNXB.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtEmail.Text = dtGirdChiTietNXB.Rows[e.RowIndex].Cells[4].Value.ToString();
              
            }
            catch { return; }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetNull();
            MoDieuKhien(true);
            temp = 0;
            txtMaNXB.Enabled = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn Sửa thông tin khach hang này?", "Cảnh báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                MoDieuKhien(true);
                txtMaNXB.Enabled = false;
                temp = 1;
                btnLuu.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string str = "";
            try
            {
                if (temp == 1)
                {
                    ds.UpDate_NXB(txtMaNXB.Text ,txtTenNXb.Text, txtDienThoai.Text, txtDiaChi.Text, txtEmail.Text);
                    MessageBox.Show("sửa thành công!");
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnThem.Enabled = true;
                }
                else if (temp == 0)
                {
                    str = ds.Insert_NXB( txtTenNXb.Text, txtDienThoai.Text, txtDiaChi.Text, txtEmail.Text);
                    MessageBox.Show("Thêm thành công!");
                    btnXoa.Enabled = true;
                    btnSua.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("Lưu Thất Bại!");
            }           
            MoDieuKhien(false);
            dtGirdChiTietNXB.DataSource = ds.HienThi_ChiTietNXB();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    ds.DeleteNXB(txtMaNXB.Text);
                    frmChiTietNXB_Load(sender, e);

                    SetNull();
                    MoDieuKhien(false);
                    MessageBox.Show("Nhà xuất bản đã được xóa!");
                }
                catch { MessageBox.Show("NXB còn có sách trong thư viện!"); }
            }
            frmChiTietNXB_Load(sender, e);
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }  
      
    }
}
