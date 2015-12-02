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
    public partial class frmDauSach_QL : DevComponents.DotNetBar.Office2007Form
    {
        public frmDauSach_QL()
        {
            InitializeComponent();
        }
        public int temp = 0;
        DauSach_QL ds = new DauSach_QL();
        TimKiem tk = new TimKiem();

        //
         public void HienThiComb(ComboBox cbo) {
            string sql = "sp_TTMaTG";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.GetConnect());
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            DataView dv = new DataView();
            dv = dt.DefaultView;
            cbo.ValueMember = "MaTg";
            cbo.DisplayMember = "TenTg";         
            cbo.DataSource = dv;             
        }
         public void HienThiCombTL(ComboBox cbo)
         {
             string sql = "sp_TTCom_TLoai";
             SqlDataAdapter da = new SqlDataAdapter();
             DataTable dt = new DataTable();
             SqlConnection con = new SqlConnection(Connect.GetConnect());
             SqlCommand cmd = new SqlCommand(sql, con);
             cmd.CommandType = CommandType.StoredProcedure;
             da.SelectCommand = cmd;
             da.Fill(dt);
             DataView dv = new DataView();
             dv = dt.DefaultView;
             cbo.ValueMember = "MaTL";
             cbo.DisplayMember = "TenTl";
             cbo.DataSource = dv;
         }
         public void HienThiCombNXB(ComboBox cbo)
         {
             string sql = "sp_TTCom_NXB";
             SqlDataAdapter da = new SqlDataAdapter();
             DataTable dt = new DataTable();
             SqlConnection con = new SqlConnection(Connect.GetConnect());
             SqlCommand cmd = new SqlCommand(sql, con);
             cmd.CommandType = CommandType.StoredProcedure;
             da.SelectCommand = cmd;
             da.Fill(dt);
             DataView dv = new DataView();
             dv = dt.DefaultView;
             cbo.ValueMember = "MaNXB";
             cbo.DisplayMember = "TenNXB";
             cbo.DataSource = dv;
         }
        private void frmDauSach_QL_Load(object sender, EventArgs e)
        {
            MoDieuKhien(false);
            SetNull();
           dtGridDauSach_Ql.DataSource= ds.HienThi_DauSach();        
           HienThiComb(txtMaTg);
           HienThiCombTL(txtMaTL);
           HienThiCombNXB(txtMaNXB);
        }

        private void txtTk_TenDauSach_TextChanged(object sender, EventArgs e)
        {
            dtGridDauSach_Ql.DataSource = tk.TK_TenDauSach(txtTk_TenDauSach.Text);

        }
        public void MoDieuKhien(bool bl)
        {
            txtMaDauSach.Enabled = txtMaNXB.Enabled = txtGia.Enabled = txtMaTg.Enabled = txtMaTL.Enabled = txtNamXB.Enabled = txtTenDauSach.Enabled = txtSoLuong.Enabled= bl;
        }
        public void SetNull()
        {
            txtMaDauSach.Text = txtMaNXB.Text = txtGia.Text = txtMaTg.Text = txtMaTL.Text =  txtTenDauSach.Text =txtSoLuong.Text= "";
            txtNamXB.Text = "";
        }               
        private void dtGridDauSach_Ql_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            MoDieuKhien(false);
            try { 
                txtMaDauSach.Text = dtGridDauSach_Ql.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenDauSach.Text= dtGridDauSach_Ql.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtNamXB.Text= dtGridDauSach_Ql.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtMaTL.Text = dtGridDauSach_Ql.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtMaTg.Text = dtGridDauSach_Ql.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtMaNXB.Text = dtGridDauSach_Ql.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtGia.Text= dtGridDauSach_Ql.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtSoLuong.Text = dtGridDauSach_Ql.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            catch { return; }
        }
    

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetNull();
            MoDieuKhien(true);
            temp = 0;
            txtMaDauSach.Enabled = false;
            txtSoLuong.Enabled = false;
           txtSoLuong.Text = "0";
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc muốn Sửa thông tin khach hang này?", "Cảnh báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                MoDieuKhien(true);
                txtMaDauSach.Enabled = false;
                txtSoLuong.Enabled = false;
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
                    ds.UpDate_DauSach(txtMaDauSach.Text, txtTenDauSach.Text, txtMaTg.SelectedValue.ToString(), txtMaTL.SelectedValue.ToString(), txtMaNXB.SelectedValue.ToString(),
                        DateTime.Parse(txtNamXB.Text),long.Parse(txtGia.Text),int.Parse(txtSoLuong.Text));
                    MessageBox.Show("sửa thành công!");
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnThem.Enabled = true;
                }
                else if(temp==0)
                {
                   str= ds.Insert_DauSach(txtTenDauSach.Text, txtMaTg.SelectedValue.ToString(), txtMaTL.SelectedValue.ToString(), txtMaNXB.SelectedValue.ToString(), 
                       DateTime.Parse( txtNamXB.Text),long.Parse( txtGia.Text), int.Parse( txtSoLuong.Text));
                    MessageBox.Show("Thêm thành công!");
                    btnXoa.Enabled = true;
                    btnSua.Enabled = true;
                }
            }
            catch {
                MessageBox.Show("Lưu Thất Bại!");
            }
           // SetNull();
            MoDieuKhien(false);
            dtGridDauSach_Ql.DataSource = ds.HienThi_DauSach();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    ds.DeleteDauSach(txtMaDauSach.Text);
                    frmDauSach_QL_Load(sender,e);

                    SetNull();
                    MoDieuKhien(false);
                    MessageBox.Show("Đầu sách đã được xóa!");
                }
                catch { MessageBox.Show("Đầu sách còn sách trong thư viện!"); }
            }
            frmDauSach_QL_Load(sender,e);
            //HienThiDGV();
              
    }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmMenu fm = new frmMenu();
            fm.Show();
            this.Close();
        }        

        private void buttonX4_Click_1(object sender, EventArgs e)
        {

            frmChiTietTacGia ft = new frmChiTietTacGia();
            ft.Show();
            this.Hide();
        }

        private void buttonX5_Click_1(object sender, EventArgs e)
        {
            frmChiTietTheLoai ft = new frmChiTietTheLoai();
            ft.Show();
            this.Hide();
        }

        private void buttonX6_Click_1(object sender, EventArgs e)
        {
            frmChiTietNXB ft = new frmChiTietNXB();
            ft.Show();
            this.Hide();
        }

        private void buttonX7_Click_1(object sender, EventArgs e)
        {

            frmQuyenSach dt = new frmQuyenSach();
            dt.Show();
            this.Hide();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            frmDauSach_QL_Load(sender, e);
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

       
        


        
    }
}
