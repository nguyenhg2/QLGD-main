namespace QLGD_WinForm
{
    partial class FormMuonTra
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
            rdoDangMuon = new RadioButton();
            rdoLichSu = new RadioButton();
            lblTim = new Label();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            btnLamMoi = new Button();
            btnMuonMoi = new Button();
            btnTraDo = new Button();
            btnCanhBao = new Button();
            pnlTop.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(btnCanhBao);
            pnlTop.Controls.Add(btnTraDo);
            pnlTop.Controls.Add(btnMuonMoi);
            pnlTop.Controls.Add(btnLamMoi);
            pnlTop.Controls.Add(btnTimKiem);
            pnlTop.Controls.Add(txtTimKiem);
            pnlTop.Controls.Add(lblTim);
            pnlTop.Controls.Add(rdoLichSu);
            pnlTop.Controls.Add(rdoDangMuon);
            pnlTop.Margin = new Padding(5, 8, 5, 8);
            pnlTop.Size = new Size(1924, 107);
            // 
            // rdoDangMuon
            // 
            rdoDangMuon.AutoSize = true;
            rdoDangMuon.Checked = true;
            rdoDangMuon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            rdoDangMuon.ForeColor = Color.DarkBlue;
            rdoDangMuon.Location = new Point(26, 15);
            rdoDangMuon.Margin = new Padding(4, 5, 4, 5);
            rdoDangMuon.Name = "rdoDangMuon";
            rdoDangMuon.Size = new Size(127, 27);
            rdoDangMuon.TabIndex = 0;
            rdoDangMuon.TabStop = true;
            rdoDangMuon.Text = "Đang Mượn";
            rdoDangMuon.UseVisualStyleBackColor = true;
            // 
            // rdoLichSu
            // 
            rdoLichSu.AutoSize = true;
            rdoLichSu.Font = new Font("Segoe UI", 10F);
            rdoLichSu.Location = new Point(193, 15);
            rdoLichSu.Margin = new Padding(4, 5, 4, 5);
            rdoLichSu.Name = "rdoLichSu";
            rdoLichSu.Size = new Size(146, 27);
            rdoLichSu.TabIndex = 1;
            rdoLichSu.Text = "Lịch Sử (Tất cả)";
            rdoLichSu.UseVisualStyleBackColor = true;
            // 
            // lblTim
            // 
            lblTim.AutoSize = true;
            lblTim.Font = new Font("Segoe UI", 9F);
            lblTim.Location = new Point(26, 64);
            lblTim.Margin = new Padding(4, 0, 4, 0);
            lblTim.Name = "lblTim";
            lblTim.Size = new Size(73, 20);
            lblTim.TabIndex = 2;
            lblTim.Text = "Tìm kiếm:";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 10F);
            txtTimKiem.Location = new Point(116, 60);
            txtTimKiem.Margin = new Padding(4, 5, 4, 5);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Mã phiếu, tên người, SĐT, tên TB, loại TB, phòng...";
            txtTimKiem.Size = new Size(385, 30);
            txtTimKiem.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.SteelBlue;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(514, 57);
            btnTimKiem.Margin = new Padding(4, 5, 4, 5);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(103, 43);
            btnTimKiem.TabIndex = 4;
            btnTimKiem.Text = "Tìm";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.White;
            btnLamMoi.Location = new Point(630, 57);
            btnLamMoi.Margin = new Padding(4, 5, 4, 5);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(116, 43);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "Làm Mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnMuonMoi
            // 
            btnMuonMoi.BackColor = Color.ForestGreen;
            btnMuonMoi.FlatStyle = FlatStyle.Flat;
            btnMuonMoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMuonMoi.ForeColor = Color.White;
            btnMuonMoi.Location = new Point(771, 57);
            btnMuonMoi.Margin = new Padding(4, 5, 4, 5);
            btnMuonMoi.Name = "btnMuonMoi";
            btnMuonMoi.Size = new Size(141, 43);
            btnMuonMoi.TabIndex = 6;
            btnMuonMoi.Text = "Mượn Mới";
            btnMuonMoi.UseVisualStyleBackColor = false;
            // 
            // btnTraDo
            // 
            btnTraDo.BackColor = Color.DarkOrange;
            btnTraDo.FlatStyle = FlatStyle.Flat;
            btnTraDo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTraDo.ForeColor = Color.White;
            btnTraDo.Location = new Point(926, 57);
            btnTraDo.Margin = new Padding(4, 5, 4, 5);
            btnTraDo.Name = "btnTraDo";
            btnTraDo.Size = new Size(141, 43);
            btnTraDo.TabIndex = 7;
            btnTraDo.Text = "Trả Thiết Bị";
            btnTraDo.UseVisualStyleBackColor = false;
            // 
            // btnCanhBao
            // 
            btnCanhBao.BackColor = Color.Firebrick;
            btnCanhBao.FlatStyle = FlatStyle.Flat;
            btnCanhBao.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCanhBao.ForeColor = Color.White;
            btnCanhBao.Location = new Point(1080, 57);
            btnCanhBao.Margin = new Padding(4, 5, 4, 5);
            btnCanhBao.Name = "btnCanhBao";
            btnCanhBao.Size = new Size(141, 43);
            btnCanhBao.TabIndex = 8;
            btnCanhBao.Text = "DS Quá Hạn";
            btnCanhBao.UseVisualStyleBackColor = false;
            // 
            // FormMuonTra
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1055);
            Margin = new Padding(5, 8, 5, 8);
            Name = "FormMuonTra";
            Text = "Quản Lý Mượn Trả";
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.RadioButton rdoDangMuon;
        private System.Windows.Forms.RadioButton rdoLichSu;
        private System.Windows.Forms.Label lblTim;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnMuonMoi;
        private System.Windows.Forms.Button btnTraDo;
        private System.Windows.Forms.Button btnCanhBao;
    }
}
