using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAO;
using DTO;

namespace BUS
{
    public class ThuNganThanhToanBUS
    {
        DataTable dt = new DataTable();
        ThuNganThanhToanDAO tt_bvdao = new ThuNganThanhToanDAO();

        public string bLayBuffetCanBan(int madv)
        {
            return tt_bvdao.dLayBuffetCanBan(madv);
        }

        public string bLayThucUongCanBan(int madv)
        {
            return tt_bvdao.dLayThucUongCanBan(madv);
        }

        public DataTable bLayDSBuffet()
        {
            return tt_bvdao.dLayDSBuffet();
        }

        public string bLayGiaThucUong(int madv)
        {
            return tt_bvdao.dLayGiaThucUong(madv);
        }

        public bool bThemHoaDon(int manv, int makh, float tongtien)
        {
            return tt_bvdao.dThemHoaDon(manv, makh, tongtien);
        }

        public DataTable bLayTheKHTheoMa(string makh)
        {
            return tt_bvdao.dLayTheKHTheoMa(makh);
        }

        public bool bCapTheKhachHang( TheKhachHangDTO tkh, int manv)
        {
            return tt_bvdao.dCapTheKhachHang(tkh, manv);
        }

        public bool bThemCTHoaDon(int madv, float dongia, int soluong)
        {
            return tt_bvdao.dThemCTHoaDon(madv, dongia, soluong);
        }

        public bool bThemHoaDonKhongKH(int manv, int tongtien)
        {
            return tt_bvdao.dThemHoaDonKhongKH(manv, tongtien);
        }

        public bool bCapNhatDiemTichLuy(int makh, int diemtichluy)
        {
            return tt_bvdao.bCapNhatDiemTichLuy(makh, diemtichluy);
        }
    }
}
