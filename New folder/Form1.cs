using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBMT_TTNhom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tsmQuanLy.Enabled = false;
            tsmThaotac.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //bật tắt form
        public void battatnv(bool trangthai)
        {
            tsmHeThong.Enabled = trangthai;
            kháchHàngToolStripMenuItem.Enabled = trangthai;
            tsmQuanLy.Enabled = trangthai;
            sảnPhẩmToolStripMenuItem.Enabled = trangthai;
            tsmhelp.Enabled = trangthai;
            tsmThaotac.Enabled = trangthai;
        }
        public void battat(bool trangthai)
        {
            tsmHeThong.Enabled = trangthai;
            tsmhelp.Enabled = trangthai;
        }
        public void BatTatMenu(bool trangthai)
        {
            tsmHeThong.Enabled = trangthai;
            tsmQuanLy.Enabled = trangthai;
            tsmThaotac.Enabled = trangthai;
        }
        public void BatTatMenuKH(bool trangthai)
        {
            tsmHeThong.Enabled = trangthai;
            tsmThaotac.Enabled = trangthai;
            tìmKiếmToolStripMenuItem.Enabled = trangthai;
            thốngKêToolStripMenuItem.Enabled = trangthai;
            tsmhelp.Enabled = trangthai;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int i = 100;
            label1.Left -= i;
            if (label1.Left <= -817)
            {
                label1.Left += 2200;
            }
        }

        private void liênHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Lienhe frm = new frm_Lienhe();
            frm.ShowDialog();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsmQuanLy.Enabled = false;
            tsmThaotac.Enabled = false;
            tsmdangnhap.Enabled = true;
            tsmdangxuat.Enabled = false;
            thoátToolStripMenuItem.Enabled = true;
            MessageBox.Show("Bạn đã thoát khỏi hệ thống!!!", "thông báo");
        }

        private void kếtNốiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ngườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Nhanvien frm = new frm_Nhanvien();
            frm.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_KhachHang kh = new frm_KhachHang();
            kh.ShowDialog();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_NhaCungCap ncc = new frm_NhaCungCap();
            ncc.ShowDialog();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_SanPham sp = new frm_SanPham();
            sp.ShowDialog();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Timkiem tk = new frm_Timkiem();
            tk.ShowDialog();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ThongKe tk = new frm_ThongKe();
            tk.ShowDialog();
        }

        private void nhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_NhapHang nh = new frm_NhapHang();
            nh.ShowDialog();
        }

        private void chiTiếtNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_CTNhap ctn = new frm_CTNhap();
            ctn.ShowDialog();
        }

        private void xuấtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_XuatHang xuat = new frm_XuatHang();
            xuat.ShowDialog();
        }

        private void chiTiếtXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_CTXuat ctx = new frm_CTXuat();
            ctx.ShowDialog();
        }
    }
}
