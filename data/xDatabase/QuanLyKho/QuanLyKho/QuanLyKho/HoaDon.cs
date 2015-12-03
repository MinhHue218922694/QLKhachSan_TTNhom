using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho
{
    public class HoaDon
    {
        public List<HangHoa> listHangHoa = new List<HangHoa>();
        public DateTime NgayThang { get; set; }
        public string MaPhieu { get; set; }
        public string NhaCungCap { get; set; }

    }
}
