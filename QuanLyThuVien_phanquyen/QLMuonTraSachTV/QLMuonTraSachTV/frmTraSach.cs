using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KETNOI_MUONTRA;
using DAL;
namespace QLMuonTraSachTV
{
    public partial class frmTraSach : Form
    {
        public frmTraSach()
        {
            InitializeComponent();
        }
        TraSach ds = new TraSach();
        TimKiem tk = new TimKiem();
        private void frmTraSach_Load(object sender, EventArgs e)
        {
            dtGidTraS.DataSource = ds.HienThi_SachMuon();
        }       

        private void txtTk_Tra_TextChanged(object sender, EventArgs e)
        {
            dtGidTraS.DataSource = tk.TK_MaSach_Tra(txtTk_Tra.Text);
        }

        private void txtTK_SOTHE_TextChanged(object sender, EventArgs e)
        {
            dtGidTraS.DataSource = tk.sp_TK_MaDG(txtTK_SOTHE.Text);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            frmMenu nb = new frmMenu();
            nb.Show();
            this.Hide();
        }



    }
}
