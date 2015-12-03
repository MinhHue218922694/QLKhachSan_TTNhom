using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyKho;

namespace QuanLyKho
{
    public partial class frmtimkiem : Form
    {
        public frmtimkiem()
        {
            InitializeComponent();
            dataGridView1.DataSource = db.GetTable("select * from HANGHOA");
        }
        Database db = new Database();
        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.GetTable("HANGHOA_TIMKIEM", new SqlParameter("@MAHANGHOA", txttimkiem.Text));
        }
    }
}
