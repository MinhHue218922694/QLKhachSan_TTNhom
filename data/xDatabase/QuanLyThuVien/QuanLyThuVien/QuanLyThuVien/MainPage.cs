using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class MainPage : Form
    {   
        public MainPage()
        {
            InitializeComponent();
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSach fSach = new frmSach();
            fSach.ShowDialog();
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDocGia fDocGia = new frmDocGia();
            fDocGia.ShowDialog();
        }

        private void mượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMuon f = new frmMuon();
            f.ShowDialog();
        }

        private void trảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTra f = new frmTra();
            f.ShowDialog();
        }
    }
}
