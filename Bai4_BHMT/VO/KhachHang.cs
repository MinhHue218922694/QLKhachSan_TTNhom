using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBMT_TTNhom.VO
{
    class KhachHang
    {
        private string makh;
        public string MaKH
        {
            get { return makh; }
            set { makh = value; }
        }
        private string tenKh;
        public string TenKH
        {
            get { return tenKh; }
            set { tenKh = value; }
        }
        private string diachi;
        public string DiaChi
        {
            get { return diachi; }
            set { diachi = value; }
        }
        private string DT;
        public string DienThoai
        {
            get { return DT; }
            set { DT = value; }
        }
        private string mail;
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        public KhachHang()
        {
            makh = "";
            tenKh = "";
            diachi = "";
            DT = "";
            mail = "";
        }
        public KhachHang(string Makh, string tenkh, string dc, string email)
        {
            makh = Makh;
            tenKh = tenkh;
            diachi = dc;
            mail = email;
        }
    }
}
