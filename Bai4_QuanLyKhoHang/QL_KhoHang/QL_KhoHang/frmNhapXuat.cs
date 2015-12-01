using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KhoHang
{
    public partial class frmNhapXuat : Form
    {
        public frmNhapXuat()
        {
            InitializeComponent();
        }


        private void frmNhapXuat_Load(object sender, EventArgs e)
        {

        }

        private void btnThemPN_Click(object sender, EventArgs e)
        {
            frmThemPN frm = new frmThemPN();
            frm.Show();
        }

    }
}
