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
            lblTenCa.Text = bus.dLayTenCaLamViec(_maCa);
            LoadMonAn();
        }

        private void LoadMonAn()
        {
            DataTable dt = bus.dLayDSMonAn();
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
            txtTenMonAn.Text = bus.dLayTenMonAn(Convert.ToInt32(cbbMaMonAn.Text));
            DataTable dt = bus.dLayKhaNangNauMon(Convert.ToInt32(cbbMaMonAn.Text),_bepTruong.MaNV);
          
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
            DataTable dt1 = bus.bKiemTraDauBepPhuTrachMonAn(Convert.ToInt32(cbbMaMonAn.Text), "Đầu bếp phụ trách chính");
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
            txtTenNV.Text = bus.dLayTenNhanVien(Convert.ToInt32(cbbMaNV.Text));
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
            int monanphutrach = Convert.ToInt32(cbbMaMonAn.Text);
            int maca = _maCa;
            CTCaLamViecDTO ctc = new CTCaLamViecDTO();
            PhuTrachMonAnDTO pt = new PhuTrachMonAnDTO();
            ctc.MaCa = maca;
            ctc.MaNV = manv;
            ctc.CV = congviec;
            pt.MaNV = manv;
            pt.MaDV = monanphutrach;
            DataTable dt = bus.dKiemTraPhuTrachMonAn(pt);
            if (dt.Rows.Count.ToString() == "0")
            {
                if (bus.bPhanCong(ctc))
                {
                    if (bus.bPhuTrachMonAn(pt))
                    {
                        MessageBox.Show("Phân công thành công");
                        LoadMonAn();
                        LoadThongTin();
                    }
                    else
                    {
                        MessageBox.Show("Phân công thất bại ,có lỗi xảy ra");
                    }
                }
                else
                {
                    MessageBox.Show("Phân công thất bại ,có lỗi xảy ra");
                }
            }
            else
            {
                MessageBox.Show("Nhân viên đã phụ trách món ăn này,lỗi");
            }
        }
    }
}
