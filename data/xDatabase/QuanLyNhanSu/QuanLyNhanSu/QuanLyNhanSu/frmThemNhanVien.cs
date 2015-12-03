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
    public partial class frmThemNhanVien : Form
    {
        public frmThemNhanVien()
        {
            InitializeComponent();
        }


        Database db = new Database();


        private void txtHoanTat_Click(object sender, EventArgs e)
        {
            try
            {
                List<SqlParameter> list = new List<SqlParameter>();
                list.Add(new SqlParameter("@MaNV", txtMaNV.Text));
                list.Add(new SqlParameter("@HoTen", txtHoTen.Text));
                list.Add(new SqlParameter("@NS", txtNgaySinh.Value));
                list.Add(new SqlParameter("@GT", txtGTNam.Checked));
                list.Add(new SqlParameter("@DiaChi", txtDiaChi.Text));
                list.Add(new SqlParameter("@SDT", txtSDT.Text));
                list.Add(new SqlParameter("@MaPB", txtMaPB.Text));
                list.Add(new SqlParameter("@MaCM", txtMaCM.Text));
                db.Execute("InSert_NHANVIEN", list.ToArray());
                MessageBox.Show("OK");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmThemNhanVien_Load(object sender, EventArgs e)
        {

        }

    }
}
