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
    public partial class frmSuDungDV : Form
    {
        public frmSuDungDV()
        {
            InitializeComponent();
        }
        SuDungDV sddv = new SuDungDV();
        int loai = 0,chose=0;
        private void bntThemDV_Click(object sender, EventArgs e)
        {
            loai = 1;
            dgvSDungDV.DataSource = null;
            Init();
            cbxIDPhong.DataSource = sddv.ShowPhongThue();
            cbxIDPhong.DisplayMember = "SP";
            cbxIDDV.DataSource = sddv.ShowDichVu();
            cbxIDDV.DisplayMember = "DV";
        }
        private void An()
        {
            cbxIDDV.Enabled = false; txtSoluongSD.Enabled = false;
            cbxIDPhong.Enabled = false; dtPtgdung.Enabled = false;
        }
        private void Init()
        {
            cbxIDDV.Text = ""; txtSoluongSD.Clear();
            cbxIDPhong.Text = "";
        }
        private void Hien()
        {
            cbxIDDV.Enabled = true; cbxIDPhong.Enabled = true;
            txtSoluongSD.Enabled = true; dtPtgdung.Enabled = true;
        }
        private void dgvSDungDV_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            cbxIDPhong.Text = dgvSDungDV.Rows[dong].Cells[0].Value.ToString();
            cbxIDDV.Text = dgvSDungDV.Rows[dong].Cells[1].Value.ToString();
            txtSoluongSD.Text = dgvSDungDV.Rows[dong].Cells[2].Value.ToString();
            dtPtgdung.Text = dgvSDungDV.Rows[dong].Cells[3].Value.ToString();
        }

        private void frmSuDungDV_Load(object sender, EventArgs e)
        {
            DataTable dt = sddv.ShowSDDV();
            dgvSDungDV.DataSource = dt;
        }
        private void ThemDV()
        {
            string kq = sddv.ThemSDDV(cbxIDPhong.Text, cbxIDDV.Text, txtSoluongSD.Text, dtPtgdung.Text);
            if (kq == "0")
                MessageBox.Show("Chưa nhập đầy đủ các thông tin");
            else
                if (kq == "3") MessageBox.Show("Không có số phòng hoặc không có dịch vụ này");
                else
                    if (kq == "4") MessageBox.Show("Ngày sử dụng quá thời hạn cho thuê");
                    else
                        if (kq == "1") MessageBox.Show("Dịch vụ đã được cộng thêm số lượng vì đã được dùng");
                        else
                            if (kq == "2")
                            {
                                MessageBox.Show("Đã thêm thành công");
                                DataTable dt = sddv.ShowSDDV();
                                dgvSDungDV.DataSource = dt;
                            }
        }
        private void SuaDV()
        {
            string kq = sddv.SuaSDDV(cbxIDPhong.Text, cbxIDDV.Text, txtSoluongSD.Text, dtPtgdung.Text);
            if (kq == "0") MessageBox.Show("Không có phòng này");
            else
                if (kq == "1") MessageBox.Show("Không có dịch vụ này");
                else
                    if (kq == "2") MessageBox.Show("Thời gian không nằm trong khung thời gian thuê");
                    else
                        if (kq == "3")
                        {
                            MessageBox.Show("Đã sửa thành công");
                            dgvSDungDV.DataSource = sddv.ShowSDDV();
                        }
        }
        private void XoaDV()
        {
            string kq = sddv.XoaSDDV(cbxIDPhong.Text, cbxIDDV.Text, dtPtgdung.Text);
            if (kq == "0") MessageBox.Show("Chưa nhập đầy đủ thông tin");
            else
                if (kq == "1") MessageBox.Show("Không tồn tại phòng hoặc không tồn tại dịch vụ");
                else
                    MessageBox.Show("Đã thêm thành công");
        }

        private void TimKiem()
        {
            DataTable dt = sddv.TimKiemSDDV(cbxIDPhong.Text, cbxIDDV.Text, dtPtgdung.Text, chose);
            if (dt.Rows.Count > 0)
                dgvSDungDV.DataSource = dt;
            else
                MessageBox.Show("Không tìm thấy");
        }
        private void bntCapNhat_Click(object sender, EventArgs e)
        {
            loai = 2;
            An();
            txtSoluongSD.Enabled = true;
            dtPtgdung.Enabled = true;
        }

        private void bntXoaDV_Click(object sender, EventArgs e)
        {
            loai = 3;
            Hien();
            txtSoluongSD.Enabled = false;
            dgvSDungDV.DataSource = null;
        }

        private void bntLuuDV_Click(object sender, EventArgs e)
        {
            if (loai == 1)
                ThemDV();
            else
                if (loai == 2)
                    SuaDV();
                else
                    if (loai == 3)
                        XoaDV();
        }

        private void bntTimKiem_Click(object sender, EventArgs e)
        {
            grbChon.Visible = true;
        }

        private void rbrPhong_CheckedChanged(object sender, EventArgs e)
        {
            chose = 1;
            An();
            cbxIDPhong.Enabled = true;
        }

        private void rdbDichVu_CheckedChanged(object sender, EventArgs e)
        {
            chose = 2;
            An();
            cbxIDDV.Enabled = true;
        }

        private void rdbNgaySD_CheckedChanged(object sender, EventArgs e)
        {
            chose = 3;
            An();
            dtPtgdung.Enabled = true;
        }

        private void bntThoatPhong_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            menu.Show();
            Hide();
        }
    }
}
