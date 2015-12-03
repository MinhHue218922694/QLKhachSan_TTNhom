using Base.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Base
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MyConnection myConn = new MyConnection("server = NANA; database = ThuVien; Integrated Security = SSPI;");

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = myConn.ExecuteQuery(txtString.Text.Trim());
        }
    }
}
