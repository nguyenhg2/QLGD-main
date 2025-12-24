namespace QLGD_WinForm
{
    partial class FormChiTietMuonTra
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblMaDK = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNguoiMuon = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDonVi = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblThietBi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNgayMuon = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTraDuKien = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTraThucTe = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tableMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.Teal;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(650, 60);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "THÔNG TIN CHI TIẾT PHIẾU MƯỢN";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableMain
            // 
            this.tableMain.ColumnCount = 2;
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableMain.Controls.Add(this.label1, 0, 0);
            this.tableMain.Controls.Add(this.lblMaDK, 1, 0);
            this.tableMain.Controls.Add(this.label2, 0, 1);
            this.tableMain.Controls.Add(this.lblNguoiMuon, 1, 1);
            this.tableMain.Controls.Add(this.label3, 0, 2);
            this.tableMain.Controls.Add(this.lblDonVi, 1, 2);
            this.tableMain.Controls.Add(this.label4, 0, 3);
            this.tableMain.Controls.Add(this.lblThietBi, 1, 3);
            this.tableMain.Controls.Add(this.label5, 0, 4);
            this.tableMain.Controls.Add(this.lblNgayMuon, 1, 4);
            this.tableMain.Controls.Add(this.label6, 0, 5);
            this.tableMain.Controls.Add(this.lblTraDuKien, 1, 5);
            this.tableMain.Controls.Add(this.label7, 0, 6);
            this.tableMain.Controls.Add(this.lblTraThucTe, 1, 6);
            this.tableMain.Controls.Add(this.label8, 0, 7);
            this.tableMain.Controls.Add(this.lblTrangThai, 1, 7);
            this.tableMain.Controls.Add(this.label9, 0, 8);
            this.tableMain.Controls.Add(this.lblGhiChu, 1, 8);
            this.tableMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableMain.Location = new System.Drawing.Point(0, 60);
            this.tableMain.Name = "tableMain";
            this.tableMain.Padding = new System.Windows.Forms.Padding(40, 10, 40, 0);
            this.tableMain.RowCount = 9;
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableMain.Size = new System.Drawing.Size(650, 380);
            this.tableMain.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(43, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Phiếu Mượn:";
            // 
            // lblMaDK
            // 
            this.lblMaDK.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMaDK.AutoSize = true;
            this.lblMaDK.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMaDK.Location = new System.Drawing.Point(299, 20);
            this.lblMaDK.Name = "lblMaDK";
            this.lblMaDK.Size = new System.Drawing.Size(16, 20);
            this.lblMaDK.TabIndex = 1;
            this.lblMaDK.Text = "...";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(43, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ Tên Người Mượn:";
            // 
            // lblNguoiMuon
            // 
            this.lblNguoiMuon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNguoiMuon.AutoSize = true;
            this.lblNguoiMuon.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblNguoiMuon.Location = new System.Drawing.Point(299, 60);
            this.lblNguoiMuon.Name = "lblNguoiMuon";
            this.lblNguoiMuon.Size = new System.Drawing.Size(16, 20);
            this.lblNguoiMuon.TabIndex = 3;
            this.lblNguoiMuon.Text = "...";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(43, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Đơn Vị / Lớp:";
            // 
            // lblDonVi
            // 
            this.lblDonVi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDonVi.AutoSize = true;
            this.lblDonVi.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDonVi.Location = new System.Drawing.Point(299, 100);
            this.lblDonVi.Name = "lblDonVi";
            this.lblDonVi.Size = new System.Drawing.Size(16, 20);
            this.lblDonVi.TabIndex = 5;
            this.lblDonVi.Text = "...";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(43, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tên Thiết Bị:";
            // 
            // lblThietBi
            // 
            this.lblThietBi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblThietBi.AutoSize = true;
            this.lblThietBi.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblThietBi.Location = new System.Drawing.Point(299, 140);
            this.lblThietBi.Name = "lblThietBi";
            this.lblThietBi.Size = new System.Drawing.Size(16, 20);
            this.lblThietBi.TabIndex = 7;
            this.lblThietBi.Text = "...";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(43, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Thời Gian Mượn:";
            // 
            // lblNgayMuon
            // 
            this.lblNgayMuon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNgayMuon.AutoSize = true;
            this.lblNgayMuon.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblNgayMuon.Location = new System.Drawing.Point(299, 180);
            this.lblNgayMuon.Name = "lblNgayMuon";
            this.lblNgayMuon.Size = new System.Drawing.Size(16, 20);
            this.lblNgayMuon.TabIndex = 9;
            this.lblNgayMuon.Text = "...";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(43, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Thời Gian Trả Dự Kiến:";
            // 
            // lblTraDuKien
            // 
            this.lblTraDuKien.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTraDuKien.AutoSize = true;
            this.lblTraDuKien.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTraDuKien.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTraDuKien.Location = new System.Drawing.Point(299, 220);
            this.lblTraDuKien.Name = "lblTraDuKien";
            this.lblTraDuKien.Size = new System.Drawing.Size(16, 20);
            this.lblTraDuKien.TabIndex = 11;
            this.lblTraDuKien.Text = "...";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(43, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Thời Gian Trả Thực Tế:";
            // 
            // lblTraThucTe
            // 
            this.lblTraThucTe.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTraThucTe.AutoSize = true;
            this.lblTraThucTe.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTraThucTe.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTraThucTe.Location = new System.Drawing.Point(299, 260);
            this.lblTraThucTe.Name = "lblTraThucTe";
            this.lblTraThucTe.Size = new System.Drawing.Size(16, 20);
            this.lblTraThucTe.TabIndex = 13;
            this.lblTraThucTe.Text = "...";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(43, 300);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Trạng Thái Phiếu:";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTrangThai.Location = new System.Drawing.Point(299, 300);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(16, 20);
            this.lblTrangThai.TabIndex = 15;
            this.lblTrangThai.Text = "...";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(43, 340);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "Ghi Chú:";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblGhiChu.Location = new System.Drawing.Point(299, 340);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(16, 20);
            this.lblGhiChu.TabIndex = 17;
            this.lblGhiChu.Text = "...";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(265, 460);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // FormChiTietMuonTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(650, 520);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tableMain);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormChiTietMuonTra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi Tiết Phiếu Mượn";
            this.tableMain.ResumeLayout(false);
            this.tableMain.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TableLayoutPanel tableMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMaDK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNguoiMuon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDonVi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblThietBi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNgayMuon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTraDuKien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTraThucTe;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.Button btnClose;
    }
}
