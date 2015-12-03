using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Models
{
    class SanPham
    {
        public int SanphamID { get; set; }
        public string Tensanpham { get; set; }
        public string Donvitinh { get; set; }
        public double Giaban { get; set; }
        public int NhacungcapID { get; set; }
        public int LoaisanphamID { get; set; }
        public string Tenloaisanpham { get; set; }
        public string Tennhacungcap { get; set; }
        public int Soluong { get; set; }
        public SanPham() { }
    }
}
