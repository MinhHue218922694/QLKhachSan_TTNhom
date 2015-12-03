using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QLBMT_TTNhom.DAO;

namespace QLBMT_TTNhom.BUS
{
    public class CT_PhieuXuat_Bus
    {
        CT_PhieuXuat_Dao ctpx = new CT_PhieuXuat_Dao();
        public DataTable getAllCTPhieuXuat()
        {
            return ctpx.GetAllCTPhieuXuat();
        }
        //thêm, sửa xóa
        public void Themct_xuat(string maphieux, string mahang, int soluong, float dongia, float thanhtien)
        {
            ctpx.themct_xuat(maphieux, mahang, soluong, dongia, thanhtien);
        }
        public void Suact_xuat(string maphieux, string mahang, int soluong, float dongia, float thanhtien)
        {
            ctpx.suact_xuat(maphieux, mahang, soluong, dongia, thanhtien);
        }
        public void xoact_xuat(string maphieux, string mahang)
        {
            ctpx.xoact_xuat(maphieux, mahang);
        }
    }
}
