using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Models
{
    class Khachhang
    {
        public int KhachhangID { get; set; }
        public string  Tenkhachhang { get; set; }
        public DateTime Ngaysinh { get; set; }
        public bool Gioitinh { get; set; }
        public string Sodienthoai { get; set; }
        public string Diachi { get; set; }
        public int Mucthanthiet { get; set; }
        public Khachhang() { }
    }
}
