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
    public partial class frmPhong : Form
    {
        public frmPhong()
        {
            InitializeComponent();
        }
        PhongKS phong=new PhongKS();
        DataTable dt;
        int chose,loai;
        private void frmPhong_Load(object sender, EventArgs e)
        {
            dt = phong.ShowPhong();
            dgvPhong.DataSource = dt;
            cbxIDPhong.DataSource = dt;
            cbxIDPhong.DisplayMember = "Số Phòng";
            DataTable dt1 = phong.ShowMaLPhong();
            cbxMaLPhong.DataSource = dt1;
            cbxMaLPhong.DisplayMember = "malphong";
        }

        private void dgvPhong_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            cbxIDPhong.Text = dgvPhong.Rows[dong].Cells[0].Value.ToString();
            cbxMaLPhong.Text = dgvPhong.Rows[dong].Cells[1].Value.ToString();
            cbxTinhTrang.Text = dgvPhong.Rows[dong].Cells[2].Value.ToString();
            cbxHienTrang.Text = dgvPhong.Rows[dong].Cells[3].Value.ToString();
            txtSoDT.Text = dgvPhong.Rows[dong].Cells[4].Value.ToString();
        }

        private void themToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvPhong.DataSource = null;
            Init();
            cbxIDPhong.Enabled = false;
            loai = 1;
        }
        private void Init()
        {
            cbxHienTrang.Text = ""; cbxIDPhong.Text = ""; cbxMaLPhong.Text = ""; cbxTinhTrang.Text = "";
            txtSoDT.Text = "";
        }
        private void Hien()
        {
            cbxIDPhong.Enabled = true; cbxHienTrang.Enabled = true; cbxMaLPhong.Enabled = true; cbxTinhTrang.Enabled = true;
            txtSoDT.Enabled = true;
        }
        private void An()
        {
            cbxIDPhong.Enabled = false; cbxHienTrang.Enabled = false; cbxMaLPhong.Enabled = false; cbxTinhTrang.Enabled = false;
            txtSoDT.Enabled = false;
        }
        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvPhong.DataSource = dt;
            cbxIDPhong.Enabled = false;
            loai = 2;
        }
        private void Them()
        {
            string kq = phong.ThemPhong(cbxMaLPhong.Text, cbxTinhTrang.Text, cbxHienTrang.Text, txtSoDT.Text);
            if (kq == "0")
                MessageBox.Show("Không được để trống mã loại");
            else
                if (kq == "1")
                    MessageBox.Show("Không có Loại phòng này");
                else
                    if (kq == "3")
                        MessageBox.Show("Số điện thoại đã có");
                    else if (kq == "2")
                    {
                        MessageBox.Show("Đã thêm thành công");
                        dt = phong.ShowPhong();
                        dgvPhong.DataSource = dt;
                    }
        }
        private void Sua()
        {
            string kq = phong.SuaPhong(cbxIDPhong.Text, cbxMaLPhong.Text, cbxTinhTrang.Text, cbxHienTrang.Text, txtSoDT.Text);
            if (kq == "0")
                MessageBox.Show("Phải chọn phòng");
            else
                if (kq == "1")
                    MessageBox.Show("Phòng không tồn tại");
                else
                    if (kq == "2")
                    {
                        MessageBox.Show("Đã sửa thành công");
                        dgvPhong.DataSource = phong.ShowPhong();
                    }
        }
        private void Xoa()
        {
            string kq = phong.XoaPhong(cbxIDPhong.Text);
            if (kq == "1")
                MessageBox.Show("Không tồn tại phòng này");
            else
                if (kq == "3")
                    MessageBox.Show("Phòng đang thuê không được xóa");
                else
                    if (kq == "2")
                        MessageBox.Show("Đã xóa thành công");
            
        }
        private void TimKiem()
        {
            DataTable dt2 = phong.Timkiem(Convert.ToInt32(cbxIDPhong.Text), cbxMaLPhong.Text, cbxTinhTrang.Text, cbxHienTrang.Text, chose);
            if (dt.Rows.Count > 0)
                dgvPhong.DataSource = dt2;
            else
                MessageBox.Show("Không tìm thấy");
        }
     
        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            menu.Show();
            Hide();
        }

        private void bntSave_Click_1(object sender, EventArgs e)
        {
            if (loai == 1)
                Them();
            else
                if (loai == 2)
                    Sua();
                else
                    if (loai == 3)
                        Xoa();
        }
        private void txtSoDT_TextChanged(object sender, EventArgs e)
        {
            string tmp = txtSoDT.Text;
            bool ok = true;
            foreach (char c in tmp)
                if (c > '9' || c < '0' || c == null) ok = false;
            if (ok == false)
            {
                bntSave.Enabled = false;
                lblBaoLoi.Visible = true;
                lblBaoLoi.Text = "Phải nhập số ở đây";
            }
            else
            {
                bntSave.Enabled = true;
                lblBaoLoi.Visible = false;
            }
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grbChon.Visible = true;
            dgvPhong.DataSource = null;
            An();
            bntSave.Enabled = false;
        }
        private void rdbPhong_CheckedChanged(object sender, EventArgs e)
        {
            chose = 1;
            An();
            cbxIDPhong.Enabled = true;
        }

        private void rdbLPhong_CheckedChanged(object sender, EventArgs e)
        {
            chose = 2;
            An();
            cbxMaLPhong.Enabled = true;
        }

        private void rdbtinhtrang_CheckedChanged(object sender, EventArgs e)
        {
            chose = 3;
            An();
            cbxTinhTrang.Enabled = true;
        }

        private void rdbHientrang_CheckedChanged(object sender, EventArgs e)
        {
            chose = 4;
            An();
            cbxHienTrang.Enabled = true;
        }

        private void bntTim_Click(object sender, EventArgs e)
        {
            TimKiem();
            bntSave.Enabled = false;
        }
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            An();
            cbxIDPhong.Enabled = true;
            loai = 3;
            dgvPhong.DataSource = null;
        }

        private void bntSearch_Click(object sender, EventArgs e)
        {
            TimKiem();
        }
    }
}
