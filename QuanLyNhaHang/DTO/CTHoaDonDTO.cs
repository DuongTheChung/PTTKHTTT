using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class CTHoaDonDTO
    {
        private int _maHD;
        private int _maDV;
        private int _soLuong;
        private float _donGia;

        public CTHoaDonDTO()
        {
        }

        public CTHoaDonDTO(int madv, int soluong, float dongia)
        {
            this._maDV = madv;
            this._soLuong = soluong;
            this._donGia = dongia;
        }

        public int MaHD
        {
            get { return _maHD; }
            set { _maHD = value; }
        }

        public int MaDV
        {
            get { return _maDV; }
            set { _maDV = value; }
        }

        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }

        public float DonGia
        {
            get { return _donGia; }
            set { _donGia = value; }
        }
    }
}
