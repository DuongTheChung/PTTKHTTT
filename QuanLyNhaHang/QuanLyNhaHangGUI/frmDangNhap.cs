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
    public partial class frmDangNhap : Office2007Form
    {
        private DangNhapBUS dangNhapBUS;
        private NhanVienDTO nhanVienDTO;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát hay không  ", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" | txtPass.Text == "")
            {
                MessageBox.Show("Bạn chưa điền đầy đủ thông tin", "Có lỗi xảy ra");
                txtUser.Focus();
                return;
            }
            else
            {
                nhanVienDTO = new NhanVienDTO();
                dangNhapBUS = new DangNhapBUS();
                int kqDangNhap;
                nhanVienDTO = dangNhapBUS.DangNhap(txtUser.Text, txtPass.Text);
                kqDangNhap = nhanVienDTO.MaCV;
                if (kqDangNhap == 3)
                {
                    frmThuNgan f = new frmThuNgan();
                    f.NV = nhanVienDTO;
                    f.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                    f.Show();
                    this.Hide();
                }

            }
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
