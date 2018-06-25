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
using System.IO;
namespace QuanLyNhaHangGUI
{
    public partial class frmThuNgan : Office2007Form
    {
  
        public frmThuNgan()
        {
            InitializeComponent();
        }
        ThuNganBUS tnbus = new ThuNganBUS();
        DataTable dt = new DataTable();

        private NhanVienDTO _nV;
        public NhanVienDTO NV
        {
            get { return _nV; }
            set { _nV = value; }
        }

        private void frmThuNgan_Load(object sender, EventArgs e)
        {
            
            timer1.Start();
            lbTenNV.Text = _nV.TenNV;
            LayDSNuocUong();
            LayDSBuffet(2);
            LayThongTinGiaVe();
            LayGiaVe();
        }

        private void rdbKhaiVi_CheckedChanged(object sender, EventArgs e)
        {
           LayDSBuffet(1);
        }

        private void rdbMonNuong_CheckedChanged(object sender, EventArgs e)
        {
            LayDSBuffet(2);
        }

        private void rdbMonLau_CheckedChanged(object sender, EventArgs e)
        {
            LayDSBuffet(3);
        }

        private void rdbTrangMieng_CheckedChanged(object sender, EventArgs e)
        {
            LayDSBuffet(4);
        }

        private void txtTenNuocGK_TextChanged(object sender, EventArgs e)
        {
            dgvDichVuKhac.DataSource = tnbus.bTimNuocUong(txtTenNuocGK.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbNgayHT.Text = DateTime.Today.DayOfWeek.ToString() + " , " + DateTime.Now.ToShortDateString();
            lbThoiGian.Text = DateTime.Now.ToShortTimeString();
        }

        private void lbThoiGian_TextChanged(object sender, EventArgs e)
        {
            LayThongTinGiaVe();
        }

        private void tabKHTT_Click(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = tnbus.bLayDSKHThanThiet();
        }

        private void txtTenKhachHang_TextChanged(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = tnbus.bTimKhThanThiet(txtTenKhachHang.Text);
        }

        private void dgvDichVuKhac_DoubleClick(object sender, EventArgs e)
        {
            int dong = dgvDichVuKhac.CurrentCell.RowIndex;
            string madv = dgvDichVuKhac.Rows[dong].Cells["madichvu"].Value.ToString();
            frmThuNganThanhToan_BanVe tt = new frmThuNganThanhToan_BanVe();
            tt.lbDSDichVu.Text = "Danh sách Thức uống";
            tt.lbTieuDe.Text = "THANH TOÁN";
            tt.dgvDichVuKhac.Visible = true;
            tt.dgvDSBuffet.Visible = false;
            tt.lbBuoi.Visible = false;
            tt.lbNgayThuong.Visible = false;
            tt.lbChuThichBuoi.Visible = false;
            tt.lbMaDV.Text = madv;

            tt.Text = lbTenNV.Text + " thanh toán";
            tt.Manv = _nV.MaNV;
            tt.ShowDialog();
        }

        public void LayDSNuocUong()
        {
           dgvDichVuKhac.DataSource = tnbus.bLayDSNuocUong();
        }

        public void LayDSBuffet(int loaiBuffet)
        {
            dgBuffet.DataSource = tnbus.bLayDSBuffet(loaiBuffet); 
        }

        
        public void LayThongTinGiaVe()
        {
           
            //Lấy buổi trong ngày
            string giohientai = DateTime.Now.ToString();
            if (DateTime.Compare(DateTime.Parse(giohientai), DateTime.Parse("6:00 PM")) >= 0)
            {
                cbBuoi.Text = "Tối";
            }
            else
                cbBuoi.Text = "Trưa";

            //Lấy thứ ngày trong tuần
            string thu = DateTime.Today.DayOfWeek.ToString();
            if (thu == "Satuday" || thu == "Sunday")
            {
                cbNgayThuong.Text = "Thứ 7 CN";
            }
            else
                cbNgayThuong.Text = "Ngày thường";

            //Lấy giá vé theo thời gian và đối tượng
            LayGiaVe();
             
        }

        public void LayGiaVe()
        {
            lbDonGiaVe.Text = tnbus.bLayGiaVe(cbBuoi.Text, cbNgayThuong.Text, cbDoiTuong.Text);
        }

        private void cbDoiTuong_SelectedIndexChanged(object sender, EventArgs e)
        {
           LayGiaVe();
        }

        private void dgBuffet_DoubleClick(object sender, EventArgs e)
        {
            int dong = dgBuffet.CurrentCell.RowIndex;
            string madv = dgBuffet.Rows[dong].Cells["madvbuffet"].Value.ToString();
            frmThuNganThanhToan_BanVe tt = new frmThuNganThanhToan_BanVe();
            tt.lbDSDichVu.Text = "Danh sách Buffet";
            tt.lbTieuDe.Text = "BÁN VÉ";
            tt.dgvDichVuKhac.Visible = false;
            tt.dgvDSBuffet.Visible = true;
            tt.lbMaDV.Text = madv;
            tt.lbBuoi.Text = cbBuoi.Text;
            tt.lbNgayThuong.Text = cbNgayThuong.Text;
            tt.Text = lbTenNV.Text + " bán vé";
            tt.Manv = _nV.MaNV;
            tt.lbDoiTuong.Text = cbDoiTuong.Text;
            tt.lbgiave.Text = lbDonGiaVe.Text;
            tt.ShowDialog();
           
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
    }
}
