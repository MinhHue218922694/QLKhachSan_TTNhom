using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QUANLYQN.Data;
using QUANLYQN.Entities ;

namespace QUANLYQN
{
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {


        }

        private void mnuTheoDoiQuanNhan_Click(object sender, EventArgs e)
        {
            VoidTurnoffMDIform();
            QUANLYQN.Forms.Phan_he.Theo_doi_thong_tin.frmTheoDoiThongTin frm = new QUANLYQN.Forms.Phan_he.Theo_doi_thong_tin.frmTheoDoiThongTin();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();

        }


        void VoidTurnoffMDIform()
        {
            foreach (Form  item in this.MdiChildren )
            {
                if (item != null)
                    item.Close();  
            }
        }

        private void mnuNhapThongTinQN_Click(object sender, EventArgs e)
        {
            VoidTurnoffMDIform();
            QUANLYQN.Forms.Phan_he.Nhap_Thong_Tin.frmNhapthongtin frm = new QUANLYQN.Forms.Phan_he.Nhap_Thong_Tin.frmNhapthongtin();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VoidTurnoffMDIform();
            QUANLYQN.Forms.Phan_he.Nhap_Thong_Tin.frmTimkiem frm = new QUANLYQN.Forms.Phan_he.Nhap_Thong_Tin.frmTimkiem();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuNhapThongTin_Click(object sender, EventArgs e)
        {
            VoidTurnoffMDIform();

        }
    }
}
