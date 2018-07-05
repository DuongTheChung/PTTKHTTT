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
        private DangNhapBUS bus;
        private NhanVienDTO nhanVienDTO;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            if (txtUser.Text == "" | txtPass.Text == "")
            {
                MessageBox.Show("Bạn chưa điền đầy đủ thông tin","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUser.Focus();
                return;
            }
            else
            {
                nhanVienDTO = new NhanVienDTO();
                bus = new DangNhapBUS();

                int kq = bus.DangNhap(txtUser.Text, txtPass.Text);
                if (kq == -1)
                {
                    MessageBox.Show("Tài khoản đăng nhập không chính xác", "Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (kq == -2)
                    {
                        MessageBox.Show("Mật khẩu đăng nhập không chính xác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (kq == 1)
                        {
                            nhanVienDTO = bus.getNhanVienDangNhap(txtUser.Text, txtPass.Text);
                            frmTrangChu f = new frmTrangChu();
                            f.NV = nhanVienDTO;
                            f.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                            f.Show();
                            this.Hide();

                        }
                    }
                }

            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát hay không  ", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

    }
}
