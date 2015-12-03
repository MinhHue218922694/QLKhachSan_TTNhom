using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho
{
    public partial class frmchinh : Form
    {
        public frmchinh()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmNhapKho frmnhap = new frmNhapKho();
            frmnhap.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmXuatKho frmxuat = new frmXuatKho();
            frmxuat.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmtimkiem frmtim = new frmtimkiem();
            frmtim.Show();
        }
    }
}
