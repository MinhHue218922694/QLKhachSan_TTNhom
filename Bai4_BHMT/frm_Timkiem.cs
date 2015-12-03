using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBMT_TTNhom.BUS;
using QLBMT_TTNhom.VO;
using System.Data.SqlClient;

namespace QLBMT_TTNhom
{
    public partial class frm_Timkiem : Form
    {
        public frm_Timkiem()
        {
            InitializeComponent();
        }
        NhanVien_Bus nvb = new NhanVien_Bus();
        SanPham_Bus spb = new SanPham_Bus();
        private void frm_Timkiem_Load(object sender, EventArgs e)
        {
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if(rdNV.Checked)
            {
                dtgTimKiem.DataSource = nvb.TimKiemTen(txtTimKiem.Text);
                txtTimKiem.Clear();
                dtgTimKiem.ClearSelection();
            }
             else if(rdMaHag.Checked)
            {
                dtgTimKiem.DataSource = spb.TimKiem_Ma(txtTimKiem.Text);
                txtTimKiem.Clear();
                dtgTimKiem.ClearSelection();
            }
            else if(rdTenHg.Checked)
            {
                dtgTimKiem.DataSource = spb.TimKiem_Ten(txtTimKiem.Text);
                txtTimKiem.Clear();
                dtgTimKiem.ClearSelection();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "")
            {
                btnTim.Enabled = true;
            }
            
        }
    }
}
