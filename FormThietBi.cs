using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QLGD_WinForm
{
    public class FormThietBi : BaseManagementForm
    {
        private ComboBox cboGiangDuong;
        private TextBox txtTimKiemTB;
        private ComboBox cboTrangThai;

        public FormThietBi() : base("Quản Lý Thiết Bị Theo Giảng Đường", "ThietBi", new Size(1400, 750))
        {
            InitializeCustomToolbar();
            LoadComboboxGD();
            dgvMain.CellFormatting += DgvMain_CellFormatting;
            LoadData();
        }

        #region UI Setup
        private void InitializeCustomToolbar()
        {
            pnlTop.Controls.Clear();

            Label lblChon = new Label
            {
                Text = "Giảng Đường:",
                Location = new Point(20, 23),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            cboGiangDuong = new ComboBox
            {
                Location = new Point(120, 20),
                Width = 120,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10)
            };

            Label lblTrangThai = new Label
            {
                Text = "Trạng thái:",
                Location = new Point(260, 23),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };

            cboTrangThai = new ComboBox
            {
                Location = new Point(350, 20),
                Width = 140,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10)
            };
            cboTrangThai.Items.Add("Tất cả");
            cboTrangThai.Items.Add("Tốt");
            cboTrangThai.Items.Add("Đang sử dụng");
            cboTrangThai.Items.Add("Hỏng");
            cboTrangThai.Items.Add("Đang sửa chữa");
            cboTrangThai.Items.Add("Chờ thanh lý");
            cboTrangThai.SelectedIndex = 0;

            Label lblTim = new Label
            {
                Text = "Tìm TB:",
                Location = new Point(520, 23),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };

            txtTimKiemTB = new TextBox
            {
                Location = new Point(590, 20),
                Width = 200,
                Font = new Font("Segoe UI", 10),
                PlaceholderText = "Tên hoặc mã TB..."
            };

            Button btnAdd = new Button { Text = "Thêm TB", BackColor = Color.Teal, ForeColor = Color.White };
            Button btnEdit = new Button { Text = "Sửa" };
            Button btnDel = new Button { Text = "Xóa", BackColor = Color.IndianRed, ForeColor = Color.White };

            btnAdd.Location = new Point(820, 18); btnAdd.Size = new Size(110, 32);
            btnEdit.Location = new Point(940, 18); btnEdit.Size = new Size(90, 32);
            btnDel.Location = new Point(1040, 18); btnDel.Size = new Size(90, 32);

            pnlTop.Controls.AddRange(new Control[] {
                lblChon, cboGiangDuong, lblTrangThai, cboTrangThai,
                lblTim, txtTimKiemTB, btnAdd, btnEdit, btnDel
            });

            cboGiangDuong.SelectedIndexChanged += (s, e) => LoadData();
            cboTrangThai.SelectedIndexChanged += (s, e) => FilterData();
            txtTimKiemTB.TextChanged += (s, e) => FilterData();

            btnAdd.Click += (s, e) => {
                if (new FormNhapThietBi().ShowDialog() == DialogResult.OK)
                    LoadData();
            };
            btnEdit.Click += (s, e) => EditSelected();
            btnDel.Click += (s, e) => DeleteSelected();
        }
        #endregion

        #region Data Loading
        private DataTable _dtFull; // Lưu dữ liệu gốc để filter

        private void LoadComboboxGD()
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand("sp_GetAllGiangDuong", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    cboGiangDuong.DisplayMember = "MaGD";
                    cboGiangDuong.ValueMember = "MaGD";
                    cboGiangDuong.DataSource = dt;

                    if (cboGiangDuong.Items.Count > 0)
                        cboGiangDuong.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load danh sách Giảng đường:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void LoadData(string search = "")
        {
            if (cboGiangDuong?.SelectedValue == null) return;

            string maGD = cboGiangDuong.SelectedValue.ToString();
            if (string.IsNullOrEmpty(maGD) || maGD.Contains("DataRowView")) return;

            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand("sp_GetThietBiByGD", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaGD", maGD);

                    _dtFull = new DataTable();
                    new SqlDataAdapter(cmd).Fill(_dtFull);

                    ConfigureColumns();
                    FilterData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterData()
        {
            if (_dtFull == null) return;

            string tuKhoa = txtTimKiemTB?.Text?.Trim() ?? "";
            int trangThaiIndex = cboTrangThai?.SelectedIndex ?? 0;

            string filter = "";

            // Filter theo từ khóa
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                filter = $"(TenTB LIKE '%{tuKhoa}%' OR MaTB LIKE '%{tuKhoa}%' OR TenLoai LIKE '%{tuKhoa}%')";
            }

            // Filter theo trạng thái
            if (trangThaiIndex > 0)
            {
                int trangThai = trangThaiIndex - 1;
                if (!string.IsNullOrEmpty(filter))
                    filter += " AND ";
                filter += $"TrangThai = {trangThai}";
            }

            try
            {
                _dtFull.DefaultView.RowFilter = filter;
                dgvMain.DataSource = _dtFull;
                this.Text = $"Quản Lý Thiết Bị - {_dtFull.DefaultView.Count} bản ghi";
            }
            catch
            {
                dgvMain.DataSource = _dtFull;
            }
        }

        private void ConfigureColumns()
        {
            dgvMain.AutoGenerateColumns = false;
            dgvMain.Columns.Clear();

            dgvMain.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaTB",
                HeaderText = "Mã TB",
                DataPropertyName = "MaTB",
                Width = 200
            });

            dgvMain.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenTB",
                HeaderText = "Tên Thiết Bị",
                DataPropertyName = "TenTB",
                Width = 400
            });

            dgvMain.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenLoai",
                HeaderText = "Loại TB",
                DataPropertyName = "TenLoai",
                Width = 220
            });

            dgvMain.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TrangThai",
                HeaderText = "Trạng Thái",
                DataPropertyName = "TrangThai",
                Width = 200
            });

            dgvMain.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaPhong",
                HeaderText = "Phòng",
                DataPropertyName = "MaPhong",
                Width = 150
            });

            dgvMain.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ViTri",
                HeaderText = "Vị Trí",
                DataPropertyName = "ViTri",
                Width = 150
            });

            // Style header
            foreach (DataGridViewColumn col in dgvMain.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }
        }

        private void DgvMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dgvMain.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
                {
                    if (int.TryParse(e.Value.ToString(), out int trangThai))
                    {
                        e.Value = trangThai switch
                        {
                            0 => "Tốt",
                            1 => "Đang sử dụng",
                            2 => "Hỏng",
                            3 => "Đang sửa chữa",
                            4 => "Chờ thanh lý",
                            _ => "Không xác định"
                        };

                        e.CellStyle.ForeColor = trangThai switch
                        {
                            0 => Color.Green,
                            1 => Color.DarkBlue,
                            2 => Color.Red,
                            3 => Color.DarkOrange,
                            4 => Color.Gray,
                            _ => Color.Black
                        };

                        if (trangThai == 2)
                        {
                            e.CellStyle.Font = new Font(dgvMain.Font, FontStyle.Bold);
                            e.CellStyle.BackColor = Color.MistyRose;
                        }

                        e.FormattingApplied = true;
                    }
                }
            }
            catch { }
        }
        #endregion

        #region Actions
        protected override void EditSelected()
        {
            if (dgvMain.CurrentRow == null || dgvMain.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn thiết bị cần sửa!");
                return;
            }

            string maTB = dgvMain.CurrentRow.Cells["MaTB"].Value?.ToString();
            if (string.IsNullOrEmpty(maTB)) return;

            if (new FormNhapThietBi(maTB).ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        protected override void DeleteSelected()
        {
            if (dgvMain.CurrentRow == null || dgvMain.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn thiết bị cần xóa!");
                return;
            }

            string maTB = dgvMain.CurrentRow.Cells["MaTB"].Value?.ToString();
            string tenTB = dgvMain.CurrentRow.Cells["TenTB"].Value?.ToString();

            if (string.IsNullOrEmpty(maTB)) return;

            var result = MessageBox.Show(
                $"Bạn có chắc muốn xóa thiết bị?\n\n" +
                $"Mã: {maTB}\n" +
                $"Tên: {tenTB}\n\n" +
                $"Lưu ý: Không thể xóa nếu thiết bị đang được mượn hoặc có sự cố chưa xử lý!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var conn = new SqlConnection(AppConfig.ConnectionString))
                    {
                        conn.Open();
                        var cmd = new SqlCommand("sp_XoaThietBi", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaTB", maTB);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Đã xóa thiết bị thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Không thể xóa thiết bị:\n\n{ex.Message}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}
