namespace QLGD_WinForm
{
    partial class FormCapNhatSuCo
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
            this.tableMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblThongTin = new System.Windows.Forms.Label();
            this.lblTrangThaiTitle = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblNguoiXuLyTitle = new System.Windows.Forms.Label();
            this.txtNguoiXuLy = new System.Windows.Forms.TextBox();
            this.lblChiPhiTitle = new System.Windows.Forms.Label();
            this.numChiPhi = new System.Windows.Forms.NumericUpDown();
            this.lblGhiChuTitle = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.pnlBtn = new System.Windows.Forms.FlowLayoutPanel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.tableMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChiPhi)).BeginInit();
            this.pnlBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableMain
            // 
            this.tableMain.ColumnCount = 2;
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableMain.Controls.Add(this.lblThongTin, 0, 0);
            this.tableMain.Controls.Add(this.lblTrangThaiTitle, 0, 1);
            this.tableMain.Controls.Add(this.cboTrangThai, 1, 1);
            this.tableMain.Controls.Add(this.lblNguoiXuLyTitle, 0, 2);
            this.tableMain.Controls.Add(this.txtNguoiXuLy, 1, 2);
            this.tableMain.Controls.Add(this.lblChiPhiTitle, 0, 3);
            this.tableMain.Controls.Add(this.numChiPhi, 1, 3);
            this.tableMain.Controls.Add(this.lblGhiChuTitle, 0, 4);
            this.tableMain.Controls.Add(this.txtGhiChu, 1, 4);
            this.tableMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableMain.Location = new System.Drawing.Point(0, 0);
            this.tableMain.Name = "tableMain";
            this.tableMain.Padding = new System.Windows.Forms.Padding(20);
            this.tableMain.RowCount = 5;
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableMain.Size = new System.Drawing.Size(500, 350);
            this.tableMain.TabIndex = 0;
            // 
            // lblThongTin
            // 
            this.lblThongTin.AutoSize = true;
            this.tableMain.SetColumnSpan(this.lblThongTin, 2);
            this.lblThongTin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblThongTin.ForeColor = System.Drawing.Color.Teal;
            this.lblThongTin.Location = new System.Drawing.Point(23, 20);
            this.lblThongTin.Name = "lblThongTin";
            this.lblThongTin.Size = new System.Drawing.Size(0, 19);
            this.lblThongTin.TabIndex = 0;
            // 
            // lblTrangThaiTitle
            // 
            this.lblTrangThaiTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTrangThaiTitle.AutoSize = true;
            this.lblTrangThaiTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTrangThaiTitle.Location = new System.Drawing.Point(23, 95);
            this.lblTrangThaiTitle.Name = "lblTrangThaiTitle";
            this.lblTrangThaiTitle.Size = new System.Drawing.Size(74, 19);
            this.lblTrangThaiTitle.TabIndex = 1;
            this.lblTrangThaiTitle.Text = "Trạng Thái:";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Items.AddRange(new object[] {
            "Đang sửa chữa",
            "Đã xử lý"});
            this.cboTrangThai.Location = new System.Drawing.Point(184, 92);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(293, 25);
            this.cboTrangThai.TabIndex = 2;
            // 
            // lblNguoiXuLyTitle
            // 
            this.lblNguoiXuLyTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNguoiXuLyTitle.AutoSize = true;
            this.lblNguoiXuLyTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNguoiXuLyTitle.Location = new System.Drawing.Point(23, 145);
            this.lblNguoiXuLyTitle.Name = "lblNguoiXuLyTitle";
            this.lblNguoiXuLyTitle.Size = new System.Drawing.Size(83, 19);
            this.lblNguoiXuLyTitle.TabIndex = 3;
            this.lblNguoiXuLyTitle.Text = "Người Xử Lý:";
            // 
            // txtNguoiXuLy
            // 
            this.txtNguoiXuLy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNguoiXuLy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNguoiXuLy.Location = new System.Drawing.Point(184, 142);
            this.txtNguoiXuLy.Name = "txtNguoiXuLy";
            this.txtNguoiXuLy.Size = new System.Drawing.Size(293, 25);
            this.txtNguoiXuLy.TabIndex = 4;
            // 
            // lblChiPhiTitle
            // 
            this.lblChiPhiTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblChiPhiTitle.AutoSize = true;
            this.lblChiPhiTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblChiPhiTitle.Location = new System.Drawing.Point(23, 195);
            this.lblChiPhiTitle.Name = "lblChiPhiTitle";
            this.lblChiPhiTitle.Size = new System.Drawing.Size(99, 19);
            this.lblChiPhiTitle.TabIndex = 5;
            this.lblChiPhiTitle.Text = "Chi Phí (VNĐ):";
            // 
            // numChiPhi
            // 
            this.numChiPhi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numChiPhi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numChiPhi.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numChiPhi.Location = new System.Drawing.Point(184, 192);
            this.numChiPhi.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numChiPhi.Name = "numChiPhi";
            this.numChiPhi.Size = new System.Drawing.Size(200, 25);
            this.numChiPhi.TabIndex = 6;
            // 
            // lblGhiChuTitle
            // 
            this.lblGhiChuTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGhiChuTitle.AutoSize = true;
            this.lblGhiChuTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGhiChuTitle.Location = new System.Drawing.Point(23, 260);
            this.lblGhiChuTitle.Name = "lblGhiChuTitle";
            this.lblGhiChuTitle.Size = new System.Drawing.Size(60, 19);
            this.lblGhiChuTitle.TabIndex = 7;
            this.lblGhiChuTitle.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGhiChu.Location = new System.Drawing.Point(184, 233);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGhiChu.Size = new System.Drawing.Size(293, 74);
            this.txtGhiChu.TabIndex = 8;
            // 
            // pnlBtn
            // 
            this.pnlBtn.Controls.Add(this.btnHuy);
            this.pnlBtn.Controls.Add(this.btnLuu);
            this.pnlBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBtn.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlBtn.Location = new System.Drawing.Point(0, 410);
            this.pnlBtn.Name = "pnlBtn";
            this.pnlBtn.Padding = new System.Windows.Forms.Padding(15);
            this.pnlBtn.Size = new System.Drawing.Size(500, 70);
            this.pnlBtn.TabIndex = 1;
            // 
            // btnHuy
            // 
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Location = new System.Drawing.Point(382, 18);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 40);
            this.btnHuy.TabIndex = 0;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.ForestGreen;
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(266, 18);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(110, 40);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "CẬP NHẬT";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // FormCapNhatSuCo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 480);
            this.Controls.Add(this.pnlBtn);
            this.Controls.Add(this.tableMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormCapNhatSuCo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CẬP NHẬT TRẠNG THÁI & CHI PHÍ";
            this.tableMain.ResumeLayout(false);
            this.tableMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChiPhi)).EndInit();
            this.pnlBtn.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableMain;
        private System.Windows.Forms.Label lblThongTin;
        private System.Windows.Forms.Label lblTrangThaiTitle;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label lblNguoiXuLyTitle;
        private System.Windows.Forms.TextBox txtNguoiXuLy;
        private System.Windows.Forms.Label lblChiPhiTitle;
        private System.Windows.Forms.NumericUpDown numChiPhi;
        private System.Windows.Forms.Label lblGhiChuTitle;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.FlowLayoutPanel pnlBtn;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
    }
}
