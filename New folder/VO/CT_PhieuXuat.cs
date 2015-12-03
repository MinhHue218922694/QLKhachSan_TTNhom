using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBMT_TTNhom.VO
{
    class CT_PhieuXuat
    {
        private string ma_ct_xuat;

        public string Ma_ct_xuat
        {
            get { return ma_ct_xuat; }
            set { ma_ct_xuat = value; }
        }
        private string mahang;

        public string Mahang
        {
            get { return mahang; }
            set { mahang = value; }
        }
        private int soluong;

        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }
        private float dongia;

        public float Dongia
        {
            get { return dongia; }
            set { dongia = value; }
        }
        private float thanhtien;

        public float Thanhtien
        {
            get { return thanhtien; }
            set { thanhtien = value; }
        }
    }
}
