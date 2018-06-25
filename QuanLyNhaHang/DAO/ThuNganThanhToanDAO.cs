using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data;

namespace DAO
{
    public class ThuNganThanhToanDAO
    {
        DataProvider dp = new DataProvider();

        public string dLayBuffetCanBan(int madv)
        {
            string sql = "Select TenDV from DichVu where MaDV = " + madv + " and LoaiDV <> 0";
            return dp.ExecuteScalar_(sql);
        }

        public string dLayThucUongCanBan(int madv)
        {
            string sql = "Select TenDV from DichVu where MaDV = " + madv + "and LoaiDV = 0";
            return dp.ExecuteScalar_(sql);
        }

        public DataTable dLayDSBuffet()
        {
            string sql = "select MaDV, TenDV from DichVu where LoaiDV <> 0";
            return dp.ExecuteQuery(sql);
        }

        public string dLayGiaThucUong(int madv)
        {
            string sql = "Select DonGia from DichVu where MaDV = " + madv + "and LoaiDV = 0";
            return dp.ExecuteScalar_(sql);
        }

        public DataTable dLayTheKHTheoMa(string makh)
        {
            string sql = "SELECT MaKH, TenKH, CmndKH, DiemTichLuy FROM dbo.TheKhachHang WHERE MaKH like '" + makh + "%' and DiemTichLuy >= 20";
            return dp.ExecuteQuery(sql);
        }

        public bool dCapTheKhachHang(TheKhachHangDTO tkh, int manv)
        {
            string sql = "insert into TheKhachHang values(N'" + tkh.TenKh + "', N'" + tkh.Diachi + "', '" + tkh.Sodienthoai + "', '" + tkh.CMND + "', 20,'" + manv + "')";
            return dp.ExecuteNonQuery(sql);
        }

        public bool dThemHoaDon(int manv, int makh, float tongtien)
        {
            string sql = "insert into HoaDon values(GETDATE(), " + tongtien + ", " + makh + ", " + manv + ")";
            return dp.ExecuteNonQuery(sql);
        }

        public bool dThemCTHoaDon(int madv, float dongia, int soluong)
        {
            string sql = "insert into CTHoaDon values((select top(1)MaHD from HoaDon order by MaHD desc), " + madv + ", " + soluong + ", " + dongia + ")";
            return dp.ExecuteNonQuery(sql);
        }

        public bool dThemHoaDonKhongKH(int manv, int tongtien)
        {
            string sql = "insert into HoaDon values(GETDATE(), " + tongtien + ", NULL, " + manv + ")";
            return dp.ExecuteNonQuery(sql);
        }

        public bool bCapNhatDiemTichLuy(int makh, int diemtichluy)
        {
            string sql = "update TheKhachHang set DiemTichLuy = " + diemtichluy + " + (select DiemTichLuy from TheKhachHang where MaKH = " + makh + ") where MaKH =" + makh;
            return dp.ExecuteNonQuery(sql);
        }

       
    }
}
