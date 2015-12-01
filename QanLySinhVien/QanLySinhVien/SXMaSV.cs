using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QanLySinhVien
{
    public class SXMaSV : IComparer
    {
        public int Compare(object obj1, object obj2)
        {
            SinhVien sv1 = (SinhVien)obj1;
            SinhVien sv2 = (SinhVien)obj2;
            return sv1.maSV.CompareTo(sv2.maSV);
        }
    }
    public class SXTenSV : IComparer
    {
        public int Compare(object obj1, object obj2)
        {
            SinhVien sv1 = (SinhVien)obj1;
            SinhVien sv2 = (SinhVien)obj2;
            return sv1.hoten.CompareTo(sv2.hoten);
        }
    }
    public class SXDiemSV : IComparer
    {
        public int Compare(object obj1, object obj2)
        {
            SinhVien sv1 = (SinhVien)obj1;
            SinhVien sv2 = (SinhVien)obj2;
            return sv1.diem.CompareTo(sv2.diem);
        }
    }
}
