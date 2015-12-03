using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sieuthi
{
    public partial class ThongKeNhapXuat : Form
    {
        public ThongKeNhapXuat()
        {
            InitializeComponent();
        }
        Database db = new Database();
        DataTable table;
        DataView view;
        private void ThongKeNhapXuat_Load(object sender, EventArgs e)
        {
            table = db.GetTable("select * from vThongKeNhapXuat");
            dataGridView1.DataSource = table;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            view = table.DefaultView;
            string s = "MaMH like N%'" + textBox1.Text + "'% or TenMH like N%'" + textBox1.Text + "'%";
            view.RowFilter = s;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = view;
        }


    }
}
