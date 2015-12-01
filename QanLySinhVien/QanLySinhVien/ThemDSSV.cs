using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QanLySinhVien
{
    public partial class ThemDSSV : Form
    {
        public ThemDSSV()
        {
            InitializeComponent();
        }

        SinhVien sv;
        DSSinhVien dsSV1 = new DSSinhVien();
        List<SinhVien> lst = new List<SinhVien>();

        public ThemDSSV(DSSinhVien dsSV)
        {
            dsSV1 = dsSV;
            InitializeComponent();
            dsSV.Insert(lst);
        }
        public void KhoiTao()
        {
            txtHoTen.Text = txtQueQuan.Text = txtGT.Text = txtDV.Text = txtCMND.Text = "";
            txtDiem.Text = "0";
            dateTimePickerSV.ResetText();
        }
        public void LayGT()
        {
            sv = new SinhVien();
            try
            {
                string Masv = "";
                Masv = dsSV1.SinhMaSV();
                sv = new SinhVien(Masv, txtHoTen.Text, txtGT.Text, dateTimePickerSV.Text, txtQueQuan.Text, txtDV.Text, txtCMND.Text, txtDiem.Text);
            }
            catch { }
        }
        private void btnNhapTiep_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == null)
            {
                MessageBox.Show("Bạn Cần Nhập Thông Tin Sinh Viên Này.");
                return;
            }
            LayGT();
            lst.Add(sv);
            KhoiTao();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            LayGT();
            lst.Add(sv);
            dsSV1.Insert(lst);
            this.Close();
        }

        private void ThemDSSV_Load(object sender, EventArgs e)
        {
            KhoiTao();
        }
    }
}
