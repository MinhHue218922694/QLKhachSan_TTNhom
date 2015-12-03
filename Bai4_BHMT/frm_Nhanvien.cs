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
    public partial class frm_Nhanvien : Form
    {
        public frm_Nhanvien()
        {
            InitializeComponent();
        }
        NhanVien_Bus nvb = new NhanVien_Bus();
        NhanVien_Dao nvd = new NhanVien_Dao();
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        //kiểm tra mã id có trùng không
        public bool check_IDNV(string id)
        {
            DataConnect dc = new DataConnect();
            SqlParameter ma = new SqlParameter("@MaNV", id);
            DataTable dt = dc.ExecuteQuery("select *from tblNhanVien where MaNV=@MaNV", ma);
            return dt.Rows.Count > 0;
        }
        private void dtgNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dtgNhanVien.CurrentRow.Cells[0].Value.ToString();
            txtTenNV.Text = dtgNhanVien.CurrentRow.Cells[1].Value.ToString();
            dtpNSNV.Text = dtgNhanVien.CurrentRow.Cells[2].Value.ToString();
            txtBoPhan.Text = dtgNhanVien.CurrentRow.Cells[3].Value.ToString();
            txtChucVu.Text = dtgNhanVien.CurrentRow.Cells[4].Value.ToString();
            txtDiaChi.Text = dtgNhanVien.CurrentRow.Cells[5].Value.ToString();
            txtSDT.Text = dtgNhanVien.CurrentRow.Cells[6].Value.ToString();
        }
        public void battattext(bool trangthai)
        {
            txtMaNV.Enabled = trangthai;
            txtTenNV.Enabled = trangthai;
            txtChucVu.Enabled = trangthai;
            txtDiaChi.Enabled = trangthai;
            txtBoPhan.Enabled = trangthai;
            dtpNSNV.Enabled = trangthai;
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
        private void frm_Nhanvien_Load(object sender, EventArgs e)
        {
            dt = nvb.getAllNhanVien();
            bs.DataSource = dt;
            dtgNhanVien.DataSource = bs;
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
        int sua = 0; //nếu button đang được nhấn thì sửa=1,ngược lại thì =0
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
            if ((check_IDNV(txtMaNV.Text))&&(txtMaNV.Text!=""))
            {
                int pos = dtgNhanVien.CurrentRow.Index;
                if (pos >= 0)
                {
                    nvb.xoanv(txtMaNV.Text);
                    dtgNhanVien.DataSource = nvb.getAllNhanVien();
                    
                }
                MessageBox.Show("Bạn đã xóa thành công");
            }
            else
            {
                MessageBox.Show("bạn cần chọn một đối tượng để xóa");
                return;
            }
        }

        private void btnGhi_Click_1(object sender, EventArgs e)
        {
            if (sua == 0)
            {
                //kiểm tra dữ liệu đầu vào
                if (check_IDNV(txtMaNV.Text))
                {
                    MessageBox.Show("đối tượng nhân viên đã tồn tại trong danh sách");
                    return;
                }
                if (txtMaNV.Text.Trim() == "")
                {
                    MessageBox.Show("bạn chưa nhập mã nhân viên(^~^)");
                    txtMaNV.Focus();
                    return;
                }
                if (txtTenNV.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên nhân viên!!!");
                    txtTenNV.Focus();
                    return;
                }
                if (txtBoPhan.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập bộ phận của nhân viên");
                    txtBoPhan.Focus();
                    return;
                }
                if (txtChucVu.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập chức vụ");
                    txtChucVu.Focus();
                    return;
                }
                if (txtDiaChi.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập địa chỉ!!!");
                    txtDiaChi.Focus();
                    return;
                }
                else
                {
                    nvb.Themnv(txtMaNV.Text, txtTenNV.Text, DateTime.Parse(dtpNSNV.Text), txtBoPhan.Text, txtChucVu.Text, txtDiaChi.Text, txtSDT.Text);
                    dtgNhanVien.DataSource = nvb.getAllNhanVien();
                    MessageBox.Show("Bạn đã thêm thành công");
                    battatbutton(true);
                    btnGhi.Enabled = false;
                    btnHuy.Enabled = false;
                }
            }
            else
            {
                if((txtMaNV.Text.Trim() == "")&&!check_IDNV(txtMaNV.Text))
                {
                    MessageBox.Show("Bạn chưa nhập đối tượng cần sửa");
                    return;
                }
                if(check_IDNV(txtMaNV.Text))
                {
                    nvb.suanv(txtMaNV.Text, txtTenNV.Text, DateTime.Parse(dtpNSNV.Text), txtBoPhan.Text, txtChucVu.Text, txtDiaChi.Text, txtSDT.Text);
                    dtgNhanVien.DataSource = nvb.getAllNhanVien();
                    MessageBox.Show("Bạn đã sửa thành công ");
                    battatbutton(true);
                    btnHuy.Enabled = false;
                    btnGhi.Enabled = false;
                    
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtTenNV.Text = "";
            txtBoPhan.Text = "";
            txtChucVu.Text = "";
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

        private void btnLui_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (dtgNhanVien.Rows.Count > 0)
            {
                for (int i = 1; i < dtgNhanVien.Rows.Count; i++)
                {
                    if (dtgNhanVien.Rows[i].Selected == true)
                    {
                        k = i - 1;
                        break;
                    }
                }
                dtgNhanVien.Rows[k].Selected = true;
            }
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            if (dtgNhanVien.Rows.Count > 0)
            {
                dtgNhanVien.Rows[0].Selected = true;
            }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            if (dtgNhanVien.Rows.Count > 0)
            { 
                dtgNhanVien.Rows[dtgNhanVien.Rows.Count-1].Selected=true;
            }
        }

        private void btnTien_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (dtgNhanVien.Rows.Count > 0)
            {
                for (int i = 0; i < dtgNhanVien.Rows.Count; i++)
                {
                    if (dtgNhanVien.Rows[i].Selected == true)
                    {
                        k = i + 1;
                        break;
                    }
                     
                }
                if (dtgNhanVien.Rows[dtgNhanVien.Rows.Count - 1].Selected == false)
                    dtgNhanVien.Rows[k].Selected = true;          
            }
        }
    }
}
