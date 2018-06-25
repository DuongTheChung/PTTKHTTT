using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAO;

namespace BUS
{
    public class ThuNganBUS
    {
        ThuNganDAO tndao = new ThuNganDAO();

        public DataTable bLayDSNuocUong()
        {
            return tndao.dLayDSNuocUong();
        }

        public DataTable bTimNuocUong(string tenThucUong)
        {
            return tndao.dTimNuocUongTheoTen(tenThucUong);
        }

        public DataTable bLayDSKHThanThiet()
        {
            return tndao.dLayDSKhThanThiet();
        }

        public DataTable bTimKhThanThiet(string tenKH)
        {
            return tndao.dTimKhThanThiet(tenKH);
        }

        public DataTable bLayDSBuffet(int loaiBuffet)
        {
            return tndao.dLayDSBuffet(loaiBuffet);
        }

        public string bLayGiaVe(string buoi, string ngaythuong, string doituong)
        {
            return tndao.dLayGiaVe(buoi, ngaythuong, doituong);
        }
    }
}
