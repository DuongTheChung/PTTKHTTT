using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class PhuTrachMonAnDTO
    {
        private int _maNV;
        private int _maDV;

        public PhuTrachMonAnDTO()
        {
        }

        public PhuTrachMonAnDTO(int manv, int madv)
        {
            this._maNV = manv;
            this._maDV = madv;
        }

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
