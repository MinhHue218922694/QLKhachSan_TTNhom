using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBMT_TTNhom.VO
{
    class NhanVien
    {
        private string manv;

        public string Manv
        {
            get { return manv; }
            set { manv = value; }
        }
        private string tennv;

        public string Tennv
        {
            get { return tennv; }
            set { tennv = value; }
        }
        private DateTime ngaysinh;

        public DateTime Ngaysinh
        {
            get { return ngaysinh; }
            set {
                if (ngaysinh.Month < 0 && ngaysinh.Month > 12)
                    throw new Exception("không hợp lý");
                else
                       ngaysinh = value; }
        }
        private string bophan;

        public string Bophan
        {
            get { return bophan; }
            set { bophan = value; }
        }
        private string chucvu;

        public string Chucvu
        {
            get { return chucvu; }
            set { chucvu = value; }
        }
        private string diachi;

        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }
        private string dienthoai;

        public string Dienthoai
        {
            get { return dienthoai; }
            set { dienthoai = value; }
        }
    }
}
