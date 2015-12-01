using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QanLySinhVien
{
    public class SinhVien : IComparable
    {
        private string MaSV, HoTen, QueQuan, DonVi;       
        private string GioiTinh;
        private DateTime NgaySinh;       
        private string CMND;
        private double Diem;

        public int CompareTo(object ob2)
        {
            SinhVien sv2 = (SinhVien)ob2;
            if (string.Compare(maSV, sv2.maSV) < 0)
                return 1;
            else if (string.Compare(maSV, sv2.maSV) == 0)
                return 0;
            else
                return -1;
        }
        //public int CompareTo(object ob2)
        //{
        //    SinhVien sv2 = (SinhVien)ob2;
        //    if (string.Compare(hoten, sv2.hoten) < 0)
        //        return 1;
        //    else if (string.Compare(hoten, sv2.hoten) == 0)
        //        return 0;
        //    else
        //        return -1;
        //}
        //public int CompareTo(object ob2)
        //{
        //    SinhVien sv2 = (SinhVien)ob2;
        //    if (diem < sv2.diem)
        //        return 1;
        //    else if (diem == sv2.diem)
        //        return 0;
        //    else
        //        return -1;
        //}

        public SinhVien()
        {
            maSV = hoten = "";
            quequan = donvi = "";
            gioitinh = "";
            DateTime.TryParse(@"01/01/2000", out NgaySinh);
            cmnd = "";
            diem = 0;
        }

        public SinhVien(string _ma, string _hoten, string _gt, string _ns, string _qq, string _dv, string _cmnd, string _diem)
        {
            maSV = _ma;
            hoten = _hoten;
            gioitinh = _gt;
            ngaysinh = DateTime.Parse(_ns);
            quequan = _qq;
            donvi = _dv;
            cmnd = _cmnd;
            diem = double.Parse(_diem);
        }
        public void ThemSV(string _ma, string _hoten)
        {
            this.MaSV = _ma;
            this.HoTen = _hoten;
        }

        public string maSV
        {
            get { return MaSV; }
            set { if (value.Length > 0) MaSV = value; }
        }

        public string hoten
        {
            get { return HoTen; }
            set { if (value.Length >= 0) HoTen = value; }
        }
        public string quequan
        {
            get { return QueQuan; }
            set { if (value.Length >= 0) QueQuan = value; }
        }
        public string donvi
        {
            get;
            set;
        }
        public string gioitinh
        {
            get { return GioiTinh; }
            set { GioiTinh = value; }
        }

        public DateTime ngaysinh
        {
            get { return NgaySinh; }
            set {
                NgaySinh = value;
            }
        }

        public string cmnd
        {
            get;
            set;
        }

        public double diem
        {
            get { return Diem; }
            set
            {
                if (value <= 10 && value >= 0)
                    Diem = value;
            }
        }
    }
}
