using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho
{
    public class QuanLyKho
    {
        Database db = new Database();
        public void NhapHang(HangHoa h)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@tenhanghoa", h.TenHangHoa));
            list.Add(new SqlParameter("@soluong", h.SoLuong));
            list.Add(new SqlParameter("@mahanghoa", h.MaHangHoa));
            db.Execute("ThemHangHoa", list.ToArray());
        }

        public void AddPhieuNhap(HoaDon hd)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@MAPHIEU", hd.MaPhieu));
            list.Add(new SqlParameter("@NHACUNGCAP", hd.NhaCungCap));
            list.Add(new SqlParameter("@NGAYNHAP", hd.NgayThang));
            db.Execute("PHIEUNHAP_THEM", list.ToArray());
        }

        public void AddChiTietPhieuNhap(HoaDon hd)
        {
            for (int i = 0; i < hd.listHangHoa.Count; i++)
            {
                List<SqlParameter> list = new List<SqlParameter>();
                list.Add(new SqlParameter("@maPhieu",hd.MaPhieu));
                list.Add(new SqlParameter("@maHangHoa", hd.listHangHoa[i].MaHangHoa));
                list.Add(new SqlParameter("@soLuong", hd.listHangHoa[i].SoLuong));
                list.Add(new SqlParameter("@donGia", hd.listHangHoa[i].Gia));
                db.Execute("ThemChiTietPhieuNhap", list.ToArray());
            }
        }
    }
}
