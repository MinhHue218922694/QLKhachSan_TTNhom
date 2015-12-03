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
    public partial class frm_CTNhap : Form
    {
        public frm_CTNhap()
        {
            InitializeComponent();
        }
        PhieuNhap_Bus pnb = new PhieuNhap_Bus();
        SanPham_Bus spb = new SanPham_Bus();
        CT_PhieuNhap_Bus ctpnb = new CT_PhieuNhap_Bus();
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        private void btnDau_Click(object sender, EventArgs e)
        {
            if (dtgCT_Nhap.Rows.Count > 0)
            {
                dtgCT_Nhap.Rows[0].Selected = true;
            }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            if (dtgCT_Nhap.Rows.Count > 0)
            {
                dtgCT_Nhap.Rows[dtgCT_Nhap.Rows.Count - 1].Selected = true;
            }
        }

        private void btnTien_Click(object sender, EventArgs e)
        {
            int k=0;
            if (dtgCT_Nhap.Rows.Count > 0)
            {
                for (int i = 0; i < dtgCT_Nhap.Rows.Count; i++)
                {
                    if (dtgCT_Nhap.Rows[i].Selected == true)
                    {
                        k = i + 1;
                        break;
                    }
                }
                if (dtgCT_Nhap.Rows[dtgCT_Nhap.Rows.Count - 1].Selected == false)
                    dtgCT_Nhap.Rows[k].Selected = true;
            }
        }

        private void btnLui_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (dtgCT_Nhap.Rows.Count > 0)
            {
                for (int i = 1; i < dtgCT_Nhap.Rows.Count; i++)
                {
                    if (dtgCT_Nhap.Rows[i].Selected == true)
                    {
                        k = i - 1;
                        break;
                    }
                }
                dtgCT_Nhap.Rows[k].Selected = true;
            }
        }
        public void battattext(bool trangthai)
        {
            cboMaHang.Enabled = trangthai;
            cboMaPhieuNhap.Enabled = trangthai;
            txtSoluong.Enabled = trangthai;
            txtThanhTien.Enabled = trangthai;
            txtGia.Enabled = trangthai;
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

        private void frm_CTNhap_Load(object sender, EventArgs e)
        {
            //nối database vào bindingsource
            dt = ctpnb.getAllCT_PhieuNhap();
            bs.DataSource = dt;
            dtgCT_Nhap.DataSource = bs;
            //load lên combobox
            cboMaHang.DataSource = spb.getMaSP();
            cboMaHang.DisplayMember = "MaHang";
            cboMaHang.ValueMember = "MaHang";
            //đưa ra  lời gợi ý
            cboMaHang.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboMaHang.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboMaPhieuNhap.DataSource = pnb.getMaPhieuN();
            cboMaPhieuNhap.DisplayMember = "MaPhieuNhap";
            cboMaPhieuNhap.ValueMember = "MaPhieuNhap";
            btnGhi.Enabled = false;
            btnHuy.Enabled = false;
            battattext(false);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            battattext(true);
            battatbutton(false);
            btnGhi.Enabled = true;
            btnHuy.Enabled = true;
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
            if (cboMaPhieuNhap.Text != "")
            {
                int pos = dtgCT_Nhap.CurrentRow.Index;
                if (pos >= 0)
                {
                    ctpnb.Xoact_nhap(cboMaPhieuNhap.Text, cboMaHang.Text);
                    dtgCT_Nhap.DataSource = ctpnb.getAllCT_PhieuNhap();

                }
                MessageBox.Show("Bạn đã xóa thành công");
            }
            else
            {
                MessageBox.Show("bạn cần chọn một đối tượng để xóa");
                return;
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (sua == 0)
            {
                //kiểm tra dữ liệu đầu vào
                if (txtSoluong.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập!!!");
                    txtSoluong.Focus();
                    return;
                }
                if (txtGia.Text.Trim() == "")
                {
                    MessageBox.Show("bạn chưa nhập");
                    return;
                }
                if (txtThanhTien.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập");
                    return;
                }
                else
                {
                    ctpnb.Themct_nhap(cboMaPhieuNhap.Text, cboMaHang.Text, int.Parse(txtSoluong.Text), float.Parse(txtGia.Text), float.Parse(txtThanhTien.Text));
                    dtgCT_Nhap.DataSource = ctpnb.getAllCT_PhieuNhap();
                    MessageBox.Show("Bạn đã thêm thành công");
                    battatbutton(true);
                    btnGhi.Enabled = false;
                    btnHuy.Enabled = false;
                }
            }
            else
            {
                    ctpnb.Suact_nhap(cboMaPhieuNhap.Text, cboMaHang.Text, int.Parse(txtSoluong.Text), float.Parse(txtGia.Text), float.Parse(txtThanhTien.Text));
                    dtgCT_Nhap.DataSource = ctpnb.getAllCT_PhieuNhap();
                    MessageBox.Show("Bạn đã sửa thành công ");
                    battatbutton(true);
                    btnHuy.Enabled = false;
                    btnGhi.Enabled = false;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            cboMaHang.Text = "";
            cboMaPhieuNhap.Text = "";
            txtGia.Text = "";
            txtSoluong.Text = "";
            txtThanhTien.Text = "";
            battatbutton(true);
            battattext(false);
            btnHuy.Enabled = false;
            btnGhi.Enabled = false;
            sua = 0;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
