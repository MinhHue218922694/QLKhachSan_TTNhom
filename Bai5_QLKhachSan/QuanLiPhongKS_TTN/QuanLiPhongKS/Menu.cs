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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void phòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhong phong = new frmPhong();
            phong.Show();
            Hide();
        }

        private void quảnLíThiếtBịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTBThietBi tb = new frmTBThietBi();
            tb.Show();
            Hide();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang kh = new frmKhachHang();
            kh.Show();
            Hide();
        }

        private void thuêPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThuePhong thue = new frmThuePhong();
            thue.Show();
            Hide();
        }

        private void sửDụngDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSuDungDV sddv = new frmSuDungDV();
            sddv.Show();
            Hide();
        }
    }
}
