using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAO;
using DTO;

namespace BUS
{
    public class ThuNganBUS
    {
        ThuNganDAO dao = new ThuNganDAO();

        public DataTable LayDSDichVuKhac()
        {
            return dao.LayDSDichVuKhac();
        }

        public string LayGiaDichVuKhac(int madv)
        {
            return dao.LayGiaDichVuKhac(madv);
        }

        public bool ThemHoaDonKhongTheKH(HoaDonDTO dto)
        {
            return dao.ThemHoaDonKhongTheKH(dto);
        }

        public bool ThemCTHoaDon(CTHoaDonDTO dto)
        {
            return dao.ThemCTHoaDon(dto);
        }

        public bool ThemHoaDonCoTheKhachHang(HoaDonDTO dto)
        {
            return dao.ThemHoaDonCoTheKhachHang(dto);
        }

        public bool CapNhatDiemTichLuy(int makh, int diemtichluy)
        {
            return dao.CapNhatDiemTichLuy(makh, diemtichluy);
        }

        public DataTable LayTheKHTheoMa(int makh)
        {
            return dao.LayTheKHTheoMa(makh);
        }

        public DataTable KiemTraTheKhachHangDaTonTaiChua(string tenkh, string cmnd)
        {
            return dao.KiemTraTheKhachHangDaTonTaiChua(tenkh, cmnd);
        }

        public bool CapTheKhachHang(TheKhachHangDTO tkh, int manv)
        {
            return dao.CapTheKhachHang(tkh, manv);
        }

        public DataTable LayDSDichVuBuffet()
        {
            return dao.LayDSDichVuBuffet();
        }

        public string LayGiaVeDichVuBuffet(string buoi, string ngaythuong, string doituong)
        {
            return dao.LayGiaVeDichVuBuffet(buoi, ngaythuong, doituong);
        }
    }
}
