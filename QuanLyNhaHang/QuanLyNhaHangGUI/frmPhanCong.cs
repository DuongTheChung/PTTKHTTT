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
namespace QuanLyNhaHangGUI
{
    public partial class frmPhanCong : Office2007Form
    {
        PhanCongBUS bus = new PhanCongBUS();
        public frmPhanCong()
        {
            InitializeComponent();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            frmPhanCongDauBep f = new frmPhanCongDauBep();
            f.ShowDialog();
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
            DataTable dt = bus.dLayDSPhanCong();
            dgvDsPhanCong.DataSource = dt;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvTimKiem.DataSource = bus.dTimKiemDauBep(txtTimKiem.Text);
            lblKetQua.Text = "Tìm thấy " + bus.dTimKiemDauBep(txtTimKiem.Text).Rows.Count + " kết quả";
        }

    }
}
