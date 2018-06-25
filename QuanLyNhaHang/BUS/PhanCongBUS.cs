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
        public DataTable dLayDSPhanCong()
        {
            return dao.dLayDSPhanCong();
        }

        public DataTable dTimKiemDauBep(string search)
        {
            return dao.dTimKiemDauBep(search);
        }

        public DataTable dLayKhaNangNauMon(int madv,int manv)
        {
            return dao.dLayKhaNangNauMon(madv,manv);
        }

        public DataTable dLayDSNhanVienTheoChucVu(int chucvu)
        {
            return dao.dLayDSNhanVienTheoChucVu(chucvu);
        }

        public DataTable dLayDSCaLamViec()
        {
            return dao.dLayDSCaLamViec();
        }

        public DataTable dLayDSMonAn()
        {
            return dao.dLayDSMonAn();
        }

        public DataTable dLayMaBepTruong(int maca, string congviec)
        {
            return dao.dLayMaBepTruong(maca, congviec);
        }

        public DataTable dKiemTraBepTruong(int maca, string congviec)  
        {
            return dao.dKiemTraBepTruong(maca, congviec);
        }

        public DataTable dKTNhanVienCoLaBepTruong(int manv, string congviec)
        {
            return dao.dKTNhanVienCoLaBepTruong(manv, congviec);
        }

        public DataTable bKiemTraDauBepPhuTrachMonAn(int mamonan,string congviec)
        {
            return dao.bKiemTraDauBepPhuTrachMonAn(mamonan,congviec);
        }

        public DataTable dKiemTraPhuTrachMonAn(PhuTrachMonAnDTO dto)
        {
            return dao.dKiemTraPhuTrachMonAn(dto);
        }

        public bool bPhuTrachMonAn(PhuTrachMonAnDTO dto)
        {
            return dao.bPhuTrachMonAn(dto);
        }

        public bool bPhanCong(CTCaLamViecDTO dto)
        {
            return dao.bPhanCong(dto);
        }

        public string dLayTenNhanVien(int manv)
        {
            return dao.dLayTenNhanVien(manv);
        }

        public string dLayTenCaLamViec(int maca)
        {
            return dao.dLayTenCaLamViec(maca);
        }

        public string dLayTenMonAn(int ma)
        {
            return dao.dLayTenMonAn(ma);
        }
                  

    }
}
