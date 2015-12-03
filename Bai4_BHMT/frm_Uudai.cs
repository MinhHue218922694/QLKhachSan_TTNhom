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
    public partial class frm_Uudai : Form   
    {
        public frm_Uudai()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        UuDai_Bus udb = new UuDai_Bus();
        UuDai_Dao udd = new UuDai_Dao();
        KhachHang_Bus khb = new KhachHang_Bus();
        //tạo các nút di chuyển trên datagridview
        private void btnDau_Click(object sender, EventArgs e)
        {
            if (dtgUuDai.Rows.Count > 0)
            {
                dtgUuDai.Rows[0].Selected = true;
            }
        }
        private void btnCuoi_Click(object sender, EventArgs e)
        {
            if (dtgUuDai.Rows.Count > 0)
            {
                dtgUuDai.Rows[dtgUuDai.Rows.Count - 1].Selected = true;
            }
        }

        private void btnTien_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (dtgUuDai.Rows.Count > 0)
            {
                for (int i = 0; i < dtgUuDai.Rows.Count; i++)
                {
                    if (dtgUuDai.Rows[i].Selected == true)
                    {
                        k = i + 1;
                        break;
                    }
                }
                if (dtgUuDai.Rows[dtgUuDai.Rows.Count - 1].Selected == false)
                    dtgUuDai.Rows[k].Selected = true;
            }
        }

        private void btnLui_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (dtgUuDai.Rows.Count > 0)
            {
                for (int i = 1; i < dtgUuDai.Rows.Count; i++)
                {
                    if (dtgUuDai.Rows[i].Selected == true)
                    {
                        k = i - 1;
                        break;
                    }
                }
                dtgUuDai.Rows[k].Selected = true;
            }
        }

        private void frm_Uudai_Load(object sender, EventArgs e)
        {
            //nối database vào bindingsource
            dt = udb.GetAllUuDai();
            bs.DataSource = dt;
            dtgUuDai.DataSource = bs;
            //load lên combobox
            cboMaKH.DataSource = khb.GetMaKH();
            cboMaKH.DisplayMember = "MaKH";
            cboMaKH.ValueMember = "MaKH";
            //đưa ra  lời gợi ý
            cboMaKH.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboMaKH.AutoCompleteSource = AutoCompleteSource.ListItems;
            btnGhi.Enabled = false;
            btnHuy.Enabled = false;
            battattext(false);
        }
        public bool check_Muc(string muc)
        {
            DataConnect dc = new DataConnect();
            SqlParameter m = new SqlParameter("@MucUD", muc);
            DataTable dt = dc.ExecuteQuery("select *from tblUuDai where MucUD=@MucUD");
            return dt.Rows.Count > 0;
        }

        private void dtgUuDai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboMaKH.Text = dtgUuDai.CurrentRow.Cells[0].Value.ToString();
            txtMucUD.Text = dtgUuDai.CurrentRow.Cells[1].Value.ToString();
            txtTongMua.Text = dtgUuDai.CurrentRow.Cells[2].Value.ToString();
        }
        public void battattext(bool trangthai)
        {
            cboMaKH.Enabled = trangthai;
            txtTongMua.Enabled = trangthai;
            txtMucUD.Enabled = trangthai;
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (check_Muc(txtMucUD.Text) && (txtMucUD.Text != ""))
            {
                int pos = dtgUuDai.CurrentRow.Index;
                if (pos >= 0)
                {
                    udb.xoaud(txtMucUD.Text);
                    dtgUuDai.DataSource = udb.GetAllUuDai();
                }
                MessageBox.Show("Bạn đã xóa thành công");
            }
            else
            {
                MessageBox.Show("Bạn cần chọn một đối tượng để xóa");
                return;
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (sua == 0)
            {
                //kiểm tra dữ liệu đầu vào
                if (check_Muc(txtMucUD.Text))
                {
                    MessageBox.Show("dữ liệu này đã tồn tại");
                    return;
                }
                if (txtMucUD.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập dữ liệu");
                    txtMucUD.Focus();
                    return;
                }
                else 
                {
                    udb.Themud(cboMaKH.Text,txtMucUD.Text,int.Parse(txtTongMua.Text));
                    dtgUuDai.DataSource=udb.GetAllUuDai();
                    MessageBox.Show("Bạn đã thêm thành công");
                }
            }
            else
            {
                if (check_Muc(txtMucUD.Text))
                {
                    udb.Suaud(cboMaKH.Text, txtMucUD.Text, int.Parse(txtTongMua.Text));
                    dtgUuDai.DataSource = udb.GetAllUuDai();
                    MessageBox.Show("Bạn đã sửa thành công ");
                    battatbutton(true);
                    btnGhi.Enabled = false;
                    btnHuy.Enabled = false;
                }
                if ((txtMucUD.Text.Trim() == "")&&!check_Muc(txtMucUD.Text))
                {
                    MessageBox.Show("Bạn chưa nhập dữ liệu cần sửa hay dữ liệu chưa tồn tại");
                    return;
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMucUD.Text = "";
            txtTongMua.Text = "";
            cboMaKH.Text = "";
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
