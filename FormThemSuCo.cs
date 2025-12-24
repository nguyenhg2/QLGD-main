using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QLGD_WinForm
{
    public partial class FormThemSuCo : Form
    {
        public FormThemSuCo()
        {
            InitializeComponent();
            SetupEvents();
            cboLoaiSuKien.SelectedIndex = 0;
        }

        #region Events Setup
        private void SetupEvents()
        {
            btnLoadTB.Click += BtnLoadTB_Click;
            cboThietBi.SelectedIndexChanged += CboThietBi_SelectedIndexChanged;
            btnLuu.Click += BtnLuu_Click;
        }
        #endregion

        #region Actions
        private void BtnLoadTB_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtMaTB.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                LoadTatCaThietBi();
                return;
            }

            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                {
                    conn.Open();

                    string sql = @"
                        SELECT MaTB, TenTB + ' (' + MaTB + ')' as DisplayName 
                        FROM THIET_BI 
                        WHERE (MaTB LIKE @tuKhoa OR TenTB LIKE @tuKhoa)
                          AND MaTB NOT IN (
                              SELECT MaTB FROM SU_CO_BAO_TRI 
                              WHERE TrangThai IN (0, 1)
                          )
                        ORDER BY TenTB";

                    var cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");

                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy thiết bị khả dụng!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    cboThietBi.DataSource = dt;
                    cboThietBi.DisplayMember = "DisplayName";
                    cboThietBi.ValueMember = "MaTB";
                    cboThietBi.Enabled = true;

                    if (dt.Rows.Count == 1)
                        cboThietBi.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thiết bị: " + ex.Message);
            }
        }

        private void LoadTatCaThietBi()
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                {
                    conn.Open();

                    string sql = @"
                        SELECT MaTB, TenTB + ' (' + MaTB + ')' as DisplayName 
                        FROM THIET_BI 
                        WHERE MaTB NOT IN (
                            SELECT MaTB FROM SU_CO_BAO_TRI 
                            WHERE TrangThai IN (0, 1)
                        )
                        ORDER BY TenTB";

                    var dt = new DataTable();
                    new SqlDataAdapter(sql, conn).Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có thiết bị nào khả dụng để báo sự cố!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    cboThietBi.DataSource = dt;
                    cboThietBi.DisplayMember = "DisplayName";
                    cboThietBi.ValueMember = "MaTB";
                    cboThietBi.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thiết bị: " + ex.Message);
            }
        }

        private void CboThietBi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboThietBi.SelectedValue == null) return;

            string maTB = cboThietBi.SelectedValue.ToString();
            if (maTB.Contains("System.Data")) return;

            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                {
                    conn.Open();

                    // Kiểm tra sự cố chưa xử lý
                    string sqlCheck = @"
                        SELECT TOP 1 MaSuKien, NgayPhatSinh, TrangThai
                        FROM SU_CO_BAO_TRI
                        WHERE MaTB = @MaTB AND TrangThai IN (0, 1)
                        ORDER BY NgayPhatSinh DESC";

                    var cmdCheck = new SqlCommand(sqlCheck, conn);
                    cmdCheck.Parameters.AddWithValue("@MaTB", maTB);

                    using (var reader = cmdCheck.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string maSK = reader["MaSuKien"].ToString();
                            DateTime ngay = Convert.ToDateTime(reader["NgayPhatSinh"]);
                            int trangThai = Convert.ToInt32(reader["TrangThai"]);

                            string tenTrangThai = trangThai == 0 ? "Chờ xử lý" : "Đang sửa chữa";

                            lblCanhBao.Text = $"CẢNH BÁO: Thiết bị đã có sự cố chưa xử lý!\n" +
                                            $"Mã SK: {maSK} | Ngày: {ngay:dd/MM/yyyy HH:mm} | {tenTrangThai}";
                            lblCanhBao.Visible = true;
                            lblThongTinTB.Visible = false;
                            btnLuu.Enabled = false;
                            btnLuu.BackColor = Color.Gray;
                            return;
                        }
                    }

                    // Lấy thông tin thiết bị
                    string sqlInfo = @"
                        SELECT tb.TenTB, tb.TrangThai, ltb.TenLoai, tb.MaGD, tb.MaPhong
                        FROM THIET_BI tb
                        LEFT JOIN LOAI_THIET_BI ltb ON tb.MaLoai = ltb.MaLoai
                        WHERE tb.MaTB = @MaTB";

                    var cmdInfo = new SqlCommand(sqlInfo, conn);
                    cmdInfo.Parameters.AddWithValue("@MaTB", maTB);

                    using (var reader = cmdInfo.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int trangThai = Convert.ToInt32(reader["TrangThai"]);
                            string tenTrangThai = TrangThaiHelper.GetTenTrangThai(trangThai, typeof(TrangThaiThietBi));

                            lblThongTinTB.Text = $"{reader["TenLoai"]} | " +
                                               $"Trạng thái: {tenTrangThai} | " +
                                               $"Vị trí: {reader["MaGD"]}-{reader["MaPhong"]}";
                            lblThongTinTB.Visible = true;
                        }
                    }

                    lblCanhBao.Visible = false;
                    btnLuu.Enabled = true;
                    btnLuu.BackColor = Color.Firebrick;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (cboThietBi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn thiết bị!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMoTa.Text))
            {
                MessageBox.Show("Vui lòng nhập mô tả chi tiết sự cố!");
                return;
            }

            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand("sp_ThemSuCoChiTiet", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaTB", cboThietBi.SelectedValue);
                    cmd.Parameters.AddWithValue("@LoaiSuKien", cboLoaiSuKien.SelectedIndex);
                    cmd.Parameters.AddWithValue("@MoTa", txtMoTa.Text.Trim());
                    cmd.Parameters.AddWithValue("@NguoiXuLy", txtNguoiBao.Text.Trim());
                    cmd.Parameters.AddWithValue("@NgayPhatSinh", dtpNgay.Value);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã ghi nhận sự cố thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        #endregion
    }
}
