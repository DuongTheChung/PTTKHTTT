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

        ThuNganThanhToanBUS bus = new ThuNganThanhToanBUS();
        TheKhachHangDTO tkh = new TheKhachHangDTO();

       
        private void btnCapThe_Click(object sender, EventArgs e)
        {
            if (txtHoten.Text == "" || txtSDT.Text == "" || txtCMND.Text == "" || txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa điền đầy đủ thông tin", "Có lỗi xảy ra");
                return;
            }
            else
            {
                tkh.TenKh=txtHoten.Text;
                tkh.Diachi=txtDiaChi.Text;
                tkh.Sodienthoai=txtSDT.Text;
                tkh.CMND=txtCMND.Text;
                if (bus.bCapTheKhachHang(tkh, _maNV))
                {
                    MessageBox.Show("Cấp thẻ thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cấp thẻ thất bại");
                }
            }
        }
    }
}
