using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanHang.Controllers;
using QLBanHang.Models;

namespace QLBanHang.Views.QuanLySanPham
{
    public partial class Quanly : UserControl
    {
        QLBanHang.Views.Sanpham s = new QLBanHang.Views.Sanpham();
        ViewControl.Khohang kh = new ViewControl.Khohang();
        ViewControl.Nhanvien nv = new ViewControl.Nhanvien();
        ViewControl.Khachhang khachhang = new ViewControl.Khachhang();
        ViewControl.Thongke Thongke = new ViewControl.Thongke();

        private void NoneActive()
        {
            button11.BackColor = Color.FromArgb(224, 224, 224);
            button12.BackColor = Color.FromArgb(224, 224, 224);
            button13.BackColor = Color.FromArgb(224, 224, 224);
            button14.BackColor = Color.FromArgb(224, 224, 224);
            button10.BackColor = Color.FromArgb(224, 224, 224);
        }
        public Quanly()
        {
            InitializeComponent();
            Content.Controls.Clear();
            Content.Controls.Add(s);
            s.Dock = DockStyle.Fill;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            NoneActive();
            button14.BackColor = Color.FromArgb(128, 255, 255);
            Content.Controls.Clear();
            Content.Controls.Add(s);
            s.Dock = DockStyle.Fill;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            NoneActive();
            button11.BackColor = Color.FromArgb(128, 255, 255);
            Content.Controls.Clear();
            Content.Controls.Add(kh);
            kh.Dock = DockStyle.Fill;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            NoneActive();
            button12.BackColor = Color.FromArgb(128, 255, 255);
            Content.Controls.Clear();
            Content.Controls.Add(khachhang);
            khachhang.Dock = DockStyle.Fill;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            NoneActive();
            button13.BackColor = Color.FromArgb(128, 255, 255);
            Content.Controls.Clear();
            Content.Controls.Add(nv);
            nv.Dock = DockStyle.Fill;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            NoneActive();
            button10.BackColor = Color.FromArgb(128, 255, 255);
            Content.Controls.Clear();
            Content.Controls.Add(Thongke);
            Thongke.Dock = DockStyle.Fill;
        }
    }
}
