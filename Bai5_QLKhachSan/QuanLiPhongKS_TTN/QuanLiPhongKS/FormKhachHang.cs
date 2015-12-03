using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongKS
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        KhachHang kh = new KhachHang();
        DataTable dtkh;
        int chose;
        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLiPhongKSDataSet.tblKhachHang' table. You can move, or remove it, as needed.
            this.tblKhachHangTableAdapter.Fill(this.quanLiPhongKSDataSet.tblKhachHang);
            dtkh = kh.ShowKhachHang();
            dgvKhachHang.DataSource = dtkh;           
        }

        private void dgvKhachHang_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            comboBox1.Text = dgvKhachHang.Rows[dong].Cells[0].Value.ToString();
            txtTenKH.Text = dgvKhachHang.Rows[dong].Cells[1].Value.ToString();
            dtpNgaySinh.Text = dgvKhachHang.Rows[dong].Cells[2].Value.ToString();
            cbxGT.Text = dgvKhachHang.Rows[dong].Cells[3].Value.ToString();
            txtQueQuan.Text = dgvKhachHang.Rows[dong].Cells[4].Value.ToString();
            txtCMND.Text = dgvKhachHang.Rows[dong].Cells[5].Value.ToString();
            txtSDT.Text = dgvKhachHang.Rows[dong].Cells[6].Value.ToString();
            txtQuocTich.Text = dgvKhachHang.Rows[dong].Cells[7].Value.ToString();
        }
        private void Init()
        {
            comboBox1.Text = ""; txtTenKH.Clear(); dtpNgaySinh.Text = ""; cbxGT.Text = "";
            txtQueQuan.Clear(); txtCMND.Clear(); txtSDT.Clear();
            txtQuocTich.Clear();
        }

        private void bntSua_Click(object sender, EventArgs e)
        {
            bntSave.Visible = true;
            Hien();
            comboBox1.Enabled=false;
            Init();
        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            string kq = kh.SuaKhachHang(comboBox1.Text, txtTenKH.Text, dtpNgaySinh.Text, txtQueQuan.Text, cbxGT.Text, txtCMND.Text, txtSDT.Text, txtQuocTich.Text);
            if (kq == "1")
                MessageBox.Show("Không tồn tại mã khách hàng");
            else
                if (kq == "2")
                {
                    MessageBox.Show("Đã sửa thành công");
                    dgvKhachHang.DataSource = kh.ShowKhachHang();
                }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            string tmp = txtSDT.Text;
            bool ok = true;
            foreach (char c in tmp)
                if (c > '9' || c < '0' || c == null) ok = false;
            if (ok == false)
            {
                bntSave.Enabled = false;
                lblCanhBao.Visible = true;
                lblCanhBao.Text = "Phải nhập số ở đây";
            }
            else
            {
                bntSave.Enabled = true;
                lblCanhBao.Visible = false;
            }
        }

        public string tx { get; set; }

        private void txtCMND_TextChanged(object sender, EventArgs e)
        {
            string tmp = txtCMND.Text;
            bool ok = true;
            foreach (char c in tmp)
                if (c > '9' || c < '0' || c == null) ok = false;
            if (ok == false)
            {
                bntSave.Enabled = false;
                lblCanhBao.Visible = true;
                lblCanhBao.Text = "Phải nhập số ở đây";
            }
            else
            {
                bntSave.Enabled = true;
                lblCanhBao.Visible = false;
            }
        }
        private void An()
        {
            comboBox1.Enabled = false; txtTenKH.Enabled = false; dtpNgaySinh.Enabled = false; cbxGT.Enabled = false;
            txtQueQuan.Enabled = false; txtSDT.Enabled = false; txtCMND.Enabled = false; txtQuocTich.Enabled = false;
        }
        private void Hien()
        {
            comboBox1.Enabled = true; txtTenKH.Enabled = true; dtpNgaySinh.Enabled = true; cbxGT.Enabled = true;
            txtQueQuan.Enabled = true; txtSDT.Enabled = true; txtCMND.Enabled = true; txtQuocTich.Enabled = true;
        }
        private void bntTimKiem_Click(object sender, EventArgs e)
        {
            grbTK.Visible = true;
            An();
            dgvKhachHang.DataSource = null;
        }
        private void TimKiem()
        {
            DataTable dt = kh.TimKiemKH(comboBox1.Text, txtCMND.Text, txtTenKH.Text, chose);
            if (dt.Rows.Count == 0) MessageBox.Show("Không thể tìm thấy");
            else
            {
                dgvKhachHang.DataSource = dt;
            }
        }
        
        private void rBTKMa_CheckedChanged(object sender, EventArgs e)
        {
            chose = 1;
            An();
            comboBox1.Enabled = true;
        }

        private void rBTKTen_CheckedChanged(object sender, EventArgs e)
        {
            chose = 2;
            An();
            txtTenKH.Enabled = true;
        }

        private void rBTKCMND_CheckedChanged(object sender, EventArgs e)
        {
            chose = 3;
            An();
            txtCMND.Enabled = true;
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                TimKiem();
        }

        private void txtTenKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                TimKiem();
        }

        private void txtCMND_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                TimKiem();
        }
    }
}
