using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBMT_TTNhom.DAO;
using System.Data;
using System.Data.SqlClient;

namespace QLBMT_TTNhom.BUS
{
    public class PhieuNhap_Bus
    {
        PhieuNhap_Dao pn = new PhieuNhap_Dao();
        public DataTable getPhieuNhap()
        {
            return pn.GetPhieuNhap();
        }
        public DataTable getMaPhieuN()
        {
            return pn.GetMaPhieuN();
        }
        public void Thempn(string maphieun, string manv, string mancc, DateTime ngaynhap, float tongtiennhap)
        {
            pn.thempn(maphieun, manv, mancc, ngaynhap, tongtiennhap);
        }
        public void Suapn(string maphieun, string manv, string mancc, DateTime ngaynhap, float tongtiennhap)
        {
            pn.suapn(maphieun, manv, mancc, ngaynhap, tongtiennhap);
        }
        public void Xoapn(string maphieunhap, string manv, string mancc)
        {
            pn.xoapn(maphieunhap, manv, mancc);
        }
        public DataTable ThongKespnhap(DateTime ngay)
        {
            return pn.thongkenhapsp(ngay);
        }
        public DataTable ThongKe_tiennhap(DateTime ngay)
        {
            return pn.thongketiennhap(ngay);
        }
    }
}
