using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using DTO;

namespace BUS
{
    public class DangNhapBUS
    {
        DangNhapDAO dao = new DangNhapDAO();
        public int DangNhap(string user, string pass)
        {
            return dao.DangNhap(user, pass);
        }
        public NhanVienDTO getNhanVienDangNhap(string user, string pass)
        {
            return dao.getNhanVienDangNhap(user, pass);
        }
    }
}
