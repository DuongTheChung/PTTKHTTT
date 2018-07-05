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
    public partial class frmCapTheKhachHang : Office2007Form
    {
        public frmCapTheKhachHang()
        {
            InitializeComponent();
        }

        private int _maNV;
        public int MaNV
        {
            get { return _maNV; }
            set { _maNV = value; }
        }

        ThuNganBUS bus = new ThuNganBUS();


        private void btnCapThe_Click_1(object sender, EventArgs e)
        {
            if (txtHoten.Text == "" || txtSDT.Text == "" || txtCMND.Text == "" || txtDiaChi.Text == ""||txtCMND.Text.Length>9||txtSDT.Text.Length>11)
            {
                MessageBox.Show("Thông tin chưa chính xác", "Có lỗi xảy ra");
                return;
            }
            else
            {

                TheKhachHangDTO tkh = new TheKhachHangDTO(txtHoten.Text, txtDiaChi.Text, txtSDT.Text, txtCMND.Text);
                DataTable dt = new DataTable();
                dt = bus.KiemTraTheKhachHangDaTonTaiChua(tkh.TenKh, tkh.CMND);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Khách hàng đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                else
                {
                    if (bus.CapTheKhachHang(tkh, _maNV))
                    {
                        MessageBox.Show("Cấp thẻ thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cấp thẻ thất bại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;

            }
        }
    }
}
