using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Models
{
    class Hoadonbanhang
    {
        public int HoadonbanghangID { get; set; }
        public DateTime Ngayviet { get; set; }
        public int KhachhangID { get; set; }
        public int NhanvienID { get; set; }
    }
}
