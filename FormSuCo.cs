using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QLGD_WinForm
{
    public class FormSuCo : BaseManagementForm
    {
        private TextBox txtTim;
        private Button btnThem;
        private Button btnCapNhat;
        private Button btnXoa;

        public FormSuCo() : base("Quản Lý Sự Cố & Bảo Trì", "SuCo", new Size(1400, 700))
        {
            InitializeCustomToolbar();

            if (ValidateDatabase())
            {
                LoadData();
            }
            else
            {
                MessageBox.Show(
                    "DATABASE CHƯA SẴN SÀNG!\n\n" +
                    "Vui lòng:\n" +
                    "1. Chạy script xóa và sinh dữ liệu mới\n" +
                    "2. Đảm bảo TrangThai, LoaiSuKien là INT",
                    "Lỗi Database",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        #region Validation
        private bool ValidateDatabase()
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                {
                    conn.Open();

                    var cmdCount = new SqlCommand("SELECT COUNT(*) FROM SU_CO_BAO_TRI", conn);
                    int count = (int)cmdCount.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Database không có dữ liệu sự cố!\n\n" +
                            "Vui lòng chạy script sinh dữ liệu.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    var cmdCheck = new SqlCommand(
                        "SELECT TOP 1 LoaiSuKien, TrangThai FROM SU_CO_BAO_TRI",
                        conn
                    );

                    using (var reader = cmdCheck.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var loaiSK = reader["LoaiSuKien"];
                            var trangThai = reader["TrangThai"];

                            if (loaiSK.GetType() != typeof(int))
                            {
                                MessageBox.Show(
                                    $"LỖI KIỂU DỮ LIỆU!\n\n" +
                                    $"Cột LoaiSuKien: {loaiSK.GetType().Name} ('{loaiSK}')\n" +
                                    $"Mong đợi: Int32\n\n" +
                                    $"Chạy script xóa và sinh dữ liệu mới!",
                                    "Lỗi Database",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                                return false;
                            }

                            if (trangThai.GetType() != typeof(int))
                            {
                                MessageBox.Show(
                                    $"LỖI KIỂU DỮ LIỆU!\n\n" +
                                    $"Cột TrangThai: {trangThai.GetType().Name} ('{trangThai}')\n" +
                                    $"Mong đợi: Int32\n\n" +
                                    $"Chạy script xóa và sinh dữ liệu mới!",
                                    "Lỗi Database",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                                return false;
                            }
                        }
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kiểm tra DB:\n{ex.Message}", "Lỗi");
                return false;
            }
        }
        #endregion

        #region UI Setup
        private void InitializeCustomToolbar()
        {
            txtTim = new TextBox
            {
                Width = 250,
                PlaceholderText = "Tìm theo Mã, Tên TB, Mô tả...",
                Font = new Font("Segoe UI", 10)
            };

            Button btnTim = new Button
            {
                Text = "Tìm Kiếm",
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                Width = 110
            };

            btnThem = new Button
            {
                Text = "Báo Hỏng Mới",
                BackColor = Color.Firebrick,
                ForeColor = Color.White,
                Width = 140,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            btnCapNhat = new Button
            {
                Text = "Cập Nhật / Xử Lý",
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
                Width = 150,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            btnXoa = new Button
            {
                Text = "Xóa",
                BackColor = Color.Gray,
                ForeColor = Color.White,
                Width = 90
            };

            Button btnLamMoi = new Button
            {
                Text = "Làm Mới",
                BackColor = Color.White,
                Width = 110
            };

            btnTim.Click += (s, e) => LoadData(txtTim.Text);
            txtTim.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter)
                {
                    LoadData(txtTim.Text);
                    e.SuppressKeyPress = true;
                }
            };
            btnLamMoi.Click += (s, e) => { txtTim.Clear(); LoadData(); };

            btnThem.Click += (s, e) =>
            {
                FormThemSuCo frm = new FormThemSuCo();
                if (frm.ShowDialog() == DialogResult.OK) LoadData(txtTim.Text);
            };

            btnCapNhat.Click += BtnCapNhat_Click;
            btnXoa.Click += BtnXoa_Click;

            pnlTop.Controls.Clear();
            int x = 20, y = 15, h = 35;
            Control[] ctrls = { txtTim, btnTim, btnThem, btnCapNhat, btnXoa, btnLamMoi };
            foreach (var c in ctrls)
            {
                c.Location = new Point(x, y);
                c.Height = h;
                pnlTop.Controls.Add(c);
                x += c.Width + 10;
            }
        }
        #endregion

        #region Data Loading
        protected override void LoadData(string search = "")
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand("sp_GetAllSuCo", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TuKhoa", search.Trim());

                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    this.Text = $"Quản Lý Sự Cố & Bảo Trì - {dt.Rows.Count} kết quả";

                    dgvMain.AutoGenerateColumns = false;
                    dgvMain.Columns.Clear();

                    // Cột ẩn chứa giá trị INT gốc
                    dgvMain.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "LoaiSuKienValue",
                        DataPropertyName = "LoaiSuKien",
                        Visible = false
                    });

                    dgvMain.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "TrangThaiValue",
                        DataPropertyName = "TrangThai",
                        Visible = false
                    });

                    // Các cột hiển thị
                    dgvMain.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "MaSuKien",
                        HeaderText = "Mã Sự Kiện",
                        DataPropertyName = "MaSuKien",
                        Width = 130
                    });

                    dgvMain.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "MaTB",
                        HeaderText = "Mã TB",
                        DataPropertyName = "MaTB",
                        Width = 100
                    });

                    dgvMain.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "TenTB",
                        HeaderText = "Tên Thiết Bị",
                        DataPropertyName = "TenTB",
                        Width = 250
                    });

                    dgvMain.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "TenLoai",
                        HeaderText = "Loại TB",
                        DataPropertyName = "TenLoai",
                        Width = 150
                    });

                    // Cột hiển thị text (không bind trực tiếp)
                    dgvMain.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "LoaiSuKien",
                        HeaderText = "Loại Sự Kiện",
                        Width = 140
                    });

                    dgvMain.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "NgayPhatSinh",
                        HeaderText = "Ngày Ghi Nhận",
                        DataPropertyName = "NgayPhatSinh",
                        Width = 150,
                        DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
                    });

                    dgvMain.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "MoTa",
                        HeaderText = "Mô Tả",
                        DataPropertyName = "MoTa",
                        Width = 300
                    });

                    dgvMain.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "NguoiXuLy",
                        HeaderText = "Người Xử Lý",
                        DataPropertyName = "NguoiXuLy",
                        Width = 130
                    });

                    // Cột hiển thị text (không bind trực tiếp)
                    dgvMain.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "TrangThai",
                        HeaderText = "Trạng Thái",
                        Width = 130
                    });

                    dgvMain.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "ChiPhi",
                        HeaderText = "Chi Phí (VNĐ)",
                        DataPropertyName = "ChiPhi",
                        Width = 120,
                        DefaultCellStyle = new DataGridViewCellStyle
                        {
                            Format = "N0",
                            Alignment = DataGridViewContentAlignment.MiddleRight
                        }
                    });

                    dgvMain.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "ViTri",
                        HeaderText = "Vị Trí",
                        DataPropertyName = "ViTri",
                        Width = 100
                    });

                    dgvMain.DataSource = dt;

                    if (dt.Rows.Count > 0)
                    {
                        ApplyFormatting();
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu sự cố!\n\nVui lòng chạy script sinh dữ liệu.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                foreach (DataGridViewRow row in dgvMain.Rows)
                {
                    if (row.IsNewRow) continue;

                    // Đọc từ cột ẩn (INT)
                    if (row.Cells["LoaiSuKienValue"].Value != null &&
                        row.Cells["LoaiSuKienValue"].Value != DBNull.Value)
                    {
                        int loai = Convert.ToInt32(row.Cells["LoaiSuKienValue"].Value);
                        string tenLoai = loai switch
                        {
                            0 => "Sự cố",
                            1 => "Bảo trì định kỳ",
                            2 => "Bảo trì đột xuất",
                            _ => "Không xác định"
                        };

                        // Gán vào cột hiển thị
                        row.Cells["LoaiSuKien"].Value = tenLoai;
                    }

                    // Đọc từ cột ẩn (INT)
                    if (row.Cells["TrangThaiValue"].Value != null &&
                        row.Cells["TrangThaiValue"].Value != DBNull.Value)
                    {
                        int trangThai = Convert.ToInt32(row.Cells["TrangThaiValue"].Value);

                        string tenTrangThai = trangThai switch
                        {
                            0 => "Chờ xử lý",
                            1 => "Đang sửa chữa",
                            2 => "Đã xử lý",
                            _ => "Không xác định"
                        };

                        Color mauTrangThai = trangThai switch
                        {
                            0 => Color.Red,
                            1 => Color.DarkOrange,
                            2 => Color.Green,
                            _ => Color.Black
                        };

                        // Gán vào cột hiển thị
                        row.Cells["TrangThai"].Value = tenTrangThai;
                        row.Cells["TrangThai"].Style.ForeColor = mauTrangThai;

                        if (trangThai == 0)
                        {
                            row.Cells["TrangThai"].Style.Font = new Font(dgvMain.Font, FontStyle.Bold);
                            row.Cells["TrangThai"].Style.BackColor = Color.MistyRose;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi định dạng:\n{ex.Message}\n\nStack:\n{ex.StackTrace}",
                    "Lỗi Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Actions
        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            if (dgvMain.CurrentRow == null || dgvMain.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn sự cố cần cập nhật!");
                return;
            }

            string maSK = dgvMain.CurrentRow.Cells["MaSuKien"].Value?.ToString();
            string tenTB = dgvMain.CurrentRow.Cells["TenTB"].Value?.ToString();

            string trangThaiText = dgvMain.CurrentRow.Cells["TrangThai"].Value?.ToString();

            decimal chiPhi = 0;
            if (dgvMain.CurrentRow.Cells["ChiPhi"].Value != DBNull.Value)
                decimal.TryParse(dgvMain.CurrentRow.Cells["ChiPhi"].Value.ToString(), out chiPhi);

            if (string.IsNullOrEmpty(maSK)) return;

            FormCapNhatSuCo frm = new FormCapNhatSuCo(maSK, tenTB, trangThaiText, chiPhi);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData(txtTim.Text);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgvMain.CurrentRow == null || dgvMain.CurrentRow.IsNewRow) return;

            string maSK = dgvMain.CurrentRow.Cells["MaSuKien"].Value.ToString();

            if (MessageBox.Show($"Bạn có chắc muốn xóa sự kiện {maSK}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = new SqlConnection(AppConfig.ConnectionString))
                    {
                        conn.Open();
                        var cmd = new SqlCommand("DELETE FROM SU_CO_BAO_TRI WHERE MaSuKien = @id", conn);
                        cmd.Parameters.AddWithValue("@id", maSK);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Đã xóa thành công!");
                        LoadData(txtTim.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi xóa:\n{ex.Message}");
                }
            }
        }
        #endregion
    }
}