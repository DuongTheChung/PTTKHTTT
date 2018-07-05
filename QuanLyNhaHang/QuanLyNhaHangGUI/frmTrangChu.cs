using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO;
using DevComponents.DotNetBar;
namespace QuanLyNhaHangGUI
{
    public partial class frmTrangChu : Office2007Form
    {
        private NhanVienDTO _nV;
        public NhanVienDTO NV
        {
            get { return _nV; }
            set { _nV = value; }
        }
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            lblNv.Text = _nV.TenNV;
            if (_nV.MaCV == 1)
            {
                btnQLBep.Enabled = false;
                btnQLKho.Enabled = false;
                btnQLThuNgan.Enabled = false;
            }
            if (_nV.MaCV == 2)
            {
                btnQLNhaHang.Enabled = false;
                btnQLKho.Enabled = false;
                btnQLThuNgan.Enabled = false;
            }
            if (_nV.MaCV == 3)
            {
                btnQLBep.Enabled = false;
                btnQLNhaHang.Enabled = false;
                btnQLThuNgan.Enabled = false;
            }
            if (_nV.MaCV == 5)
            {
                btnQLBep.Enabled = false;
                btnQLKho.Enabled = false;
                btnQLNhaHang.Enabled = false;
            }
        }

        private void btnQLNhaHang_Click(object sender, EventArgs e)
        {
            frmPhanCong f = new frmPhanCong();
            f.NV = NV;
            f.FormClosed += new FormClosedEventHandler(frm_FormShowed);
            f.Show();
            this.Hide();
        }

        private void btnQLThuNgan_Click(object sender, EventArgs e)
        {
            frmQLThuNgan f = new frmQLThuNgan();
            f.NV = NV;
            f.FormClosed += new FormClosedEventHandler(frm_FormShowed);
            f.Show();
            this.Hide();
        }


        private void lblDangXuat_Click(object sender, EventArgs e)
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

        private void frm_FormShowed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
