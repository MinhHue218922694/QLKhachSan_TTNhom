using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBMT_TTNhom.VO
{
    class PhieuXuat
    {
        private string maphieux;

        public string Maphieux
        {
            get { return maphieux; }
            set { maphieux = value; }
        }
        private string makh;

        public string Makh
        {
            get { return makh; }
            set { makh = value; }
        }
        private DateTime ngaylap;

        public DateTime Ngaylap
        {
            get { return ngaylap; }
            set {
                if (ngaylap.Month < 0 && ngaylap.Month > 12)
                    throw new Exception("không hợp lý");
                else 
                    ngaylap = value; }
        }
        private float chietkhau;

        public float Chietkhau
        {
            get { return chietkhau; }
            set {
                if (chietkhau < 0)
                    throw new Exception("không hợp lý");
                else 
                     chietkhau = value; }
        }
        private float tongtien;

        public float Tongtien
        {
            get { return tongtien; }
            set {
                if (tongtien < 0)
                    throw new Exception("không hợp lý");
                else 
                    tongtien = value; }
        }
    }
}
