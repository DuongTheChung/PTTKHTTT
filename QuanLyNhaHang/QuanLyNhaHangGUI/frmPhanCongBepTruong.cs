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
    public partial class frmPhanCongBepTruong : Office2007Form
    {
        PhanCongBUS bus = new PhanCongBUS();
        public frmPhanCongBepTruong()
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
            DataTable dt = bus.LayDSCaLamViec();
            cbbCaLamViec.DataSource = dt;
            cbbCaLamViec.DisplayMember = "MaCa";
        }

        private void LoadDSNhanVien()
        {
            DataTable dt = bus.LayDSNhanVienTheoChucVu(8);
            cbbMaNV.DataSource = dt;
            cbbMaNV.DisplayMember = "MaNV";
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            int maca = Convert.ToInt32(cbbCaLamViec.Text);
            int manv = Convert.ToInt32(cbbMaNV.Text);
            CTCaLamViecDTO dto = new CTCaLamViecDTO(maca,manv,cbbCongViec.Text);
            DataTable dt1 = bus.KiemTraCaDaCoBepTruongChua(maca, cbbCongViec.Text);
            if (dt1.Rows.Count.ToString() != "0")
            {
                MessageBox.Show("Ca đã được phân công bếp trưởng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmPhanCongDauBep_MonAn f = new frmPhanCongDauBep_MonAn();
                DataTable dt = bus.LayMaBepTruongTheoCa(maca, cbbCongViec.Text);
                int mabeptruong = Convert.ToInt32(dt.Rows[0]["MaNV"].ToString());
                string tenbeptruong = dt.Rows[0]["TenNV"].ToString();
                NhanVienDTO nv = new NhanVienDTO(mabeptruong,tenbeptruong);
                f.MaCa = maca;
                f.BepTruong = nv;
                f.ShowDialog();
            }
            else
            {
                DataTable dt2 = bus.KiemTraNhanVienCoLaBepTruongKhong(dto.MaNV, cbbCongViec.Text);
                if (dt2.Rows.Count.ToString() == "0")
                {
                    if (bus.PhanCong(dto))
                    {
                        MessageBox.Show("Phân công bếp trưởng thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmPhanCongDauBep_MonAn f = new frmPhanCongDauBep_MonAn();
                        int mabeptruong = dto.MaNV;
                        string tenbeptruong = bus.LayTenNhanVien(dto.MaNV);
                        NhanVienDTO nv = new NhanVienDTO(mabeptruong,tenbeptruong);
                        f.MaCa = maca;
                        f.BepTruong = nv;
                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Nhân viên đã được phân công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cbbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tennv = bus.LayTenNhanVien(Convert.ToInt32(cbbMaNV.Text));
            txtTenNhanVien.Text = tennv;
        }

        private void cbbCaLamViec_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tenca = bus.LayTenCaLamViec(Convert.ToInt32(cbbCaLamViec.Text));
            txtTenCa.Text = tenca;

        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát hay không  ", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
