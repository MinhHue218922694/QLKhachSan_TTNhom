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
    public partial class frmMuon : Form
    {
        public frmMuon()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool check = false;
                SqlParameter pCheck = new SqlParameter("@check",check);
                pCheck.Direction = ParameterDirection.Output;

                List<SqlParameter> list = new List<SqlParameter>();
                list.Add(new SqlParameter("@SachID", txtMaSach.Text));
                list.Add(new SqlParameter("@DocGiaID", txtMaThe.Text));
                string s = DateTime.Today.Date.ToShortDateString();
                list.Add(new SqlParameter("@NgayMuon", DateTime.Today));
                list.Add(new SqlParameter("@HanTra", DateTime.Today.AddDays(20)));
                list.Add(pCheck);
                db.Execute("MuonSach", list.ToArray());

                check = bool.Parse(pCheck.Value.ToString());
                if (check == true)
                    MessageBox.Show("OK");
                else
                    MessageBox.Show("Hết sách!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearchSach_TextChanged(object sender, EventArgs e)
        {
            DataView view = tableSach.DefaultView;
            view.RowFilter = "TenSach like '%" + txtSearchSach.Text + "%' or SachID like '%" + txtSearchSach.Text + "%'";
            dgvSach.DataSource = view;
        }

        private void txtSearchDG_TextChanged(object sender, EventArgs e)
        {
            DataView view = tableDocGia.DefaultView;
            view.RowFilter = "TenDocGia like '%" + txtSearchDG.Text + "%' or DocGiaID like '%" + txtSearchDG.Text + "%'";
            dgvDocGia.DataSource = view;
        }

        DataTable tableSach = new DataTable();
        DataTable tableDocGia = new DataTable();
        Database db = new Database();
        private void frmMuon_Load(object sender, EventArgs e)
        {

            ReLoad();
            dgvDocGia.DataSource = tableDocGia;
            dgvSach.DataSource = tableSach;
        }

        private void ReLoad()
        {
            tableSach = db.GetTable("select * from Sach where SoLuong > 0");
            tableDocGia = db.GetTable("select * from DocGia");
        }



        private void ClickSach(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMaSach.Text = dgvSach.Rows[i].Cells[0].Value.ToString();
            txtTenSach.Text = dgvSach.Rows[i].Cells[1].Value.ToString();
        }

        private void ClickDocGia(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMaThe.Text = dgvDocGia.Rows[i].Cells[0].Value.ToString();
            txtTenDocGia.Text = dgvDocGia.Rows[i].Cells[1].Value.ToString();
        }

        private void ClickSach(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = e.RowIndex;
            txtMaSach.Text = dgvSach.Rows[i].Cells[0].Value.ToString();
            txtTenSach.Text = dgvSach.Rows[i].Cells[1].Value.ToString();
        }

        private void dgvDocGia_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = e.RowIndex;
            txtMaThe.Text = dgvDocGia.Rows[i].Cells[0].Value.ToString();
            txtTenDocGia.Text = dgvDocGia.Rows[i].Cells[1].Value.ToString();
        }
    }
}
