using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DTO;
using System.Windows.Forms;

namespace DAO
{
    public class DangNhapDAO
    {
        DataProvider dp = new DataProvider();
        public bool KiemTraDangNhap(string query)
        {
            DataTable dt=new DataTable();
            dt=dp.ExecuteQuery(query);
            if(dt.Rows.Count>0)
            {
                return true;
            }
            else
                return false;
        }


        public int DangNhap(string user, string pass)
        {
            String query = "select * from TaiKhoan where TenDangNhap='" + user + "'";
            if (!KiemTraDangNhap(query))
            {
                return -1;
            }
            else
            {
                string query1 = "select * from TaiKhoan where TenDangNhap='" + user + "' and MatKhau='"+pass+"'";
                if(!KiemTraDangNhap(query1))
                {
                    return -2;
                }
                else
                {
                    return 1;
                }
            }
        }

        public NhanVienDTO getNhanVienDangNhap(string user,string pass)
        {
            DataTable dt=new DataTable();
            string query = "select * from TaiKhoan where TenDangNhap='" + user + "' and MatKhau='"+pass+"'";
             dt = dp.ExecuteQuery(query);
            string query1 = "select * from NhanVien nv, TaiKhoan tk where nv.MaNV=tk.MaNV and  nv.MaNV=" + dt.Rows[0][2].ToString();
            dt = dp.ExecuteQuery(query1);
            NhanVienDTO nv = new NhanVienDTO();
            nv.MaNV = int.Parse(dt.Rows[0][0].ToString());
            nv.TenNV = dt.Rows[0][1].ToString();
            nv.MaCV = int.Parse(dt.Rows[0][4].ToString());
            return nv;
        }
    }
}
