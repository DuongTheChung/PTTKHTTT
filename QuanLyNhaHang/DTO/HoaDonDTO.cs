using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class HoaDonDTO
    {
        private int _maHD;
        private DateTime _ngayLap;
        private float _tongTien;
        private float _tienGiam;
        private float _tienThanhToan;
        private int _maKH;
        private int _nVLapHD;

        public HoaDonDTO()
        {
            
        }

        public HoaDonDTO(float tongtien,float tiengiam,float tienthanhtoan,int makh,int nvlhd)
        {
            this._tongTien = tongtien;
            this._tienGiam = tiengiam;
            this._tienThanhToan = tienthanhtoan;
            this._maKH = makh;
            this._nVLapHD = nvlhd;
        }

        public int MaHD
        {
            get { return _maHD; }
            set { _maHD = value; }
        }

        public DateTime NgayLap
        {
            get { return _ngayLap; }
            set { _ngayLap = value; }
        }

        public float TongTien
        {
            get { return _tongTien; }
            set { _tongTien = value; }
        }

        public float TienGiam
        {
            get { return _tienGiam; }
            set { _tienGiam = value; }
        }

        public float TienThanhToan
        {
            get { return _tienThanhToan; }
            set { _tienThanhToan = value; }
        }

        public int MaKH
        {
            get { return _maKH; }
            set { _maKH = value; }
        }

        public int NVLapHD
        {
            get { return _nVLapHD; }
            set { _nVLapHD = value; }
        }
    }
}
