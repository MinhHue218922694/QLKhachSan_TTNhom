using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongKS
{
    public partial class frmTBThietBi : Form
    {
        public frmTBThietBi()
        {
            InitializeComponent();
        }
        TrangBiTB tbtb = new TrangBiTB();
        int chose,loai;
        int sukien = 0;
        private void FormTBThietBi_Load(object sender, EventArgs e)
        {
            DataTable dt = tbtb.ShowTrangbi();
            dgvTBTB.DataSource = dt;
        }

        private void bntThem_Click(object sender, EventArgs e)
        {
            DataTable dt1 = tbtb.ShowMaLPhong();
            cbxSoPhong.DataSource = dt1;
            cbxSoPhong.DisplayMember = "malphong";
            dt1 = tbtb.ShowMaTB();
            cbxMaTB.DataSource = dt1;
            cbxMaTB.DisplayMember = "matb";
            dgvTBTB.DataSource = null;
            Init();
            loai = 1;
            bntLuuTBTB.Enabled = true;
            Hien();
        }
        private void Init()
        {
            cbxMaTB.Text = ""; cbxSoPhong.Text = ""; txtSoluongTB.Clear();
        }
        private void dgvTBTB_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (sukien == 0)
            {
                int dong = e.RowIndex;
                cbxSoPhong.Text = dgvTBTB.Rows[dong].Cells[0].Value.ToString();
                cbxMaTB.Text = dgvTBTB.Rows[dong].Cells[1].Value.ToString();
                txtSoluongTB.Text = dgvTBTB.Rows[dong].Cells[2].Value.ToString();
            }
        }

        private void bntLuuTBTB_Click(object sender, EventArgs e)
        {
            if (loai == 1)
                ThemTBTB();
            else
                if (loai == 2)
                    SuaTBTB();
                else
                    if (loai == 3)
                        XoaTBTB();

        }
        private void ThemTBTB()
        {
            string kq = tbtb.ThemTrangBi(cbxSoPhong.Text, cbxMaTB.Text, txtSoluongTB.Text);
            if (kq == "0")
                MessageBox.Show("Mã loại phòng hoặc mã thiết bị không được null");
            else
                if (kq == "1")
                    MessageBox.Show("Thiết bị không tồn tại");
                else
                    if (kq == "3")
                        MessageBox.Show("Loại phòng không tồn tại");
                    else
                        if (kq == "2")
                        {
                            MessageBox.Show("Đã thêm thành công");
                            dgvTBTB.DataSource = tbtb.ShowTrangbi();
                        }
                        else
                            if (kq == "4") MessageBox.Show("Phòng đã được trang bị thiết bị này rồi");
        }
        private void SuaTBTB()
        {
            string kq = tbtb.SuaTrangBi(cbxSoPhong.Text, cbxMaTB.Text, txtSoluongTB.Text);
            if (kq == "0")
                MessageBox.Show("Không được để rỗng các dữ liệu");
            else
                if (kq == "1")
                    MessageBox.Show("Không có thiết bị này");
                else
                    if (kq == "3")
                        MessageBox.Show("Không có loại phòng này");
                    else
                        if (kq == "2")
                            MessageBox.Show("Đã sửa thành công");

        }
        private void XoaTBTB()
        {
            string kq = tbtb.XoaTrangBi(cbxSoPhong.Text, cbxMaTB.Text);
            if (kq == "0")
                MessageBox.Show("Không được để rỗng các dữ liệu");
            else
                if (kq == "1")
                    MessageBox.Show("Không tồn tại loại phòng này");
                else
                    if (kq == "3")
                        MessageBox.Show("Trang bị không có trong phòng đó");
                    else
                        if (kq == "2")
                            MessageBox.Show("Xóa thành công");
        }
        private void bntSua_Click(object sender, EventArgs e)
        {
            DataTable dt1 = tbtb.ShowMaLPhong();
            cbxSoPhong.DataSource = dt1;
            cbxSoPhong.DisplayMember = "malphong";
            dt1 = tbtb.ShowMaTB();
            cbxMaTB.DataSource = dt1;
            cbxMaTB.DisplayMember = "matb";
            DataTable dt = tbtb.ShowTrangbi();
            dgvTBTB.DataSource = dt;
            loai = 2;
            bntLuuTBTB.Enabled = true;
            Hien();
        }
        private void An()
        {
            cbxSoPhong.Enabled = false; cbxMaTB.Enabled = false;
            txtSoluongTB.Enabled = false;
        }
        private void Hien()
        {
            cbxMaTB.Enabled = true; cbxSoPhong.Enabled = true;
            txtSoluongTB.Enabled = true;
        }
        private void bntXoa_Click(object sender, EventArgs e)
        {
            DataTable dt1 = tbtb.ShowMaLPhong();
            cbxSoPhong.DataSource = dt1;
            cbxSoPhong.DisplayMember = "malphong";
            dt1 = tbtb.ShowMaTB();
            cbxMaTB.DataSource = dt1;
            cbxMaTB.DisplayMember = "matb";
            loai = 3;
            bntLuuTBTB.Enabled = true;
            Hien();
        }

        private void bntTimKiem_Click(object sender, EventArgs e)
        {
            grbChonTBTB.Visible = true;
            DataTable dt1 = tbtb.ShowPhong();
            cbxSoPhong.DataSource = dt1;
            cbxSoPhong.DisplayMember = "sophong";
            dt1 = tbtb.ShowMaTB();
            cbxMaTB.DataSource = dt1;
            cbxMaTB.DisplayMember = "matb";
            sukien = 1;
        }
        private void TimKiemTBTB()
        {
            DataTable dt = tbtb.TimKiemTBTB(cbxSoPhong.Text, cbxMaTB.Text, chose);
            if (dt.Rows.Count > 0) dgvTBTB.DataSource = dt;
            else MessageBox.Show("Không tìm thấy");
        }

        private void rdbPhong_CheckedChanged(object sender, EventArgs e)
        {
            chose = 1;
            Init();
            cbxMaTB.Enabled = false;
            txtSoluongTB.Enabled = false;
            cbxSoPhong.Enabled = true;
            dgvTBTB.DataSource = null;
        }

        private void rdbtinhtrang_CheckedChanged(object sender, EventArgs e)
        {

            chose = 2;
            Init();
            cbxMaTB.Enabled = true;
            txtSoluongTB.Enabled = false;
            cbxSoPhong.Enabled = false;
            dgvTBTB.DataSource = null;
        }

        private void bntSearch_Click(object sender, EventArgs e)
        {
            TimKiemTBTB();
        }

        private void bntBack_Click(object sender, EventArgs e)
        {
            
        }

    }
}
