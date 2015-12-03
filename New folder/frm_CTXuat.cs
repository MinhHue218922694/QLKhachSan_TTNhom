using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBMT_TTNhom
{
    public partial class frm_CTXuat : Form
    {
        public frm_CTXuat()
        {
            InitializeComponent();
        }

        private void frm_CTXuat_Load(object sender, EventArgs e)
        {

        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            if (dtgCT_Xuat.Rows.Count > 0)
            {
                dtgCT_Xuat.Rows[0].Selected = true;
            }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            if (dtgCT_Xuat.Rows.Count > 0)
            {
                dtgCT_Xuat.Rows[dtgCT_Xuat.Rows.Count - 1].Selected = true;
            }
        }

        private void btnTien_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (dtgCT_Xuat.Rows.Count > 0)
            {
                for (int i = 0; i < dtgCT_Xuat.Rows.Count; i++)
                {
                    if (dtgCT_Xuat.Rows[i].Selected == true)
                    {
                        k = i + 1;
                        break;
                    }
                }
                if (dtgCT_Xuat.Rows[dtgCT_Xuat.Rows.Count - 1].Selected == false)
                    dtgCT_Xuat.Rows[k].Selected = true;
            }
        }

        private void btnLui_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (dtgCT_Xuat.Rows.Count > 0)
            {
                for (int i = 1; i < dtgCT_Xuat.Rows.Count; i++)
                {
                    if (dtgCT_Xuat.Rows[i].Selected == true)
                    {
                        k = i - 1;
                        break;
                    }
                }
                dtgCT_Xuat.Rows[k].Selected = true;
            }
        }
    }
}
