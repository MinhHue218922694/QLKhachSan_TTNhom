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
    public partial class frmMuon : Form
    {
        public frmMuon()
        {
            InitializeComponent();
        }
        MuonSach ds = new MuonSach();
        TimKiem tk = new TimKiem();
        public void HienThiComb1(ComboBox cbo)
        {
            string sql = "combo_MaDG";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            DataView dv = new DataView();
            dv = dt.DefaultView;
            cbo.ValueMember = "MaDG";
            cbo.DisplayMember = "MaDG";
            cbo.DataSource = dv;
        }
        public void HienThiComb2(ComboBox cbo)
        {
            string sql = "combo_MaSach";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            DataView dv = new DataView();
            dv = dt.DefaultView;
            cbo.ValueMember = "MaSach";
            cbo.DisplayMember = "MaSach";
            cbo.DataSource = dv;
        }
        private void frmMuon_Load(object sender, EventArgs e)
        {
            dtGiridMuon.DataSource = ds.HienThi_SachMuon();
          
            HienThiComb1(txtSoThe);
            HienThiComb2(txtMaSach);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmMenu nm = new frmMenu();
            nm.Show();
            this.Hide();
        }
        private void txtTK_MaS_TextChanged(object sender, EventArgs e)
        {
            dtGiridMuon.DataSource = tk.TK_MaSach_MT(txtTK_MaS.Text);//TK_MaSach_MT
        }
        private void txtTK_SoThe_TextChanged(object sender, EventArgs e)
        {
            dtGiridMuon.DataSource = tk.TK_SoThe(txtTK_SoThe.Text);
        }
        public void MoDieuKhien(bool bl)
        {
            txtMaSach.Enabled = txtNgayMuon.Enabled =  txtSoThe.Enabled = txtNgayHenTra.Enabled= bl;
        }
        public void SetNull()
        {
           txtMaSach.Text = txtNgayMuon.Text = txtNgayHenTra.Text = txtSoThe.Text =  "";
        }     
        private void dtGiridMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            MoDieuKhien(false);
            try
            {
                txtMaSach.Text = dtGiridMuon.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtNgayMuon.Text = dtGiridMuon.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtNgayHenTra.Text = dtGiridMuon.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtSoThe.Text = dtGiridMuon.Rows[e.RowIndex].Cells[0].Value.ToString();
                           

            }
            catch { return; }
        }
        int temp = 0;

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetNull();
            MoDieuKhien(true);
            temp = 0;           
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {            
            try
            {
                if (temp == 1)
                {
                    ds.UpDate_MuonSach(txtSoThe.SelectedValue.ToString(), txtMaSach.SelectedValue.ToString(), DateTime.Parse(txtNgayMuon.Text), DateTime.Parse(txtNgayHenTra.Text));
                    MessageBox.Show("sửa thành công!");
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                }
                else if (temp == 0)
                {                
                    {
                        ds.Insert_Muon(txtSoThe.SelectedValue.ToString(), txtMaSach.SelectedValue.ToString(), DateTime.Parse(txtNgayMuon.Text), DateTime.Parse(txtNgayHenTra.Text));
                        MessageBox.Show("Thêm thành công!");
                        btnXoa.Enabled = true;
                        btnSua.Enabled = true;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lưu Thất Bại(Sách đã được mượn)!");
            }
            MoDieuKhien(false);
            dtGiridMuon.DataSource = ds.HienThi_SachMuon();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn trả sách?", "Cảnh báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    ds.DeleteSachMuon(txtMaSach.Text);
                    frmMuon_Load(sender, e);
                    SetNull();
                    MoDieuKhien(false);
                    MessageBox.Show("Trả thành công!");
                }
                catch
                {
                    MessageBox.Show("Trả thất bại!");
                }
            }
            dtGiridMuon.DataSource = ds.HienThi_SachMuon();
        }

        private void btnThongKe_Ngay_Click(object sender, EventArgs e)
        {
            dtGiridMuon.DataSource = ds.ShowMuonTHeoNgay(DateTime.Parse(dateTimePicker2.Text), DateTime.Parse(dateTimePicker1.Text));
            int i = 0;
            while (i < dtGiridMuon.Rows.Count - 1)
            {
                dtGiridMuon.Rows[i].Cells[0].Value = (i + 1).ToString();
                i++;
            }
            
        }

        private void txtNgayMuon_Click(object sender, EventArgs e)
        {

        }
    }
}
