using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBMT_TTNhom.DAO;
using QLBMT_TTNhom.BUS;
using System.Data.SqlClient;

namespace QLBMT_TTNhom
{
    public partial class frm_NhapHang : Form
    {
        public frm_NhapHang()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        PhieuNhap_Bus pnb = new PhieuNhap_Bus();
        PhieuNhap_Dao pnd = new PhieuNhap_Dao();
        BindingSource bs = new BindingSource();
        DataTable dt = new DataTable();
        NhanVien_Bus nvb = new NhanVien_Bus();
        NCC_Bus nccb = new NCC_Bus();
        private void btnDau_Click(object sender, EventArgs e)
        {
            if (dtgNhapHang.Rows.Count > 0)
            {
                dtgNhapHang.Rows[0].Selected = true;
            }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            if (dtgNhapHang.Rows.Count > 0)
            {
                dtgNhapHang.Rows[dtgNhapHang.Rows.Count - 1].Selected = true;
            }
        }

        private void btnTien_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (dtgNhapHang.Rows.Count > 0)
            {
                for (int i = 0; i < dtgNhapHang.Rows.Count; i++)
                {
                    if (dtgNhapHang.Rows[i].Selected == true)
                    {
                        k = i + 1;
                        break;
                    }
                }
                if (dtgNhapHang.Rows[dtgNhapHang.Rows.Count - 1].Selected == false)
                    dtgNhapHang.Rows[k].Selected = true;
            }
        }

        private void btnLui_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (dtgNhapHang.Rows.Count > 0)
            {
                for (int i = 1; i < dtgNhapHang.Rows.Count; i++)
                {
                    if (dtgNhapHang.Rows[i].Selected == true)
                    {
                        k = i - 1;
                        break;
                    }
                }
                dtgNhapHang.Rows[k].Selected = true;
            }
        }

        private void frm_NhapHang_Load(object sender, EventArgs e)
        {
            //nối database vào bindingsource
            dt = pnb.getPhieuNhap();
            bs.DataSource = dt;
            dtgNhapHang.DataSource = bs;
            //load lên combobox
            cboMaNV.DataSource = nvb.getMaNV();
            cboMaNV.DisplayMember = "MaNV";
            cboMaNV.ValueMember = "MaNV";
            //đưa ra  lời gợi ý
            cboMaNV.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboMaNV.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboMaNCC.DataSource = nccb.getMaNCC();
            cboMaNCC.DisplayMember = "MaNCC";
            cboMaNCC.ValueMember = "MaNCC";
            btnGhi.Enabled = false;
            btnHuy.Enabled = false;
            battattext(false);
        }
        public void battattext(bool trangthai)
        {
            cboMaNCC.Enabled = trangthai;
            cboMaNV.Enabled = trangthai;
            txtMaPN.Enabled = trangthai;
            txtTongTienN.Enabled = trangthai;
        }
        public void battatbutton(bool trangthai)
        {
            btnCuoi.Enabled = trangthai;
            btnDau.Enabled = trangthai;
            btnLui.Enabled = trangthai;
            btnTien.Enabled = trangthai;
            btnThem.Enabled = trangthai;
            btnSua.Enabled = trangthai;
            btnXoa.Enabled = trangthai;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            battattext(true);
            battatbutton(false);
            btnGhi.Enabled = true;
            btnHuy.Enabled = true;
        }
        public bool check_idph(string id)
        {
            DataConnect dc = new DataConnect();
            SqlParameter ma = new SqlParameter("@MaPhieuNhap", id);
            DataTable dt = dc.ExecuteQuery("select *from tblPhieuNhap where MaPhieuNhap=@MaPhieuNhap", ma);
            return dt.Rows.Count > 0;
        }
        int sua = 0;
        private void btnSua_Click(object sender, EventArgs e)
        {
            sua = 1;
            battatbutton(false);
            battattext(true);
            btnGhi.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if ((check_idph(txtMaPN.Text)) && (txtMaPN.Text != ""))
            {
                int pos = dtgNhapHang.CurrentRow.Index;
                if (pos >= 0)
                {
                    pnb.Xoapn(txtMaPN.Text,cboMaNV.Text,cboMaNCC.Text);
                    dtgNhapHang.DataSource = pnb.getPhieuNhap();

                }
                MessageBox.Show("Bạn đã xóa thành công");
            }
            else
            {
                MessageBox.Show("bạn cần chọn một đối tượng để xóa");
                return;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaPN.Text = "";
            txtTongTienN.Text = "";
            cboMaNCC.Text = "";
            cboMaNV.Text = "";
            battatbutton(true);
            battattext(false);
            btnHuy.Enabled = false;
            btnGhi.Enabled = false;
            sua = 0;
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (sua == 0)
            {
                //kiểm tra dữ liệu đầu vào
                if (check_idph(txtMaPN.Text))
                {
                    MessageBox.Show("đối tượng đã tồn tại trong danh sách");
                    return;
                }
                if (txtMaPN.Text.Trim() == "")
                {
                    MessageBox.Show("bạn chưa nhập (^~^)");
                    txtMaPN.Focus();
                    return;
                }
                if (txtTongTienN.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập!!!");
                    txtTongTienN.Focus();
                    return;
                }
                else
                {
                    pnb.Thempn(txtMaPN.Text, cboMaNV.Text, cboMaNCC.Text, DateTime.Parse(dtpNgayNhap.Text), float.Parse(txtTongTienN.Text));
                    dtgNhapHang.DataSource = pnb.getPhieuNhap();
                    MessageBox.Show("Bạn đã thêm thành công");
                    battatbutton(true);
                    btnGhi.Enabled = false;
                    btnHuy.Enabled = false;
                }
            }
            else
            {
                if ((txtMaPN.Text.Trim() == "") && !check_idph(txtMaPN.Text))
                {
                    MessageBox.Show("Bạn chưa nhập đối tượng cần sửa");
                    return;
                }
                if (check_idph(txtMaPN.Text))
                {
                    pnb.Suapn(txtMaPN.Text, cboMaNV.Text, cboMaNCC.Text, DateTime.Parse(dtpNgayNhap.Text), float.Parse(txtTongTienN.Text));
                    dtgNhapHang.DataSource = pnb.getPhieuNhap();
                    MessageBox.Show("Bạn đã sửa thành công ");
                    battatbutton(true);
                    btnHuy.Enabled = false;
                    btnGhi.Enabled = false;
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPN.Text = dtgNhapHang.CurrentRow.Cells[0].Value.ToString();
            cboMaNV.Text = dtgNhapHang.CurrentRow.Cells[1].Value.ToString();
            cboMaNCC.Text = dtgNhapHang.CurrentRow.Cells[2].Value.ToString();
            dtpNgayNhap.Text = dtgNhapHang.CurrentRow.Cells[3].Value.ToString();
            txtTongTienN.Text = dtgNhapHang.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
