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
    public partial class frmSach : Form
    {
        DataTable table;
        Database db = new Database();
        public frmSach()
        {
            InitializeComponent();
        }



        private void frmSach_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void LoadAllData()
        {
            table = db.GetTable("select * from Sach");
            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            Map(index);
        }

        public void Map(int i)
        {
            txtId.Text = dataGridView1.Rows[i].Cells["SachID"].Value.ToString();
            txtGhiChu.Text = dataGridView1.Rows[i].Cells["ThongTin"].Value.ToString();
            txtSoLuong.Text = dataGridView1.Rows[i].Cells["SoLuong"].Value.ToString();
            txtTacGia.Text = dataGridView1.Rows[i].Cells["TacGia"].Value.ToString();
            txtTenSach.Text = dataGridView1.Rows[i].Cells["TenSach"].Value.ToString();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            DataView v = table.DefaultView;
            v.RowFilter = string.Format("TenSach like '%{0}%'", txtTimKiem.Text.ToLower());
        }

        private void clickThem(object sender, EventArgs e)
        {
            List<SqlParameter> listParams = new List<SqlParameter>();
            listParams.Add(new SqlParameter("@SachID", txtId.Text));
            listParams.Add(new SqlParameter("@TenSach", txtTenSach.Text));
            listParams.Add(new SqlParameter("@TacGia", txtTacGia.Text));
            listParams.Add(new SqlParameter("@SoLuong", int.Parse(txtSoLuong.Text)));
            listParams.Add(new SqlParameter("@ThongTin", txtGhiChu.Text));
            db.Execute("ThemSach", listParams.ToArray());
            LoadAllData();
        }

        private void clickSua(object sender, EventArgs e)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@SachID",txtId.Text));
            list.Add(new SqlParameter("@TenSach",txtTenSach.Text));
            list.Add(new SqlParameter("@TacGia",txtTacGia.Text));
            list.Add(new SqlParameter("@SoLuong",int.Parse(txtSoLuong.Text)));
            list.Add(new SqlParameter("@ThongTin",txtGhiChu.Text));
            db.Execute("SuaSach",list.ToArray());
            LoadAllData();
        }

        private void clickXoa(object sender, EventArgs e)
        {
            SqlParameter p = new SqlParameter("SachID", txtId.Text);
            db.Execute("XoaSach",p);
            MessageBox.Show("OK");
            LoadAllData();
        }
    }
}
