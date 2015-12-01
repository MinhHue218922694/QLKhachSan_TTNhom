using System.Text.RegularExpressions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QanLySinhVien
{
    public partial class frmQLSinhVien : Form
    {
        public frmQLSinhVien()
        {
            InitializeComponent();
        }

        public SinhVien sv;
        DSSinhVien dsSV = new DSSinhVien();
        public string str = "";
        bool them = false, last = true;
        public int dong = 0;

        private void frmQLSinhVien_Load(object sender, EventArgs e)
        {
            KhoiTao();
            DKTextBoxs(false);
        }

        public void KhoiTao()
        {
            txtMaSV.Text = txtMaSV1.Text = txtHoTen.Text = txtTenSV1.Text = txtQueQuan.Text = txtGT.Text = txtDV.Text = txtCMND.Text = "";
            txtDiem.Text = "0";
            them = false;
            dateTimePickerSV.ResetText();
            txtTenSV1.Text = txtMaSV1.Text = cmbDiem.Text = "";
            last = true;
        }

        public void DKTextBoxs(bool b)
        {
            txtHoTen.Enabled  = txtQueQuan.Enabled = txtGT.Enabled = txtDV.Enabled = b;
            txtCMND.Enabled = txtDiem.Enabled = b;
            txtMaSV.Enabled = false;
            dateTimePickerSV.Enabled = b;
        }

        private void btbMoFile_Click(object sender, EventArgs e)
        {
            dsSV = new DSSinhVien();

            openFileDialog.Filter = "(file text)| *.txt";
            openFileDialog.InitialDirectory = @"DuLieu//";
            openFileDialog.Multiselect = false;
            //string arr = openFile.SafeFileNames;
            openFileDialog.ShowDialog();

            dsSV.Input(openFileDialog.FileName);
            str = openFileDialog.FileName;

            dsSV.Show(dgvSinhVien);
            dsSV.Show(dgvSV2);
        }

        private void dgvSV2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSV.Enabled = false;
            DKTextBoxs(false);
            dong = e.RowIndex;
            try
            {
                txtMaSV.Text = dgvSV2.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtHoTen.Text = dgvSV2.Rows[e.RowIndex].Cells[2].Value.ToString();
                dateTimePickerSV.Text = dgvSV2.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtGT.Text = dgvSV2.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtQueQuan.Text = dgvSV2.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtDV.Text = dgvSV2.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtCMND.Text = dgvSV2.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtDiem.Text = dgvSV2.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
            catch
            {
                return;
            }
        }

        private void btnRef_Click(object sender, EventArgs e)
        {
            KhoiTao();
            DKTextBoxs(false);
            dgvSV2.Enabled = true;
            btnThem.Enabled = btnLuu.Enabled = true;
            dsSV.Show(dgvSV2);
        }

        public void LayGT()
        {
            sv = new SinhVien();
            try
            {
                string Masv = "";
                if (them == true) Masv = dsSV.SinhMaSV();
                else Masv = txtMaSV.Text;
                sv = new SinhVien(Masv, txtHoTen.Text, txtGT.Text, dateTimePickerSV.Text, txtQueQuan.Text, txtDV.Text, txtCMND.Text, txtDiem.Text);
            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {          
            KhoiTao();
            them = true;
            DKTextBoxs(true);
            btnSua.Enabled = btnXoa.Enabled = false;
            dgvSV2.Enabled = false;
            txtMaSV.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                LayGT();
                if (them == true)
                {
                    if (last == true) dsSV.Insert(sv);
                    else dsSV.Insert(sv, dong);
                }
                else dsSV.Edit(sv, dong);
                KhoiTao();
                dgvSV2.Enabled = true;
                btnSua.Enabled = btnXoa.Enabled = true;
                dsSV.Save(str);
                dsSV.Show(dgvSinhVien);
                dsSV.Show(dgvSV2);
                DKTextBoxs(false);
            }
            catch
            {
                MessageBox.Show("Lưu Thất Bại.");
            }
        }
        public void XoaSV()
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                LayGT();
                if (dsSV.Remove(dong) == true)
                {
                    dsSV.Show(dgvSinhVien);
                    dsSV.Show(dgvSV2);
                    dsSV.Save(str);
                    KhoiTao();
                    MessageBox.Show("Delete Successful.");
                }
                else MessageBox.Show("Delete Failed.");

            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            XoaSV();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            if (MessageBox.Show("Bạn có chắc muốn Sửa thông tin sinh viên này?", "Cảnh báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DKTextBoxs(true);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Cảnh báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void txtMaSV1_TextChanged(object sender, EventArgs e)
        {
            if (txtMaSV1.Text != null) dgvSinhVien.DataSource = dsSV.Search(txtMaSV1.Text, txtTenSV1.Text, cmbDiem.Text);
            else txtMaSV1.Text = "";
        }

        private void txtTenSV1_TextChanged(object sender, EventArgs e)
        {
            if (txtTenSV1.Text != null) dgvSinhVien.DataSource = dsSV.Search(txtMaSV1.Text, txtTenSV1.Text, cmbDiem.Text);
            else txtTenSV1.Text = "";
        }

        private void comboBoxDiem_TextChanged(object sender, EventArgs e)
        {
            if (cmbDiem.Text != null) dgvSinhVien.DataSource = dsSV.Search(txtMaSV1.Text, txtTenSV1.Text, cmbDiem.Text);
            else cmbDiem.Text = "";
        }

        private void btnRefresh1_Click(object sender, EventArgs e)
        {
            dsSV.Show(dgvSinhVien);
        }

        private void btbMoFile_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Control && e.KeyData == Keys.O)
                btbMoFile_Click(sender, (EventArgs)e);
        }

        private void btnSapXep_Click(object sender, EventArgs e)
        {
            if (cmbSapXep.Text == "Tên")
                dsSV.SXTheoTen();
            else if (cmbSapXep.Text == "Điểm")
                dsSV.SXTheoDiem();
            else dsSV.SXTheoMa();
            dsSV.Show(dgvSinhVien);
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DKTextBoxs(true);
            KhoiTao();
            MessageBox.Show("Hãy nhập thông tin vào các ô thông tin trên!");
            them = true;
            last = false;
        }

        private void dgvSV2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dong = e.RowIndex;
        }
        
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XoaSV();
        }

        private void btnThemDS_Click(object sender, EventArgs e)
        {
            ThemDSSV frm = new ThemDSSV(dsSV);
            frm.ShowDialog();
            dsSV.Show(dgvSV2);
            dsSV.Show(dgvSinhVien);
            dsSV.Save(str);
        }   
    }
}
