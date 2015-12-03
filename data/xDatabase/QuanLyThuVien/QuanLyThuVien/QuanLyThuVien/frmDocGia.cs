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
    public partial class frmDocGia : Form
    {
        public frmDocGia()
        {
            InitializeComponent();
        }
        Database db = new Database();
        DataTable table = new DataTable();
        private void btThem_Click(object sender, EventArgs e)
        {
            List<SqlParameter> List = new List<SqlParameter>();
            List.Add(new SqlParameter("@DocGiaID", txtID.Text));
            List.Add(new SqlParameter("@TenDocGia", txtTenDG.Text));
            List.Add(new SqlParameter("@NgaySinh", dtpNs.Value));
            List.Add(new SqlParameter("@DiaChi", txtDC.Text));
            db.Execute("ThemDocGia", List.ToArray());

            LoadData();

        }

        private void btSua_Click(object sender, EventArgs e)
        {

            List<SqlParameter> List = new List<SqlParameter>();
            List.Add(new SqlParameter("@DocGiaID", txtID.Text));
            List.Add(new SqlParameter("@TenDocGia", txtTenDG.Text));
            List.Add(new SqlParameter("@NgaySinh", dtpNs.Value));
            List.Add(new SqlParameter("@DiaChi", txtDC.Text));
            db.Execute("SuaDocGia", List.ToArray());


            LoadData();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            List<SqlParameter> List = new List<SqlParameter>();
            List.Add(new SqlParameter("@DocGiaID", txtID.Text));
            db.Execute("XoaDocGia", List.ToArray());
            LoadData();      //load lai du lieu
        }

        private void frmDocGia_Load(object sender, EventArgs e)
        {
            LoadData();      //load khi open
        }


        private void LoadData()   //lay du lieu vao dtgview
        {
            table = db.GetTable("select *  from DocGia");
            dtgView.DataSource = table;
        }

        private void txtTK_TextChanged(object sender, EventArgs e)   //tim kiem theo ten
        {
            DataView view = table.DefaultView;
            view.RowFilter = "TenDocGia like '%" + txtTK.Text.Trim() + "%'";
            dtgView.DataSource = view;
        }

        private void dtgView_CellClick(object sender, DataGridViewCellEventArgs e)  //hien thi du lieu theo cell click
        {
            int i = e.RowIndex;

            txtID.Text = dtgView.Rows[i].Cells["DocGiaID"].Value.ToString();
            txtDC.Text = dtgView.Rows[i].Cells["DiaChi"].Value.ToString();
            txtTenDG.Text = dtgView.Rows[i].Cells["TenDocGia"].Value.ToString();
            string s = dtgView.Rows[i].Cells["NgaySinh"].Value.ToString();
            if (s.Length > 0)
                dtpNs.Value = DateTime.Parse(s);


        }

    }
}
