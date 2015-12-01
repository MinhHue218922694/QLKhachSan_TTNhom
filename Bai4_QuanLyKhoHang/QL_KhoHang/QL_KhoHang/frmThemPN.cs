using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;

namespace QL_KhoHang
{
    public partial class frmThemPN : Form
    {
        public frmThemPN()
        {
            InitializeComponent();
        }

        HangHoa hh = new HangHoa();
        private void frmThemPN_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        public void HienThi()
        {
            dgvSP.DataSource = hh.ShowHangHoa("");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenhh = txtTenSP.Text;
            int soluong = Convert.ToInt32(numericUpDown2.Value.ToString());
            long gianhap = long.Parse(numericUpDown3.Value.ToString());
            long giaxuat = long.Parse(numericUpDown1.Value.ToString());
            string nsx = txtNSX.Text;
            string thongtin = txtMoTa.Text;
            string ma = hh.InsertHangHoa(tenhh, soluong, gianhap, giaxuat, nsx, thongtin);
            MessageBox.Show("Thêm dữ liệu thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            HienThi();
            if (dgvSP.SelectedRows.Count > 0)
            {
                dgvSPN.Rows.AddRange(new DataGridViewRow());
                dgvSPN.Rows[dgvSPN.RowCount - 2].Cells[1].Value = ma;
                dgvSPN.Rows[dgvSPN.RowCount - 2].Cells[2].Value = soluong;
                dgvSPN.Rows[dgvSPN.RowCount - 2].Cells[3].Value = gianhap;
                dgvSPN.Rows[dgvSPN.RowCount - 2].Cells[4].Value = soluong * gianhap;
            }
            
        }
    }
}
