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
    public partial class frmThuNganThanhToan_BanVe : Office2007Form
    {
        public frmThuNganThanhToan_BanVe()
        {
            InitializeComponent();
        }

        private int manv;

        public int Manv
        {
            get { return manv; }
            set { manv = value; }
        }

        Ve ve = new Ve();
        ThuNganThanhToanBUS tntt = new ThuNganThanhToanBUS();
        ThuNganBUS tn = new ThuNganBUS();
        TheKhachHangDTO tkh=new TheKhachHangDTO();

        private void frmThuNganBanVe_Load(object sender, EventArgs e)
        {
            int madv = int.Parse(lbMaDV.Text);
            if (lbTieuDe.Text == "THANH TOÁN")
            {
                txtTheKhachHang.Enabled = false;
                dgvDichVuKhac.Rows[0].Cells["txtMaThucuong"].Value = madv;
                dgvDichVuKhac.Rows[0].Cells["cbbThucuong"].Value = tntt.bLayThucUongCanBan(madv);
                cbbThucuong.DataSource = tn.bLayDSNuocUong();
                cbbThucuong.DisplayMember = "TenDV";
                cbbThucuong.ValueMember = "MaDV";
                dgvDichVuKhac.Rows[0].Cells["txtDongia"].Value = tntt.bLayGiaThucUong(madv);
                dgvDichVuKhac.Rows[0].Cells["txtSoLuong"].Value = 1;
                TinhThanhTienNuoc(0);
                TinhTongTienNuoc();
            }
            else
            {
                dgvDSBuffet.Rows[0].Cells["txtMaBuffet"].Value = madv;
                dgvDSBuffet.Rows[0].Cells["cbbBuffet"].Value = tntt.bLayBuffetCanBan(madv);
                cbbBuffet.DataSource = tntt.bLayDSBuffet();
                cbbBuffet.DisplayMember = "TenDV";
                cbbBuffet.ValueMember = "MaDV";
                dgvDSBuffet.Rows[0].Cells["txtSLve"].Value = 1;

                dgvDSBuffet.Rows[0].Cells["cbbDoiTuong"].Value = lbDoiTuong.Text;
                cbbDoiTuong.Items.Add("Người lớn");
                cbbDoiTuong.Items.Add("Trẻ em");

                dgvDSBuffet.Rows[0].Cells["txtGiave"].Value = lbgiave.Text;

                TinhThanhTienBuffet(0);

                TinhTongTienBuffet();
            }

            string giohientai = DateTime.Now.ToString();
            if (DateTime.Compare(DateTime.Parse(giohientai), DateTime.Parse("6:00 PM")) >= 0)
            {
                lbBuoi.Text = "Tối";
            }
            else
                lbBuoi.Text = "Trưa";

            //Lấy thứ ngày trong tuần
            string thu = DateTime.Today.DayOfWeek.ToString();
            if (thu == "Satuday" || thu == "Sunday")
            {
                lbNgayThuong.Text = "Thứ 7 CN";
            }
            else
                lbNgayThuong.Text = "Ngày thường";

            txtTienThanhToan.Text = (int.Parse(lbTongThanhTien.Text) - int.Parse(lbTienGiam.Text)).ToString();

        }

        private void radioATM_CheckedChanged(object sender, EventArgs e)
        {
            lbTienKhachTra.Text = "Số tài khoản";
            lbtienthua.Visible = false;
            txtTienTra_STK.Text = "";
            txtTienThua.Visible = false;
            lbvnd.Visible = false;
            lbvnd2.Visible = false;
        }

        private void radioTienMat_CheckedChanged(object sender, EventArgs e)
        {
            lbTienKhachTra.Text = "Tiền khách trả";
            lbtienthua.Visible = true;
            txtTienThua.Visible = true;
            lbvnd.Visible = true;
            lbvnd2.Visible = true;
        }

        //Xử lý sự kiện cac control trong datagridview
        private void dgvDSBuffet_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int chisocot = dgvDSBuffet.CurrentCell.ColumnIndex;     //lấy chỉ số cột
            string tencot = dgvDSBuffet.Columns[chisocot].Name.ToString();   //lấy cột cần thêm sự kiện
            if (tencot == "cbbDoiTuong")
            {
                // Check box column
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.KeyPress += new KeyPressEventHandler(this.cbbDoiTuong_KeyPress);
                comboBox.SelectedIndexChanged += new EventHandler(cbbDoiTuong_SelectedIndexChanged); // thêm sự kiện SelectedIndexChanged cho combobox khi giá trị combobox thay đổi 
            }
            if (tencot == "txtSLve")
            {
                if (e.Control is TextBox)
                {
                    TextBox textbox = e.Control as TextBox;
                    textbox.KeyPress += new KeyPressEventHandler(this.txtSLve_KeyPress);// thêm sự kiện KeyPress cho textbox tức chỉ cho nhập số
                }
            }
            if (tencot == "cbbBuffet")
            {
                ComboBox combobox1 = e.Control as ComboBox;
                combobox1.SelectedIndexChanged += new EventHandler(cbbBuffet_SelectedIndexChange);
            }
        }
        //Tự định nghĩa sự kiện KeyPress ko nhập số cho combobox
        void cbbDoiTuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Tự định nghĩa sự kiện Keypress chỉ nhập số cho txtSLve
        void txtSLve_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Tự Định nghĩa sự kiện cho cbbDoiTuong
        void cbbDoiTuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            int dong = dgvDSBuffet.CurrentCell.RowIndex;
            int selectedIndex = ((ComboBox)sender).SelectedIndex;
            float giave = 0;
            if (selectedIndex == 0)
            {
                giave = Convert.ToSingle(tn.bLayGiaVe(lbBuoi.Text, lbNgayThuong.Text, "Người lớn"));
                dgvDSBuffet.Rows[dong].Cells["txtGiave"].Value = giave;
                TinhThanhTienBuffet(dong);
            }
            else
            {
                giave = Convert.ToSingle(tn.bLayGiaVe(lbBuoi.Text, lbNgayThuong.Text, "Trẻ em"));
                dgvDSBuffet.Rows[dong].Cells["txtGiave"].Value = giave;
                TinhThanhTienBuffet(dong);
            }
        }

        private void txtTienTra_STK_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTienTra_STK.Text != "")
                {
                    float tienthanhtoan = int.Parse(txtTienThanhToan.Text);
                    float tienkhachtra = int.Parse(txtTienTra_STK.Text);
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

        private void txtTienTra_STK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvDSBuffet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int dong = dgvDSBuffet.CurrentCell.RowIndex;
            TinhThanhTienBuffet(dong);
            TinhTongTienBuffet();
        }

        private void dgvDichVuKhac_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int dong = dgvDichVuKhac.CurrentCell.RowIndex;
            TinhThanhTienNuoc(dong);
            TinhTongTienNuoc();
        }

        private void dgvDichVuKhac_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int chisocot = dgvDichVuKhac.CurrentCell.ColumnIndex;     //lấy chỉ số cột
            string tencot = dgvDichVuKhac.Columns[chisocot].Name.ToString();   //lấy cột cần thêm sự kiện
            if (tencot == "txtSoLuong")
            {
                if (e.Control is TextBox)
                {
                    TextBox textbox = e.Control as TextBox;
                    textbox.KeyPress += new KeyPressEventHandler(this.txtSLve_KeyPress);// thêm sự kiện KeyPress cho textbox tức chỉ cho nhập số
                }
            }
            if (tencot == "cbbThucuong")
            {
                ComboBox combobox1 = e.Control as ComboBox;
                combobox1.SelectedIndexChanged += new EventHandler(cbbThucuong_SelectedIndexChange);
            }
        }

        void cbbThucuong_SelectedIndexChange(object sender, EventArgs e)
        {
            int dong = dgvDichVuKhac.CurrentCell.RowIndex;
            string selectedvalue = ((ComboBox)sender).SelectedValue.ToString();
            int madv = int.Parse(selectedvalue);
            float giave = Convert.ToSingle(tntt.bLayGiaThucUong(madv));
            dgvDichVuKhac.Rows[dong].Cells["txtDongia"].Value = giave;
            dgvDichVuKhac.Rows[dong].Cells["txtMaThucuong"].Value = madv;
            TinhThanhTienNuoc(dong);
            TinhTongTienNuoc();
        }

        void cbbBuffet_SelectedIndexChange(object sender, EventArgs e)
        {
            int dong = dgvDSBuffet.CurrentCell.RowIndex;
            string selectedvalue = ((ComboBox)sender).SelectedValue.ToString();
            int madv = int.Parse(selectedvalue);
            dgvDSBuffet.Rows[dong].Cells["txtMaBuffet"].Value = madv;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (txtTienTra_STK.Text == "" || int.Parse(txtTienThua.Text) < 0)
            {
                MessageBox.Show("Chưa đủ tiền thanh toán. Vui lòng nhập lại.");
            }
            else
            {
                int makh = 0;
                int tongtien = int.Parse(lbTongThanhTien.Text);
                if (tongtien < 500000)
                {
                    if (tntt.bThemHoaDonKhongKH(manv, tongtien))
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

                    if (tntt.bThemHoaDon(manv, makh, tongtien))
                    {
                        
                        ThemCTHoaDon();
                    }
                    tntt.bCapNhatDiemTichLuy(makh, tkh.TinhDiemTichLuy(tongtien));
                }
            }
        }

        private void ThemCTHoaDon()
        {
            int madv, dongia, soluong;
            if (lbTieuDe.Text == "THANH TOÁN")
            {
                for (int i = 0; i < dgvDichVuKhac.Rows.Count - 1; i++)
                {
                    madv = int.Parse(dgvDichVuKhac.Rows[i].Cells["txtMathucuong"].Value.ToString());
                    dongia = int.Parse(dgvDichVuKhac.Rows[i].Cells["txtDonGia"].Value.ToString());
                    soluong = int.Parse(dgvDichVuKhac.Rows[i].Cells["txtSoLuong"].Value.ToString());
                    tntt.bThemCTHoaDon(madv, dongia, soluong);
                }
                MessageBox.Show("Thanh toán thành công.");
                this.Close();
            }
            else
            {
                for (int j = 0; j < dgvDSBuffet.Rows.Count - 1; j++)
                {
                    madv = int.Parse(dgvDSBuffet.Rows[j].Cells["txtMaBuffet"].Value.ToString());
                    dongia = int.Parse(dgvDSBuffet.Rows[j].Cells["txtGiave"].Value.ToString());
                    soluong = int.Parse(dgvDSBuffet.Rows[j].Cells["txtSLve"].Value.ToString());
                    tntt.bThemCTHoaDon(madv, dongia, soluong);
                }
                MessageBox.Show("Thanh toán thành công.");
                this.Close();
            }
        }

        private void LayBuffetCanBan(int madv)
        {
            tntt.bLayBuffetCanBan(madv);
        }

        private void LayThucUongCanBan(int madv)
        {
            tntt.bLayThucUongCanBan(madv);
        }

        private void TinhThanhTienBuffet(int dong)
        {
            try
            {
                float dongia = Convert.ToSingle(dgvDSBuffet.Rows[dong].Cells["txtGiave"].Value);
                int soluongve = Convert.ToInt32(dgvDSBuffet.Rows[dong].Cells["txtSLve"].Value);
                float thanhtien = dongia * soluongve;
                dgvDSBuffet.Rows[dong].Cells["txtThanhtien"].Value = thanhtien;
            }
            catch { }
        }

        private void TinhThanhTienNuoc(int dong)
        {
            try
            {
                float dongia = Convert.ToSingle(dgvDichVuKhac.Rows[dong].Cells["txtDonGia"].Value);
                int soluongve = Convert.ToInt32(dgvDichVuKhac.Rows[dong].Cells["txtSoLuong"].Value);
                float thanhtien = dongia * soluongve;
                dgvDichVuKhac.Rows[dong].Cells["txtThanhtiennuoc"].Value = thanhtien;
            }
            catch { }
        }

        private void TinhTongTienBuffet()
        {
            float tongthanhtien = 0;
            for (int i = 0; i < dgvDSBuffet.Rows.Count; i++)
            {
                tongthanhtien += Convert.ToSingle(dgvDSBuffet.Rows[i].Cells["txtThanhtien"].Value);
            }
            lbTongThanhTien.Text = tongthanhtien.ToString();
        }

        private void TinhTongTienNuoc()
        {
            float tongthanhtien = 0;
            for (int i = 0; i < dgvDichVuKhac.Rows.Count; i++)
            {
                tongthanhtien += Convert.ToSingle(dgvDichVuKhac.Rows[i].Cells["txtThanhtiennuoc"].Value);
            }
            lbTongThanhTien.Text = tongthanhtien.ToString();
        }

        private void txtTheKhachHang_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (txtTheKhachHang.Text == "")
            {
                dgvTheKhachHang.Visible = false;

                lbDTL_GiamGia.Text = "";
                lbTienGiam.Text = "0";
            }
            else
            {
                dt = tntt.bLayTheKHTheoMa(txtTheKhachHang.Text);
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

        private void lbTienGiam_TextChanged(object sender, EventArgs e)
        {
            float tongtien = int.Parse(lbTongThanhTien.Text);
            float tiengiam = int.Parse(lbTienGiam.Text);
            float tienthanhtoan = tongtien - tiengiam;
            txtTienThanhToan.Text = tienthanhtoan.ToString();
        }

        private void lbTongThanhTien_TextChanged(object sender, EventArgs e)
        {
            float tongthanhtien = int.Parse(lbTongThanhTien.Text);
            txtTienThanhToan.Text = (tongthanhtien - int.Parse(lbTienGiam.Text)).ToString();
            if (lbTieuDe.Text == "THANH TOÁN" && tongthanhtien < 500000)
            {
                txtTheKhachHang.ReadOnly = true;
            }
            else
                txtTheKhachHang.ReadOnly = false;
        }

        private void XacDinhPhanTramGiam()
        {
            int dong = dgvTheKhachHang.CurrentCell.RowIndex;
            txtTheKhachHang.Text = dgvTheKhachHang.Rows[dong].Cells["MaKH"].Value.ToString();
            tkh.Diemtichluy = Convert.ToInt32(dgvTheKhachHang.Rows[dong].Cells["DiemTichLuy"].Value);
            tkh.TinhPhanTramGiam();
            float tiengiam = int.Parse(lbTongThanhTien.Text) * tkh.TinhPhanTramGiam() / 100;
            lbTienGiam.Text = tiengiam.ToString();
            lbDTL_GiamGia.Text = "Điểm tích lũy: " + tkh.Diemtichluy.ToString() + " (Giảm: " + tkh.TinhPhanTramGiam() + "%)";
            dgvTheKhachHang.Visible = false;
            if (lbTieuDe.Text == "THANH TOÁN")
            {
                lbDTL_GiamGia.Visible = false;
                lbTienGiam.Text = "0";
            }
        }

        private void dgvTheKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            XacDinhPhanTramGiam();
        }
    }
}
