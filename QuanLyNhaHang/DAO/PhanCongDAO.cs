using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DTO;

namespace DAO
{
    public class PhanCongDAO
    {
        DataProvider dp = new DataProvider();

        public DataTable LayDSPhanCong()
        {
            string sql = "select n.MaNV,n.TenNV,ctc.CV,clv.TenCa from NhanVien n,CTCaLamViec ctc,CaLamViec clv  where ";
                sql=sql+ "n.MaNV=ctc.MaNV and ctc.MaCa=clv.MaCa";
            return dp.ExecuteQuery(sql);
        }

        public DataTable TimKiemDauBep(string search)
        {
            string sql = "select n.TenNV,clv.TenCa,dv.TenDV from NhanVien n,CTCaLamViec ctc,CaLamViec clv,PhuTrachMonAn ptm,DichVu dv where ";
            sql = sql + "ptm.MaNV=n.MaNV and ptm.MaNV=ctc.MaNV and ";
            sql = sql + "ctc.MaCa=clv.MaCa and ptm.MaDV=dv.MaDV and ";
            sql = sql + "n.TenNV like N'%" + search + "%'";
            return dp.ExecuteQuery(sql);
        }
        public DataTable LayKhaNangNauMonKhacNV(int madv,int manv)
        {
            string sql = "select d.MaNV,d.TenNV  from NhanVien d,KhaNangNauMon k where d.MaNV=k.MaNV and k.MaDV=" + madv + " and d.MaNV <> "+manv+"";
            return dp.ExecuteQuery(sql);
        }


        public DataTable LayDSNhanVienTheoChucVu(int macv)
        {
            string sql = "select MaNV,TenNV from NhanVien where MaCV="+macv+"";
            return dp.ExecuteQuery(sql);
        }


        public DataTable LayDSCaLamViec()
        {
            string sql = "select MaCa,TenCa from CaLamViec";
            return dp.ExecuteQuery(sql);
        }

        public DataTable LayMaBepTruongTheoCa(int maca, string congviec)
        {
            string sql = "select n.MaNV ,n.TenNV from CTCaLamViec ctc ,NhanVien n where ctc.MaCa="+maca+" and ctc.CV=N'" + congviec + "' and n.MaNV=ctc.MaNV";
            return dp.ExecuteQuery(sql);
        }

        public DataTable KiemTraCaDaCoBepTruongChua(int maca, string congviec)
        {
            string sql = "select MaNV from CTCaLamViec where MaCa="+maca+" and CV=N'" + congviec + "'";
            return dp.ExecuteQuery(sql);
        }

        public DataTable KiemTraNhanVienCoLaBepTruongKhong(int manv, string congviec)
        {
            string sql = "select MaNV from CTCaLamViec where MaNV=" + manv + " and CV=N'" + congviec + "'";
            return dp.ExecuteQuery(sql);
        }

        public DataTable KiemTraDauBepChinhMonAn(int mamonan, string congviec)
        {
            string sql = "select pt.MaNV from CTCaLamViec ctc,PhuTrachMonAn pt where ctc.MaNV=pt.MaNV and pt.MaDV=" + mamonan + " and ctc.CV=N'" + congviec + "'";
            return dp.ExecuteQuery(sql);
        }

        public DataTable KiemTraNVDaPhuTrachMonAnChua(PhuTrachMonAnDTO dto)
        {
            string sql = "select MaNV from PhuTrachMonAn where MaNV=" + dto.MaNV + " and MaDV="+dto.MaDV+"";
            return dp.ExecuteQuery(sql);
        }

        public DataTable KiemTraMonAnPVPhuTrach(int mamonan)
        {
            string sql = "select* from PhuTrachMonAn pt,NhanVien nv where pt.MaNV=nv.MaNV and nv.MaCV <> 8 and MaDV=" + mamonan + "";
            return dp.ExecuteQuery(sql);
        }


        public bool PhanCong(CTCaLamViecDTO dto)
        {
            string sql = "insert into CTCaLamViec values(" + dto.MaCa + "," + dto.MaNV + ",N'" + dto.CV + "')";
            return dp.ExecuteNonQuery(sql);
        }

        public string LayTenNhanVien(int manv)
        {
            string sql = "Select TenNV from NhanVien where MaNV = " + manv + "";
            return dp.ExecuteScalar_(sql);
        }

        public string LayTenCaLamViec(int maca)
        {
            string sql = "Select TenCa from CaLamViec where MaCa = " + maca + "";
            return dp.ExecuteScalar_(sql);
        }

        public string LayTenMonAn(int ma)
        {
            string sql = "Select TenDV from DichVu where MaDV = " + ma + "";
            return dp.ExecuteScalar_(sql);
        }

        public DataTable LayDSMonAn()
        {
            string sql = "select MaDV,TenDV from DichVu where LoaiDV <> 0";
            return dp.ExecuteQuery(sql);
        }

        public bool ThemPhuTrachMonAn(PhuTrachMonAnDTO dto)
        {
            string sql = "insert into PhuTrachMonAn values(" + dto.MaNV + "," + dto.MaDV+")";
            return dp.ExecuteNonQuery(sql);
        }

        public DataTable KiemTraNVPV(CTCaLamViecDTO dto)
        {
            string sql = "select * from CTCaLamViec where MaCa="+dto.MaCa+" and MaNV="+dto.MaNV+" and CV=N'"+dto.CV+"'";
            return dp.ExecuteQuery(sql);
        }

    }
}
