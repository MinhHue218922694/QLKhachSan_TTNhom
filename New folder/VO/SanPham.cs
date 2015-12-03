using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBMT_TTNhom.VO
{
    class SanPham
    {
        private string mahang;

        public string Mahang
        {
            get { return mahang; }
            set { mahang = value; }
        }
        private string tenhang;

        public string Tenhang
        {
            get { return tenhang; }
            set { tenhang = value; }
        }
        private float gianhap;

        public float Gianhap
        {
            get { return gianhap; }
            set {
                if (giaban < 0)
                    throw new Exception("không hợp lý");
                else 
                    gianhap = value; }
        }
        private float giaban;

        public float Giaban
        {
            get { return giaban; }
            set {
                if (giaban < 0)
                    throw new Exception("không hợp lý");
                else
                    giaban = value; }
        }
        private int soluong;

        public int Soluong
        {
            get { return soluong; }
            set {
                if (soluong < 0)
                    throw new Exception("không hợp lý");
                soluong = value; }
        }
        private float vat;

        public float Vat
        {
            get { return vat; }
            set { vat = value; }
        }
        private float thanhtien;

        public float Thanhtien
        {
            get { return thanhtien; }
            set { thanhtien = value; }
        }
        private string ncc;

        public string Ncc
        {
            get { return ncc; }
            set { ncc = value; }
        }
    }
}
