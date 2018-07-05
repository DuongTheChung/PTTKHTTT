using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DTO;
using BUS;

namespace QuanLyNhaHangGUI
{
    public partial class frmQLThuNgan : Office2007Form
    {

        ThuNganBUS bus = new ThuNganBUS();
        private NhanVienDTO _nV;
        public NhanVienDTO NV
        {
            get { return _nV; }
            set { _nV = value; }
        }
        public frmQLThuNgan()
        {
            InitializeComponent();
        }

        private void frmQLThuNgan_Load(object sender, EventArgs e)
        {
            LayDSDichVuKhac();
            LayDSDichVuBuffet();
        }

        private void LayDSDichVuKhac()
        {
            DataTable dt = bus.LayDSDichVuKhac();
            dgvDVKhac.DataSource = dt;

        }

        private void LayDSDichVuBuffet()
        {
            DataTable dt = bus.LayDSDichVuBuffet();
            dgvDichVuBuffet.DataSource = dt;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            frmMua_ThanhToan f = new frmMua_ThanhToan();
            f.Manv = _nV.MaNV;
            f.ShowDialog();
        }

        private void btnBanVe_Click(object sender, EventArgs e)
        {
            frmBanVe_ThanhToan f = new frmBanVe_ThanhToan();
            f.Manv = _nV.MaNV;
            f.ShowDialog();
        }
    }
}
