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
    public partial class frmXoaNhanVien : Form
    {
        public frmXoaNhanVien()
        {
            InitializeComponent();
        }

        Database db = new Database();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@MaNV", txtmanhanvien.Text));
            db.Execute("delete NHANVIEN", list.ToArray());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@MaPB", txtmaphongban.Text));
            db.Execute("DELETE_PHONGBAN", list.ToArray());
        }
    }
}
