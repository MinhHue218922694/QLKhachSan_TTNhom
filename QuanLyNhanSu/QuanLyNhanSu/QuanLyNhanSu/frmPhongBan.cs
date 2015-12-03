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

namespace QuanLyNhanSu
{
    public partial class frmPhongBan : Form
    {
        public frmPhongBan()
        {
            InitializeComponent();
        }
        Database db = new Database();
        private void button1_Click(object sender, EventArgs e)
        {
            //thêm
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@MaPB", txtMaPB.Text));
            list.Add(new SqlParameter("@TenPB", txtTenPB.Text));
            list.Add(new SqlParameter("@DiaDiem", txtDiaDiem.Text));
            list.Add(new SqlParameter("@SDT", txtSDT.Text));
            list.Add(new SqlParameter("@MaNQL", txtMaNQL.Text));
            db.Execute("InSert_PHONGBAN", list.ToArray());
            reload();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Sửa
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@MaPB", txtMaPB.Text));
            list.Add(new SqlParameter("@TenPB", txtTenPB.Text));
            list.Add(new SqlParameter("@DiaDiem", txtDiaDiem.Text));
            list.Add(new SqlParameter("@SDT", txtSDT.Text));
            list.Add(new SqlParameter("@MaNQL", txtMaNQL.Text));
            db.Execute("UPDATE_PHONGBAN", list.ToArray());
            reload();
        }
        public void reload()
        {
            dataGridView1.DataSource = db.GetTable("select * from PHONGBAN");
            txtMaPB.Text = "";
            txtTenPB.Text = "";
            txtDiaDiem.Text = "";
            txtSDT.Text = "";
            txtMaNQL.Text = "";
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Xóa
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@MaPB", txtMaPB.Text));
            db.Execute("DELETE_PHONGBAN", list.ToArray());
            reload();
        }



        private void frmPhongBan_Load(object sender, EventArgs e)
        {
            reload();
        }
    }
}
