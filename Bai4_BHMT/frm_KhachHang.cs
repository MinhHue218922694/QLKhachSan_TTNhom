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
    public partial class frm_KhachHang : Form
    {
        public frm_KhachHang()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        KhachHang_Bus khb = new KhachHang_Bus();
        KhachHang_Dao khd = new KhachHang_Dao();
        //kiểm tra mã khách hàng
        public bool check_IdKH(string id)
        {
            DataConnect dc = new DataConnect();
            SqlParameter ma = new SqlParameter("@MaKH", id);
            DataTable dt = dc.ExecuteQuery("select *from tblKhachHang where MaKH=@MaKH", ma);
            return dt.Rows.Count > 0;
        }
        private void frm_KhachHang_Load(object sender, EventArgs e)
        {
            dt = khb.GetAllKH();
            bs.DataSource = dt;
            dtgKhachHang.DataSource = bs;
            btnGhi.Enabled = false;
            btnHuy.Enabled = false;
            battattext(false);
        }

        private void dtgKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Text = dtgKhachHang.CurrentRow.Cells[0].Value.ToString();
            txtTenKH.Text = dtgKhachHang.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi.Text = dtgKhachHang.CurrentRow.Cells[2].Value.ToString();
            txtSDT.Text = dtgKhachHang.CurrentRow.Cells[3].Value.ToString();
            txtMail.Text = dtgKhachHang.CurrentRow.Cells[4].Value.ToString();
        }
        public void battatbutton(bool trangthai)
        {
            btnCuoi.Enabled = trangthai;
            btnDau.Enabled = trangthai;
            btnLui.Enabled = trangthai;
            btnTien.Enabled = trangthai;
            btnThem.Enabled = trangthai;
            btnXoa.Enabled = trangthai;
            btnSua.Enabled = trangthai;
        }
        public void battattext(bool trangthai)
        {
            txtMaKH.Enabled = trangthai;
            txtMail.Enabled = trangthai;
            txtSDT.Enabled = trangthai;
            txtTenKH.Enabled = trangthai;
            txtDiaChi.Enabled = trangthai;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            battatbutton(false);
            battattext(true);
            btnHuy.Enabled = true;
            btnGhi.Enabled = true;
        }
        int sua = 0;
        //nếu button đang được nhấn thì sửa=1,ngược lại thì =0
        private void btnSua_Click(object sender, EventArgs e)
        {
            sua = 1;
            battatbutton(false);
            battattext(true);
            btnHuy.Enabled = true;
            btnGhi.Enabled = true;
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (sua == 0)
            {
                //kiểm tra dữ liệu đầu vào
                if (check_IdKH(txtMaKH.Text))
                {
                    MessageBox.Show("đối tượng khách hàng đã tồn tại trong danh sách");
                    return;
                }
                if (txtMaKH.Text.Trim() == "")
                {
                    MessageBox.Show("bạn chưa nhập mã khách hàng(^~^)");
                    txtMaKH.Focus();
                    return;
                }
                if (txtTenKH.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên khách hàng!!!");
                    txtTenKH.Focus();
                    return;
                }
                if (txtDiaChi.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập địa chỉ của khách hàng");
                    txtDiaChi.Focus();
                    return;
                }
                if (txtMail.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập mail của khách");
                    txtMail.Focus();
                    return;
                }
                if (txtSDT.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập số liên lạc!!!");
                    txtSDT.Focus();
                    return;
                }
                else
                {
                    khb.Themkh(txtMaKH.Text,txtTenKH.Text,txtDiaChi.Text,txtSDT.Text,txtMail.Text);
                    dtgKhachHang.DataSource = khb.GetAllKH();
                    MessageBox.Show("Bạn đã thêm thành công");
                    battatbutton(true);
                    battattext(false);
                    btnGhi.Enabled = false;
                    btnHuy.Enabled = false;
                }
            }
            else
            {
                if ((txtMaKH.Text.Trim() == "")&&!check_IdKH(txtMaKH.Text))
                {
                    MessageBox.Show("Bạn chưa nhập đối tượng cần sửa hay đối tượng này chưa tồn tại");
                    return;
                }
                if (check_IdKH(txtMaKH.Text))
                {
                    khb.Suakh(txtMaKH.Text, txtTenKH.Text, txtDiaChi.Text, txtSDT.Text, txtMail.Text);
                    dtgKhachHang.DataSource = khb.GetAllKH();
                    MessageBox.Show("Bạn đã sửa thành công ");
                    battatbutton(true);
                    battattext(false);
                    btnHuy.Enabled = false;
                    btnGhi.Enabled = false;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (check_IdKH(txtMaKH.Text) && (txtMaKH.Text != ""))
            {
                int pos = dtgKhachHang.CurrentRow.Index;
                if (pos >= 0)
                {
                    khb.Xoakh(txtMaKH.Text);
                    dtgKhachHang.DataSource = khb.GetAllKH();
                }
                MessageBox.Show("Bạn đã xóa thành công");
            }
            else
            {
                MessageBox.Show("Bạn cần chọn một đối tượng để xóa");
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            if (dtgKhachHang.Rows.Count != 0)
            {
                dtgKhachHang.Rows[dtgKhachHang.Rows.Count - 1].Selected = true;
            }
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            if (dtgKhachHang.Rows.Count != 0)
            {
                dtgKhachHang.Rows[0].Selected = true;
            }
        }

        private void btnTien_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (dtgKhachHang.Rows.Count > 0)
            {
                for (int i = 0; i < dtgKhachHang.Rows.Count; i++)
                {
                    if (dtgKhachHang.Rows[i].Selected == true)
                    {
                        k = i + 1;
                        break;
                    }
                }
                if (dtgKhachHang.Rows[dtgKhachHang.Rows.Count - 1].Selected == false)
                    dtgKhachHang.Rows[k].Selected = true;
            }
        }

        private void btnLui_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (dtgKhachHang.Rows.Count > 0)
            {
                for (int i = 1; i < dtgKhachHang.Rows.Count; i++)
                {
                    if (dtgKhachHang.Rows[i].Selected == true)
                    {
                        k = i - 1;
                        break;
                    }
                }
                dtgKhachHang.Rows[k].Selected = true;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtTenKH.Text = "";
            txtMail.Text = "";
            battatbutton(true);
            battattext(false);
            btnHuy.Enabled = false;
            btnGhi.Enabled = false;
            sua = 0;
        }

        private void dtgKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        } 
    }
}
