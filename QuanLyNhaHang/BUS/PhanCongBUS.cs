using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAO;
using DTO;

namespace BUS
{
    public class PhanCongBUS
    {
        PhanCongDAO dao = new PhanCongDAO();
        public DataTable LayDSPhanCong()
        {
            return dao.LayDSPhanCong();
        }

        public DataTable TimKiemDauBep(string search)
        {
        
            return dao.TimKiemDauBep(search);
        }

        public DataTable LayKhaNangNauMonKhacNV(int madv, int manv)
        {
            return dao.LayKhaNangNauMonKhacNV(madv, manv);
        }

        public DataTable LayDSNhanVienTheoChucVu(int macv)
        {
            return dao.LayDSNhanVienTheoChucVu(macv);
        }

        public DataTable LayDSCaLamViec()
        {
            return dao.LayDSCaLamViec();
        }

        public DataTable LayDSMonAn()
        {
            return dao.LayDSMonAn();
        }

        public DataTable LayMaBepTruongTheoCa(int maca, string congviec)
        {
            return dao.LayMaBepTruongTheoCa(maca, congviec);
        }

        public DataTable KiemTraCaDaCoBepTruongChua(int maca, string congviec)  
        {
            return dao.KiemTraCaDaCoBepTruongChua(maca, congviec);
        }

        public DataTable KiemTraNhanVienCoLaBepTruongKhong(int manv, string congviec)
        {
            return dao.KiemTraNhanVienCoLaBepTruongKhong(manv, congviec);
        }

        public DataTable KiemTraDauBepChinhMonAn(int mamonan,string congviec)
        {
            return dao.KiemTraDauBepChinhMonAn(mamonan, congviec);
        }

        public DataTable KiemTraNVDaPhuTrachMonAnChua(PhuTrachMonAnDTO dto)
        {
            return dao.KiemTraNVDaPhuTrachMonAnChua(dto);
        }

        //Kiem tra món ăn đã được nhân viên bộ phận phục vụ phụ trách chưa
        public DataTable KiemTraMonAnPVPhuTrach(int mamonan)
        {
            return dao.KiemTraMonAnPVPhuTrach(mamonan);
        }

        public bool ThemPhuTrachMonAn(PhuTrachMonAnDTO dto)
        {
            return dao.ThemPhuTrachMonAn(dto);
        }

        public bool PhanCong(CTCaLamViecDTO dto)
        {
            return dao.PhanCong(dto);
        }

        public string LayTenNhanVien(int manv)
        {
            return dao.LayTenNhanVien(manv);
        }

        public string LayTenCaLamViec(int maca)
        {
            return dao.LayTenCaLamViec(maca);
        }

        public string LayTenMonAn(int ma)
        {
            return dao.LayTenMonAn(ma);
        }

        public DataTable KiemTraNVPV(CTCaLamViecDTO dto)
        {
            return dao.KiemTraNVPV(dto);
        }
                 
    }
}
