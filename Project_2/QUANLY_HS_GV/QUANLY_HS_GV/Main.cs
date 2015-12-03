using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace QUANLY_HS_GV
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnhuongdan_Click(object sender, EventArgs e)
        {
            huongdan hd = new huongdan();
            hd.ShowDialog();
        }

        private void btnhocsinh_Click(object sender, EventArgs e)
        {
            HocSinh hs = new HocSinh();
            hs.ShowDialog();
        }

        private void btngiaovien_Click(object sender, EventArgs e)
        {
            GiaoVien gv = new GiaoVien();
            gv.ShowDialog();
        }
        }
}
