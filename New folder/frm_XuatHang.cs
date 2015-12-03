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
    public partial class frm_XuatHang : Form
    {
        public frm_XuatHang()
        {
            InitializeComponent();
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            if (dtgXuatHang.Rows.Count > 0)
            {
                dtgXuatHang.Rows[0].Selected = true;
            }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            if (dtgXuatHang.Rows.Count > 0)
            {
                dtgXuatHang.Rows[dtgXuatHang.Rows.Count - 1].Selected = true;
            }
        }

        private void btnTien_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (dtgXuatHang.Rows.Count > 0)
            {
                for (int i = 0; i < dtgXuatHang.Rows.Count; i++)
                {
                    if (dtgXuatHang.Rows[i].Selected == true)
                    {
                        k = i + 1;
                        break;
                    }
                }
                if (dtgXuatHang.Rows[dtgXuatHang.Rows.Count - 1].Selected == false)
                    dtgXuatHang.Rows[k].Selected = true;
            }
        }

        private void btnLui_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (dtgXuatHang.Rows.Count > 0)
            {
                for (int i = 1; i < dtgXuatHang.Rows.Count; i++)
                {
                    if (dtgXuatHang.Rows[i].Selected == true)
                    {
                        k = i - 1;
                        break;
                    }
                }
                dtgXuatHang.Rows[k].Selected = true;
            }
        }
    }
}
