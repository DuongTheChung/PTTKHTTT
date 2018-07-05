using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class NhanVienDTO
    {
        private int _maNV;
        private string _tenNV;
        private string _diachiNV;
        private string _gioiTinhNV;
        private int _maCV;

        public NhanVienDTO()
        {
        }

        public NhanVienDTO(int manv, string tennv)
        {
            this._maNV = manv;
            this._tenNV = tennv;
        }

        public int MaNV
        {
            get { return _maNV; }
            set { _maNV = value; }
        }

        public string TenNV
        {
            get { return _tenNV; }
            set { _tenNV = value; }
        }

        public string DiaChiNV
        {
            get { return _diachiNV; }
            set { _diachiNV = value; }
        }

        public string GioiTinhNV
        {
            get { return _gioiTinhNV; }
            set { _gioiTinhNV = value; }
        }

        public int MaCV
        {
            get { return _maCV; }
            set { _maCV = value; }

        }
    }
}
