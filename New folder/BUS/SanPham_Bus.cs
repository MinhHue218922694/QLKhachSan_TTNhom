using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QLBMT_TTNhom.DAO;

namespace QLBMT_TTNhom.BUS
{
    public class SanPham_Bus
    {
        SanPham_Dao sp = new SanPham_Dao();
        public DataTable getAllSanPham()
        {
            return sp.GetAllSanPham();
        }
        public DataTable getMaSP()
        {
            return sp.GetMaSP();
        }
        public void Themsp(string mahang, string tenhang, float gianhap, float giaban, int soluong, float vat, string ncc)
        {
            sp.themsp(mahang, tenhang, gianhap, giaban, soluong, vat, ncc);
        }
        public void Suasp(string mahang, string tenhang, float gianhap, float giaban, int soluong, float vat, string ncc)
        {
            sp.suasp(mahang, tenhang, gianhap, giaban, soluong, vat, ncc);
        }
        public void xoasp(string mahang)
        {
            sp.xoasp(mahang);
        }
        public DataTable TimKiem_Ma(string ma)
        {
            return sp.timkiemma(ma);
        }
        public DataTable TimKiem_Ten(string ten)
        {
            return sp.timkiemten(ten);
        }
    }
}
