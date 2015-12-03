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
namespace QuanLiNhanSu
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        NhanVien NV = new NhanVien();
        int chose=1;
        private void frmMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLiNhanSuDataSet1.tblNhanVien' table. You can move, or remove it, as needed.
            this.tblNhanVienTableAdapter.Fill(this.quanLiNhanSuDataSet1.tblNhanVien);
            DataTable dt = NV.ShowNhanVien();
            DataTable dt1 = NV.ShowChucVu();
            DataTable dt2 = NV.ShowPhongBan();
            dtgNhanVien.DataSource = dt;
            dtgSuaNV.DataSource = dt;

           

            cbxTKMaCV.DataSource = dt1;
            cbxTKMaCV.DisplayMember = "Mã Chức Vụ";
            
            cbxThemMaCV.DataSource = dt1;
            cbxThemMaCV.DisplayMember = "Mã Chức Vụ";

            cbxThemMaPB.DataSource = dt2;
            cbxThemMaPB.DisplayMember = "Mã Phòng Ban";

            cbxTKMaCV.DataSource = dt1;
            cbxTKMaCV.DisplayMember = "Mã Chức Vụ";
        }

        private void dtgNhanVien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            comboBox1.Text = dtgNhanVien.Rows[dong].Cells[0].Value.ToString();
            txtTenNV.Text = dtgNhanVien.Rows[dong].Cells[1].Value.ToString();
            dTPNgaySinh.Text = dtgNhanVien.Rows[dong].Cells[2].Value.ToString();
            cbxGT.Text = dtgNhanVien.Rows[dong].Cells[5].Value.ToString();
            txtQueQuan.Text = dtgNhanVien.Rows[dong].Cells[4].Value.ToString();
            txtLuong.Text = dtgNhanVien.Rows[dong].Cells[5].Value.ToString();
            cbxMaCV.Text = dtgNhanVien.Rows[dong].Cells[6].Value.ToString();
            cbxMaPB.Text = dtgNhanVien.Rows[dong].Cells[7].Value.ToString();
        }

        private void Init()
        {
            txtThemTen.Clear(); txtQueQuan.Clear();
            txtLuong.Clear(); cbxThemMaPB.Text = "";
            cbxThemGT.Text = ""; cbxThemMaCV.Text = "";
            txtThemQQ.Clear(); txtThemLuong.Clear();
        }
        private void bntLamRong_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void bntThemNV_Click(object sender, EventArgs e)
        {
            ThemNV them = new ThemNV();
            string kq = them.ThemNhanVien(txtThemTen.Text, dTPThemNS.Text, cbxThemGT.Text, txtThemQQ.Text, txtThemLuong.Text, cbxThemMaCV.Text, cbxThemMaPB.Text);
            if (kq == "2")
                MessageBox.Show("Thêm thành công");
            else
                if (kq == "0")
                    MessageBox.Show("Không có mã công việc này hoặc mã công việc bị sai");
                else
                    if (kq == "1")
                        MessageBox.Show("Không có mã phòng ban hoặc mã phòng ban bị sai");

        }

        private void bntRefreshThem_Click(object sender, EventArgs e)
        {
            DataTable dt = NV.ShowNhanVien();
            dtgThemNV.DataSource = dt;
            Init();
        }

        private void dtgSuaNV_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            cbxSuaMaNV.Text = dtgSuaNV.Rows[dong].Cells[0].Value.ToString();
            txtSuaTenNV.Text = dtgSuaNV.Rows[dong].Cells[1].Value.ToString();
            dTPSuaNS.Text = dtgSuaNV.Rows[dong].Cells[2].Value.ToString();
            cbxSuaGT.Text = dtgSuaNV.Rows[dong].Cells[5].Value.ToString();
            txtSuaQQ.Text = dtgSuaNV.Rows[dong].Cells[4].Value.ToString();
            txtSuaLuong.Text = dtgSuaNV.Rows[dong].Cells[5].Value.ToString();
            cbxSuaMaCV.Text = dtgSuaNV.Rows[dong].Cells[6].Value.ToString();
            cbxSuaMaPB.Text = dtgSuaNV.Rows[dong].Cells[7].Value.ToString();
        }

        private void bntRefreshXoa_Click(object sender, EventArgs e)
        {
            DataTable dt = NV.ShowNhanVien();
            dtgThemNV.DataSource = dt;
            Init();
        }

        private void rBMaNV_CheckedChanged(object sender, EventArgs e)
        {
            chose = 1;
            cbxTimKiemMaNV.Enabled = true;
            cbxTKMaCV.Enabled = false;
            txtTKTenNV.Enabled = false;
            dtgTimKiem.DataSource = null;
        }

        private void rBTenNV_CheckedChanged(object sender, EventArgs e)
        {
            chose = 2;
            cbxTimKiemMaNV.Enabled=false;
            cbxTKMaCV.Enabled = false;
            txtTKTenNV.Enabled = true;
            dtgTimKiem.DataSource = null;
        }

        private void rBMaCV_CheckedChanged(object sender, EventArgs e)
        {
            chose = 3;
            cbxTimKiemMaNV.Enabled = false;
            cbxTKMaCV.Enabled = true;
            txtTKTenNV.Enabled = false;
            dtgTimKiem.DataSource = null;
        }

        private void bntSua_Click(object sender, EventArgs e)
        {
            SuaNV sua = new SuaNV();
            string kq=sua.SuaNhanVien(cbxSuaMaNV.Text, txtSuaTenNV.Text, dTPSuaNS.Text, cbxSuaGT.Text, txtSuaQQ.Text, txtSuaLuong.Text, cbxSuaMaCV.Text, cbxSuaMaPB.Text);
            if (kq == "0")
                MessageBox.Show("Không có mã nhân viên hoặc mã nhân viên bị sai");
            else
                if (kq == "1")
                    MessageBox.Show("Không có mã công việc hoặc mã công việc bị sai");
                else
                    if (kq == "2")
                        MessageBox.Show("Không có mã phòng ban hoặc mã phòng ban bị sai");
                    else
                        MessageBox.Show("Sửa thành công");
        }

        private void bntRefreshSua_Click(object sender, EventArgs e)
        {
            DataTable dt = NV.ShowNhanVien();
            dtgThemNV.DataSource = dt;
            Init();
        }

        private void bntXoa_Click(object sender, EventArgs e)
        {
            XoaNV xoa = new XoaNV();
            string kq=xoa.XoaNhanVien(cbxXoaMaNV.Text);
            if (kq == "0")
                MessageBox.Show("Không có mã nhân viên hoặc mã nhân viên bị sai");
            else
                if (kq == "false")
                    MessageBox.Show("Không thể xóa nhân viên");
                else
            {
                MessageBox.Show("Xóa thành công");
                DataTable dt = NV.ShowNhanVien();
                dtgXoaNV.DataSource = dt;
                Init();
            }
        }

        //private void txtTKTenNV_TextChanged(object sender, EventArgs e)
        //{
        //    dtgTimKiem.DataSource = null;
        //}
        private void TimKiem()
        {
            try
            {
                TimKiemNV tk = new TimKiemNV();
                DataTable dt = tk.TimKiem(cbxTimKiemMaNV.Text.ToString(), txtTKTenNV.Text, cbxTKMaCV.Text, chose);
                if (dt.Rows.Count == 0) MessageBox.Show("Không tìm thấy");
                else dtgTimKiem.DataSource = dt;
            }
            catch (Exception er)
            { MessageBox.Show(er.Message); }
        }

        private void txtTKTenNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                TimKiem();
            }
        }

      
        private void cbxTKMaCV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                TimKiem();
            }
        }

        private void cbxTimKiemMaNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                TimKiem();
            }
        }

        private void txtTKTenNV_TextChanged(object sender, EventArgs e)
        {
            dtgTimKiem.DataSource = null;
        }
    }
}