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
    public partial class frmQuyenSach :DevComponents.DotNetBar.Office2007Form
    {
    
        public frmQuyenSach()
        {
            InitializeComponent();
        }
        QuyenSach_QL ds = new QuyenSach_QL();
        TimKiem tk = new TimKiem();
        public void HienThiCombMaDauSach(ComboBox cbo)
        {
            string sql = "sp_TTCom_MaDauSach";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            DataView dv = new DataView();
            dv = dt.DefaultView;
            cbo.ValueMember = "MaDauSach";
            cbo.DisplayMember = "TenDauSach";
            cbo.DataSource = dv;
        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            frmDauSach_QL ft = new frmDauSach_QL();
            ft.Show();
            this.Hide();
        }
       
        private void frmQuyenSach_Load(object sender, EventArgs e)
        {
            MoDieuKhien(false);
            SetNull();
            dtGidQuyenSach.DataSource = ds.HienThi_QuyenSach();
            HienThiCombMaDauSach(txtMaDauSach);
        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {
            dtGidQuyenSach.DataSource = tk.TK_MaSach(txtTK_MaSach.Text);
        }
        public void MoDieuKhien(bool bl)
        {
            txtMaDauSach.Enabled = txtTinhTrang.Enabled = txtMaSach.Enabled = txtTrangThai.Enabled = bl;
        }
        public void SetNull()
        {
            txtMaDauSach.Text =txtTrangThai.Text=txtTinhTrang.Text=txtMaSach.Text= "";
        }     
        private void dtGidQuyenSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            MoDieuKhien(false);
            try
            {
                txtMaDauSach.Text = dtGidQuyenSach.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtTinhTrang.Text = dtGidQuyenSach.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtTrangThai.Text = dtGidQuyenSach.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtMaSach.Text = dtGidQuyenSach.Rows[e.RowIndex].Cells[0].Value.ToString();
              
            }
            catch { return; }
        }
        int temp = 0;
        private void btnThem_Click(object sender, EventArgs e)
        {
            SetNull();
            MoDieuKhien(true);
            temp = 0;
            txtMaSach.Enabled = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn Sửa thông tin khach hang này?", "Cảnh báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                MoDieuKhien(true);
                txtMaSach.Enabled = false;
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
                    ds.UpDate_QuyenSach(txtMaSach.Text, txtMaDauSach.SelectedValue.ToString(), txtTinhTrang.Text, txtTrangThai.Text);
                    MessageBox.Show("sửa thành công!");
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnThem.Enabled = true;
                }
                else if (temp == 0)
                {
                    str = ds.Insert_Sach(txtMaDauSach.SelectedValue.ToString(), txtTinhTrang.Text, txtTrangThai.Text);
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
            dtGidQuyenSach.DataSource = ds.HienThi_QuyenSach();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = btnSua.Enabled = btnThem.Enabled = btnThoat.Enabled = btnXoa.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    ds.DeleteQuyenSach(txtMaSach.Text);
                    frmQuyenSach_Load(sender, e);
                    SetNull();
                    MoDieuKhien(false);                    
                    MessageBox.Show("Xóa thành công!");
                }
                catch
                {
                    MessageBox.Show("xóa thất bại(sách đang được mượn)!");
                }
            }
            dtGidQuyenSach.DataSource = ds.HienThi_QuyenSach();
        }

        
        
    }
}
