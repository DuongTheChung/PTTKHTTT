using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class KhaNangNauMonDTO
    {
        private int _maNV;
        private int _maDV;

        public int MaNV
        {
            get { return _maNV; }
            set { _maNV = value; }
        }

        public int MaDV
        {
            get { return _maDV; }
            set { _maDV = value; }
        }

    }
}
