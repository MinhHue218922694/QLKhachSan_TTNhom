using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QanLySinhVien
{
    public class CMND
    {
        private int SoCMND;
        private DateTime NgayCap;
        private string NoiCap;

        public CMND()
        {
            SoCMND = 0;
            NgayCap = Convert.ToDateTime("01/01/2000");
            NoiCap = null;
        }

        public CMND(int x, DateTime y, string z)
        {
            this.SoCMND = x;
            this.NgayCap = y;
            this.NoiCap = z;
        }

        public void setSoCMND(int x) { this.SoCMND = x; }
        public int getSoCMND() { return this.SoCMND; }

        public void setNoiCap(string str) { this.NoiCap = str; }
        public string getNoiCap() { return this.NoiCap; }
    }
}
