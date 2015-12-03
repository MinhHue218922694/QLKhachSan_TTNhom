using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HTDFramework.Data;
using QLBanHang.Controllers;
using System.Data.SqlClient;

namespace QLBanHang.Views.ViewControl
{
    public partial class Khachhang : UserControl
    {
        DataManager<Models.Khachhang> dm = new DataManager<Models.Khachhang>();
        List<Models.Khachhang> lstKhachhang;
        private void LoadData()
        {
            lstKhachhang = dm.GetAllData();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = lstKhachhang;
        }
        private void ViewData()
        {
            if (dataGridView1.CurrentRow != null)
            {
                int KhachhangID;
                int.TryParse(dataGridView1.CurrentRow.Cells[0].Value.ToString(),out KhachhangID);
                Models.Khachhang kh = lstKhachhang.Find(x => x.KhachhangID == KhachhangID);
                if (KhachhangID > 0)
                {
                    textBox2.Text = kh.Tenkhachhang;
                    dateTimePicker1.Text = kh.Ngaysinh.ToShortDateString();
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    if (kh.Gioitinh) { radioButton1.Checked = true; } else { radioButton2.Checked = true; }
                    maskedTextBox1.Text = kh.Sodienthoai;
                    textBox6.Text = kh.Diachi;
                    textBox7.Text = kh.KhachhangID.ToString();
                    button2.Enabled = false;
                    button3.Enabled = true;
                    button4.Enabled = true;
                }
            }
        }
        private Models.Khachhang GetData()
        {
            Models.Khachhang kh = new Models.Khachhang();
            kh.Tenkhachhang = textBox2.Text;
            kh.Ngaysinh = DateTime.Parse(dateTimePicker1.Text);
            kh.Sodienthoai = maskedTextBox1.Text;
            kh.Diachi = textBox6.Text;
            if (textBox7.Text != "")
            {
                kh.KhachhangID = int.Parse(textBox7.Text);
            }
            if (radioButton1.Checked==true)
            {
                kh.Gioitinh = true;
            }
            else { kh.Gioitinh = false; }
            return kh;
        }
        private void SearchData()
        {
            dataGridView1.DataSource = DataAccess.ViewForGridView("Khachhang_Search", new SqlParameter("@COntent", textBox1.Text));
        }
        private void RefreshData()
        {
            textBox2.Text ="";
            dateTimePicker1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            maskedTextBox1.Clear();
            textBox6.Text ="";
            textBox7.Text ="";
            button2.Enabled = false;
            button3.Enabled=false;
            button4.Enabled = false;
        }
        public Khachhang()
        {
            InitializeComponent();
            LoadData();
        }
        private void label3_Click(object sender, EventArgs e)
        {
            
        }
        private void label31_Click(object sender, EventArgs e)
        {
            LoadData();
            RefreshData();
            label31.BackColor = Color.White;
            label30.BackColor = Color.FromArgb(192, 255, 192);
        }
        private void label30_Click(object sender, EventArgs e)
        {
            RefreshData();
            button2.Enabled = true;
            label30.BackColor = Color.White;
            label31.BackColor = Color.FromArgb(192, 255, 192);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                ViewData();
                button3.Enabled = true;
                button4.Enabled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn thêm khách hàng này", "Thông báo", MessageBoxButtons.YesNo);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    dm.Insert(GetData());
                    LoadData();
                    RefreshData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền thông tin!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!textBox7.Text.Equals(""))
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn sửa khách hàng này!","Thông báo",MessageBoxButtons.YesNo);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    dm.Update(GetData());
                    LoadData();
                    RefreshData();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!textBox7.Text.Equals(""))
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này!", "Thông báo", MessageBoxButtons.YesNo);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    dm.DeleteByID(int.Parse(textBox7.Text));
                    LoadData();
                    RefreshData();
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshData();
            SearchData();
        }
    }
}
