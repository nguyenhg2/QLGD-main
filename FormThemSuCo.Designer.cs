namespace QLGD_WinForm
{
    partial class FormThemSuCo
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtNguoiBao = new System.Windows.Forms.TextBox();
            this.lblNguoiBao = new System.Windows.Forms.Label();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.lblNgay = new System.Windows.Forms.Label();
            this.cboLoaiSuKien = new System.Windows.Forms.ComboBox();
            this.lblLoaiSuKien = new System.Windows.Forms.Label();
            this.lblThongTinTB = new System.Windows.Forms.Label();
            this.lblCanhBao = new System.Windows.Forms.Label();
            this.cboThietBi = new System.Windows.Forms.ComboBox();
            this.btnLoadTB = new System.Windows.Forms.Button();
            this.txtMaTB = new System.Windows.Forms.TextBox();
            this.lblChonTB = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Firebrick;
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(700, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(700, 60);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "THÔNG TIN SỰ CỐ";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBody
            // 
            this.pnlBody.AutoScroll = true;
            this.pnlBody.Controls.Add(this.txtMoTa);
            this.pnlBody.Controls.Add(this.lblMoTa);
            this.pnlBody.Controls.Add(this.txtNguoiBao);
            this.pnlBody.Controls.Add(this.lblNguoiBao);
            this.pnlBody.Controls.Add(this.dtpNgay);
            this.pnlBody.Controls.Add(this.lblNgay);
            this.pnlBody.Controls.Add(this.cboLoaiSuKien);
            this.pnlBody.Controls.Add(this.lblLoaiSuKien);
            this.pnlBody.Controls.Add(this.lblThongTinTB);
            this.pnlBody.Controls.Add(this.lblCanhBao);
            this.pnlBody.Controls.Add(this.cboThietBi);
            this.pnlBody.Controls.Add(this.btnLoadTB);
            this.pnlBody.Controls.Add(this.txtMaTB);
            this.pnlBody.Controls.Add(this.lblChonTB);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 60);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.pnlBody.Size = new System.Drawing.Size(700, 450);
            this.pnlBody.TabIndex = 1;
            // 
            // lblChonTB
            // 
            this.lblChonTB.AutoSize = true;
            this.lblChonTB.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblChonTB.Location = new System.Drawing.Point(10, 13);
            this.lblChonTB.Name = "lblChonTB";
            this.lblChonTB.Size = new System.Drawing.Size(120, 19);
            this.lblChonTB.TabIndex = 0;
            this.lblChonTB.Text = "Chọn Thiết Bị (*):";
            // 
            // txtMaTB
            // 
            this.txtMaTB.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaTB.Location = new System.Drawing.Point(150, 10);
            this.txtMaTB.Name = "txtMaTB";
            this.txtMaTB.PlaceholderText = "Nhập mã TB...";
            this.txtMaTB.Size = new System.Drawing.Size(200, 25);
            this.txtMaTB.TabIndex = 1;
            // 
            // btnLoadTB
            // 
            this.btnLoadTB.BackColor = System.Drawing.Color.Teal;
            this.btnLoadTB.FlatAppearance.BorderSize = 0;
            this.btnLoadTB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadTB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLoadTB.ForeColor = System.Drawing.Color.White;
            this.btnLoadTB.Location = new System.Drawing.Point(360, 8);
            this.btnLoadTB.Name = "btnLoadTB";
            this.btnLoadTB.Size = new System.Drawing.Size(80, 28);
            this.btnLoadTB.TabIndex = 2;
            this.btnLoadTB.Text = "Tải TB";
            this.btnLoadTB.UseVisualStyleBackColor = false;
            // 
            // cboThietBi
            // 
            this.cboThietBi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThietBi.Enabled = false;
            this.cboThietBi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboThietBi.FormattingEnabled = true;
            this.cboThietBi.Location = new System.Drawing.Point(150, 45);
            this.cboThietBi.Name = "cboThietBi";
            this.cboThietBi.Size = new System.Drawing.Size(450, 25);
            this.cboThietBi.TabIndex = 3;
            // 
            // lblCanhBao
            // 
            this.lblCanhBao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCanhBao.ForeColor = System.Drawing.Color.Red;
            this.lblCanhBao.Location = new System.Drawing.Point(150, 80);
            this.lblCanhBao.Name = "lblCanhBao";
            this.lblCanhBao.Size = new System.Drawing.Size(450, 50);
            this.lblCanhBao.TabIndex = 4;
            this.lblCanhBao.Visible = false;
            // 
            // lblThongTinTB
            // 
            this.lblThongTinTB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblThongTinTB.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblThongTinTB.Location = new System.Drawing.Point(150, 135);
            this.lblThongTinTB.Name = "lblThongTinTB";
            this.lblThongTinTB.Size = new System.Drawing.Size(450, 40);
            this.lblThongTinTB.TabIndex = 5;
            this.lblThongTinTB.Visible = false;
            // 
            // lblLoaiSuKien
            // 
            this.lblLoaiSuKien.AutoSize = true;
            this.lblLoaiSuKien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLoaiSuKien.Location = new System.Drawing.Point(10, 183);
            this.lblLoaiSuKien.Name = "lblLoaiSuKien";
            this.lblLoaiSuKien.Size = new System.Drawing.Size(95, 19);
            this.lblLoaiSuKien.TabIndex = 6;
            this.lblLoaiSuKien.Text = "Loại Sự Kiện:";
            // 
            // cboLoaiSuKien
            // 
            this.cboLoaiSuKien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiSuKien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiSuKien.FormattingEnabled = true;
            this.cboLoaiSuKien.Items.AddRange(new object[] {
            "Sự cố",
            "Bảo trì định kỳ",
            "Bảo trì đột xuất"});
            this.cboLoaiSuKien.Location = new System.Drawing.Point(150, 180);
            this.cboLoaiSuKien.Name = "cboLoaiSuKien";
            this.cboLoaiSuKien.Size = new System.Drawing.Size(450, 25);
            this.cboLoaiSuKien.TabIndex = 7;
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNgay.Location = new System.Drawing.Point(10, 223);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(76, 19);
            this.lblNgay.TabIndex = 8;
            this.lblNgay.Text = "Thời Gian:";
            // 
            // dtpNgay
            // 
            this.dtpNgay.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpNgay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgay.Location = new System.Drawing.Point(150, 220);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(250, 25);
            this.dtpNgay.TabIndex = 9;
            // 
            // lblNguoiBao
            // 
            this.lblNguoiBao.AutoSize = true;
            this.lblNguoiBao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNguoiBao.Location = new System.Drawing.Point(10, 263);
            this.lblNguoiBao.Name = "lblNguoiBao";
            this.lblNguoiBao.Size = new System.Drawing.Size(122, 19);
            this.lblNguoiBao.TabIndex = 10;
            this.lblNguoiBao.Text = "Người Báo/Xử Lý:";
            // 
            // txtNguoiBao
            // 
            this.txtNguoiBao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNguoiBao.Location = new System.Drawing.Point(150, 260);
            this.txtNguoiBao.Name = "txtNguoiBao";
            this.txtNguoiBao.Size = new System.Drawing.Size(450, 25);
            this.txtNguoiBao.TabIndex = 11;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMoTa.Location = new System.Drawing.Point(10, 303);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(109, 19);
            this.lblMoTa.TabIndex = 12;
            this.lblMoTa.Text = "Mô Tả Chi Tiết:";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMoTa.Location = new System.Drawing.Point(150, 300);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMoTa.Size = new System.Drawing.Size(450, 80);
            this.txtMoTa.TabIndex = 13;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlFooter.Controls.Add(this.btnHuy);
            this.pnlFooter.Controls.Add(this.btnLuu);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 510);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(700, 70);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.Firebrick;
            this.btnLuu.Enabled = false;
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(460, 16);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(120, 38);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "LƯU SỰ CỐ";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.Gray;
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(590, 16);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(90, 38);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            // 
            // FormThemSuCo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 580);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormThemSuCo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "KHAI BÁO SỰ CỐ / BẢO TRÌ";
            this.pnlHeader.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblChonTB;
        private System.Windows.Forms.TextBox txtMaTB;
        private System.Windows.Forms.Button btnLoadTB;
        private System.Windows.Forms.ComboBox cboThietBi;
        private System.Windows.Forms.Label lblCanhBao;
        private System.Windows.Forms.Label lblThongTinTB;
        private System.Windows.Forms.Label lblLoaiSuKien;
        private System.Windows.Forms.ComboBox cboLoaiSuKien;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Label lblNguoiBao;
        private System.Windows.Forms.TextBox txtNguoiBao;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
    }
}
