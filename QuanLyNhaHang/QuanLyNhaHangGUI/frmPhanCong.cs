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
    public partial class frmPhanCong : Office2007Form
    {
        PhanCongBUS bus = new PhanCongBUS();
        public frmPhanCong()
        {
            InitializeComponent();
        }

        private NhanVienDTO _nV;
        public NhanVienDTO NV
        {
            get { return _nV; }
            set { _nV = value; }
        }
       

        private void frmPhanCong_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
        
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            LoadDanhSach();
        }

        private void LoadDanhSach()
        {
            DataTable dt = bus.LayDSPhanCong();
            dgvDsPhanCong.DataSource = dt;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvTimKiem.DataSource = bus.TimKiemDauBep(txtTimKiem.Text);
            lblKetQua.Text = "Tìm thấy " + bus.TimKiemDauBep(txtTimKiem.Text).Rows.Count + " kết quả";
        }

        private void btnPhanCongBepTruong_Click(object sender, EventArgs e)
        {
            frmPhanCongBepTruong f = new frmPhanCongBepTruong();
            f.ShowDialog();
        }

        private void lbDangXuat_Click(object sender, EventArgs e)
        {
            frmDangNhap f = new frmDangNhap();
            f.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            f.Show();
            this.Hide();
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void btnPhanCongPV_Click(object sender, EventArgs e)
        {
            frmPhanCongNVPhucVu f = new frmPhanCongNVPhucVu();
            f.ShowDialog();
        }
    }
}
