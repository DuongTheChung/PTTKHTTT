using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class CaLamViecDTO
    {
        private int _maCa;
        private string _tenCa;
        private TimeSpan _gioBatDau;
        private TimeSpan _gioKetThuc;

        public int MaCa
        {
            get { return _maCa; }
            set { _maCa = value; }
        }

        public string TenCa
        {
            get { return _tenCa; }
            set { _tenCa = value; }
        }

        public TimeSpan GioBatDau
        {
            get { return _gioBatDau; }
            set { _gioBatDau = value; }
        }

        public TimeSpan GioKetThuc
        {
            get { return _gioKetThuc; }
            set { _gioKetThuc = value; }
        }

    }
}
