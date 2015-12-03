using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBMT_TTNhom.DAO;
using System.Data;
using System.Data.SqlClient;
using QLBMT_TTNhom.VO;

namespace QLBMT_TTNhom.BUS
{
    public class KhachHang_Bus
    {
        KhachHang_Dao khhang = new KhachHang_Dao();
       
        public DataTable GetAllKH()
        {
            return khhang.getAllKH();
        }
        public DataTable GetMaKH()
        {
            return khhang.getMaKH();
        }
        public void Themkh(string makh, string tenkh, string diachi, string dienthoai, string email)
        {
            khhang.themkh(makh,tenkh,diachi,dienthoai,email);
        }
        public void Suakh(string makh, string tenkh, string diachi, string dienthoai, string email)
        {
            khhang.suakh(makh, tenkh, diachi, dienthoai, email);
        }
        public void Xoakh(string makh)
        {
            khhang.xoakh(makh);
        }
    }
}
