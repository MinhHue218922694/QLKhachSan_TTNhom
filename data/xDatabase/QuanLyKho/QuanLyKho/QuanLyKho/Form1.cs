using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        HoaDon hoadon = new HoaDon();
        QuanLyKho khohang = new QuanLyKho();
        bool chayLanDauTien = true;

        //THêm thông tin vào list
        private void button1_Click(object sender, EventArgs e)
        {
            if(chayLanDauTien)
            {
                chayLanDauTien = false;
                hoadon.MaPhieu = txtMaPhieu.Text;
                hoadon.NgayThang = txtTime.Value;
                hoadon.NhaCungCap = txtTenNCC.Text;
            }

            //Thêm vào giao diện
            dataGridView1.Rows.Add(GetInforFromView());
            
            //Thêm vào list trong code
            hoadon.listHangHoa.Add(GetHangHoFromView());
        }

        string[] GetInforFromView()
        {
            List<string> list = new List<string>();
            list.Add(txtMaPhieu.Text);
            list.Add(txtTenNCC.Text);
            list.Add(txtTime.Text);
            list.Add(txtMaHH.Text);
            list.Add(txtTenHH.Text);
            list.Add(txtSL.Text);
            list.Add(txtThanhTien.Text);
            return list.ToArray();
        }

        HangHoa GetHangHoFromView()
        {
            HangHoa h = new HangHoa();
            h.TenHangHoa = txtTenHH.Text;
            h.SoLuong = int.Parse(txtSL.Text);
            h.MaHangHoa = txtMaHH.Text;
            h.Gia = int.Parse(txtThanhTien.Text);
            return h;
        }

     

        //Tuyền data vào Server
        private void button2_Click(object sender, EventArgs e)
        {
            //Thêm Phiếu nhập
            khohang.AddPhieuNhap(hoadon);


            //Thêm Hàng Hóa
            for (int i = 0; i < hoadon.listHangHoa.Count; i++)
                khohang.NhapHang(hoadon.listHangHoa[i]);
            

            //Thêm chi tiết phiếu nhập
            khohang.AddChiTietPhieuNhap(hoadon);
        }

        
    }
}
