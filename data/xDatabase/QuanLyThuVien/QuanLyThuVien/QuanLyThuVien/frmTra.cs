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

namespace QuanLyThuVien
{
    public partial class frmTra : Form
    {
        public frmTra()
        {
            InitializeComponent();
        }
        Database db = new Database();

        DataView vDocGia;
        DataView vSach;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string key = textBox1.Text;
            vDocGia.RowFilter = "DocGiaID like '%" + key + "%' or TenDocGia like '%"+key+"%'";

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string key = textBox2.Text;
            vSach.RowFilter = "SachID like '%" + key + "%' or TenSach like '%" + key + "%'";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gvSachMuon.SelectedCells.Count > 0)
            {
                var c = gvSachMuon.SelectedCells[0];
                var r = gvSachMuon.Rows[c.RowIndex];

                List<SqlParameter> list = new List<SqlParameter>();
                list.Add(new SqlParameter("@DocGiaID", r.Cells["DocGiaids"].Value));
                list.Add(new SqlParameter("@SachID", r.Cells["SachID"].Value));
                list.Add(new SqlParameter("@NgayTra", DateTime.Now.Date));
                db.Execute("TraSach", list.ToArray());
                MessageBox.Show("OK!");

                vSach = db.GetTable("select * from ListSachMuon where DocGiaID = '" + r.Cells["DocGiaids"].Value.ToString() + "'").DefaultView;
                gvSachMuon.DataSource = vSach;
            }
            else
            {
                MessageBox.Show("Chon sach muon tra!");
            }

        }

        private void frmTra_Load(object sender, EventArgs e)
        {
            //Load danh sách các độc giả
            vDocGia = db.GetTable("select * from DocGia").DefaultView;
            gvDocGia.DataSource = vDocGia;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = gvDocGia.Rows[e.RowIndex].Cells["DocGiaID"].Value.ToString();
            vSach = db.GetTable("select * from ListSachMuon where DocGiaID = '" + id + "'").DefaultView;
            gvSachMuon.DataSource = vSach;
        }
    }
}
