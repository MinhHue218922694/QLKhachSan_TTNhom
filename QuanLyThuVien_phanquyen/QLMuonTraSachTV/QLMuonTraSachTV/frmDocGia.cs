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

namespace QLMuonTraSachTV
{
    public partial class frmDocGia : DevComponents.DotNetBar.Office2007Form
    {
        public frmDocGia()
        {
            InitializeComponent();
        }
        public int temp = 0;
        DocGia ds = new DocGia();
        TimKiem tk = new TimKiem();
        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmMenu ft = new frmMenu();
            ft.Show();
            this.Hide();
        }

        private void frmDocGia_Load(object sender, EventArgs e)
        {
            dtGridDocGia.DataSource = ds.HienThi_DocGia();
        }

        private void txtTK_MaDG_TextChanged(object sender, EventArgs e)
        {
            dtGridDocGia.DataSource = tk.TK_MaDG(txtTK_MaDG.Text);
        }

        private void txtTK_TenDG_TextChanged(object sender, EventArgs e)
        {
            dtGridDocGia.DataSource = tk.TK_TenDG(txtTK_TenDG.Text);
        }
        public void MoDieuKhien(bool bl)
        {
            txtChucVu.Enabled = txtGioTinh.Enabled = txtLop.Enabled = txtMaDG.Enabled = txtNgaySinh.Enabled = txtSdt.Enabled = txtTenDG.Enabled = bl;
        }
        public void SetNull()
        {
            txtChucVu.Text = txtGioTinh.Text = txtLop.Text = txtMaDG.Text = txtNgaySinh.Text = txtSdt.Text = txtTenDG.Text = "";
        }

        private void dtGridDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            MoDieuKhien(false);
            try
            {
                txtMaDG.Text = dtGridDocGia.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenDG.Text = dtGridDocGia.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtNgaySinh.Text = dtGridDocGia.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtLop.Text = dtGridDocGia.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtChucVu.Text = dtGridDocGia.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtSdt.Text = dtGridDocGia.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtGioTinh.Text = dtGridDocGia.Rows[e.RowIndex].Cells[6].Value.ToString();
                
            }
            catch { return; }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetNull();
            MoDieuKhien(true);
            temp = 0;
            txtMaDG.Enabled = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn Sửa thông tin khach hang này?", "Cảnh báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                MoDieuKhien(true);
                txtMaDG.Enabled = false;
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
                    ds.UpDate_DocGia(txtMaDG.Text,txtTenDG.Text,DateTime.Parse(txtNgaySinh.Text) ,txtLop.Text,txtChucVu.Text,txtSdt.Text,txtGioTinh.Text);
                    MessageBox.Show("sửa thành công!");
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnThem.Enabled = true;
                }
                else if (temp == 0)
                {
                    str = ds.Insert_DocGia(txtTenDG.Text, DateTime.Parse(txtNgaySinh.Text), txtLop.Text, txtChucVu.Text, txtSdt.Text, txtGioTinh.Text);
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
            dtGridDocGia.DataSource = ds.HienThi_DocGia();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    ds.DeleteDocGia(txtMaDG.Text);
                    frmDocGia_Load(sender, e);

                    SetNull();
                    MoDieuKhien(false);
                    MessageBox.Show("Độc giả đã được xóa!");
                }
                catch { MessageBox.Show("Độc Giả còn mượn sách trong thư viện!"); }
            }
            frmDocGia_Load(sender, e);
        }

        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

                   
       
    }
}
