namespace QuanLyNhaHangGUI
{
    partial class frmPhanCongNVPhucVu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnHuyBoPV = new DevComponents.DotNetBar.ButtonX();
            this.btnPhanCongPV = new DevComponents.DotNetBar.ButtonX();
            this.cbbCaLamViec = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbbMonAnPhuTrach = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblPTMonAn = new DevComponents.DotNetBar.LabelX();
            this.cbbCongViec = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.cbbTenNhanVien = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnHuyBoPV);
            this.panelEx1.Controls.Add(this.btnPhanCongPV);
            this.panelEx1.Controls.Add(this.cbbCaLamViec);
            this.panelEx1.Controls.Add(this.cbbMonAnPhuTrach);
            this.panelEx1.Controls.Add(this.lblPTMonAn);
            this.panelEx1.Controls.Add(this.cbbCongViec);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.cbbTenNhanVien);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(715, 283);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // btnHuyBoPV
            // 
            this.btnHuyBoPV.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHuyBoPV.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnHuyBoPV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyBoPV.Image = global::QuanLyNhaHangGUI.Properties.Resources.icons8_delete_16;
            this.btnHuyBoPV.Location = new System.Drawing.Point(379, 218);
            this.btnHuyBoPV.Name = "btnHuyBoPV";
            this.btnHuyBoPV.Size = new System.Drawing.Size(102, 27);
            this.btnHuyBoPV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnHuyBoPV.TabIndex = 12;
            this.btnHuyBoPV.Text = "Hủy bỏ";
            this.btnHuyBoPV.Click += new System.EventHandler(this.btnHuyBoPV_Click);
            // 
            // btnPhanCongPV
            // 
            this.btnPhanCongPV.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPhanCongPV.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPhanCongPV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhanCongPV.Image = global::QuanLyNhaHangGUI.Properties.Resources.icons8_checkmark_16;
            this.btnPhanCongPV.Location = new System.Drawing.Point(252, 218);
            this.btnPhanCongPV.Name = "btnPhanCongPV";
            this.btnPhanCongPV.Size = new System.Drawing.Size(103, 27);
            this.btnPhanCongPV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPhanCongPV.TabIndex = 11;
            this.btnPhanCongPV.Text = "Phân công";
            this.btnPhanCongPV.Click += new System.EventHandler(this.btnPhanCongPV_Click);
            // 
            // cbbCaLamViec
            // 
            this.cbbCaLamViec.DisplayMember = "Text";
            this.cbbCaLamViec.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbCaLamViec.FormattingEnabled = true;
            this.cbbCaLamViec.ItemHeight = 14;
            this.cbbCaLamViec.Location = new System.Drawing.Point(118, 96);
            this.cbbCaLamViec.Name = "cbbCaLamViec";
            this.cbbCaLamViec.Size = new System.Drawing.Size(157, 20);
            this.cbbCaLamViec.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbCaLamViec.TabIndex = 10;
            // 
            // cbbMonAnPhuTrach
            // 
            this.cbbMonAnPhuTrach.DisplayMember = "Text";
            this.cbbMonAnPhuTrach.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbMonAnPhuTrach.FormattingEnabled = true;
            this.cbbMonAnPhuTrach.ItemHeight = 14;
            this.cbbMonAnPhuTrach.Location = new System.Drawing.Point(462, 143);
            this.cbbMonAnPhuTrach.Name = "cbbMonAnPhuTrach";
            this.cbbMonAnPhuTrach.Size = new System.Drawing.Size(157, 20);
            this.cbbMonAnPhuTrach.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbMonAnPhuTrach.TabIndex = 9;
            // 
            // lblPTMonAn
            // 
            // 
            // 
            // 
            this.lblPTMonAn.BackgroundStyle.Class = "";
            this.lblPTMonAn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPTMonAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPTMonAn.Location = new System.Drawing.Point(336, 140);
            this.lblPTMonAn.Name = "lblPTMonAn";
            this.lblPTMonAn.Size = new System.Drawing.Size(110, 23);
            this.lblPTMonAn.TabIndex = 8;
            this.lblPTMonAn.Text = "Món ăn phụ trách";
            // 
            // cbbCongViec
            // 
            this.cbbCongViec.DisplayMember = "Text";
            this.cbbCongViec.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbCongViec.FormattingEnabled = true;
            this.cbbCongViec.ItemHeight = 14;
            this.cbbCongViec.Location = new System.Drawing.Point(462, 99);
            this.cbbCongViec.Name = "cbbCongViec";
            this.cbbCongViec.Size = new System.Drawing.Size(157, 20);
            this.cbbCongViec.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbCongViec.TabIndex = 7;
            this.cbbCongViec.SelectedIndexChanged += new System.EventHandler(this.cbbCongViec_SelectedIndexChanged);
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.Location = new System.Drawing.Point(336, 96);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 6;
            this.labelX5.Text = "Công việc";
            // 
            // cbbTenNhanVien
            // 
            this.cbbTenNhanVien.DisplayMember = "Text";
            this.cbbTenNhanVien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbTenNhanVien.FormattingEnabled = true;
            this.cbbTenNhanVien.ItemHeight = 14;
            this.cbbTenNhanVien.Location = new System.Drawing.Point(118, 143);
            this.cbbTenNhanVien.Name = "cbbTenNhanVien";
            this.cbbTenNhanVien.Size = new System.Drawing.Size(157, 20);
            this.cbbTenNhanVien.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbbTenNhanVien.TabIndex = 4;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(12, 140);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(109, 23);
            this.labelX4.TabIndex = 3;
            this.labelX4.Text = "Tên nhân viên";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(12, 91);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(87, 33);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "Ca làm việc";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(199, 21);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(317, 47);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Phân công nhân viên phục vụ";
            // 
            // frmPhanCongNVPhucVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 283);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Name = "frmPhanCongNVPhucVu";
            this.Text = "frmPhanCongNVPhucVu";
            this.Load += new System.EventHandler(this.frmPhanCongNVPhucVu_Load);
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnHuyBoPV;
        private DevComponents.DotNetBar.ButtonX btnPhanCongPV;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbCaLamViec;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbMonAnPhuTrach;
        private DevComponents.DotNetBar.LabelX lblPTMonAn;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbCongViec;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbTenNhanVien;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}