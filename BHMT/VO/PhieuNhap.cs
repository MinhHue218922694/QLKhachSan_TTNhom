using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBMT_TTNhom.VO
{
    class PhieuNhap
    {
        private string maphieun;

        public string Maphieun
        {
            get { return maphieun; }
            set { maphieun = value; }
        }
        private string manv;

        public string Manv
        {
            get { return manv; }
            set { manv = value; }
        }
        private string mancc;

        public string Mancc
        {
            get { return mancc; }
            set { mancc = value; }
        }
        private DateTime ngaynhap;

        public DateTime Ngaynhap
        {
            get { return ngaynhap; }
            set { ngaynhap = value; }
        }
        private float tongtiennhap;

        public float Tongtiennhap
        {
            get { return tongtiennhap; }
            set { tongtiennhap = value; }
        }

    }
}
