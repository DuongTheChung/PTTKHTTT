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
    public partial class frmPhanCongDauBep_MonAn : Office2007Form
    {
        PhanCongBUS bus = new PhanCongBUS();
        public frmPhanCongDauBep_MonAn()
        {
            InitializeComponent();
        }

        private int _maCa;
        public int MaCa
        {
            get { return _maCa; }
            set { _maCa = value; }
        }

        private NhanVienDTO  _bepTruong;
        public NhanVienDTO BepTruong
        {
            get { return _bepTruong; }
            set { _bepTruong = value; }
        }

        private void frmPhanCongDauBep_MonAn_Load(object sender, EventArgs e)
        {
            lblBepTruong.Text = _bepTruong.TenNV.ToString();
            lblMaCa.Text = _maCa.ToString();
            lblTenCa.Text = bus.LayTenCaLamViec(_maCa);
            LoadMonAn();
        }

        private void LoadMonAn()
        {
            DataTable dt = bus.LayDSMonAn();
            cbbMaMonAn.DataSource = dt;
            cbbMaMonAn.DisplayMember = "MaDV";
        }
        private void LoadThongTin()
        {
            cbbMaNV.ResetText();
            txtTenNV.Text = "";
        }

        private void cbbMaMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenMonAn.Text = bus.LayTenMonAn(Convert.ToInt32(cbbMaMonAn.Text));

            //Lay kha nang nau mon cua cac nhan vien tru bep truong ra
            DataTable dt = bus.LayKhaNangNauMonKhacNV(Convert.ToInt32(cbbMaMonAn.Text),_bepTruong.MaNV);
          
            if (dt.Rows.Count.ToString() == "0")
            {
                cbbMaNV.ResetText();
                txtTenNV.Text = "";
            }
            else
            {
                cbbMaNV.DataSource = dt;
                cbbMaNV.DisplayMember = "MaNV";
            }

            //Kiem tra mon an da co dau bep phu trach chinh chua
            DataTable dt1 = bus.KiemTraDauBepChinhMonAn(Convert.ToInt32(cbbMaMonAn.Text), "Đầu bếp phụ trách chính");
            if (dt1.Rows.Count.ToString() == "0")
            {
                cbbCongViec.Text = "Đầu bếp phụ trách chính";
            }
            else
            {
                cbbCongViec.Text="Đầu bếp phụ nấu món";

            }
           
        }

        private void cbbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenNV.Text = bus.LayTenNhanVien(Convert.ToInt32(cbbMaNV.Text));
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
        
            if (cbbMaMonAn.Text == "" || cbbMaNV.Text == "")
            {
                MessageBox.Show("Thông tin chưa đầy đủ,lỗi");
                return;
            }
            int manv = Convert.ToInt32(cbbMaNV.Text);
            string congviec = cbbCongViec.Text;
            int mamonan = Convert.ToInt32(cbbMaMonAn.Text);
            int maca = _maCa;
            CTCaLamViecDTO ctc = new CTCaLamViecDTO(maca,manv,congviec);
            PhuTrachMonAnDTO pt = new PhuTrachMonAnDTO(manv,mamonan);

            DataTable dt = bus.KiemTraNVDaPhuTrachMonAnChua(pt);
            if (dt.Rows.Count.ToString() == "0")
            {
                if (bus.PhanCong(ctc))
                {
                    if (bus.ThemPhuTrachMonAn(pt))
                    {
                        MessageBox.Show("Phân công thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMonAn();
                        LoadThongTin();
                    }
                    else
                    {
                        MessageBox.Show("Phân công thất bại ,có lỗi xảy ra", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (bus.ThemPhuTrachMonAn(pt))
                    {
                        MessageBox.Show("Phân công thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMonAn();
                        LoadThongTin();
                    }
                    else
                    {
                        MessageBox.Show("Phân công thất bại ,có lỗi xảy ra", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Nhân viên đã phụ trách món ăn này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
