using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sieuthi
{
    public partial class nhanvien : Form
    {
        public nhanvien()
        {
            InitializeComponent();
        }

        Database db = new Database();


        private void nhanvien_Load(object sender, EventArgs e)
        {
            Reload();
        }
        public void Reload()
        {
            dataGridView1.DataSource = db.GetTable("select * from NHAN_VIEN");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtTen.Text = dataGridView1.Rows[e.RowIndex].Cells["TenNV"].Value.ToString();
                txtMa.Text = dataGridView1.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();
                txtCMND.Text = dataGridView1.Rows[e.RowIndex].Cells["CMND"].Value.ToString();
                txtDiaChi.Text = dataGridView1.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();

                if (dataGridView1.Rows[e.RowIndex].Cells["NgaySinh"].Value.ToString().Length > 1)
                {
                    txtNS.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells["NgaySinh"].Value.ToString());
                    txtNS.Visible = true;
                }
                else txtNS.Visible = false;
            }
        }

        private void txtSua_Click(object sender, EventArgs e)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@MaNV", txtMa.Text));
            list.Add(new SqlParameter("@TenNV", txtTen.Text));
            list.Add(new SqlParameter("@NgaySinh", txtNS.Value));
            list.Add(new SqlParameter("@GioiTinh", txtGioiTinh.Checked));
            list.Add(new SqlParameter("@CMND", txtCMND.Text));
            list.Add(new SqlParameter("@DiaChi", txtDiaChi.Text));
            db.Execute("Update_NV", list.ToArray());

            Reload();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.Execute("Delete_NV", new SqlParameter("@MaNV", txtMa.Text));
            Reload();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                List<SqlParameter> list = new List<SqlParameter>();
                list.Add(new SqlParameter("@MaNV", txtMa.Text));
                list.Add(new SqlParameter("@TenNV", txtTen.Text));
                list.Add(new SqlParameter("@NgaySinh", txtNS.Value));
                list.Add(new SqlParameter("@GioiTinh", txtGioiTinh.Checked));
                list.Add(new SqlParameter("@CMND", txtCMND.Text));
                list.Add(new SqlParameter("@DiaChi", txtDiaChi.Text));
                db.Execute("InSert_NV", list.ToArray());
                Reload();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
