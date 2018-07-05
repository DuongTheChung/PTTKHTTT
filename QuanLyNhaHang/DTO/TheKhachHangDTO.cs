using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class TheKhachHangDTO
    {
        private int _maKh;
        private string _tenKh;
        private string _cMND;
        private string _diachi;
        private string _sodienthoai;
        private int _diemtichluy;
        private int _phantramgiam;


        public TheKhachHangDTO()
        {
        }

        public TheKhachHangDTO(string ten, string diachi, string sodienthoai, string cmnd)
        {
            this._tenKh = ten;
            this._diachi = diachi;
            this._sodienthoai = sodienthoai;
            this._cMND = cmnd;
        }

        public int MaKh
        {
            get { return _maKh; }
            set { _maKh = value; }
        }

        public string TenKh
        {
            get { return _tenKh; }
            set { _tenKh = value; }
        }

        public string CMND
        {
            get { return _cMND; }
            set { _cMND = value; }
        }

        public string Diachi
        {
            get { return _diachi; }
            set { _diachi = value; }
        }

        public string Sodienthoai
        {
            get { return _sodienthoai; }
            set { _sodienthoai = value; }
        }

        public int Diemtichluy
        {
            get { return _diemtichluy; }
            set { _diemtichluy = value; }
        }

        public int Phantramgiam
        {
            get { return _phantramgiam; }
            set { _phantramgiam = value; }
        }

        public int TinhPhanTramGiam()
        {
            int kq = 0;
            if (_diemtichluy >= 20 && _diemtichluy < 100)
                kq = 5;
            if (_diemtichluy >= 100 && _diemtichluy < 200)
                kq = 10;
            if (_diemtichluy >= 200)
                kq = 15;
            return kq;
        }

        public int TinhDiemTichLuy(float tongtien)
        {
            int kq = 0;
            if (tongtien >= 500000 && tongtien < 1000000)
                kq = 10;
            if (tongtien >= 1000000 && tongtien < 2000000)
                kq = 25;
            if (tongtien >= 2000000 && tongtien < 3000000)
                kq = 40;
            if (tongtien >= 3000000 && tongtien < 4000000)
                kq = 55;
            if (tongtien >= 4000000 && tongtien < 5000000)
                kq = 70;
            if (tongtien >= 5000000 && tongtien < 6000000)
                kq = 90;
            if (tongtien >= 6000000)
                kq = 120;
            return kq;
        } 
    }
}
