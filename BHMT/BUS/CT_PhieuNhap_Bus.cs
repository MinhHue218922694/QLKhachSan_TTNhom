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
    public class CT_PhieuNhap_Bus
    {
        CT_PhieuNhap_DAO ctpn = new CT_PhieuNhap_DAO();
        public DataTable getAllCT_PhieuNhap()
        {
            return ctpn.GetAllCT_PhieuNhap();
        }
        public DataTable getMaPhieuMaHang()
        {
            return ctpn.GetMaPhieuMaHang();
        }
        public void Themct_nhap(string mapn, string mahang, int soluong, float dongia, float thanhtien)
        {
            ctpn.themct_nhap(mapn, mahang, soluong, dongia, thanhtien);
        }
        public void Suact_nhap(string mapn, string mahang, int soluong, float dongia, float thanhtien)
        {
            ctpn.suact_nhap(mapn, mahang, soluong, dongia, thanhtien);
        }
        public void Xoact_nhap(string mapn, string mahang)
        {
            ctpn.xoact_nhap(mapn, mahang);
        }
    }
}
