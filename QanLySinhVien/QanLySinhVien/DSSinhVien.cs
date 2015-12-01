using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace QanLySinhVien
{
    public class DSSinhVien
    {
        public List<SinhVien> lstSv = new List<SinhVien>();

        public void Input(string str)
        {
            StreamReader rd = new StreamReader(str);
            while (!rd.EndOfStream)
            {
                SinhVien sv = new SinhVien();
                sv.maSV = rd.ReadLine();
                sv.hoten = rd.ReadLine();
                sv.gioitinh = rd.ReadLine();
                sv.ngaysinh = DateTime.Parse(rd.ReadLine());
                sv.quequan = rd.ReadLine();
                sv.donvi = rd.ReadLine();
                //int x;
                //if (int.TryParse(rd.ReadLine(), out x))
                //{
                //    sv.cmnd.setSoCMND(x);
                //}
                sv.cmnd = rd.ReadLine();
                sv.diem = Convert.ToDouble(rd.ReadLine());
                rd.ReadLine();

                lstSv.Add(sv);
            }
            rd.Close();
        }

        public void Save(string str)
        {
            StreamWriter rw = new StreamWriter(str);
            foreach (SinhVien s in lstSv)
            {
                rw.WriteLine(s.maSV);
                rw.WriteLine(s.hoten);
                rw.WriteLine(s.gioitinh);
                rw.WriteLine(s.ngaysinh.ToString());
                rw.WriteLine(s.quequan);
                rw.WriteLine(s.donvi);
                rw.WriteLine(s.cmnd);
                rw.WriteLine(s.diem.ToString());
                rw.WriteLine();
            }
            rw.Close();
        }
        public string SinhMaSV()
        {
            string str = "";
            int x1 = 0, x2 = 0;
            foreach (SinhVien s in lstSv)
            {
                string temp = s.maSV.Substring(2);
                x1 = int.Parse(temp);
                x2++;

                if (x1 - x2 > 1)
                {
                    str = "SV" + x2.ToString();
                    return str;
                }
            }
            if (x1 == x2) str = "SV" + (x1 + 1).ToString();
            return str;
        }

        public bool Insert(SinhVien sv, int i)
        {
            try
            {
                lstSv.Insert(i, sv);
                return true;
            }
            catch { return false; }
        }
        public bool Insert(SinhVien sv)
        {
            try
            {
                lstSv.Insert(lstSv.Count, sv);
                return true;
            }
            catch { return false; }
        }
        public bool Insert(SinhVien sv, bool dk)
        {
            try
            {
                if (dk == true)
                    lstSv.Insert(0, sv);
                else
                {
                    if (Insert(sv) == false)
                        return false;
                }
                return true;
            }
            catch { return false; }
        }
        public bool Insert(List<SinhVien> list)
        {
            try
            {
                lstSv.AddRange(list);
                return true;
            }
            catch { return false; }
        }


        public bool Remove(int i)
        {
            try
            {
                lstSv.RemoveAt(i);
                return true;
            }
            catch { return false; }
        }
        //public bool Remove(SinhVien sv)
        //{
        //    try
        //    {
        //        foreach (SinhVien sv_temp in lstSv)
        //        {
        //            if (sv_temp.maSV == sv.maSV)
        //            {
        //                lstSv.Remove(sv_temp);
        //                return true;
        //            }
        //        }
        //        return true;
        //    }
        //    catch { return false; }
        //}
        public void Remove(List<SinhVien> list)
        {
            foreach (SinhVien sv in list)
            {
                foreach (SinhVien sv2 in lstSv)
                {
                    if (sv2 == sv)
                        lstSv.Remove(sv2);
                }
            }
        }

        public void Show(DataGridView dgv)
        {
            int i = 0;
            dgv.RowCount = lstSv.Count;
            for (i = 0; i < lstSv.Count; i++)
            {
                dgv.Rows[i].Cells[0].Value = (i + 1).ToString();
                dgv.Rows[i].Cells[1].Value = lstSv[i].maSV.ToString();
                dgv.Rows[i].Cells[2].Value = lstSv[i].hoten.ToString();
                dgv.Rows[i].Cells[3].Value = lstSv[i].ngaysinh.ToString();
                dgv.Rows[i].Cells[4].Value = lstSv[i].gioitinh.ToString();
                dgv.Rows[i].Cells[5].Value = lstSv[i].quequan.ToString();
                dgv.Rows[i].Cells[6].Value = lstSv[i].donvi.ToString();
                dgv.Rows[i].Cells[7].Value = lstSv[i].cmnd.ToString();
                dgv.Rows[i].Cells[8].Value = lstSv[i].diem.ToString();
            }
        }

        public bool Edit(SinhVien sv, int i)
        {
            lstSv[i] = sv;
            return true;
        }

        public List<SinhVien> Search(string strMa, string strTen, string diem)
        {
            List<SinhVien> list = new List<SinhVien>();
            SinhVien sv = new SinhVien();

            strMa = strMa.ToUpper();
            strTen = strTen.ToUpper();
            foreach(SinhVien s in lstSv)
            {
                string s1 = s.maSV.ToUpper();
                string s2 = s.hoten.ToUpper();
                string s3 = s.diem.ToString().ToUpper();
                if (s1.Contains(strMa) == true && s2.Contains(strTen) && s3.Contains(diem) )
                {
                    list.Add(s);
                }
            }
            return list;
        }

        public void SXTheoMa()
        {
            SinhVien[] arr = new SinhVien[lstSv.Count];
            for (int i = 0; i < lstSv.Count; i++)
                arr[i] = lstSv[i];
            Array.Sort(arr, new SXMaSV());
            for (int i = 0; i < lstSv.Count; i++)
                lstSv[i] = arr[i];
        }
        public void SXTheoTen()
        {
            SinhVien[] arr = new SinhVien[lstSv.Count];
            for (int i = 0; i < lstSv.Count; i++)
                arr[i] = lstSv[i];
            Array.Sort(arr, new SXTenSV());
            for (int i = 0; i < lstSv.Count; i++)
                lstSv[i] = arr[i];
        }
        public void SXTheoDiem()
        {
            SinhVien[] arr = new SinhVien[lstSv.Count];
            for (int i = 0; i < lstSv.Count; i++)
                arr[i] = lstSv[i];
            Array.Sort(arr, new SXDiemSV());
            for (int i = 0; i < lstSv.Count; i++)
                lstSv[i] = arr[i];
        }
    }

}
