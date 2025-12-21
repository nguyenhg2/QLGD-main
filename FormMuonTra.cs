using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QLGD_WinForm
{
    public class FormMuonTra : BaseManagementForm
    {
        private Button btnTraDo;
        private Button btnMuonMoi;
        private RadioButton rdoDangMuon;
        private RadioButton rdoLichSu;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private Button btnLamMoi;

        public FormMuonTra() : base("Quản Lý Mượn Trả", "MuonTra", new Size(1500, 800))
        {
            InitializeCustomToolbar();
            InitializeEvents();
            LoadData();
        }

        #region UI Setup
        private void InitializeCustomToolbar()
        {
            pnlTop.Controls.Clear();
            pnlTop.Height = 70;

            rdoDangMuon = new RadioButton
            {
                Text = "Đang Mượn",
                Location = new Point(20, 10),
                Checked = true,
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.DarkBlue
            };

            rdoLichSu = new RadioButton
            {
                Text = "Lịch Sử (Tất cả)",
                Location = new Point(150, 10),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };

            Label lblTim = new Label
            {
                Text = "Tìm kiếm:",
                Location = new Point(20, 42),
                AutoSize = true,
                Font = new Font("Segoe UI", 9)
            };

            txtTimKiem = new TextBox
            {
                Location = new Point(90, 39),
                Width = 300,
                Font = new Font("Segoe UI", 10),
                PlaceholderText = "Mã phiếu, tên người, SĐT, tên TB, loại TB, phòng..."
            };

            btnTimKiem = new Button
            {
                Text = "Tìm",
                Location = new Point(400, 37),
                Size = new Size(80, 28),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnLamMoi = new Button
            {
                Text = "Làm Mới",
                Location = new Point(490, 37),
                Size = new Size(90, 28),
                BackColor = Color.White
            };

            btnMuonMoi = new Button
            {
                Text = "Mượn Mới",
                Location = new Point(600, 37),
                Size = new Size(110, 28),
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            btnTraDo = new Button
            {
                Text = "Trả Thiết Bị",
                Location = new Point(720, 37),
                Size = new Size(110, 28),
                BackColor = Color.DarkOrange,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            Button btnCanhBao = new Button
            {
                Text = "DS Quá Hạn",
                Location = new Point(840, 37),
                Size = new Size(110, 28),
                BackColor = Color.Firebrick,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            pnlTop.Controls.AddRange(new Control[] {
                rdoDangMuon, rdoLichSu,
                lblTim, txtTimKiem, btnTimKiem, btnLamMoi,
                btnMuonMoi, btnTraDo, btnCanhBao
            });

            btnCanhBao.Click += (s, e) => { new FormDanhSachQuaHan().ShowDialog(); };
        }

        private void InitializeEvents()
        {
            rdoDangMuon.CheckedChanged += (s, e) => { if (rdoDangMuon.Checked) LoadData(); };
            rdoLichSu.CheckedChanged += (s, e) => { if (rdoLichSu.Checked) LoadData(); };

            btnTimKiem.Click += (s, e) => LoadData(txtTimKiem.Text.Trim());

            txtTimKiem.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter)
                {
                    LoadData(txtTimKiem.Text.Trim());
                    e.SuppressKeyPress = true;
                }
            };

            btnLamMoi.Click += (s, e) => {
                txtTimKiem.Clear();
                LoadData();
            };

            btnMuonMoi.Click += (s, e) => {
                if (new FormNhapMuon().ShowDialog() == DialogResult.OK)
                    LoadData();
            };

            btnTraDo.Click += BtnTraDo_Click;
            dgvMain.CellDoubleClick += DgvMain_CellDoubleClick;
        }
        #endregion

        #region Data Loading & Grid Config
        protected override void LoadData(string search = "")
        {
            int mode = rdoDangMuon.Checked ? 0 : 1;

            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand("sp_GetChiTietGiaoDich", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CheDo", mode);
                    cmd.Parameters.AddWithValue("@TuKhoa", search);

                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    this.Text = $"Quản Lý Mượn Trả - {dt.Rows.Count} kết quả";

                    ConfigureColumns();
                    dgvMain.DataSource = dt;

                    btnTraDo.Enabled = rdoDangMuon.Checked;

                    if (dt.Rows.Count > 0)
                        ApplyRowFormatting();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"LỖI TẢI DỮ LIỆU:\n\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureColumns()
        {
            dgvMain.AutoGenerateColumns = false;
            dgvMain.Columns.Clear();

            var headerStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White
            };

            var centerStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter };
            var leftStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft, Padding = new Padding(5, 0, 0, 0) };
            var dateTimeStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter, Format = "dd/MM/yyyy HH:mm" };

            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaPhieu", DataPropertyName = "MaPhieu", HeaderText = "Mã Phiếu", Width = 100, DefaultCellStyle = centerStyle });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "NguoiMuon", DataPropertyName = "NguoiMuon", HeaderText = "Người Mượn", Width = 150, DefaultCellStyle = leftStyle });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "DonVi", DataPropertyName = "DonVi", HeaderText = "Đơn Vị/Lớp", Width = 110, DefaultCellStyle = leftStyle });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "SDT", DataPropertyName = "SDT", HeaderText = "SĐT", Width = 100, DefaultCellStyle = centerStyle });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaTB", DataPropertyName = "MaTB", HeaderText = "Mã TB", Width = 80, DefaultCellStyle = centerStyle });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenThietBi", DataPropertyName = "TenThietBi", HeaderText = "Tên Thiết Bị", Width = 170, DefaultCellStyle = leftStyle });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "LoaiThietBi", DataPropertyName = "LoaiThietBi", HeaderText = "Loại TB", Width = 100, DefaultCellStyle = leftStyle });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "ViTriHienTai", DataPropertyName = "ViTriHienTai", HeaderText = "Vị Trí", Width = 80, DefaultCellStyle = centerStyle });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "ThoiGianMuon", DataPropertyName = "ThoiGianMuon", HeaderText = "Thời Gian Mượn", Width = 130, DefaultCellStyle = dateTimeStyle });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "HanTra", DataPropertyName = "HanTra", HeaderText = "Hạn Trả", Width = 130, DefaultCellStyle = dateTimeStyle });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "ThoiGianTra", DataPropertyName = "ThoiGianTra", HeaderText = "Thời Gian Trả", Width = 130, DefaultCellStyle = dateTimeStyle });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThai", DataPropertyName = "TrangThai", HeaderText = "Trạng Thái", Width = 110, DefaultCellStyle = centerStyle });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoGioQuaHan", DataPropertyName = "SoGioQuaHan", Visible = false });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "GhiChu", DataPropertyName = "GhiChu", HeaderText = "Ghi Chú", Width = 140, DefaultCellStyle = leftStyle });

            dgvMain.EnableHeadersVisualStyles = false;
            dgvMain.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvMain.ColumnHeadersHeight = 40;
        }

        private void ApplyRowFormatting()
        {
            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                if (row.IsNewRow) continue;

                var cellValue = row.Cells["TrangThai"].Value;
                if (cellValue == null) continue;

                string status = cellValue.ToString();

                if (status == "QUÁ HẠN")
                {
                    row.Cells["TrangThai"].Style.ForeColor = Color.Red;
                    row.Cells["TrangThai"].Style.Font = new Font(dgvMain.Font, FontStyle.Bold);
                    row.Cells["TrangThai"].Style.BackColor = Color.MistyRose;
                    row.DefaultCellStyle.BackColor = Color.LavenderBlush;
                }
                else if (status == "Đã hoàn thành")
                {
                    row.Cells["TrangThai"].Style.ForeColor = Color.Green;
                }
                else if (status == "Đang mượn")
                {
                    row.Cells["TrangThai"].Style.ForeColor = Color.DarkBlue;
                }
            }
        }
        #endregion

        #region Event Handlers
        private void DgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var cell = dgvMain.Rows[e.RowIndex].Cells["MaPhieu"];
            if (cell?.Value != null)
            {
                string maDK = cell.Value.ToString();
                new FormChiTietMuonTra(maDK).ShowDialog();
            }
        }

        private void BtnTraDo_Click(object sender, EventArgs e)
        {
            if (dgvMain.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn cần trả!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rowCells = dgvMain.CurrentRow.Cells;
            string maDK = rowCells["MaPhieu"].Value?.ToString();
            string tenTB = rowCells["TenThietBi"].Value?.ToString();
            string nguoiMuon = rowCells["NguoiMuon"].Value?.ToString();

            if (string.IsNullOrEmpty(maDK))
            {
                MessageBox.Show("Mã phiếu không hợp lệ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show(
                $"XÁC NHẬN TRẢ THIẾT BỊ\n\n" +
                $"Người mượn: {nguoiMuon}\n" +
                $"Thiết bị: {tenTB}\n" +
                $"Mã phiếu: {maDK}\n\n" +
                $"Trạng thái thiết bị khi trả?\n\n" +
                $"• YES = Tốt\n" +
                $"• NO = Hỏng\n" +
                $"• CANCEL = Hủy",
                "Trả Thiết Bị",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Cancel) return;

            int trangThaiTB = (result == DialogResult.Yes) ? 0 : 2;

            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand("sp_TraThietBi", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaDK", maDK);
                    cmd.Parameters.AddWithValue("@TrangThaiThietBi", trangThaiTB);
                    cmd.Parameters.AddWithValue("@GhiChu", DBNull.Value);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Trả thiết bị thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(txtTimKiem.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trả thiết bị:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
