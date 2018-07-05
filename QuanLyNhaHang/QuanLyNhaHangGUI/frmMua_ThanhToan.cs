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
    public partial class frmMua_ThanhToan : Office2007Form
    {
        private int manv;

        public int Manv
        {
            get { return manv; }
            set { manv = value; }
        }

        ThuNganBUS bus = new ThuNganBUS();
        TheKhachHangDTO tkh = new TheKhachHangDTO();

        public frmMua_ThanhToan()
        {
            InitializeComponent();
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            LayDSDichVuKhac();
            txtTienGiam.Text = "0";
            rbtTTTienMat.Checked = true;

        }

        private void LayDSDichVuKhac()
        {
            DataTable dt = bus.LayDSDichVuKhac();
            cbbTenDVKhac.DataSource = dt;
            cbbTenDVKhac.DisplayMember = "TenDV";
            cbbTenDVKhac.ValueMember = "MaDV";
        }

        
        private void dgvDSDichVu_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int chisocot = dgvDSDichVu.CurrentCell.ColumnIndex;     //lấy chỉ số cột
            string tencot = dgvDSDichVu.Columns[chisocot].Name.ToString();   //lấy cột cần thêm sự kiện
            if (tencot == "txtSoLuong")
            {
                if (e.Control is TextBox)
                {
                    TextBox textbox = e.Control as TextBox;
                    textbox.KeyPress += new KeyPressEventHandler(this.txtSoLuong_KeyPress);
                }
            }

            if (tencot == "cbbTenDVKhac")
            {
                ComboBox combobox1 = e.Control as ComboBox;
                combobox1.SelectedIndexChanged += new EventHandler(cbbTenDVKhac_SelectedIndexChange);

            }

        }

        //Chi nhap so cho TextBox So luong 
        void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Lay gia ve tuong ung voi loai dich vu
        void cbbTenDVKhac_SelectedIndexChange(object sender, EventArgs e)
        {
            int dong = dgvDSDichVu.CurrentCell.RowIndex;
            string selectedvalue = ((ComboBox)sender).SelectedValue.ToString();
            int madv = int.Parse(selectedvalue);
            float giave = Convert.ToSingle(bus.LayGiaDichVuKhac(madv));
            dgvDSDichVu.Rows[dong].Cells["txtDonGia"].Value = giave;
            dgvDSDichVu.Rows[dong].Cells["txtMaDVKhac"].Value = madv;

        }

        //Event button tren datagirdView
        private void dgvDSDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int dong = dgvDSDichVu.CurrentCell.RowIndex;
            TinhThanhTien(dong);
        }

        private void dgvDSDichVu_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int dong = dgvDSDichVu.CurrentCell.RowIndex;
            TinhThanhTien(dong);
            TinhThanhTien();
        }


        //Tinh tien
        private void TinhThanhTien(int dong)
        {
            try
            {
                float dongia = Convert.ToSingle(dgvDSDichVu.Rows[dong].Cells["txtDonGia"].Value);
                int soluongve = Convert.ToInt32(dgvDSDichVu.Rows[dong].Cells["txtSoLuong"].Value);
                float thanhtien = dongia * soluongve;
                dgvDSDichVu.Rows[dong].Cells["txtThanhTien"].Value = thanhtien;
            }
            catch { }
        }
        private void TinhThanhTien()
        {
            float tong = 0;
            for (int i = 0; i < dgvDSDichVu.Rows.Count; i++)
            {
                tong += Convert.ToSingle(dgvDSDichVu.Rows[i].Cells["txtThanhTien"].Value);
            }
            txtTongTien.Text = tong.ToString();
        }
        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            float tongtien = float.Parse(txtTongTien.Text);
            float tiengiam = float.Parse(txtTienGiam.Text);
            float tienthanhtoan = tongtien - tiengiam;
            txtTienThanhToan.Text = tienthanhtoan.ToString();
        }
        private void txtTienKhachTra_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTienKhachTra.Text != "")
                {
                    float tienthanhtoan = float.Parse(txtTienThanhToan.Text);
                    float tienkhachtra = float.Parse(txtTienKhachTra.Text);
                    float tienthua = tienkhachtra - tienthanhtoan;
                    txtTienThua.Text = tienthua.ToString();
                }
                else
                {
                    txtTienThua.Text = "";
                }
            }
            catch { }
        }
        private void txtTienKhachTra_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void btnTong_Click(object sender, EventArgs e)
        {
            float tong = 0;
            for (int i = 0; i < dgvDSDichVu.Rows.Count; i++)
            {
                tong += Convert.ToSingle(dgvDSDichVu.Rows[i].Cells["txtThanhTien"].Value);
            }
            txtTongTien.Text = tong.ToString();
        }

        private void btnThanhToan_Click_1(object sender, EventArgs e)
        {
            int makh = 0;
            float tongtien = float.Parse(txtTongTien.Text);
            float tiengiam = float.Parse(txtTienGiam.Text);
            float tienthanhtoan = float.Parse(txtTienThanhToan.Text);
            if (tongtien <= 0)
            {
                MessageBox.Show("Bạn chưa nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (txtTienKhachTra.Text == "" || int.Parse(txtTienThua.Text) < 0)
                {
                    MessageBox.Show("Chưa đủ tiền thanh toán. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (tongtien < 500000)
                    {
                        HoaDonDTO dto = new HoaDonDTO(tongtien, tiengiam, tienthanhtoan, -1, manv);
                        if (bus.ThemHoaDonKhongTheKH(dto))
                        {

                            ThemCTHoaDon();
                        }
                    }
                    else if (tongtien >= 500000 && txtTheKhachHang.Text == "")
                    {
                        frmCapTheKhachHang ct = new frmCapTheKhachHang();
                        ct.MaNV = manv;
                        ct.Show();
                    }
                    else if (tongtien >= 500000 && txtTheKhachHang.Text != "")
                    {
                        makh = int.Parse(txtTheKhachHang.Text);
                        HoaDonDTO dto = new HoaDonDTO(tongtien, tiengiam, tienthanhtoan, makh, manv);
                        if (bus.ThemHoaDonCoTheKhachHang(dto))
                        {

                            ThemCTHoaDon();
                        }
                        bus.CapNhatDiemTichLuy(makh, tkh.TinhDiemTichLuy(tongtien));
                    }
                }
            }
            
        }

        private void txtTheKhachHang_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (txtTheKhachHang.Text == "")
            {
                dgvTheKhachHang.Visible = false;
                txtTienGiam.Text = "0";
            }
            else
            {
                dt = bus.LayTheKHTheoMa(int.Parse(txtTheKhachHang.Text));
                if (dt.Rows.Count == 0)
                {
                    dgvTheKhachHang.Visible = false;
                }
                else
                {
                    dgvTheKhachHang.DataSource = dt;
                    dgvTheKhachHang.Visible = true;
                }
            }
        }

        private void dgvTheKhachHang_MouseClick(object sender, MouseEventArgs e)
        {
            XacDinhPhanTramGiam();
        }

        private void dgvTheKhachHang_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            XacDinhPhanTramGiam();
        }

        private void dgvTheKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            XacDinhPhanTramGiam();
        }

        private void XacDinhPhanTramGiam()
        {
            txtTienGiam.Text = "0";
            txtPtGiamGia.Text = "0";
            dgvTheKhachHang.Visible = false;
        }

        private void ThemCTHoaDon()
        {
            int madv, soluong;
            float dongia;
            for (int i = 0; i < dgvDSDichVu.Rows.Count - 1; i++)
            {
                madv = int.Parse(dgvDSDichVu.Rows[i].Cells["txtMaDVKhac"].Value.ToString());
               
                dongia = float.Parse(dgvDSDichVu.Rows[i].Cells["txtDonGia"].Value.ToString());
                soluong = int.Parse(dgvDSDichVu.Rows[i].Cells["txtSoLuong"].Value.ToString());
                CTHoaDonDTO dto = new CTHoaDonDTO(madv, soluong, dongia);
                bus.ThemCTHoaDon(dto);
            }
            MessageBox.Show("Thanh toán thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }

        private void rbtTTTienMat_CheckedChanged(object sender, EventArgs e)
        {
            lblTTAtm.Visible = false;
            lblTienKhachTra.Visible = true;
            lblTienThua.Visible = true;
            lblvnd.Visible = true;
            lblvnd1.Visible = true;
            txtTienKhachTra.Visible = true;
            txtTienThua.Visible = true;
            btnThanhToan.Visible = true;

        }

        private void rbtTTATM_CheckedChanged(object sender, EventArgs e)
        {
            lblTTAtm.Visible = true;
            lblTienKhachTra.Visible = false;
            lblTienThua.Visible = false;
            lblvnd.Visible = false;
            lblvnd1.Visible = false;
            txtTienKhachTra.Visible = false;
            txtTienThua.Visible = false;
            btnThanhToan.Visible = false;

        }
    }

}
