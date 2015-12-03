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
    public partial class frmXuatKho : Form
    {
        public frmXuatKho()
        {
            InitializeComponent();
        }
        HoaDon hoadon = new HoaDon();
        QuanLyKho khohang = new QuanLyKho();
        bool chayLanDauTien = true;
        private void btthem_Click(object sender, EventArgs e)
        {
            if (chayLanDauTien)
            {
                chayLanDauTien = false;
                hoadon.MaPhieu = txtmaphieu.Text;
                hoadon.NgayThang = txtngayxuat.Value;
                hoadon.KhachHang = txtkhachhang.Text;
            }

            //Thêm vào giao diện
            dataGridView2.Rows.Add(GetInforFromView());

            //Thêm vào list trong code
            hoadon.listHangHoa.Add(GetHangHoFromView());
        }
        string[] GetInforFromView()
        {
            List<string> list = new List<string>();
            list.Add(txtmaphieu.Text);
            list.Add(txtkhachhang.Text);
            list.Add(txtngayxuat.Text);
            list.Add(txtmamh.Text);
            list.Add(txttenmh.Text);
            list.Add(txtsoluong.Text);
            return list.ToArray();
        }

        HangHoa GetHangHoFromView()
        {
            HangHoa h = new HangHoa();
            h.TenHangHoa = txttenmh.Text;
            h.SoLuong = int.Parse(txtsoluong.Text);
            h.MaHangHoa = txttenmh.Text;
            return h;
        }

        private void btxuat_Click(object sender, EventArgs e)
        {
            try
            {
                //Thêm Phiếu xuat
                khohang.AddPhieuXuat(hoadon);


                //xuat Hàng Hóa
                for (int i = 0; i < hoadon.listHangHoa.Count; i++)
                    khohang.XuatHang(hoadon.listHangHoa[i]);


                //Thêm chi tiết phiếu nhập
                khohang.AddChiTietPhieuxUAT(hoadon);
                MessageBox.Show("Đã Xuất thành công");
            }
            catch
            {
                MessageBox.Show("Có Lỗi");
            }
        }
    
    }
}
