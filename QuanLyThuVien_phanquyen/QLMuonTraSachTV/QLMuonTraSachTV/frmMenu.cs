using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLMuonTraSachTV
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            frmDangNhap ft = new frmDangNhap();
            ft.Show();
            this.Hide();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            frmDocGia ft = new frmDocGia();
            ft.Show();
            this.Hide();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            frmMuon g = new frmMuon();
            g.Show();
            this.Hide();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            frmTraSach gt = new frmTraSach();
            gt.Show();
            this.Hide();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            frmDauSach_QL gt = new frmDauSach_QL();
            gt.Show();
            this.Hide();
        }
    }
}
