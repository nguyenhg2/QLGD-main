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

            rdoDangMuon = new RadioButton
            {
                Text = "Đang Mượn",
                Location = new Point(20, 20),
                Checked = true,
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.DarkBlue
            };

            rdoLichSu = new RadioButton
            {
                Text = "Lịch Sử (Tất cả)",
                Location = new Point(150, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };

            Label lblTim = new Label
            {
                Text = "Tìm kiếm:",
                Location = new Point(310, 22),
                AutoSize = true,
                Font = new Font("Segoe UI", 9)
            };

            txtTimKiem = new TextBox
            {
                Location = new Point(380, 18),
                Width = 250,
                Font = new Font("Segoe UI", 10),
                PlaceholderText = "Mã phiếu, Tên người, Tên TB..."
            };

            btnTimKiem = new Button
            {
                Text = "Tìm",
                Location = new Point(640, 15),
                Size = new Size(80, 35),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnLamMoi = new Button
            {
                Text = "Làm Mới",
                Location = new Point(730, 15),
                Size = new Size(90, 35),
                BackColor = Color.White
            };

            btnMuonMoi = new Button
            {
                Text = "Mượn Mới",
                Location = new Point(840, 15),
                Size = new Size(120, 35),
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            btnTraDo = new Button
            {
                Text = "Trả Thiết Bị",
                Location = new Point(970, 15),
                Size = new Size(120, 35),
                BackColor = Color.DarkOrange,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            Button btnCanhBao = new Button
            {
                Text = "DS Quá Hạn",
                Location = new Point(1100, 15),
                Size = new Size(110, 35),
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

                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    // Áp dụng bộ lọc tìm kiếm
                    DataTable filteredTable = dt.Clone(); // Tạo bảng mới có cùng cấu trúc

                    if (!string.IsNullOrEmpty(search))
                    {
                        string searchLower = search.ToLower();

                        foreach (DataRow row in dt.Rows)
                        {
                            bool match = false;

                            // Tìm kiếm trong các cột quan trọng
                            if (row["Mã Phiếu"] != DBNull.Value &&
                                row["Mã Phiếu"].ToString().ToLower().Contains(searchLower))
                                match = true;

                            if (row["Người Mượn"] != DBNull.Value &&
                                row["Người Mượn"].ToString().ToLower().Contains(searchLower))
                                match = true;

                            if (row["Đơn Vị/Lớp"] != DBNull.Value &&
                                row["Đơn Vị/Lớp"].ToString().ToLower().Contains(searchLower))
                                match = true;

                            if (row["Tên Thiết Bị"] != DBNull.Value &&
                                row["Tên Thiết Bị"].ToString().ToLower().Contains(searchLower))
                                match = true;

                            if (row["Mã TB"] != DBNull.Value &&
                                row["Mã TB"].ToString().ToLower().Contains(searchLower))
                                match = true;

                            if (row["Vị Trí Hiện Tại"] != DBNull.Value &&
                                row["Vị Trí Hiện Tại"].ToString().ToLower().Contains(searchLower))
                                match = true;

                            if (row["Trạng Thái"] != DBNull.Value &&
                                row["Trạng Thái"].ToString().ToLower().Contains(searchLower))
                                match = true;

                            if (match)
                            {
                                filteredTable.ImportRow(row);
                            }
                        }

                        dgvMain.DataSource = filteredTable;
                        this.Text = $"Quản Lý Mượn Trả - {filteredTable.Rows.Count} kết quả";
                    }
                    else
                    {
                        dgvMain.DataSource = dt;
                        this.Text = $"Quản Lý Mượn Trả - {dt.Rows.Count} kết quả";
                    }

                    btnTraDo.Enabled = rdoDangMuon.Checked;
                    ConfigureGridColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ConfigureGridColumns()
        {
            try
            {
                if (dgvMain.Columns.Count == 0) return;

                dgvMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dgvMain.ColumnHeadersHeight = 50;
                dgvMain.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvMain.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                void SetCol(string dbCol, string headerText, int width)
                {
                    if (dgvMain.Columns.Contains(dbCol))
                    {
                        dgvMain.Columns[dbCol].HeaderText = headerText;
                        dgvMain.Columns[dbCol].Width = width;
                    }
                }

                SetCol("Mã Phiếu", "Mã Phiếu", 100);
                SetCol("Người Mượn", "Họ Tên Người Mượn", 180);
                SetCol("Đơn Vị/Lớp", "Đơn Vị / Lớp", 180);
                SetCol("Tên Thiết Bị", "Tên Thiết Bị", 240);
                SetCol("Mã TB", "Mã Thiết Bị", 100);
                SetCol("Vị Trí Hiện Tại", "Vị Trí Hiện Tại", 100);
                SetCol("Thời Gian Mượn", "Thời Gian Mượn", 140);
                SetCol("Hạn Trả", "Thời Gian Trả Dự Kiến", 150);
                SetCol("Thời Gian Trả", "Thời Gian Trả Thực Tế", 150);
                SetCol("Trạng Thái", "Trạng Thái Phiếu", 130);

                string dateFormat = "dd/MM/yyyy HH:mm";
                if (dgvMain.Columns.Contains("Thời Gian Mượn"))
                    dgvMain.Columns["Thời Gian Mượn"].DefaultCellStyle.Format = dateFormat;
                if (dgvMain.Columns.Contains("Hạn Trả"))
                    dgvMain.Columns["Hạn Trả"].DefaultCellStyle.Format = dateFormat;
                if (dgvMain.Columns.Contains("Thời Gian Trả"))
                    dgvMain.Columns["Thời Gian Trả"].DefaultCellStyle.Format = dateFormat;

                if (dgvMain.Columns.Contains("Trạng Thái"))
                {
                    foreach (DataGridViewRow row in dgvMain.Rows)
                    {
                        if (row.IsNewRow) continue;

                        var cellValue = row.Cells["Trạng Thái"].Value;
                        if (cellValue == null) continue;

                        string status = cellValue.ToString();

                        if (status == "QUÁ HẠN")
                        {
                            row.Cells["Trạng Thái"].Style.ForeColor = Color.Red;
                            row.Cells["Trạng Thái"].Style.Font = new Font(dgvMain.Font, FontStyle.Bold);
                            row.Cells["Trạng Thái"].Style.BackColor = Color.MistyRose;
                        }
                        else if (status == "Đã hoàn thành")
                        {
                            row.Cells["Trạng Thái"].Style.ForeColor = Color.Green;
                        }
                        else if (status == "Đang mượn")
                        {
                            row.Cells["Trạng Thái"].Style.ForeColor = Color.DarkBlue;
                        }
                    }
                }
            }
            catch { }
        }
        #endregion

        #region Event Handlers
        private void DgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvMain.Columns.Contains("Mã Phiếu") && dgvMain.Rows[e.RowIndex].Cells["Mã Phiếu"].Value != null)
            {
                string maDK = dgvMain.Rows[e.RowIndex].Cells["Mã Phiếu"].Value.ToString();
                new FormChiTietMuonTra(maDK).ShowDialog();
            }
        }

        private void BtnTraDo_Click(object sender, EventArgs e)
        {
            if (dgvMain.CurrentRow == null) return;
            if (!dgvMain.Columns.Contains("Mã Phiếu") || !dgvMain.Columns.Contains("Tên Thiết Bị")) return;

            string maDK = dgvMain.CurrentRow.Cells["Mã Phiếu"].Value?.ToString();
            string tenTB = dgvMain.CurrentRow.Cells["Tên Thiết Bị"].Value?.ToString();

            if (maDK == null) return;

            if (MessageBox.Show($"Xác nhận trả thiết bị:\n\n{tenTB}\n\nMã phiếu: {maDK}",
                "Trả Thiết Bị", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = new SqlConnection(AppConfig.ConnectionString))
                    {
                        conn.Open();
                        var cmd = new SqlCommand("sp_TraThietBi", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaDK", maDK);
                        cmd.Parameters.AddWithValue("@TrangThaiThietBi", "Tốt");
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Trả thiết bị thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(txtTimKiem.Text.Trim());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}
