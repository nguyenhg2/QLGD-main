using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QLGD_WinForm
{
    public class FormCapNhatSuCo : Form
    {
        private string _maSuKien;
        private Label lblThongTin;
        private ComboBox cboTrangThai;
        private NumericUpDown numChiPhi;
        private TextBox txtGhiChu;
        private TextBox txtNguoiXuLy;
        private Button btnLuu;
        private Button btnHuy;

        public FormCapNhatSuCo(string maSuKien, string tenTB, string trangThaiCu, decimal chiPhiCu)
        {
            _maSuKien = maSuKien;
            InitializeUI();

            lblThongTin.Text = $"Sự kiện: {maSuKien}\nThiết bị: {tenTB}";

            cboTrangThai.SelectedIndex = trangThaiCu switch
            {
                "Chờ xử lý" => 0,
                "Đang sửa chữa" => 0,
                "Đã xử lý" => 1,
                _ => 0
            };

            numChiPhi.Value = chiPhiCu;
        }

        #region UI Setup
        private void InitializeUI()
        {
            this.Text = "CẬP NHẬT TRẠNG THÁI & CHI PHÍ";
            this.Size = new Size(500, 480);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.White;

            TableLayoutPanel table = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 320,
                ColumnCount = 2,
                Padding = new Padding(20),
                RowCount = 5
            };
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));

            lblThongTin = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Teal
            };
            table.Controls.Add(lblThongTin, 0, 0);
            table.SetColumnSpan(lblThongTin, 2);

            cboTrangThai = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Height = 30,
                Font = new Font("Segoe UI", 10)
            };
            cboTrangThai.Items.AddRange(new object[] { "Đang sửa chữa", "Đã xử lý" });
            AddRow(table, "Trạng Thái:", cboTrangThai);

            txtNguoiXuLy = new TextBox { Height = 30, Font = new Font("Segoe UI", 10) };
            AddRow(table, "Người Xử Lý:", txtNguoiXuLy);

            numChiPhi = new NumericUpDown
            {
                Minimum = 0,
                Maximum = 1000000000,
                Increment = 10000,
                DecimalPlaces = 0,
                Width = 200,
                Font = new Font("Segoe UI", 10)
            };
            AddRow(table, "Chi Phí (VNĐ):", numChiPhi);

            txtGhiChu = new TextBox
            {
                Multiline = true,
                Height = 80,
                Font = new Font("Segoe UI", 10),
                ScrollBars = ScrollBars.Vertical
            };
            Label lblKQ = new Label
            {
                Text = "Ghi chú:",
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            table.Controls.Add(lblKQ);
            table.Controls.Add(txtGhiChu);

            btnLuu = new Button
            {
                Text = "CẬP NHẬT",
                DialogResult = DialogResult.None,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
                Height = 40,
                Width = 110
            };
            btnHuy = new Button
            {
                Text = "Hủy",
                DialogResult = DialogResult.Cancel,
                Height = 40,
                Width = 100
            };

            btnLuu.Click += BtnLuu_Click;

            FlowLayoutPanel pnlBtn = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.RightToLeft,
                Dock = DockStyle.Bottom,
                Height = 70,
                Padding = new Padding(15)
            };
            pnlBtn.Controls.Add(btnHuy);
            pnlBtn.Controls.Add(btnLuu);

            this.Controls.Add(table);
            this.Controls.Add(pnlBtn);
        }

        private void AddRow(TableLayoutPanel table, string label, Control ctrl)
        {
            Label lbl = new Label
            {
                Text = label,
                AutoSize = true,
                Anchor = AnchorStyles.Left,
                Font = new Font("Segoe UI", 10)
            };
            ctrl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            table.Controls.Add(lbl);
            table.Controls.Add(ctrl);
        }
        #endregion

        #region Actions
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand("sp_CapNhatSuCo", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaSuKien", _maSuKien);

                    int trangThaiInt = cboTrangThai.SelectedIndex + 1;
                    cmd.Parameters.AddWithValue("@TrangThai", trangThaiInt);

                    cmd.Parameters.AddWithValue("@ChiPhi", numChiPhi.Value);
                    cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text.Trim());
                    cmd.Parameters.AddWithValue("@NguoiXuLy", txtNguoiXuLy.Text.Trim());

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cập nhật thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        #endregion
    }
}