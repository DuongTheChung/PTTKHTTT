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

        public DataTable dLayDSPhanCong()
        {
            string sql = "select n.MaNV,n.TenNV,ctc.CV,clv.TenCa from NhanVien n,CTCaLamViec ctc,CaLamViec clv  where ";
                sql=sql+ "n.MaNV=ctc.MaNV and ctc.MaCa=clv.MaCa";
            return dp.ExecuteQuery(sql);
        }

        public DataTable dTimKiemDauBep(string search)
        {
            string sql = "select n.TenNV,clv.TenCa,dv.TenDV from NhanVien n,CTCaLamViec ctc,CaLamViec clv,PhuTrachMonAn ptm,DichVu dv where ";
            sql = sql + "ptm.MaNV=n.MaNV and ptm.MaNV=ctc.MaNV and ";
            sql = sql + "ctc.MaCa=clv.MaCa and ptm.MaDV=dv.MaDV and ";
            sql = sql + "n.TenNV like N'%" + search + "%'";
            return dp.ExecuteQuery(sql);
        }
        public DataTable dLayKhaNangNauMon(int madv,int manv)
        {
            string sql = "select d.MaNV,d.TenNV  from NhanVien d,KhaNangNauMon k where d.MaNV=k.MaNV and k.MaDV=" + madv + " and d.MaNV <> "+manv+"";
            return dp.ExecuteQuery(sql);
        }


        public DataTable dLayDSNhanVienTheoChucVu(int chucvu)
        {
            string sql = "select MaNV,TenNV from NhanVien where MaCV="+chucvu+"";
            return dp.ExecuteQuery(sql);
        }

        public DataTable dLayDSCaLamViec()
        {
            string sql = "select MaCa from CaLamViec";
            return dp.ExecuteQuery(sql);
        }

        public DataTable dLayMaBepTruong(int maca,string congviec)
        {
            string sql = "select n.MaNV ,n.TenNV from CTCaLamViec ctc ,NhanVien n where ctc.MaCa="+maca+" and ctc.CV=N'" + congviec + "' and n.MaNV=ctc.MaNV";
            return dp.ExecuteQuery(sql);
        }

        public DataTable dKiemTraBepTruong(int maca, string congviec)
        {
            string sql = "select MaNV from CTCaLamViec where MaCa="+maca+" and CV=N'" + congviec + "'";
            return dp.ExecuteQuery(sql);
        }

        public DataTable dKTNhanVienCoLaBepTruong(int manv, string congviec)
        {
            string sql = "select MaNV from CTCaLamViec where MaNV=" + manv + " and CV=N'" + congviec + "'";
            return dp.ExecuteQuery(sql);
        }

        public DataTable bKiemTraDauBepPhuTrachMonAn(int mamonan,string congviec)
        {
            string sql = "select pt.MaNV from CTCaLamViec ctc,PhuTrachMonAn pt where ctc.MaNV=pt.MaNV and pt.MaDV=" + mamonan + " and ctc.CV=N'" + congviec + "'";
            return dp.ExecuteQuery(sql);
        }

        public DataTable dKiemTraPhuTrachMonAn(PhuTrachMonAnDTO dto)
        {
            string sql = "select MaNV from PhuTrachMonAn where MaNV=" + dto.MaNV + " and MaDV="+dto.MaDV+"";
            return dp.ExecuteQuery(sql);
        }
        public bool bPhanCong(CTCaLamViecDTO dto)
        {
            string sql = "insert into CTCaLamViec values(" + dto.MaCa + "," + dto.MaNV + ",N'" + dto.CV + "')";
            return dp.ExecuteNonQuery(sql);
        }

        public string dLayTenNhanVien(int manv)
        {
            string sql = "Select TenNV from NhanVien where MaNV = " + manv + "";
            return dp.ExecuteScalar_(sql);
        }

        public string dLayTenCaLamViec(int maca)
        {
            string sql = "Select TenCa from CaLamViec where MaCa = " + maca + "";
            return dp.ExecuteScalar_(sql);
        }

        public string dLayTenMonAn(int ma)
        {
            string sql = "Select TenDV from DichVu where MaDV = " + ma + "";
            return dp.ExecuteScalar_(sql);
        }

        public DataTable dLayDSMonAn()
        {
            string sql = "select MaDV,TenDV from DichVu where LoaiDV <> 0";
            return dp.ExecuteQuery(sql);
        }

        public bool bPhuTrachMonAn(PhuTrachMonAnDTO dto)
        {
            string sql = "insert into PhuTrachMonAn values(" + dto.MaNV + "," + dto.MaDV+")";
            return dp.ExecuteNonQuery(sql);
        }

    }
}
