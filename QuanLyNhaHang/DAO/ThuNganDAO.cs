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

        public DataTable dLayDSNuocUong()
        {
            string sql = "Select MaDV, TenDV, DonGia from DichVu where LoaiDV = 0";
            return dp.ExecuteQuery(sql);
        }
        public DataTable dTimNuocUongTheoTen(string tenThucUong)
        {
            string sql = "Select MaDV, TenDV, DonGia from DichVu where LoaiDV = 0 and TenDV like N'%" + tenThucUong + "%'";
            return dp.ExecuteQuery(sql);
        }

        public DataTable dLayDSKhThanThiet()
        {
            string sql = "select MaKH, TenKH, DiaChiKH, SdtKH, CmndKH, DiemTichLuy, TenNV from TheKhachHang, NhanVien where MaNV = NVCapThe";
            return dp.ExecuteQuery(sql);
        }

        public DataTable dTimKhThanThiet(string tenKH)
        {
            string sql = "select MaKH, TenKH, DiaChiKH, SdtKH, CmndKH, DiemTichLuy, TenNV from TheKhachHang, NhanVien where MaNV = NVCapThe and TenKH like N'%" + tenKH + "%'";
            return dp.ExecuteQuery(sql);
        }

        public DataTable dLayDSBuffet(int loaiBuffet)
        {
            string sql = "select d.MaDV, d.TenDV, d.DonGia from DichVu d  where d.LoaiDV = " + loaiBuffet +"";
            return dp.ExecuteQuery(sql);
        }

        public string dLayGiaVe(string buoi, string ngaythuong, string doituong)
        {
            string sql = "SELECT GiaVe FROM LoaiVe WHERE (Buoi = N'" + buoi + "') AND (NgayThuong = N'" + ngaythuong + "') AND (DoiTuong = N'" + doituong + "')";
            return dp.ExecuteScalar_(sql);
        }
    }
}
