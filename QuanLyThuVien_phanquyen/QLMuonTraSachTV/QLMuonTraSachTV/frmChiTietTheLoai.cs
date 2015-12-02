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
using DAL;

namespace QLMuonTraSachTV
{
    public partial class frmChiTietTheLoai : DevComponents.DotNetBar.Office2007Form
    {
        public frmChiTietTheLoai()
        {
            InitializeComponent();
        }
        public int temp = 0;
        TheLoai ds = new TheLoai();
        TimKiem tk = new TimKiem();
        private void buttonX4_Click(object sender, EventArgs e)
        {
            frmDauSach_QL dt = new frmDauSach_QL();
            dt.Show();
            this.Hide();
        }

        private void frmChiTietTheLoai_Load(object sender, EventArgs e)
        {
            dtGridChiTietTheLoai.DataSource = ds.HienThi_TheLoai();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dtGridChiTietTheLoai.DataSource = tk.TK_TenTl(txtTimKiem.Text);
        }
        public void MoDieuKhien(bool bl)
        {
            txtTenTL.Enabled = txtMaTL.Enabled = bl;
        }
        public void SetNull()
        {
            txtMaTL.Text = txtTenTL.Text = "";
        }

        private void dtGridChiTietTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            MoDieuKhien(false);
            try
            {
                txtMaTL.Text = dtGridChiTietTheLoai.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenTL.Text = dtGridChiTietTheLoai.Rows[e.RowIndex].Cells[1].Value.ToString();

            }
            catch { return; }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetNull();
            MoDieuKhien(true);
            temp = 0;
            txtMaTL.Enabled = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn Sửa thông tin khach hang này?", "Cảnh báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                MoDieuKhien(true);
                txtMaTL.Enabled = false;
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
                    ds.UpDate_TheLoai(txtMaTL.Text, txtTenTL.Text);
                    MessageBox.Show("sửa thành công!");
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                }
                else if (temp == 0)
                {
                    str = ds.Insert_TheLoai(txtTenTL.Text);
                    MessageBox.Show("Thêm thành công!");
                    btnXoa.Enabled = true;
                    btnSua.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("Lưu Thất Bại!");
            }
            // SetNull();
            MoDieuKhien(false);
            dtGridChiTietTheLoai.DataSource = ds.HienThi_TheLoai();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    ds.DeleteTheLoai(txtMaTL.Text);
                    frmChiTietTheLoai_Load(sender, e);

                    SetNull();
                    MoDieuKhien(false);
                    MessageBox.Show("Thể loại đã được xóa!");
                }
                catch { MessageBox.Show("Thể loại còn sách trong thư viện!"); }
            }
            frmChiTietTheLoai_Load(sender, e);
        }  
    
    }
}
