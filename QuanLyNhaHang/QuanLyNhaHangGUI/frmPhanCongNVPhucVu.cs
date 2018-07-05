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
    public partial class frmPhanCongNVPhucVu : Office2007Form
    {

        PhanCongBUS bus = new PhanCongBUS();
        public frmPhanCongNVPhucVu()
        {
            InitializeComponent();
        }

        private void frmPhanCongNVPhucVu_Load(object sender, EventArgs e)
        {
            LoadCaLamViec();
            LoadNVBoPhanPhucVu();
            LoadCongViec();
            LoadMonAnTaiCacQuay();
        }

        private void btnPhanCongPV_Click(object sender, EventArgs e)
        {
            if (cbbCaLamViec.Text == "" || cbbTenNhanVien.Text == "" || cbbCongViec.Text == "" || cbbMonAnPhuTrach.Text == "")
            {
                MessageBox.Show("Cần nhập thông tin đầy đủ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int maca = int.Parse(cbbCaLamViec.SelectedValue.ToString());
                int manv = int.Parse(cbbTenNhanVien.SelectedValue.ToString());
                string cv = cbbCongViec.Text;
                if (cbbCongViec.Text == "Nhân viên dọn dẹp")
                {
                    CTCaLamViecDTO dto = new CTCaLamViecDTO(maca, manv, cv);
                    if (bus.PhanCong(dto))
                    {
                        MessageBox.Show("Phân công thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Nhân viên đã được phân công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                if (cbbCongViec.Text == "Nhân viên phục vụ món ăn")
                {
                    int maMonAn = int.Parse(cbbMonAnPhuTrach.SelectedValue.ToString());
                    CTCaLamViecDTO dto = new CTCaLamViecDTO(maca, manv, cv);
                    DataTable dt = bus.KiemTraMonAnPVPhuTrach(maMonAn);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Món ăn đã được phụ trách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        PhuTrachMonAnDTO pt = new PhuTrachMonAnDTO(manv, maMonAn);
                        DataTable dt1 = bus.KiemTraNVPV(dto);
                        if (dt1.Rows.Count > 0)
                        {
                            if (bus.ThemPhuTrachMonAn(pt))
                            {
                                MessageBox.Show("Phân công thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            if (bus.PhanCong(dto))
                            {
                                if (bus.ThemPhuTrachMonAn(pt))
                                {
                                    MessageBox.Show("Phân công thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("Phân công Thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Phân công Thất bại,nhân viên đã được phân công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                }
            }
         
        }

        private void btnHuyBoPV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát hay không  ", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void LoadCaLamViec()
        {
            DataTable dt = bus.LayDSCaLamViec();
            cbbCaLamViec.DataSource = dt;
            cbbCaLamViec.DisplayMember = "TenCa";
            cbbCaLamViec.ValueMember = "MaCa";
        }

        private void LoadNVBoPhanPhucVu()
        {
            DataTable dt = bus.LayDSNhanVienTheoChucVu(7);
            cbbTenNhanVien.DataSource = dt;
            cbbTenNhanVien.DisplayMember = "TenNV";
            cbbTenNhanVien.ValueMember = "MaNV";
        }

        private void LoadCongViec()
        {
            cbbCongViec.Items.Add("Nhân viên dọn dẹp");
            cbbCongViec.Items.Add("Nhân viên phục vụ món ăn");
        }

        private void LoadMonAnTaiCacQuay()
        {
            DataTable dt = bus.LayDSMonAn();
            cbbMonAnPhuTrach.DataSource = dt;
            cbbMonAnPhuTrach.DisplayMember = "TenDV";
            cbbMonAnPhuTrach.ValueMember = "MaDV";
        }

        private void cbbCongViec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCongViec.Text == "Nhân viên dọn dẹp")
            {
                lblPTMonAn.Visible = false;
                cbbMonAnPhuTrach.Visible = false;
            }
            else
            {
                lblPTMonAn.Visible = true;
                cbbMonAnPhuTrach.Visible = true;
            }
        }
    }
}
