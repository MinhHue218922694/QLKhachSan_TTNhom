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
    public class PhieuXuat_Bus
    {
        PhieuXuat_Dao px = new PhieuXuat_Dao();
        public DataTable getAllPhieuXuat()
        {
            return px.GetAllPhieuXuat();
        }
        public DataTable getMaPhieuX()
        {
            return px.GetMaPhieuX();
        }
        public void Thempx(string maphieu, string makh, string manv, DateTime ngaylap, float chietkhau, float tongtien)
        {
            px.thempx(maphieu, makh, manv, ngaylap, chietkhau, tongtien);
        }
        public void Suapx(string maphieu, string makh, string manv, DateTime ngaylap, float chietkhau, float tongtien)
        {
            px.suapx(maphieu, makh, manv, ngaylap, chietkhau, tongtien);
        }
        public void xoapx(string maphieux)
        {
            px.xoapx(maphieux);
        }
        public DataTable Thongke_spban(DateTime ngay)
        {
            return px.thongke_spban(ngay);
        }
        public DataTable Thongke_tienthu(DateTime ngay)
        {
            return px.thongke_tienban(ngay);
        }
    }
}
