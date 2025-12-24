namespace QLGD_WinForm
{
    partial class FormNhapMuon
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblHeader = new System.Windows.Forms.Label();
            this.tableMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaNguoiMuon = new System.Windows.Forms.Label();
            this.txtMaNguoiMuon = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblDonVi = new System.Windows.Forms.Label();
            this.txtDonVi = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblGiangDuong = new System.Windows.Forms.Label();
            this.cboGiangDuong = new System.Windows.Forms.ComboBox();
            this.lblPhong = new System.Windows.Forms.Label();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.lblThietBi = new System.Windows.Forms.Label();
            this.cboThietBi = new System.Windows.Forms.ComboBox();
            this.lblHanTra = new System.Windows.Forms.Label();
            this.dtpHanTra = new System.Windows.Forms.DateTimePicker();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.pnlThongTinMuon = new System.Windows.Forms.Panel();
            this.lblDanhSachDangMuon = new System.Windows.Forms.Label();
            this.pnlBtn = new System.Windows.Forms.FlowLayoutPanel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.tableMain.SuspendLayout();
            this.pnlThongTinMuon.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.Teal;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(700, 60);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "PHIẾU MƯỢN THIẾT BỊ";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableMain
            // 
            this.tableMain.ColumnCount = 2;
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableMain.Controls.Add(this.lblMaNguoiMuon, 0, 0);
            this.tableMain.Controls.Add(this.txtMaNguoiMuon, 1, 0);
            this.tableMain.Controls.Add(this.lblHoTen, 0, 1);
            this.tableMain.Controls.Add(this.txtHoTen, 1, 1);
            this.tableMain.Controls.Add(this.lblDonVi, 0, 2);
            this.tableMain.Controls.Add(this.txtDonVi, 1, 2);
            this.tableMain.Controls.Add(this.lblSDT, 0, 3);
            this.tableMain.Controls.Add(this.txtSDT, 1, 3);
            this.tableMain.Controls.Add(this.lblGiangDuong, 0, 4);
            this.tableMain.Controls.Add(this.cboGiangDuong, 1, 4);
            this.tableMain.Controls.Add(this.lblPhong, 0, 5);
            this.tableMain.Controls.Add(this.cboPhong, 1, 5);
            this.tableMain.Controls.Add(this.lblThietBi, 0, 6);
            this.tableMain.Controls.Add(this.cboThietBi, 1, 6);
            this.tableMain.Controls.Add(this.lblHanTra, 0, 7);
            this.tableMain.Controls.Add(this.dtpHanTra, 1, 7);
            this.tableMain.Controls.Add(this.lblGhiChu, 0, 8);
            this.tableMain.Controls.Add(this.txtGhiChu, 1, 8);
            this.tableMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableMain.Location = new System.Drawing.Point(0, 60);
            this.tableMain.Name = "tableMain";
            this.tableMain.Padding = new System.Windows.Forms.Padding(20);
            this.tableMain.RowCount = 9;
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableMain.Size = new System.Drawing.Size(700, 430);
            this.tableMain.TabIndex = 1;
            // 
            // lblMaNguoiMuon
            // 
            this.lblMaNguoiMuon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMaNguoiMuon.AutoSize = true;
            this.lblMaNguoiMuon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaNguoiMuon.Location = new System.Drawing.Point(23, 30);
            this.lblMaNguoiMuon.Name = "lblMaNguoiMuon";
            this.lblMaNguoiMuon.Size = new System.Drawing.Size(124, 19);
            this.lblMaNguoiMuon.TabIndex = 0;
            this.lblMaNguoiMuon.Text = "Mã Người Mượn (*):";
            // 
            // txtMaNguoiMuon
            // 
            this.txtMaNguoiMuon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaNguoiMuon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaNguoiMuon.Location = new System.Drawing.Point(254, 27);
            this.txtMaNguoiMuon.Name = "txtMaNguoiMuon";
            this.txtMaNguoiMuon.PlaceholderText = "Nhập mã & Enter...";
            this.txtMaNguoiMuon.Size = new System.Drawing.Size(423, 25);
            this.txtMaNguoiMuon.TabIndex = 1;
            // 
            // lblHoTen
            // 
            this.lblHoTen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHoTen.Location = new System.Drawing.Point(23, 70);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(55, 19);
            this.lblHoTen.TabIndex = 2;
            this.lblHoTen.Text = "Họ Tên:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHoTen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtHoTen.Location = new System.Drawing.Point(254, 67);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(423, 25);
            this.txtHoTen.TabIndex = 3;
            // 
            // lblDonVi
            // 
            this.lblDonVi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDonVi.AutoSize = true;
            this.lblDonVi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDonVi.Location = new System.Drawing.Point(23, 110);
            this.lblDonVi.Name = "lblDonVi";
            this.lblDonVi.Size = new System.Drawing.Size(85, 19);
            this.lblDonVi.TabIndex = 4;
            this.lblDonVi.Text = "Đơn Vị / Lớp:";
            // 
            // txtDonVi
            // 
            this.txtDonVi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDonVi.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDonVi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDonVi.Location = new System.Drawing.Point(254, 107);
            this.txtDonVi.Name = "txtDonVi";
            this.txtDonVi.ReadOnly = true;
            this.txtDonVi.Size = new System.Drawing.Size(423, 25);
            this.txtDonVi.TabIndex = 5;
            // 
            // lblSDT
            // 
            this.lblSDT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSDT.Location = new System.Drawing.Point(23, 150);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(95, 19);
            this.lblSDT.TabIndex = 6;
            this.lblSDT.Text = "Số Điện Thoại:";
            // 
            // txtSDT
            // 
            this.txtSDT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSDT.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSDT.Location = new System.Drawing.Point(254, 147);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.ReadOnly = true;
            this.txtSDT.Size = new System.Drawing.Size(423, 25);
            this.txtSDT.TabIndex = 7;
            // 
            // lblGiangDuong
            // 
            this.lblGiangDuong.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGiangDuong.AutoSize = true;
            this.lblGiangDuong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGiangDuong.Location = new System.Drawing.Point(23, 190);
            this.lblGiangDuong.Name = "lblGiangDuong";
            this.lblGiangDuong.Size = new System.Drawing.Size(131, 19);
            this.lblGiangDuong.TabIndex = 8;
            this.lblGiangDuong.Text = "Tại Giảng Đường (*):";
            // 
            // cboGiangDuong
            // 
            this.cboGiangDuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGiangDuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGiangDuong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboGiangDuong.FormattingEnabled = true;
            this.cboGiangDuong.Location = new System.Drawing.Point(254, 187);
            this.cboGiangDuong.Name = "cboGiangDuong";
            this.cboGiangDuong.Size = new System.Drawing.Size(423, 25);
            this.cboGiangDuong.TabIndex = 9;
            // 
            // lblPhong
            // 
            this.lblPhong.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPhong.AutoSize = true;
            this.lblPhong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPhong.Location = new System.Drawing.Point(23, 230);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(89, 19);
            this.lblPhong.TabIndex = 10;
            this.lblPhong.Text = "Tại Phòng (*):";
            // 
            // cboPhong
            // 
            this.cboPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPhong.FormattingEnabled = true;
            this.cboPhong.Location = new System.Drawing.Point(254, 227);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(423, 25);
            this.cboPhong.TabIndex = 11;
            // 
            // lblThietBi
            // 
            this.lblThietBi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblThietBi.AutoSize = true;
            this.lblThietBi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblThietBi.Location = new System.Drawing.Point(23, 270);
            this.lblThietBi.Name = "lblThietBi";
            this.lblThietBi.Size = new System.Drawing.Size(117, 19);
            this.lblThietBi.TabIndex = 12;
            this.lblThietBi.Text = "Thiết Bị (Kho) (*):";
            // 
            // cboThietBi
            // 
            this.cboThietBi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboThietBi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboThietBi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboThietBi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThietBi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboThietBi.FormattingEnabled = true;
            this.cboThietBi.Location = new System.Drawing.Point(254, 267);
            this.cboThietBi.Name = "cboThietBi";
            this.cboThietBi.Size = new System.Drawing.Size(423, 25);
            this.cboThietBi.TabIndex = 13;
            // 
            // lblHanTra
            // 
            this.lblHanTra.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHanTra.AutoSize = true;
            this.lblHanTra.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHanTra.Location = new System.Drawing.Point(23, 310);
            this.lblHanTra.Name = "lblHanTra";
            this.lblHanTra.Size = new System.Drawing.Size(117, 19);
            this.lblHanTra.TabIndex = 14;
            this.lblHanTra.Text = "Hạn Trả Dự Kiến:";
            // 
            // dtpHanTra
            // 
            this.dtpHanTra.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpHanTra.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpHanTra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHanTra.Location = new System.Drawing.Point(254, 307);
            this.dtpHanTra.Name = "dtpHanTra";
            this.dtpHanTra.Size = new System.Drawing.Size(250, 23);
            this.dtpHanTra.TabIndex = 15;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGhiChu.Location = new System.Drawing.Point(23, 365);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(60, 19);
            this.lblGhiChu.TabIndex = 16;
            this.lblGhiChu.Text = "Ghi Chú:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChu.Location = new System.Drawing.Point(254, 353);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGhiChu.Size = new System.Drawing.Size(423, 54);
            this.txtGhiChu.TabIndex = 17;
            // 
            // pnlThongTinMuon
            // 
            this.pnlThongTinMuon.BackColor = System.Drawing.Color.LightYellow;
            this.pnlThongTinMuon.Controls.Add(this.lblDanhSachDangMuon);
            this.pnlThongTinMuon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThongTinMuon.Location = new System.Drawing.Point(0, 490);
            this.pnlThongTinMuon.Name = "pnlThongTinMuon";
            this.pnlThongTinMuon.Padding = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.pnlThongTinMuon.Size = new System.Drawing.Size(700, 120);
            this.pnlThongTinMuon.TabIndex = 2;
            this.pnlThongTinMuon.Visible = false;
            // 
            // lblDanhSachDangMuon
            // 
            this.lblDanhSachDangMuon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDanhSachDangMuon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDanhSachDangMuon.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblDanhSachDangMuon.Location = new System.Drawing.Point(20, 5);
            this.lblDanhSachDangMuon.Name = "lblDanhSachDangMuon";
            this.lblDanhSachDangMuon.Size = new System.Drawing.Size(660, 110);
            this.lblDanhSachDangMuon.TabIndex = 0;
            // 
            // pnlBtn
            // 
            this.pnlBtn.Controls.Add(this.btnHuy);
            this.pnlBtn.Controls.Add(this.btnLuu);
            this.pnlBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBtn.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlBtn.Location = new System.Drawing.Point(0, 670);
            this.pnlBtn.Name = "pnlBtn";
            this.pnlBtn.Padding = new System.Windows.Forms.Padding(20);
            this.pnlBtn.Size = new System.Drawing.Size(700, 80);
            this.pnlBtn.TabIndex = 3;
            // 
            // btnHuy
            // 
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Location = new System.Drawing.Point(577, 23);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 45);
            this.btnHuy.TabIndex = 0;
            this.btnHuy.Text = "Hủy Bỏ";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.Teal;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(431, 23);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(140, 45);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "MƯỢN NGAY";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // FormNhapMuon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 750);
            this.Controls.Add(this.pnlBtn);
            this.Controls.Add(this.pnlThongTinMuon);
            this.Controls.Add(this.tableMain);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormNhapMuon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng Ký Mượn Thiết Bị Mới";
            this.tableMain.ResumeLayout(false);
            this.tableMain.PerformLayout();
            this.pnlThongTinMuon.ResumeLayout(false);
            this.pnlBtn.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TableLayoutPanel tableMain;
        private System.Windows.Forms.Label lblMaNguoiMuon;
        private System.Windows.Forms.TextBox txtMaNguoiMuon;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblDonVi;
        private System.Windows.Forms.TextBox txtDonVi;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblGiangDuong;
        private System.Windows.Forms.ComboBox cboGiangDuong;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.Label lblThietBi;
        private System.Windows.Forms.ComboBox cboThietBi;
        private System.Windows.Forms.Label lblHanTra;
        private System.Windows.Forms.DateTimePicker dtpHanTra;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Panel pnlThongTinMuon;
        private System.Windows.Forms.Label lblDanhSachDangMuon;
        private System.Windows.Forms.FlowLayoutPanel pnlBtn;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
    }
}
