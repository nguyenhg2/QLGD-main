namespace QLGD_WinForm
{
    partial class FormMain
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.TableLayoutPanel();
            this.btnThietBi = new System.Windows.Forms.Button();
            this.btnMuonTra = new System.Windows.Forms.Button();
            this.btnGiangDuong = new System.Windows.Forms.Button();
            this.btnSuCo = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(180, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(735, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ TRANG THIẾT BỊ VẬT TƯ GIẢNG ĐƯỜNG";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.LightGray;
            this.pnlFooter.Controls.Add(this.lblCopyright);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 670);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1100, 30);
            this.pnlFooter.TabIndex = 1;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCopyright.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblCopyright.ForeColor = System.Drawing.Color.DimGray;
            this.lblCopyright.Location = new System.Drawing.Point(0, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(1100, 30);
            this.lblCopyright.TabIndex = 0;
            this.lblCopyright.Text = "© 2025 K59 - HVKTQS. All rights reserved.";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMenu
            // 
            this.pnlMenu.ColumnCount = 2;
            this.pnlMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlMenu.Controls.Add(this.btnThietBi, 0, 0);
            this.pnlMenu.Controls.Add(this.btnMuonTra, 1, 0);
            this.pnlMenu.Controls.Add(this.btnGiangDuong, 0, 1);
            this.pnlMenu.Controls.Add(this.btnSuCo, 1, 1);
            this.pnlMenu.Controls.Add(this.btnThoat, 0, 2);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenu.Location = new System.Drawing.Point(0, 80);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Padding = new System.Windows.Forms.Padding(100, 50, 100, 50);
            this.pnlMenu.RowCount = 3;
            this.pnlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.pnlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.pnlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlMenu.Size = new System.Drawing.Size(1100, 590);
            this.pnlMenu.TabIndex = 2;
            // 
            // btnThietBi
            // 
            this.btnThietBi.BackColor = System.Drawing.Color.White;
            this.btnThietBi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThietBi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThietBi.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnThietBi.FlatAppearance.BorderSize = 2;
            this.btnThietBi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThietBi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThietBi.ForeColor = System.Drawing.Color.Teal;
            this.btnThietBi.Location = new System.Drawing.Point(103, 53);
            this.btnThietBi.Margin = new System.Windows.Forms.Padding(3, 3, 15, 15);
            this.btnThietBi.Name = "btnThietBi";
            this.btnThietBi.Size = new System.Drawing.Size(432, 178);
            this.btnThietBi.TabIndex = 0;
            this.btnThietBi.Text = "📦\r\n\r\nQUẢN LÝ THIẾT BỊ\r\n\r\nDanh sách, nhập mới, sửa, xóa thiết bị";
            this.btnThietBi.UseVisualStyleBackColor = false;
            // 
            // btnMuonTra
            // 
            this.btnMuonTra.BackColor = System.Drawing.Color.White;
            this.btnMuonTra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMuonTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMuonTra.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btnMuonTra.FlatAppearance.BorderSize = 2;
            this.btnMuonTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMuonTra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnMuonTra.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnMuonTra.Location = new System.Drawing.Point(565, 53);
            this.btnMuonTra.Margin = new System.Windows.Forms.Padding(15, 3, 3, 15);
            this.btnMuonTra.Name = "btnMuonTra";
            this.btnMuonTra.Size = new System.Drawing.Size(432, 178);
            this.btnMuonTra.TabIndex = 1;
            this.btnMuonTra.Text = "📝\r\n\r\nMƯỢN / TRẢ ĐỒ\r\n\r\nQuản lý phiếu mượn, trả thiết bị";
            this.btnMuonTra.UseVisualStyleBackColor = false;
            // 
            // btnGiangDuong
            // 
            this.btnGiangDuong.BackColor = System.Drawing.Color.White;
            this.btnGiangDuong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGiangDuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGiangDuong.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnGiangDuong.FlatAppearance.BorderSize = 2;
            this.btnGiangDuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiangDuong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnGiangDuong.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnGiangDuong.Location = new System.Drawing.Point(103, 249);
            this.btnGiangDuong.Margin = new System.Windows.Forms.Padding(3, 3, 15, 15);
            this.btnGiangDuong.Name = "btnGiangDuong";
            this.btnGiangDuong.Size = new System.Drawing.Size(432, 178);
            this.btnGiangDuong.TabIndex = 2;
            this.btnGiangDuong.Text = "🏫\r\n\r\nQUỸ PHÒNG HỌC\r\n\r\nQuản lý danh sách giảng đường, phòng học";
            this.btnGiangDuong.UseVisualStyleBackColor = false;
            // 
            // btnSuCo
            // 
            this.btnSuCo.BackColor = System.Drawing.Color.White;
            this.btnSuCo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuCo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSuCo.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnSuCo.FlatAppearance.BorderSize = 2;
            this.btnSuCo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuCo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSuCo.ForeColor = System.Drawing.Color.Firebrick;
            this.btnSuCo.Location = new System.Drawing.Point(565, 249);
            this.btnSuCo.Margin = new System.Windows.Forms.Padding(15, 3, 3, 15);
            this.btnSuCo.Name = "btnSuCo";
            this.btnSuCo.Size = new System.Drawing.Size(432, 178);
            this.btnSuCo.TabIndex = 3;
            this.btnSuCo.Text = "🔧\r\n\r\nSỰ CỐ && BẢO TRÌ\r\n\r\nBáo hỏng, theo dõi sửa chữa";
            this.btnSuCo.UseVisualStyleBackColor = false;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThoat.BackColor = System.Drawing.Color.Gray;
            this.pnlMenu.SetColumnSpan(this.btnThoat, 2);
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(400, 469);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(200, 45);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát Hệ Thống";
            this.btnThoat.UseVisualStyleBackColor = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QLGD";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.TableLayoutPanel pnlMenu;
        private System.Windows.Forms.Button btnThietBi;
        private System.Windows.Forms.Button btnMuonTra;
        private System.Windows.Forms.Button btnGiangDuong;
        private System.Windows.Forms.Button btnSuCo;
        private System.Windows.Forms.Button btnThoat;
    }
}
