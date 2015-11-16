using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public SqlConnection conn = new SqlConnection();
        private SqlCommand cmd;
        private SqlDataReader dr;

        public Form1()
        {
            InitializeComponent();
        }

        private void funcconn()
        {
            string sqlDrirectory = @"server=LETRUNG-PC;database=MyDataDemo;integrated security=true";
            conn.ConnectionString = sqlDrirectory;
            conn.Open();
        }
        private void getdata()
        {
            cmd = new SqlCommand("select * from HOCSINH", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var masv = (string)dr["MAHS"];
                var hoten = (string)dr["HOTEN"];
                var ngaysinh = dr["NGAYSINH"];
                var quequan = (string)dr["QUEQUAN"];
                var makhoa = (string)dr["MALOP"];
                dataGridView1.Rows.Add(masv, hoten, ngaysinh.ToString(), quequan, makhoa);
            }
            dr.Close();
            dr.Dispose();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            funcconn();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getdata();
        }

    }
}
