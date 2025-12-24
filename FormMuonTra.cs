using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QLGD_WinForm
{
    public partial class FormMuonTra : BaseManagementForm
    {
        public FormMuonTra()
        {
            InitializeComponent();
            SetupEvents();
            LoadData();
        }

        #region Events Setup
        private void SetupEvents()
        {
            rdoDangMuon.CheckedChanged += RdoDangMuon_CheckedChanged;
            rdoLichSu.CheckedChanged += RdoLichSu_CheckedChanged;

            btnTimKiem.Click += BtnTimKiem_Click;
            txtTimKiem.KeyDown += TxtTimKiem_KeyDown;

            btnLamMoi.Click += BtnLamMoi_Click;
            btnMuonMoi.Click += BtnMuonMoi_Click;
            btnTraDo.Click += BtnTraDo_Click;
            btnCanhBao.Click += BtnCanhBao_Click;

            dgvMain.CellDoubleClick += DgvMain_CellDoubleClick;
        }
        #endregion

        #region Event Handlers
        private void RdoDangMuon_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDangMuon.Checked) LoadData();
        }

        private void RdoLichSu_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoLichSu.Checked) LoadData();
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData(txtTimKiem.Text.Trim());
        }

        private void TxtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData(txtTimKiem.Text.Trim());
                e.SuppressKeyPress = true;
            }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadData();
        }

        private void BtnMuonMoi_Click(object sender, EventArgs e)
        {
            if (new FormNhapMuon().ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void BtnCanhBao_Click(object sender, EventArgs e)
        {
            new FormDanhSachQuaHan().ShowDialog();
        }

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
    }
}
