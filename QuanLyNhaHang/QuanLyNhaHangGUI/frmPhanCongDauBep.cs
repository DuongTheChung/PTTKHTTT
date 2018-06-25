using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using BUS;
using DTO;
namespace QuanLyNhaHangGUI
{
    public partial class frmPhanCongDauBep : Office2007Form
    {
        PhanCongBUS bus = new PhanCongBUS();
        public frmPhanCongDauBep()
        {
            InitializeComponent();
        }

        private void frmPhanCongDauBep_Load(object sender, EventArgs e)
        {
            LoadCongViec();
            LoadDSCaLamViec();
            LoadDSNhanVien();
        }

        private void LoadCongViec()
        {
            cbbCongViec.Text = "Bếp trưởng";     
        }

        private void LoadDSCaLamViec()
        {
            DataTable dt = bus.dLayDSCaLamViec();
            cbbCaLamViec.DataSource = dt;
            cbbCaLamViec.DisplayMember = "MaCa";
        }

        private void LoadDSNhanVien()
        {
            DataTable dt = bus.dLayDSNhanVienTheoChucVu(8);
            cbbMaNV.DataSource = dt;
            cbbMaNV.DisplayMember = "MaNV";
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            CTCaLamViecDTO dto = new CTCaLamViecDTO();
            int maca = Convert.ToInt32(cbbCaLamViec.Text);
            int manv = Convert.ToInt32(cbbMaNV.Text);
            dto.MaCa = maca;
            dto.MaNV = manv;
            dto.CV = cbbCongViec.Text;
            DataTable dt1 = bus.dKiemTraBepTruong(maca, cbbCongViec.Text);
            if (dt1.Rows.Count.ToString() != "0")
            {
                MessageBox.Show("Ca đã được phân công bếp trưởng");
                frmPhanCongDauBep_MonAn f = new frmPhanCongDauBep_MonAn();
                DataTable dt = bus.dLayMaBepTruong(maca, cbbCongViec.Text);
                int mabeptruong = Convert.ToInt32(dt.Rows[0]["MaNV"].ToString());
                string tenbeptruong = dt.Rows[0]["TenNV"].ToString();
                NhanVienDTO nv = new NhanVienDTO();
                nv.MaNV = mabeptruong;
                nv.TenNV = tenbeptruong;
                f.MaCa = maca;
                f.BepTruong = nv;
                f.ShowDialog();
            }
            else
            {
                DataTable dt2 = bus.dKTNhanVienCoLaBepTruong(dto.MaNV, cbbCongViec.Text);
                if (dt2.Rows.Count.ToString() == "0")
                {
                    if (bus.bPhanCong(dto))
                    {
                        MessageBox.Show("Phân công bếp trưởng thành công");
                        frmPhanCongDauBep_MonAn f = new frmPhanCongDauBep_MonAn();
                        int mabeptruong = dto.MaNV;
                        string tenbeptruong = bus.dLayTenNhanVien(dto.MaNV);
                        NhanVienDTO nv = new NhanVienDTO();
                        nv.MaNV = mabeptruong;
                        nv.TenNV = tenbeptruong;
                        f.MaCa = maca;
                        f.BepTruong = nv;
                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra");
                    }
                }
                else
                {
                    MessageBox.Show("Nhân viên đã được phân công");
                }
            }
        }

        private void cbbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tennv = bus.dLayTenNhanVien(Convert.ToInt32(cbbMaNV.Text));
            txtTenNhanVien.Text = tennv;
        }

        private void cbbCaLamViec_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tenca = bus.dLayTenCaLamViec(Convert.ToInt32(cbbCaLamViec.Text));
            txtTenCa.Text = tenca;

        }
    }
}
