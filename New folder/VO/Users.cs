using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBMT_TTNhom.VO
{
    class Users
    {
        //thuộc tính
        public string UserName;
        public string User
        {
            get { return UserName; }
            set { UserName = value; }
        }
        public string pass;
        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }
        public string manhom;
        public string MaNhom {

            get { return manhom; }
            set { manhom = value; }
        }
    }
}
