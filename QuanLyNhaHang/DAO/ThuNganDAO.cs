using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DTO;
namespace DAO
{
    public class ThuNganDAO
    {
        DataProvider dp = new DataProvider();

        public DataTable LayDSDichVuKhac()
        {
            string sql = "Select MaDV, TenDV, DonGia from DichVu where LoaiDV = 0";
            return dp.ExecuteQuery(sql);
        }

        public string LayGiaDichVuKhac(int madv)
        {
            string sql = "Select DonGia from DichVu where MaDV = " + madv + "and LoaiDV = 0";
            return dp.ExecuteScalar_(sql);
        }


        public bool ThemHoaDonKhongTheKH(HoaDonDTO dto)
        {
            string sql = "insert into HoaDon values(GETDATE(), " + dto.TongTien + "," + dto.TienGiam + ", " + dto.TienThanhToan + ", NULL, " + dto.NVLapHD + ")";
            return dp.ExecuteNonQuery(sql);
        }

        public bool ThemCTHoaDon(CTHoaDonDTO dto)
        {
            string sql = "insert into CTHoaDon values((select top(1)MaHD from HoaDon order by MaHD desc), " + dto.MaDV + ", " + dto.SoLuong + ", " + dto.DonGia + ")";
            return dp.ExecuteNonQuery(sql);
        }


        public bool ThemHoaDonCoTheKhachHang(HoaDonDTO dto)
        {
            string sql = "insert into HoaDon values(GETDATE(), " + dto.TongTien + ", " + dto.TienGiam + ", " + dto.TienThanhToan + ", " + dto.MaKH + ", " + dto.NVLapHD + ")";
            return dp.ExecuteNonQuery(sql);
        }

        public bool CapNhatDiemTichLuy(int makh, int diemtichluy)
        {
            string sql = "update TheKhachHang set DiemTichLuy = " + diemtichluy + " + (select DiemTichLuy from TheKhachHang where MaKH = " + makh + ") where MaKH =" + makh;
            return dp.ExecuteNonQuery(sql);
        }


        public DataTable LayTheKHTheoMa(int makh)
        {
            string sql = "SELECT MaKH, TenKH, CmndKH, DiemTichLuy FROM dbo.TheKhachHang WHERE MaKH="+makh+" and DiemTichLuy >= 20";
            return dp.ExecuteQuery(sql);
        }

        public DataTable KiemTraTheKhachHangDaTonTaiChua(string tenkh, string cmnd)
        {
            string sql="SELECT MaKH, TenKH, CmndKH, DiemTichLuy FROM dbo.TheKhachHang WHERE TenKH='"+tenkh+"' and CmndKH ='"+cmnd+"'";
            return dp.ExecuteQuery(sql);
        }


        public bool CapTheKhachHang(TheKhachHangDTO tkh, int manv)
        {
            string sql = "insert into TheKhachHang values(N'" + tkh.TenKh + "', N'" + tkh.Diachi + "', '" + tkh.Sodienthoai + "', '" + tkh.CMND + "', 20,'" + manv + "')";
            return dp.ExecuteNonQuery(sql);
        }


        public DataTable LayDSDichVuBuffet()
        {
            string sql = "select MaDV, TenDV from DichVu where LoaiDV <> 0";
            return dp.ExecuteQuery(sql);
        }

        public string LayGiaVeDichVuBuffet(string buoi, string ngaythuong, string doituong)
        {
            string sql = "SELECT GiaVe FROM LoaiVe WHERE (Buoi = N'" + buoi + "') AND (NgayThuong = N'" + ngaythuong + "') AND (DoiTuong = N'" + doituong + "')";
            return dp.ExecuteScalar_(sql);
        }

    }
}
