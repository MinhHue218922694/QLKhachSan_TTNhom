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
    public partial class frm_NhaCungCap : Form
    {
        public frm_NhaCungCap()
        {
            InitializeComponent();
        }
        NCC_Bus ncb = new NCC_Bus();
        NCC_Dao ncd = new NCC_Dao();
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        public void battattext(bool trangthai)
        {
            txtMaNCC.Enabled = trangthai;
            txtTenNCC.Enabled = trangthai;
            txtDiaChi.Enabled = trangthai;
            txtSDT.Enabled = trangthai;
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
        public bool check_idNCC(string ma)
        {
            DataConnect dc = new DataConnect();
            SqlParameter id = new SqlParameter("@MaNCC", ma);
            DataTable dt = dc.ExecuteQuery("select *from tblNCC where MaNCC=@MaNCC", id);
            return dt.Rows.Count > 0;
        }
        private void frm_NhaCungCap_Load(object sender, EventArgs e)
        {
            dt = ncb.getAllNCC();
            bs.DataSource = dt;
            dtgNCC.DataSource = bs;
            battattext(false);
            btnGhi.Enabled = false;
            btnHuy.Enabled = false;
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
            if ((check_idNCC(txtMaNCC.Text)) && (txtMaNCC.Text != ""))
            {
                int pos = dtgNCC.CurrentRow.Index;
                if (pos >= 0)
                {
                    ncb.xoancc(txtMaNCC.Text);
                    dtgNCC.DataSource = ncb.getAllNCC();

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
                if (check_idNCC(txtMaNCC.Text))
                {
                    MessageBox.Show("đối tượng đã tồn tại trong danh sách");
                    return;
                }
                if (txtMaNCC.Text.Trim() == "")
                {
                    MessageBox.Show("bạn chưa nhập mã nhà cung cấp(^~^)");
                    txtMaNCC.Focus();
                    return;
                }
                if (txtTenNCC.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên!!!");
                    txtTenNCC.Focus();
                    return;
                }
                if (txtDiaChi.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập địa chỉ!!!");
                    txtDiaChi.Focus();
                    return;
                }
                if (txtSDT.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập số điện thoại");
                    return;
                }
                else
                {
                    ncb.Themncc(txtMaNCC.Text, txtTenNCC.Text,txtSDT.Text,txtDiaChi.Text);
                    dtgNCC.DataSource = ncb.getAllNCC();
                    MessageBox.Show("Bạn đã thêm thành công");
                    battatbutton(true);
                    btnGhi.Enabled = false;
                    btnHuy.Enabled = false;
                }
            }
            else
            {
                if ((txtMaNCC.Text.Trim() == "") && !check_idNCC(txtMaNCC.Text))
                {
                    MessageBox.Show("Bạn chưa nhập đối tượng cần sửa");
                    return;
                }
                if (check_idNCC(txtMaNCC.Text))
                {
                    ncb.Suancc(txtMaNCC.Text, txtTenNCC.Text, txtSDT.Text, txtDiaChi.Text);
                    dtgNCC.DataSource = ncb.getAllNCC();
                    MessageBox.Show("Bạn đã sửa thành công ");
                    battatbutton(true);
                    btnHuy.Enabled = false;
                    btnGhi.Enabled = false;
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            battatbutton(true);
            battattext(false);
            btnHuy.Enabled = false;
            btnGhi.Enabled = false;
            sua = 0;
        }
        //tạo các nút di chuyển trên form
        private void btnDau_Click(object sender, EventArgs e)
        {
            if (dtgNCC.Rows.Count > 0)
            {
                dtgNCC.Rows[0].Selected = true;
            }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            if (dtgNCC.Rows.Count > 0)
            {
                dtgNCC.Rows[dtgNCC.Rows.Count - 1].Selected = true;
            }
        }

        private void btnTien_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (dtgNCC.Rows.Count > 0)
            {
                for (int i = 0; i < dtgNCC.Rows.Count; i++)
                {
                    if (dtgNCC.Rows[i].Selected == true)
                    {
                        k = i + 1;
                        break;
                    }
                }
                if (dtgNCC.Rows[dtgNCC.Rows.Count - 1].Selected == false)
                    dtgNCC.Rows[k].Selected = true;
            }
        }

        private void btnLui_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (dtgNCC.Rows.Count > 0)
            {
                for (int i = 1; i < dtgNCC.Rows.Count; i++)
                {
                    if (dtgNCC.Rows[i].Selected == true)
                    {
                        k = i - 1;
                        break;
                    }
                }
                dtgNCC.Rows[k].Selected = true;
            }
        }

        private void dtgNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNCC.Text = dtgNCC.CurrentRow.Cells[0].Value.ToString();
            txtTenNCC.Text = dtgNCC.CurrentRow.Cells[1].Value.ToString();
            txtSDT.Text = dtgNCC.CurrentRow.Cells[2].Value.ToString();
            txtDiaChi.Text = dtgNCC.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
