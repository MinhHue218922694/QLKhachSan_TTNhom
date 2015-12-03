using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyNhanSu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }
        Database db = new Database();
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.GetTable("TK_TenNhanVien", new SqlParameter("@Hoten", txtSearch.Text));
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThemNhanVien fThem = new frmThemNhanVien();
            fThem.ShowDialog();
            ReLoad();
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSuaNhanVien fSua = new frmSuaNhanVien();
            fSua.ShowDialog();
            ReLoad();
        }

  

    

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.GetTable("select * from NHANVIEN");
        }

        private void ReLoad()
        {
            if (txtSearch.Text.Length > 0)
                txtSearch.Text = "";
            else dataGridView1.DataSource = db.GetTable("select * from NHANVIEN");
        }

        private void xóaToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help f = new Help();
            f.ShowDialog();
        }

        private void thânNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChuyenMon f = new frmChuyenMon();
            f.ShowDialog();
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhongBan f = new frmPhongBan();
            f.ShowDialog();
        }

  
    }
}
