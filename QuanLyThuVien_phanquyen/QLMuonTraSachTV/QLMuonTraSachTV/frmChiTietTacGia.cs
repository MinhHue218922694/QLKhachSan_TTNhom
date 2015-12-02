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
    public partial class frmChiTietTacGia : DevComponents.DotNetBar.Office2007Form
    {
        public frmChiTietTacGia()
        {
            InitializeComponent();
        }
        public int temp = 0;
        TimKiem tk = new TimKiem();
        ChiTietTacGia ds = new ChiTietTacGia();
        private void frmChiTietTacGia_Load(object sender, EventArgs e)
        {
            dtGidCHiTietTG.DataSource = ds.HienThi_ChiTietTG();
        }

        private void txtTimKiem_TenTG_TextChanged(object sender, EventArgs e)
        {
            dtGidCHiTietTG.DataSource = tk.TK_TenTg1(txtTimKiem_TenTG.Text);
        }
        public void MoDieuKhien(bool bl)
        {
            txtTacGia.Enabled = txtMaTG.Enabled = txtGioiTinh.Enabled = txtDiaChi.Enabled = bl;
        }
        public void SetNull()
        {
            txtDiaChi.Text = txtGioiTinh.Text = txtMaTG.Text = txtTacGia.Text = "";
        }

        private void dtGidCHiTietTG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            MoDieuKhien(false);
            try
            {
                txtMaTG.Text = dtGidCHiTietTG.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTacGia.Text = dtGidCHiTietTG.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDiaChi.Text = dtGidCHiTietTG.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtGioiTinh.Text = dtGidCHiTietTG.Rows[e.RowIndex].Cells[3].Value.ToString();
               
            }
            catch { return; }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            SetNull();
            MoDieuKhien(true);
            temp = 0;
            txtMaTG.Enabled = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn Sửa thông tin khach hang này?", "Cảnh báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                MoDieuKhien(true);
                txtMaTG.Enabled = false;
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
                    ds.UpDate_TG(txtMaTG.Text, txtTacGia.Text, txtDiaChi.Text, txtGioiTinh.Text);
                    MessageBox.Show("sửa thành công!");
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnThem.Enabled = true;
                }
                else if (temp == 0)
                {
                    str = ds.Insert_TG(txtTacGia.Text, txtDiaChi.Text, txtGioiTinh.Text);
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
            dtGidCHiTietTG.DataSource = ds.HienThi_ChiTietTG();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    ds.DeleteTG(txtMaTG.Text);
                    frmChiTietTacGia_Load(sender, e);

                    SetNull();
                    MoDieuKhien(false);
                    MessageBox.Show("Tác Giả đã được xóa!");
                }
                catch { MessageBox.Show("Tác Giả còn sách trong thư viện!"); }
            }
            frmChiTietTacGia_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmDauSach_QL ft = new frmDauSach_QL();
            ft.Show();
            this.Hide();
        }

    }
}
