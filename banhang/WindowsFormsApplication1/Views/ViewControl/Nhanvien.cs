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
using QLBanHang.Models;
using QLBanHang.Controllers;
using System.Data.SqlClient;

namespace QLBanHang.Views.ViewControl
{
    public partial class Nhanvien : UserControl
    {
        DataManager<Models.Nhanvien> dm=new DataManager<Models.Nhanvien>();
        DataManager<Models.Bophan> dm1 = new DataManager<Bophan>();
        List<Models.Nhanvien> lstNhanvien;
        List<Models.Bophan> lstBophan;
        private void LoadData()
        {
            lstNhanvien = dm.GetAllData();
            lstBophan = dm1.GetAllData();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = lstNhanvien;
            comboBox1.Items.Clear();
            lstBophan.ForEach(x => { comboBox1.Items.Add(x.Tenbophan); });
            comboBox1.SelectedIndex = -1;
        }
        private void ViewData()
        {
            if (dataGridView1.CurrentRow != null)
            {
                int NhanvienID;
                int.TryParse(dataGridView1.CurrentRow.Cells[0].Value.ToString(), out NhanvienID);
                Models.Nhanvien nv = lstNhanvien.Find(x => x.NhanvienID == NhanvienID);
                if (NhanvienID > 0)
                {
                    textBox2.Text = nv.Hoten;
                    dateTimePicker1.Text = nv.Ngaysinh.ToShortDateString();
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    if (nv.Gioitinh) { radioButton1.Checked = true; } else { radioButton2.Checked = true; }
                    textBox6.Text = nv.Diachi;
                    textBox7.Text = nv.NhanvienID.ToString();
                    textBox3.Text = nv.Hesoluong.ToString();
                    comboBox1.SelectedIndex = comboBox1.Items.IndexOf(nv.Tenbophan);
                    button2.Enabled = false;
                    button3.Enabled = true;
                    button4.Enabled = true;
                }
            }
        }
        private Models.Nhanvien GetData()
        {
            Models.Nhanvien nv = new Models.Nhanvien();
            nv.Hoten = textBox2.Text;
            nv.Ngaysinh = DateTime.Parse(dateTimePicker1.Text);
            nv.Diachi = textBox6.Text;
            if (textBox7.Text != "")
            {
                nv.NhanvienID = int.Parse(textBox7.Text);
            }
            if (radioButton1.Checked == true)
            {
                nv.Gioitinh = true;
            }
            else { nv.Gioitinh = false; }
            nv.Hesoluong = float.Parse(textBox3.Text);
            Bophan bp=lstBophan.Find(x => x.Tenbophan == comboBox1.SelectedItem.ToString());
            nv.BophanID = bp.BophanID;
            nv.Tenbophan = bp.Tenbophan;
            nv.Password = "";
            return nv;
        }
        private void SearchData()
        {
            dataGridView1.DataSource = DataAccess.ViewForGridView("Nhanvien_Search", new SqlParameter("@COntent", textBox1.Text));
        }
        private void RefreshData()
        {
            textBox2.Text = "";
            dateTimePicker1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox6.Text = "";
            textBox7.Text = "";
            textBox3.Text = "";
            comboBox1.SelectedIndex = -1;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }
        public Nhanvien()
        {
            InitializeComponent();
            LoadData();
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn thêm nhân viên này", "Thông báo", MessageBoxButtons.YesNo);
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
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn sửa nhân viên này!", "Thông báo", MessageBoxButtons.YesNo);
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
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này!", "Thông báo", MessageBoxButtons.YesNo);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    dm.DeleteByID(int.Parse(textBox7.Text));
                    LoadData();
                    RefreshData();
                }
            }
        }
    }
}
