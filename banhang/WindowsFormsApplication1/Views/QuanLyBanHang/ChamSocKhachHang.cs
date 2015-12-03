using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanHang.Views
{
    public partial class ChamSocKhachHang : UserControl
    {
        public ChamSocKhachHang()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox_TenKH.ReadOnly = textBox_SDT.ReadOnly = 
                textBox_GioiTinh.ReadOnly = textBox_Diachi.ReadOnly = false;
            textBox_NgaySinh.Visible = false;
            dateTimePicker_NgaySinh.Visible = true;
            button10.Visible = button11.Visible = button12.Visible = false;
            button1.Visible = button2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox_TenKH.ReadOnly = textBox_SDT.ReadOnly =
                textBox_GioiTinh.ReadOnly = textBox_Diachi.ReadOnly = true;
            textBox_NgaySinh.Visible = true;
            dateTimePicker_NgaySinh.Visible = false;
            button10.Visible = button11.Visible = button12.Visible = true;
            button1.Visible = button2.Visible = false;
            textBox_NgaySinh.Text = dateTimePicker_NgaySinh.Value.ToShortDateString();
        }
    }
}
