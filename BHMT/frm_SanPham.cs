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
    public partial class frm_SanPham : Form
    {
        public frm_SanPham()
        {
            InitializeComponent();
        }
        SanPham_Bus spb = new SanPham_Bus();
        SanPham_Dao spd = new SanPham_Dao();
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        private void btnDau_Click(object sender, EventArgs e)
        {
            if (dtgSanPham.Rows.Count > 0)
            {
                dtgSanPham.Rows[0].Selected = true;
            }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            if (dtgSanPham.Rows.Count > 0)
            {
                dtgSanPham.Rows[dtgSanPham.Rows.Count - 1].Selected = true;
            }
        }

        private void btnTien_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (dtgSanPham.Rows.Count > 0)
            {
                for (int i = 0; i < dtgSanPham.Rows.Count; i++)
                {
                    if (dtgSanPham.Rows[i].Selected == true)
                    {
                        k = i + 1;
                        break;
                    }
                }
                if(dtgSanPham.Rows[dtgSanPham.Rows.Count-1].Selected==false)
                    dtgSanPham.Rows[k].Selected=true;
            }
        }

        private void btnLui_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (dtgSanPham.Rows.Count > 0)
            {
                for (int i = 1; i < dtgSanPham.Rows.Count; i++)
                {
                    if (dtgSanPham.Rows[i].Selected == true)
                    {
                        k = i - 1;
                        break;
                    }
                }
                dtgSanPham.Rows[k].Selected = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dtgSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHH.Text = dtgSanPham.CurrentRow.Cells[0].Value.ToString();
            txtHH.Text = dtgSanPham.CurrentRow.Cells[1].Value.ToString();
            txtGiaNhap.Text = dtgSanPham.CurrentRow.Cells[2].Value.ToString();
            txtGiaBan.Text = dtgSanPham.CurrentRow.Cells[3].Value.ToString();
            txtSoluong.Text = dtgSanPham.CurrentRow.Cells[4].Value.ToString();
            txtVAT.Text = dtgSanPham.CurrentRow.Cells[5].Value.ToString();
            txtNCC.Text = dtgSanPham.CurrentRow.Cells[6].Value.ToString();
        }
        public void battattext(bool trangthai)
        {
            txtMaHH.Enabled = trangthai;
            txtHH.Enabled = trangthai;
            txtGiaNhap.Enabled = trangthai;
            txtGiaBan.Enabled = trangthai;
            txtSoluong.Enabled = trangthai;
            txtVAT.Enabled = trangthai;
            txtNCC.Enabled = trangthai;
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
        int sua = 0;

        private void btnSua_Click(object sender, EventArgs e)
        {
            sua = 1;
            battatbutton(false);
            battattext(true);
            btnGhi.Enabled = true;
            btnHuy.Enabled = true;
        }
        public bool check_idMa(string id)
        {
            DataConnect dc = new DataConnect();
            SqlParameter ma = new SqlParameter("@MaHang", id);
            DataTable dt = dc.ExecuteQuery("select *from tblSanPham where MaHang=@MaHang", ma);
            return dt.Rows.Count > 0;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if ((check_idMa(txtMaHH.Text)) && (txtMaHH.Text != ""))
            {
                int pos = dtgSanPham.CurrentRow.Index;
                if (pos >= 0)
                {
                    spb.xoasp(txtMaHH.Text);
                    dtgSanPham.DataSource = spb.getAllSanPham();

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
                if (check_idMa(txtMaHH.Text))
                {
                    MessageBox.Show("đối tượng nhân viên đã tồn tại trong danh sách");
                    return;
                }
                if (txtMaHH.Text.Trim() == "")
                {
                    MessageBox.Show("bạn chưa nhập mã sản phẩm(^~^)");
                    txtMaHH.Focus();
                    return;
                }
                if (txtHH.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên sản phẩm!!!");
                    txtHH.Focus();
                    return;
                }
                if (txtGiaBan.Text.Trim() == "")
                {
                    MessageBox.Show("nhập thiếu");
                    txtGiaBan.Focus();
                    return;
                }
                if (txtGiaNhap.Text.Trim() == "")
                {
                    MessageBox.Show("nhập thiếu");
                    txtGiaNhap.Focus();
                    return;
                }
                if (txtSoluong.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập!!!");
                    txtSoluong.Focus();
                    return;
                }
                else
                {
                    spb.Themsp(txtMaHH.Text, txtHH.Text, float.Parse(txtGiaNhap.Text), float.Parse(txtGiaBan.Text), int.Parse(txtSoluong.Text), float.Parse(txtVAT.Text), txtNCC.Text);
                    dtgSanPham.DataSource = spb.getAllSanPham();
                    MessageBox.Show("Bạn đã thêm thành công");
                    battatbutton(true);
                    btnGhi.Enabled = false;
                    btnHuy.Enabled = false;
                }
            }
            else
            {
                if ((txtMaHH.Text.Trim() == "") && !check_idMa(txtMaHH.Text))
                {
                    MessageBox.Show("Bạn chưa nhập đối tượng cần sửa");
                    return;
                }
                if (check_idMa(txtMaHH.Text))
                {
                    spb.Suasp(txtMaHH.Text, txtHH.Text, float.Parse(txtGiaNhap.Text), float.Parse(txtGiaBan.Text), int.Parse(txtSoluong.Text), float.Parse(txtVAT.Text), txtNCC.Text);
                    dtgSanPham.DataSource = spb.getAllSanPham();
                    MessageBox.Show("Bạn đã sửa thành công ");
                    battatbutton(true);
                    btnHuy.Enabled = false;
                    btnGhi.Enabled = false;
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaHH.Text = "";
            txtHH.Text = "";
            txtGiaNhap.Text = "";
            txtGiaBan.Text = "";
            txtSoluong.Text = "";
            txtVAT.Text = "";
            txtNCC.Text = "";
            battatbutton(true);
            battattext(false);
            btnHuy.Enabled = false;
            btnGhi.Enabled = false;
            sua = 0;
        }

        private void frm_SanPham_Load(object sender, EventArgs e)
        {
            dt = spb.getAllSanPham();
            bs.DataSource = dt;
            dtgSanPham.DataSource = bs;
            btnGhi.Enabled = false;
            btnHuy.Enabled = false;
            battattext(false);
        }
    }
}
