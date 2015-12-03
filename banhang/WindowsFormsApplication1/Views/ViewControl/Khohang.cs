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
    public partial class Khohang : UserControl
    {
        DataManager<Models.Kho> dm = new DataManager<Models.Kho>();
        List<Models.Kho> lstKho;
        SanPhamCollection lstSanpham;
        public void LoadDataKho()
        {
            lstKho = dm.GetAllData();
            dataGridView1.DataSource = lstKho;
        }
        public void ViewDataKho()
        {
            if (dataGridView1.CurrentRow != null)
            {
                int KhoID;
                int.TryParse(dataGridView1.CurrentRow.Cells[0].Value.ToString(), out KhoID);
                Models.Kho k = lstKho.Find(x => x.KhoID == KhoID);
                if (KhoID > 0)
                {
                    textBox1.Text = k.KhoID.ToString();
                    textBox2.Text = k.Tenkho;
                    lstSanpham=new SanPhamCollection(KhoID);
                    GridView_SanPham.DataSource = lstSanpham.Items;
                }
            }
        }
        private Models.Kho GetDataKho()
        {
            Models.Kho k = new Models.Kho();
            if (textBox1.Text != "")
            {
                k.KhoID = int.Parse(textBox1.Text);
            }
            k.Tenkho = textBox2.Text;
            return k;
        }
        private void SearchDataKho()
        {
            dataGridView1.DataSource = DataAccess.ViewForGridView("Kho_Search", new SqlParameter("@Content", textBox3.Text));
        }
        private void RefreshData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            button3.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
        }
        public Khohang()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            GridView_SanPham.AutoGenerateColumns = false;
            LoadDataKho();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                ViewDataKho();
                button5.Enabled = true;
                button6.Enabled = true;
                button4.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshData();
            SearchDataKho();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn thêm kho này!", "Thông báo", MessageBoxButtons.YesNo);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    dm.Insert(GetDataKho());
                    RefreshData();
                    LoadDataKho();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền thông tin!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn sửa kho này!", "Thông báo", MessageBoxButtons.YesNo);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    dm.Update(GetDataKho());
                    RefreshData();
                    LoadDataKho();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền thông tin!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa kho này!", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                dm.DeleteByID(GetDataKho().KhoID);
                RefreshData();
                LoadDataKho();
            }
        }

        private void GridView_SanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                button4.Enabled = true;
                button2.Enabled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string SanphamID;
                SanphamID = (GridView_SanPham.CurrentRow != null) ? GridView_SanPham.CurrentRow.Cells[0].Value.ToString() : "0";
                QuanLySanPham.Nhapkho nk = new QuanLySanPham.Nhapkho(int.Parse(textBox1.Text),int.Parse(SanphamID));
                nk.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lựa chọn kho");
            }
            
        }

        private void label31_Click(object sender, EventArgs e)
        {
            RefreshData();
            LoadDataKho();
            label31.BackColor = Color.White;
            label30.BackColor = Color.FromArgb(192, 255, 192);
        }

        private void label30_Click(object sender, EventArgs e)
        {
            RefreshData();
            button3.Enabled = true;
            label30.BackColor = Color.White;
            label31.BackColor = Color.FromArgb(192, 255, 192);
        }

    }
}
