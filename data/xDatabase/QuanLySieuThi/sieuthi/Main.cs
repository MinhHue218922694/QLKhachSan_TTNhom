using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sieuthi
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NhapHang f = new NhapHang();
            f.ShowDialog();
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nhanvien f = new nhanvien();
            f.ShowDialog();
        }

        private void thốngKêKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HangHoa f = new HangHoa();
            f.ShowDialog();
        }

        private void thốngKêMuaBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeNhapXuat f = new ThongKeNhapXuat();
            f.ShowDialog();

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help f = new Help();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BanHang f = new BanHang();
            f.ShowDialog();
        }
    }
}
