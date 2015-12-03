using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Models
{
    class Nhanvien
    {
        public int NhanvienID { get; set; }
        public string Hoten { get; set; }
        public int BophanID { get; set; }
        public float Hesoluong { get; set; }
        public bool Gioitinh { get; set; }
        public DateTime Ngaysinh { get; set; }
        public string Diachi { get; set; }
        public string Password { get; set; }
        public string Tenbophan { get; set; }
        public Nhanvien() { }
    }
}
