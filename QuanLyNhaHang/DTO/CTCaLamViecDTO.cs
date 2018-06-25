using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class CTCaLamViecDTO
    {
        private int _maCa;
        private int _maNV;
        private string _cV;

        public int MaCa
        {
            get { return _maCa; }
            set { _maCa = value; }
        }

        public int MaNV
        {
            get { return _maNV; }
            set { _maNV = value; }
        }

        public string CV
        {
            get { return _cV; }
            set { _cV = value; }
        }
    }
}
