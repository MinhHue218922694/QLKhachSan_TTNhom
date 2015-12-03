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
    public partial class frmChuyenMon : Form
    {
        public frmChuyenMon()
        {
            InitializeComponent();
        }

        Database db = new Database();
        private void frmChuyenMon_Load(object sender, EventArgs e)
        {
            reload();
        }

        public void reload()
        {
            dataGridView1.DataSource = db.GetTable("select * from ChuyenMon");
            txtMaCM.Text = "";
            TenCM.Text = "";
            BangCap.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@MaCM", txtMaCM.Text));
            list.Add(new SqlParameter("@TenCM", TenCM.Text));
            list.Add(new SqlParameter("@BangCap", BangCap.Text));
            db.Execute("insert_ChuyenMon", list.ToArray());
            reload();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@MaCM", txtMaCM.Text));
            list.Add(new SqlParameter("@TenCM", TenCM.Text));
            list.Add(new SqlParameter("@BangCap", BangCap.Text));
            db.Execute("update ChuyenMon", list.ToArray());
            reload();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@MaCM", txtMaCM.Text));
            db.Execute("delete ChuyenMon", list.ToArray());
            reload();
        }
    }
}
