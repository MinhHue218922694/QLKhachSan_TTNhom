using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiNhanSu
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void HoSo_Click(object sender, EventArgs e)
        {
            Form frm1 = new frmMain();
            frm1.Show();
            Hide();
        }

        private void ChiDan_Click(object sender, EventArgs e)
        {
            frmChiDan cd = new frmChiDan();
            cd.Show();
            Hide();
        }
    }
}
