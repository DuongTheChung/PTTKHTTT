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
    public partial class frmBanVe_ThanhToan : Office2007Form
    {


        ThuNganBUS bus = new ThuNganBUS();
        TheKhachHangDTO tkh = new TheKhachHangDTO();

        private int manv;

        public int Manv
        {
            get { return manv; }
            set { manv = value; }
        }

        
        public frmBanVe_ThanhToan()
        {
            InitializeComponent();
        }


        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            LayDSDichVuBuffet();
            LayBuoiVaNgayHienTai();
            dgvDSVeDat.Rows[0].Cells["cbbDoiTuong"].Value = "Người lớn";
            cbbDoiTuong.Items.Add("Người lớn");
            cbbDoiTuong.Items.Add("Trẻ em");
            txtTienGiam.Text = "0";
            rbtTTTienMat.Checked = true;

        }

        private void LayDSDichVuBuffet()
        {
            DataTable dt = bus.LayDSDichVuBuffet();
            cbbTenBuffet.DataSource = dt;
            cbbTenBuffet.DisplayMember = "TenDV";
            cbbTenBuffet.ValueMember = "MaDV";
            
        }


        private void dgvDSVeDat_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int chisocot = dgvDSVeDat.CurrentCell.ColumnIndex;     //lấy chỉ số cột
            string tencot = dgvDSVeDat.Columns[chisocot].Name.ToString();   //lấy cột cần thêm sự kiện
            if (tencot == "txtSoLuongVe")
            {
                if (e.Control is TextBox)
                {
                    TextBox textbox = e.Control as TextBox;
                    textbox.KeyPress += new KeyPressEventHandler(this.txtSoLuongVe_KeyPress);
                }
            }

            if (tencot == "cbbDoiTuong")
            {
                ComboBox combobox = e.Control as ComboBox;
                combobox.SelectedIndexChanged += new EventHandler(this.cbbDoiTuong_SelectedIndexChanged);

            }

            if (tencot == "cbbTenBuffet")
            {
                ComboBox combobox1 = e.Control as ComboBox;
                combobox1.SelectedIndexChanged += new EventHandler(this.cbbTenBuffet_SelectedIndexChanged);

            }

        }

        //

        private void dgvDSVeDat_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int dong = dgvDSVeDat.CurrentCell.RowIndex;
            TinhThanhTien(dong);
            TinhThanhTien();
        }


        //Chi nhap so cho TextBox So luong ve
        void txtSoLuongVe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Lay gia ve tuong ung 
        void cbbDoiTuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            int dong = dgvDSVeDat.CurrentCell.RowIndex;
            int selectedIndex = ((ComboBox)sender).SelectedIndex;
            float giave = 0;
            if (selectedIndex == 0)
            {
                giave = Convert.ToSingle(bus.LayGiaVeDichVuBuffet(lblBuoi.Text, lblLoaiNgay.Text, "Người lớn"));
                dgvDSVeDat.Rows[dong].Cells["txtGiaVe"].Value = giave;
                TinhThanhTien(dong);
            }
            else
            {
                giave = Convert.ToSingle(bus.LayGiaVeDichVuBuffet(lblBuoi.Text, lblLoaiNgay.Text, "Trẻ em"));
                dgvDSVeDat.Rows[dong].Cells["txtGiaVe"].Value = giave;
                TinhThanhTien(dong);
            }

        }

        //Lay ma dich vu  buffet tuong ung 
        void cbbTenBuffet_SelectedIndexChanged(object sender, EventArgs e)
        {
            int dong = dgvDSVeDat.CurrentCell.RowIndex;
            int selectedIndex = ((ComboBox)sender).SelectedIndex;
            string selectedvalue = ((ComboBox)sender).SelectedValue.ToString();
            int madv = int.Parse(selectedvalue);
            dgvDSVeDat.Rows[dong].Cells["txtMaBuffet"].Value = madv;

        }

        //Tinh tien tung dong
        private void TinhThanhTien(int dong)
        {
            try
            {
                float giave = Convert.ToSingle(dgvDSVeDat.Rows[dong].Cells["txtGiaVe"].Value);
                int soluongve = Convert.ToInt32(dgvDSVeDat.Rows[dong].Cells["txtSoLuongVe"].Value);   
                float thanhtien = giave * soluongve;
                dgvDSVeDat.Rows[dong].Cells["txtThanhTien"].Value = thanhtien;
            }
            catch { }
        }

        //Tinh tong tat ca cac dong
        private void TinhThanhTien()
        {
            float tong = 0;
            for (int i = 0; i < dgvDSVeDat.Rows.Count; i++)
            {
                tong += Convert.ToSingle(dgvDSVeDat.Rows[i].Cells["txtThanhTien"].Value);
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

        private void txtTheKhachHang_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (txtTheKhachHang.Text == "")
            {
                dgvTheKhachHang.Visible = false;
                txtTienGiam.Text = "0";
                txtPtGiamGia.Text = "";
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

        private void txtTienGiam_TextChanged(object sender, EventArgs e)
        {
            if (txtTienGiam.Text == "0")
            {
                txtTienThanhToan.Text = txtTongTien.Text;
            }
            else
            {
                txtTienThanhToan.Text = (float.Parse(txtTongTien.Text) - float.Parse(txtTienGiam.Text)).ToString();
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
            int dong = dgvTheKhachHang.CurrentCell.RowIndex;
            txtTheKhachHang.Text = dgvTheKhachHang.Rows[dong].Cells["MaKH"].Value.ToString();
            tkh.Diemtichluy = Convert.ToInt32(dgvTheKhachHang.Rows[dong].Cells["DiemTichLuy"].Value);
            float tiengiam = ((float.Parse(txtTongTien.Text)) * (tkh.TinhPhanTramGiam())) / 100;
            txtTienGiam.Text = tiengiam.ToString();
            txtPtGiamGia.Text = tkh.TinhPhanTramGiam().ToString();
            dgvTheKhachHang.Visible = false;
        }

        private void ThemCTHoaDon()
        {
            int madv, soluongve;
            float giave;
            for (int j = 0; j < dgvDSVeDat.Rows.Count - 1; j++)
            {
                madv = int.Parse(dgvDSVeDat.Rows[j].Cells["txtMaBuffet"].Value.ToString());
                giave = int.Parse(dgvDSVeDat.Rows[j].Cells["txtGiaVe"].Value.ToString());
                soluongve = int.Parse(dgvDSVeDat.Rows[j].Cells["txtSoLuongVe"].Value.ToString());
                CTHoaDonDTO dto = new CTHoaDonDTO(madv, soluongve, giave);
                if(!bus.ThemCTHoaDon(dto))
                {
                    MessageBox.Show("Thanh toán không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            btnThanhToanBanVe.Visible = true;

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
            btnThanhToanBanVe.Visible = false;

        }

        private void LayBuoiVaNgayHienTai()
        {

            string giohientai = DateTime.Now.ToString();
            if (DateTime.Compare(DateTime.Parse(giohientai), DateTime.Parse("6:00 PM")) >= 0)
            {
                lblBuoi.Text = "Tối";
            }
            else
                lblBuoi.Text = "Trưa";

            //Lấy thứ ngày trong tuần
            string thu = DateTime.Today.DayOfWeek.ToString();
            if (thu == "Satuday" || thu == "Sunday")
            {
                lblLoaiNgay.Text = "Thứ 7 CN";
            }
            else
                lblLoaiNgay.Text = "Ngày thường";
        }

        private void LoadDSDoiTuongMuaVe()
        {
            cbbDoiTuong.Items.Add("Người lớn");
            cbbDoiTuong.Items.Add("Trẻ em");
        }

        private void btnThanhToanBanVe_Click(object sender, EventArgs e)
        {

            if (txtTienKhachTra.Text == "" || int.Parse(txtTienThua.Text) < 0)
            {
                MessageBox.Show("Chưa đủ tiền thanh toán. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int makh = 0;
                float tongtien = float.Parse(txtTongTien.Text);
                float tiengiam=float.Parse(txtTienGiam.Text);
                float tienthanhtoan=float.Parse(txtTienThanhToan.Text);
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
}
