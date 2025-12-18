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
                Location = new Point(20, 40),
                AutoSize = true,
                Font = new Font("Segoe UI", 9)
            };

            txtTimKiem = new TextBox
            {
                Location = new Point(90, 37),
                Width = 250,
                Font = new Font("Segoe UI", 10),
                PlaceholderText = "Mã phiếu, Tên người, Tên TB..."
            };

            btnTimKiem = new Button
            {
                Text = "Tìm",
                Location = new Point(350, 35),
                Size = new Size(80, 28),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnLamMoi = new Button
            {
                Text = "Làm Mới",
                Location = new Point(440, 35),
                Size = new Size(100, 28),
                BackColor = Color.White
            };

            btnMuonMoi = new Button
            {
                Text = "Mượn Mới",
                Location = new Point(560, 35),
                Size = new Size(120, 28),
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            btnTraDo = new Button
            {
                Text = "Trả Thiết Bị",
                Location = new Point(690, 35),
                Size = new Size(120, 28),
                BackColor = Color.DarkOrange,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            Button btnCanhBao = new Button
            {
                Text = "DS Quá Hạn",
                Location = new Point(820, 35),
                Size = new Size(120, 28),
                BackColor = Color.Firebrick,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            pnlTop.Controls.AddRange(new Control[] {
                rdoDangMuon, rdoLichSu, lblTim, txtTimKiem, btnTimKiem, btnLamMoi,
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
                    LoadData(txtTimKiem.Text.Trim());
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

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu!\n\nVui lòng chạy script sinh dữ liệu!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    dgvMain.AutoGenerateColumns = true;
                    dgvMain.DataSource = dt;

                    btnTraDo.Enabled = rdoDangMuon.Checked;

                    if (dt.Rows.Count > 0)
                    {
                        ApplyFormatting();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"LỖI TẢI DỮ LIỆU:\n\n{ex.Message}\n\n{ex.StackTrace}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFormatting()
        {
            try
            {
                string dateFormat = "dd/MM/yyyy HH:mm";
                if (dgvMain.Columns.Contains("ThoiGianMuon"))
                    dgvMain.Columns["ThoiGianMuon"].DefaultCellStyle.Format = dateFormat;
                if (dgvMain.Columns.Contains("HanTra"))
                    dgvMain.Columns["HanTra"].DefaultCellStyle.Format = dateFormat;
                if (dgvMain.Columns.Contains("ThoiGianTra"))
                    dgvMain.Columns["ThoiGianTra"].DefaultCellStyle.Format = dateFormat;

                if (dgvMain.Columns.Contains("SoGioQuaHan"))
                    dgvMain.Columns["SoGioQuaHan"].Visible = false;

                if (dgvMain.Columns.Contains("TrangThai"))
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

                dgvMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                if (dgvMain.Columns.Contains("MaPhieu"))
                    dgvMain.Columns["MaPhieu"].Width = 150;
                if (dgvMain.Columns.Contains("NguoiMuon"))
                    dgvMain.Columns["NguoiMuon"].Width = 180;
                if (dgvMain.Columns.Contains("TenThietBi"))
                    dgvMain.Columns["TenThietBi"].Width = 250;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi format: {ex.Message}");
            }
        }
        #endregion

        #region Event Handlers
        private void DgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvMain.Columns.Contains("MaPhieu") &&
                dgvMain.Rows[e.RowIndex].Cells["MaPhieu"].Value != null)
            {
                string maDK = dgvMain.Rows[e.RowIndex].Cells["MaPhieu"].Value.ToString();
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

            if (!dgvMain.Columns.Contains("MaPhieu") || !dgvMain.Columns.Contains("TenThietBi"))
            {
                MessageBox.Show("Lỗi: Không tìm thấy cột dữ liệu!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maDK = dgvMain.CurrentRow.Cells["MaPhieu"].Value?.ToString();
            string tenTB = dgvMain.CurrentRow.Cells["TenThietBi"].Value?.ToString();

            if (string.IsNullOrEmpty(maDK))
            {
                MessageBox.Show("Mã phiếu không hợp lệ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show(
                $"XÁC NHẬN TRẢ THIẾT BỊ\n\n" +
                $"Thiết bị: {tenTB}\n" +
                $"Mã phiếu: {maDK}\n\n" +
                $"Trạng thái thiết bị khi trả?\n\n" +
                $"• YES = Tốt (0)\n" +
                $"• NO = Hỏng (2)\n" +
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