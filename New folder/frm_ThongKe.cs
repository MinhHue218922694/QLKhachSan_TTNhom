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

namespace QLBMT_TTNhom
{
    public partial class frm_ThongKe : Form
    {
        public frm_ThongKe()
        {
            InitializeComponent();
        }
        PhieuNhap_Bus pnb = new PhieuNhap_Bus();
        PhieuXuat_Bus pxb = new PhieuXuat_Bus();
        private void frm_ThongKe_Load(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rdNhap.Checked)
            { 
               dtgHienthi.DataSource=pnb.ThongKe_tiennhap(DateTime.Parse(dateTimePicker1.Value.ToString()));
                dtgHienthi.ClearSelection();
            }
            if(rdXuat.Checked)
            {
                dtgHienthi.DataSource = pxb.Thongke_tienthu(DateTime.Parse(dateTimePicker1.Value.ToString()));
                dtgHienthi.ClearSelection();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (rdNhapSL.Checked)
            {
                dtgHienthi.DataSource = pnb.ThongKespnhap(DateTime.Parse(dateTimePicker2.Value.ToString()));
                dtgHienthi.ClearSelection();
            }
            if (rdXuatSL.Checked)
            {
                dtgHienthi.DataSource = pxb.Thongke_spban(DateTime.Parse(dateTimePicker2.Value.ToString()));
                dtgHienthi.ClearSelection();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            In_Bus xuat=new In_Bus();
            xuat.ExportDataGridViewTo_Excel(dtgHienthi);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            In_Bus xuat = new In_Bus();
            xuat.ExportDataGridViewTo_Excel(dtgHienthi);
        }
    }
}
