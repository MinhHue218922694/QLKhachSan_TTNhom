using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBanHang.Models;
using System.Data;
using System.Data.SqlClient;

namespace QLBanHang.Controllers
{
    class SanPhamCollection
    {
        List<SanPham> items = new List<SanPham>();
        public List<SanPham> Items
        {
            get { return items; }
        }
        public SanPham this[int index]
        {
            get
            {
                return items[index];
            }
        }
        public SanPhamCollection()
        {
            Items.Clear();
            DataTable dt = DataAccess.ViewForGridView("Sanpham_ViewAll");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    SanPham sp = new SanPham();
                    sp.SanphamID = int.Parse(dr["SanphamID"].ToString());
                    sp.Tenloaisanpham = dr["Tenloaisanpham"].ToString();
                    sp.Tennhacungcap = dr["Tennhacungcap"].ToString();
                    sp.Tensanpham = dr["Tensanpham"].ToString();
                    sp.Soluong = int.Parse(dr["Soluong"].ToString());
                    sp.Giaban = double.Parse(dr["Giaban"].ToString());
                    sp.Donvitinh = dr["Donvitinh"].ToString();
                    sp.NhacungcapID = int.Parse(dr["NhacungcapID"].ToString());
                    sp.LoaisanphamID = int.Parse(dr["LoaisanphamID"].ToString());
                    Items.Add(sp);
                }
            }
        }
        public SanPhamCollection(int KhoID)
        {
            Items.Clear();
            DataTable dt = DataAccess.ViewForGridView("Sanpham_ViewByKho", new SqlParameter("@KhoID", KhoID));
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    SanPham sp = new SanPham();
                    sp.SanphamID = int.Parse(dr["SanphamID"].ToString());
                    sp.Tenloaisanpham = dr["Tenloaisanpham"].ToString();
                    sp.Tennhacungcap = dr["Tennhacungcap"].ToString();
                    sp.Tensanpham = dr["Tensanpham"].ToString();
                    sp.Soluong = int.Parse(dr["Soluong"].ToString());
                    sp.Giaban = double.Parse(dr["Giaban"].ToString());
                    sp.Donvitinh = dr["Donvitinh"].ToString();
                    sp.NhacungcapID = int.Parse(dr["NhacungcapID"].ToString());
                    sp.LoaisanphamID = int.Parse(dr["LoaisanphamID"].ToString());
                    Items.Add(sp);
                }
            }
        }
        public void Insert(SanPham sp)
        {
            DataAccess.ExecuteNonQuery("Sanpham_Insert",
                                             new SqlParameter("@Tensanpham", sp.Tensanpham),
                                             new SqlParameter("@Donvitinh", sp.Donvitinh),
                                             new SqlParameter("@Giaban", sp.Giaban),
                                             new SqlParameter("@NhacungcapID", sp.NhacungcapID),
                                             new SqlParameter("@LoaisanphamID", sp.LoaisanphamID),
                                             new SqlParameter("@Soluong", sp.Soluong)
                                             );
            Items.Add(sp);

        }
        public void Update(SanPham sp)
        {
            int index = Items.FindIndex(x => x.SanphamID == sp.SanphamID);
            DataAccess.ExecuteNonQuery("Sanpham_Update",
                                             new SqlParameter("@SanphamID", sp.SanphamID),
                                             new SqlParameter("@Tensanpham", sp.Tensanpham),
                                             new SqlParameter("@Donvitinh", sp.Donvitinh),
                                             new SqlParameter("@Giaban", sp.Giaban),
                                             new SqlParameter("@NhacungcapID", sp.NhacungcapID),
                                             new SqlParameter("@LoaisanphamID", sp.LoaisanphamID),
                                             new SqlParameter("@Soluong", sp.Soluong)
                                             );

        }
        public void Delete(SanPham sp)
        {
            int index = Items.FindIndex(x => x.SanphamID == sp.SanphamID);
            DataAccess.ExecuteNonQuery("Sanpham_Delete",
                                             new SqlParameter("@SanphamID", sp.SanphamID)
                                             );
        }
        public List<SanPham> Search(string content,string Loai,string Nhacungcap)
        {
            List<SanPham> lst = new List<SanPham>();
            DataTable dt = DataAccess.ViewForGridView("Sanpham_ViewByFilter", new SqlParameter("@Content", content),
                                                                       new SqlParameter("@Loaisanpham", Loai),
                                                                       new SqlParameter("@Nhasanxuat", Nhacungcap)
                                                            );
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    SanPham sp = new SanPham();
                    sp.SanphamID = int.Parse(dr["SanphamID"].ToString());
                    sp.Tenloaisanpham = dr["Tenloaisanpham"].ToString();
                    sp.Tennhacungcap = dr["Tennhacungcap"].ToString();
                    sp.Tensanpham = dr["Tensanpham"].ToString();
                    sp.Soluong = int.Parse(dr["Soluong"].ToString());
                    sp.Giaban = double.Parse(dr["Giaban"].ToString());
                    sp.Donvitinh = dr["Donvitinh"].ToString();
                    sp.NhacungcapID = int.Parse(dr["NhacungcapID"].ToString());
                    sp.LoaisanphamID = int.Parse(dr["LoaisanphamID"].ToString());
                    lst.Add(sp);
                }
            }
            return lst;
        }
        public List<SanPham> Find(int Loai)
        {
            List<SanPham> ret1 = new List<SanPham>();
            List<SanPham> ret2 = new List<SanPham>();
            foreach (SanPham sp in Items)
            {
                if (sp.Soluong == 0)
                {
                    ret1.Add(sp);
                }
                else
                {
                    ret2.Add(sp);
                }
            }
            if (Loai == 1)
            {
                return ret1;
            }
            else
            {
                return ret2;
            }
        }
    }
}
