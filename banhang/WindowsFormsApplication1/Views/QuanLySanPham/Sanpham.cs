using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanHang.Controllers;
using System.Data.SqlClient;
using QLBanHang.Models;
using HTDFramework.Data;

namespace QLBanHang.Views
{
    public partial class Sanpham : UserControl
    {
        SanPhamCollection lstSanpham;
        LoaiSanPhamCollection lstLoaisanpham;
        NhacungcapCollection lstNhacungcap;
        public void LoadProduct()
        {
            lstSanpham = new SanPhamCollection();
            lstLoaisanpham = new LoaiSanPhamCollection();
            lstNhacungcap = new NhacungcapCollection();
            GridView_Sanpham.Refresh();
            GridView_Sanpham.AutoGenerateColumns = false;
            GridView_Sanpham.DataSource = lstSanpham.Items;
        }
        private void Search()
        {
            string Lsp = (comboBox1.SelectedItem==null||comboBox1.SelectedItem.ToString().Equals("All"))?"":comboBox1.SelectedItem.ToString();
            string Ncc = (comboBox2.SelectedItem == null || comboBox2.SelectedItem.ToString().Equals("All")) ? "" : comboBox2.SelectedItem.ToString();
            List<Models.SanPham> lst = lstSanpham.Search(textBox1.Text,Lsp,Ncc);
            if (lst.Count > 0)
            {
                GridView_Sanpham.DataSource = lst;
            }
            else
            {
                MessageBox.Show("Danh sách trống");
            }
        }
        public void RefreshInfo()
        {
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            textBox2.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }
        private void LoadInfo()
        {
            if (GridView_Sanpham.CurrentRow != null)
            {
                int SanphamID;
                int.TryParse(GridView_Sanpham.CurrentRow.Cells[0].Value.ToString(), out SanphamID);
                if (SanphamID > 0)
                {
                    Models.SanPham sp = lstSanpham.Items.Find(x => x.SanphamID == SanphamID);
                    comboBox3.SelectedIndex = comboBox3.Items.IndexOf(sp.Tenloaisanpham);
                    comboBox4.SelectedIndex = comboBox4.Items.IndexOf(sp.Tennhacungcap);
                    textBox4.Text = sp.Tensanpham;
                    textBox6.Text = sp.Donvitinh;
                    textBox7.Text = sp.Giaban.ToString();
                    textBox8.Text = sp.Soluong.ToString();
                    textBox2.Text = sp.SanphamID.ToString();
                    textBox8.Enabled = false;
                }
            }
        }
        private bool CheckfullInput()
        {
            if (textBox4.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
            {
                return false;
            }
            else { return true; }
        }
        private Models.SanPham GetData()
        {
            Models.SanPham sp = new Models.SanPham();
            int id;
            if (int.TryParse(textBox2.Text, out id))
            {
                sp.SanphamID = id;
            }
            LoaiSanPham lsp = lstLoaisanpham.Items.Find(x => x.Tenloaisanpham == comboBox3.SelectedItem.ToString());
            Nhacungcap ncc = lstNhacungcap.Items.Find(x => x.Tennhacungcap == comboBox4.SelectedItem.ToString());
            sp.LoaisanphamID = lsp.LoaisanphamID;
            sp.NhacungcapID = ncc.NhacungcapID;
            sp.Tensanpham = textBox4.Text;
            sp.Donvitinh = textBox6.Text;
            sp.Giaban = double.Parse(textBox7.Text);
            sp.Soluong = int.Parse(textBox8.Text);
            return sp;
        }
        public Sanpham()
        {
            InitializeComponent();
            LoadProduct();
            
            lstLoaisanpham.Items.ForEach(x =>
            {
                comboBox3.Items.Add(x.Tenloaisanpham);
                comboBox1.Items.Add(x.Tenloaisanpham);
            });
            lstNhacungcap.Items.ForEach(x =>
            {
                comboBox2.Items.Add(x.Tennhacungcap);
                comboBox4.Items.Add(x.Tennhacungcap);
            });
            comboBox3.SelectedIndex = -1;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }
        private void label31_Click_1(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void label30_Click_1(object sender, EventArgs e)
        {
            textBox8.Enabled = true;
            button2.Visible = true;
            button1.Visible = false;
            button3.Visible = false;
            RefreshInfo();
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckfullInput())
            {
                if (!textBox2.Text.Equals(""))
                {
                    DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn sửa sản phẩm này", "Thông báo", MessageBoxButtons.YesNo);
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        lstSanpham.Update(GetData());
                        LoadProduct();
                        RefreshInfo();
                        button1.Visible = false;
                        button3.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Xin chọn sản phẩm muốn sửa", "Thông báo", MessageBoxButtons.OK);
                }

            }
            else
            {
                MessageBox.Show("Xin điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckfullInput())
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thêm sản phẩm này", "Thông báo", MessageBoxButtons.YesNo);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    lstSanpham.Insert(GetData());
                    LoadProduct();
                    RefreshInfo();
                }

            }
            else
            {
                MessageBox.Show("Xin điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                lstSanpham.Delete(GetData());
                LoadProduct();
                RefreshInfo();
                button1.Visible = false;
                button3.Visible = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void GridView_Sanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int SanphamID;
                int.TryParse(GridView_Sanpham.CurrentRow.Cells[0].Value.ToString(), out SanphamID);
                if (SanphamID > 0)
                {
                    LoadInfo();
                    button1.Visible = true;
                    button3.Visible = true;
                }
                else
                {
                    RefreshInfo();
                    button1.Visible = false;
                    button3.Visible = false;
                }
                button2.Visible = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}