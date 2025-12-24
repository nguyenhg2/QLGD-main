namespace QLGD_WinForm
{
    partial class FormThietBi
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
            this.lblChon = new System.Windows.Forms.Label();
            this.cboGiangDuong = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblTim = new System.Windows.Forms.Label();
            this.txtTimKiemTB = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnDel);
            this.pnlTop.Controls.Add(this.btnEdit);
            this.pnlTop.Controls.Add(this.btnAdd);
            this.pnlTop.Controls.Add(this.txtTimKiemTB);
            this.pnlTop.Controls.Add(this.lblTim);
            this.pnlTop.Controls.Add(this.cboTrangThai);
            this.pnlTop.Controls.Add(this.lblTrangThai);
            this.pnlTop.Controls.Add(this.cboGiangDuong);
            this.pnlTop.Controls.Add(this.lblChon);
            this.pnlTop.Size = new System.Drawing.Size(1400, 60);
            // 
            // dgvMain
            // 
            this.dgvMain.Size = new System.Drawing.Size(1400, 690);
            // 
            // lblChon
            // 
            this.lblChon.AutoSize = true;
            this.lblChon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblChon.Location = new System.Drawing.Point(20, 23);
            this.lblChon.Name = "lblChon";
            this.lblChon.Size = new System.Drawing.Size(95, 19);
            this.lblChon.TabIndex = 0;
            this.lblChon.Text = "Giảng Đường:";
            // 
            // cboGiangDuong
            // 
            this.cboGiangDuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGiangDuong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboGiangDuong.FormattingEnabled = true;
            this.cboGiangDuong.Location = new System.Drawing.Point(120, 20);
            this.cboGiangDuong.Name = "cboGiangDuong";
            this.cboGiangDuong.Size = new System.Drawing.Size(120, 25);
            this.cboGiangDuong.TabIndex = 1;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTrangThai.Location = new System.Drawing.Point(260, 23);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(74, 19);
            this.lblTrangThai.TabIndex = 2;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Items.AddRange(new object[] {
            "Tất cả",
            "Tốt",
            "Đang sử dụng",
            "Hỏng",
            "Đang sửa chữa",
            "Chờ thanh lý"});
            this.cboTrangThai.Location = new System.Drawing.Point(350, 20);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(140, 25);
            this.cboTrangThai.TabIndex = 3;
            // 
            // lblTim
            // 
            this.lblTim.AutoSize = true;
            this.lblTim.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTim.Location = new System.Drawing.Point(520, 23);
            this.lblTim.Name = "lblTim";
            this.lblTim.Size = new System.Drawing.Size(55, 19);
            this.lblTim.TabIndex = 4;
            this.lblTim.Text = "Tìm TB:";
            // 
            // txtTimKiemTB
            // 
            this.txtTimKiemTB.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiemTB.Location = new System.Drawing.Point(590, 20);
            this.txtTimKiemTB.Name = "txtTimKiemTB";
            this.txtTimKiemTB.PlaceholderText = "Tên hoặc mã TB...";
            this.txtTimKiemTB.Size = new System.Drawing.Size(200, 25);
            this.txtTimKiemTB.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Teal;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(820, 18);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 32);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Thêm TB";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(940, 18);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 32);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.IndianRed;
            this.btnDel.ForeColor = System.Drawing.Color.White;
            this.btnDel.Location = new System.Drawing.Point(1040, 18);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(90, 32);
            this.btnDel.TabIndex = 8;
            this.btnDel.Text = "Xóa";
            this.btnDel.UseVisualStyleBackColor = false;
            // 
            // FormThietBi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 750);
            this.Name = "FormThietBi";
            this.Text = "Quản Lý Thiết Bị Theo Giảng Đường";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblChon;
        private System.Windows.Forms.ComboBox cboGiangDuong;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label lblTim;
        private System.Windows.Forms.TextBox txtTimKiemTB;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDel;
    }
}
