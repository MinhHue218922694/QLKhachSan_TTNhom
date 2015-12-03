
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
    public partial class frmSuaNhanVien : Form
    {
        public frmSuaNhanVien()
        {
            InitializeComponent();
        }
        Database db = new Database();



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<SqlParameter> list = new List<SqlParameter>();
                list.Add(new SqlParameter("@MaNV", txtmanv.Text));
                list.Add(new SqlParameter("@HoTen", txthotennhanvien.Text));
                list.Add(new SqlParameter("@NS", namsinh.Value));
                list.Add(new SqlParameter("@GT", radioButton1.Checked));
                list.Add(new SqlParameter("@DiaChi", txtdiachi.Text));
                list.Add(new SqlParameter("@SDT", txtdenthoai.Text));
                list.Add(new SqlParameter("@MaPB", txtmaphongban.Text));
                list.Add(new SqlParameter("@MaCM", txtmachuyenmon.Text));

                db.Execute("update_NHANVIEN", list.ToArray());
                MessageBox.Show("OK");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                List<SqlParameter> list = new List<SqlParameter>();
                list.Add(new SqlParameter("@MaNV", txtmanv.Text));
                db.Execute("delete NHANVIEN", list.ToArray());
                MessageBox.Show("OK");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
