using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBanHang.Models;
using System.Data;
using QLBanHang.Controllers;

namespace QLBanHang.Controllers
{
    class LoaiSanPhamCollection
    {
        List<LoaiSanPham> lst = new List<LoaiSanPham>();

        public List<LoaiSanPham> Items
        {
            get { return lst; }
            set { lst = value; }
        }
        public LoaiSanPham this[int index]
        {
            get
            {
                return lst[index];
            }
        }
        public LoaiSanPhamCollection()
        {
            DataTable dt = DataAccess.ViewForGridView("Loaisanpham_ViewAll");
            foreach (DataRow dr in dt.Rows)
            {
                LoaiSanPham lsp = new LoaiSanPham();
                lsp.LoaisanphamID = int.Parse(dr["LoaisanphamID"].ToString());
                lsp.Tenloaisanpham = dr["Tenloaisanpham"].ToString();
                lst.Add(lsp);
            }

        }
        
    }
}
