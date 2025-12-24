using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QLGD_WinForm
{
    public partial class FormSuCo : BaseManagementForm
    {
        public FormSuCo()
        {
            InitializeComponent();
            SetupEvents();

            if (ValidateDatabase())
            {
                LoadData();
            }
            else
            {
                MessageBox.Show(
                    "DATABASE CHƯA SẴN SÀNG!\n\nVui lòng chạy script tạo dữ liệu.",
                    "Lỗi Database",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        #region Events Setup
        private void SetupEvents()
        {
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
        }
        #endregion

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
                    return count > 0;
                }
            }
            catch
            {
                return false;
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

                    ConfigureColumns();
                    dgvMain.DataSource = dt;

                    if (dt.Rows.Count > 0)
                        ApplyFormatting();
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

            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "LoaiSuKienValue", DataPropertyName = "LoaiSuKien", Visible = false });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThaiValue", DataPropertyName = "TrangThai", Visible = false });

            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaSuKien", HeaderText = "Mã Sự Kiện", DataPropertyName = "MaSuKien", Width = 130 });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaTB", HeaderText = "Mã TB", DataPropertyName = "MaTB", Width = 100 });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenTB", HeaderText = "Tên Thiết Bị", DataPropertyName = "TenTB", Width = 250 });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenLoai", HeaderText = "Loại TB", DataPropertyName = "TenLoai", Width = 150 });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "LoaiSuKien", HeaderText = "Loại Sự Kiện", Width = 140 });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayPhatSinh", HeaderText = "Ngày Ghi Nhận", DataPropertyName = "NgayPhatSinh", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "MoTa", HeaderText = "Mô Tả", DataPropertyName = "MoTa", Width = 300 });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "NguoiXuLy", HeaderText = "Người Xử Lý", DataPropertyName = "NguoiXuLy", Width = 130 });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThai", HeaderText = "Trạng Thái", Width = 130 });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "ChiPhi", HeaderText = "Chi Phí (VNĐ)", DataPropertyName = "ChiPhi", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "ViTri", HeaderText = "Vị Trí", DataPropertyName = "ViTri", Width = 100 });
        }

        private void ApplyFormatting()
        {
            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["LoaiSuKienValue"].Value != null && row.Cells["LoaiSuKienValue"].Value != DBNull.Value)
                {
                    int loai = Convert.ToInt32(row.Cells["LoaiSuKienValue"].Value);
                    row.Cells["LoaiSuKien"].Value = loai switch
                    {
                        0 => "Sự cố",
                        1 => "Bảo trì định kỳ",
                        2 => "Bảo trì đột xuất",
                        _ => "Không xác định"
                    };
                }

                if (row.Cells["TrangThaiValue"].Value != null && row.Cells["TrangThaiValue"].Value != DBNull.Value)
                {
                    int trangThai = Convert.ToInt32(row.Cells["TrangThaiValue"].Value);

                    row.Cells["TrangThai"].Value = trangThai switch
                    {
                        0 => "Chờ xử lý",
                        1 => "Đang sửa chữa",
                        2 => "Đã xử lý",
                        _ => "Không xác định"
                    };

                    row.Cells["TrangThai"].Style.ForeColor = trangThai switch
                    {
                        0 => Color.Red,
                        1 => Color.DarkOrange,
                        2 => Color.Green,
                        _ => Color.Black
                    };

                    if (trangThai == 0)
                    {
                        row.Cells["TrangThai"].Style.Font = new Font(dgvMain.Font, FontStyle.Bold);
                        row.Cells["TrangThai"].Style.BackColor = Color.MistyRose;
                    }
                }
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
