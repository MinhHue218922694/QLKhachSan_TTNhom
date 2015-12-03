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
using QLBanHang.Models;

namespace QLBanHang.Views
{
    public partial class Banhang : UserControl
    {
        SanPham spNow = new SanPham();
        // Status = 1 <=> Từ Gridview add vào box; Status = 2 <=> từ ListView add vào box để cập nhật số lượng
        List<SanPham> lstSanpham;
        List<LoaiSanPham> lstLoaisanpham;
        List<Nhacungcap> lstNhacungcap;
        int status;

        public Banhang()
        {
            InitializeComponent();
            InitData();
        }
        private void InitData()
        {
            dataGridView1.AutoGenerateColumns = false;
            lstSanpham = SanphamController.ViewAll();
            dataGridView1.DataSource = lstSanpham;
            lstLoaisanpham = LoaisanphamController.ViewAll();
            foreach (LoaiSanPham lsp in lstLoaisanpham)
            {
                comboBox1.Items.Add(lsp.Tenloaisanpham);
            }
            lstNhacungcap = NhacungcapController.ViewAll();
            foreach (Nhacungcap ncc in lstNhacungcap)
            {
                comboBox2.Items.Add(ncc.Tennhacungcap);
            }
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }
        private void Viewdata(SanPham sp,int Soluongmua)
        {
            label20.Text = (sp!=null?sp.SanphamID.ToString():"");
            label21.Text = (sp!=null?sp.Tensanpham:"");
            label22.Text = (sp!=null?sp.Tenloaisanpham:"");
            label23.Text = (sp!=null?sp.Tennhacungcap:"");
            numericUpDown2.Value = Soluongmua;
            button4.Enabled = true;
            
        }
        private void AddtoListView(SanPham sp,int Soluongmua)
        {
            foreach (ListViewItem it in listView1.Items)
            {
                if (it.Text.Equals(sp.SanphamID.ToString()))
                {
                    int sl = int.Parse(it.SubItems[2].Text) +Soluongmua;
                    it.SubItems[2].Text = sl.ToString();
                    return;
                }
            }
            ListViewItem item = new ListViewItem();
            item.Text = sp.SanphamID.ToString();
            item.SubItems.Add(sp.Tensanpham);
            item.SubItems.Add(Soluongmua.ToString());
            item.SubItems.Add(sp.Giaban.ToString());
            listView1.Items.Add(item);
        }
        private void CountMoney()
        {
            double Total = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                Total += (double.Parse(listView1.Items[i].SubItems[3].Text)) * double.Parse(listView1.Items[i].SubItems[2].Text);
            }
            Total *= 1000;
            label3.Text = Total.ToString("N0") + " VNĐ";
            
        }
        private void Search()
        {
            string lsp = (comboBox1.SelectedItem == null || comboBox1.SelectedItem.Equals("(Tất cả)") ? "" : comboBox1.SelectedItem.ToString());
            string ncc = (comboBox2.SelectedItem == null || comboBox2.SelectedItem.Equals("(Tất cả)") ? "" : comboBox2.SelectedItem.ToString());
            string ContentSearch = (textBox3.Text != null ? textBox3.Text : "");
            int temp = 0;
            bool IsNummeric = (textBox3.Text != null ? int.TryParse(textBox3.Text, out temp) : false);
            lstSanpham = SanphamController.Search(ContentSearch, lsp, ncc, IsNummeric);
            dataGridView1.DataSource = lstSanpham;
        }
        private void RfInfoProduct()
        {
            label20.Text = "______________________";
            label21.Text = "______________________";
            label22.Text = "______________________";
            label23.Text = "______________________";
            numericUpDown2.Value = 0;
            button4.Enabled = false;
            button5.Enabled = false;
        }
        //private void 
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.Checked == true)
            {
                label24.Enabled = true;
                textBox1.Enabled = true;

                label25.Enabled = false;
                label26.Enabled = false;
                label27.Enabled = false;
                label28.Enabled = false;
                label29.Enabled = false;

                textBox2.Enabled = false;
                panel5.Enabled = false;
                dateTimePicker1.Enabled = false;
                maskedTextBox1.Enabled = false;
                textBox4.Enabled = false;
                button2.Enabled = false;
            }
            else
            {
                label24.Enabled = false;
                textBox1.Enabled = false;

                label25.Enabled = true;
                label26.Enabled = true;
                label27.Enabled = true;
                label28.Enabled = true;
                label29.Enabled = true;

                textBox2.Enabled = true;
                panel5.Enabled = true;
                dateTimePicker1.Enabled = true;
                maskedTextBox1.Enabled = true;
                textBox4.Enabled = true;
                button2.Enabled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn muốn chọn "+textBox2.Text+" làm khách hàng thân thiết?","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                Khachhang kh = new Khachhang();
                kh.Tenkhachhang = textBox2.Text;
                kh.Gioitinh = radioButton1.Checked;
                kh.Ngaysinh = dateTimePicker1.Value.Date;
                kh.Sodienthoai = maskedTextBox1.Text;
                kh.Diachi = textBox4.Text;
                KhachhangController.Insert(kh);
                MessageBox.Show("Thêm thành công!");
                textBox1.Text = KhachhangController.GetKhachhangID(kh).ToString();
            }
            
        }
        //Bỏ chọn
        private void button5_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                listView1.SelectedItems[0].Remove();
                CountMoney();
                status = 1;
                RfInfoProduct();
            }
        }
        //Thêm mới, cập nhật
        private void button4_Click(object sender, EventArgs e)
        {
                if (status == 1 )
                {
                    int Soluongmua = int.Parse(numericUpDown2.Value.ToString());
                    if (Soluongmua > 0)
                    {
                       AddtoListView(spNow, Soluongmua);
                            CountMoney();
                            RfInfoProduct();
                    }
                }
                else
                {
                    int Soluongmua = int.Parse(numericUpDown2.Value.ToString());
                    if (Soluongmua > 0)
                    {
                            listView1.SelectedItems[0].SubItems[2].Text = Soluongmua.ToString();
                            CountMoney();
                            status = 1;
                            RfInfoProduct();
                    }
                    else
                    {
                        if (listView1.SelectedItems.Count != 0)
                        {
                            listView1.SelectedItems[0].Remove();
                            CountMoney();
                            status = 1;
                            RfInfoProduct();
                        }
                    }
                }
                    
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn muốn thanh toán?","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                Hoadonbanhang hd = new Hoadonbanhang();
                //hd.NhanvienID = Global.MaNV;
                hd.Ngayviet = DateTime.Now;
                hd.KhachhangID = (textBox1.Text==null||textBox1.Text==""?1:int.Parse(textBox1.Text));
                HoadonbanhangController.Insert(hd);
                int HoadonID = HoadonbanhangController.GetHoadonID(hd);
                foreach (ListViewItem item in listView1.Items)
                {
                    ChitietHDBH ct = new ChitietHDBH();
                    ct.HoadonbanhangID = HoadonID;
                    ct.SanphamID = int.Parse(item.Text);
                    ct.Soluong = int.Parse(item.SubItems[2].Text);
                    ct.Dongia = double.Parse(item.SubItems[3].Text);
                    ChitietHDBHController.Insert(ct);
                }
                MessageBox.Show("Thanh toán thành công!");
            }
        }
        
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            RfInfoProduct();
            if (dataGridView1.CurrentRow != null)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells["col_SanPhamID"].Value.ToString());
                spNow = lstSanpham.Find(x => x.SanphamID.Equals(id));
                Viewdata(spNow, 1);
                status = 1;
                button4.Text = "Chọn mua";
                button5.Enabled = false;
            }   
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (status == 2)
            {
                listView1.SelectedItems[0].SubItems[2].Text = numericUpDown2.Value.ToString();
                CountMoney();
            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                int id = int.Parse(listView1.SelectedItems[0].Text);
                spNow = lstSanpham.Find(x => x.SanphamID.Equals(id));
                int Soluongmua = int.Parse(listView1.SelectedItems[0].SubItems[2].Text);
                Viewdata(spNow, Soluongmua);
                button4.Text = "Cập nhật";
                status = 2;
                button5.Enabled = true;
            }
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                int PageSize = int.Parse(comboBox3.SelectedItem.ToString());
                int PageNumberMax;
                if (lstSanpham.Count <= PageSize)
                {
                    PageNumberMax = 1;
                }
                else
                {
                    double t = (double)lstSanpham.Count / PageSize;
                    PageNumberMax = (int)(t- Convert.ToInt32(t)>(double)0 ?t+1:t);
                }
                numericUpDown1.Value = 1;
                numericUpDown1.Maximum = PageNumberMax;
                label14.Text = PageNumberMax.ToString();
                List<SanPham> lst = new List<SanPham>();
                if (PageSize < lstSanpham.Count)
                {
                    for (int i = 0; i < PageSize; i++) {
                        lst.Add(lstSanpham[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < lstSanpham.Count; i++)
                    {
                        lst.Add(lstSanpham[i]);
                    }
                }
                dataGridView1.DataSource = lst;
            }
            

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
                List<SanPham> lst = new List<SanPham>();
                int PageSize = int.Parse(comboBox3.SelectedItem.ToString());
                int PageNumber = int.Parse(numericUpDown1.Value.ToString());
                int From = PageSize * (PageNumber - 1);
                int To = (PageSize * PageNumber > lstSanpham.Count ? lstSanpham.Count : PageSize * PageNumber );
                for (int i = From; i < To; i++)
                {
                    lst.Add(lstSanpham[i]);
                }
                dataGridView1.DataSource = lst;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Search();
        }

    }
}
