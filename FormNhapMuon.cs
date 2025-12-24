using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QLGD_WinForm
{
    public partial class FormNhapMuon : Form
    {
        private bool _isNewUser = false;

        public FormNhapMuon()
        {
            InitializeComponent();
            SetupEvents();
            LoadComboboxGD();
            dtpHanTra.Value = DateTime.Now.AddHours(4);
        }

        #region Events Setup
        private void SetupEvents()
        {
            txtMaNguoiMuon.KeyDown += TxtMaNguoiMuon_KeyDown;
            txtMaNguoiMuon.Leave += TxtMaNguoiMuon_Leave;
            cboGiangDuong.SelectedIndexChanged += CboGiangDuong_SelectedIndexChanged;
            btnLuu.Click += BtnLuu_Click;
        }
        #endregion

        #region Logic
        private void CheckNguoiMuon()
        {
            string maNM = txtMaNguoiMuon.Text.Trim();
            if (string.IsNullOrEmpty(maNM)) return;

            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand("sp_GetThongTinNguoiMuon", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNguoiMuon", maNM);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtHoTen.Text = reader["HoTen"].ToString();
                            txtDonVi.Text = reader["DonVi"].ToString();
                            txtSDT.Text = reader["SDT"].ToString();

                            txtHoTen.ReadOnly = true;
                            txtDonVi.ReadOnly = true;
                            txtSDT.ReadOnly = true;

                            txtHoTen.BackColor = Color.WhiteSmoke;
                            txtDonVi.BackColor = Color.WhiteSmoke;
                            txtSDT.BackColor = Color.WhiteSmoke;

                            _isNewUser = false;
                            HienThiDanhSachDangMuon(maNM);
                        }
                        else
                        {
                            txtHoTen.ReadOnly = false;
                            txtDonVi.ReadOnly = false;
                            txtSDT.ReadOnly = false;

                            txtHoTen.BackColor = Color.White;
                            txtDonVi.BackColor = Color.White;
                            txtSDT.BackColor = Color.White;

                            txtHoTen.Text = "";
                            txtDonVi.Text = "";
                            txtSDT.Text = "";

                            txtHoTen.Focus();
                            _isNewUser = true;
                            pnlThongTinMuon.Visible = false;

                            btnLuu.Enabled = true;
                            btnLuu.BackColor = Color.Teal;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra người mượn: " + ex.Message);
            }
        }

        private void HienThiDanhSachDangMuon(string maNguoiMuon)
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                {
                    conn.Open();
                    string sql = @"
                        SELECT 
                            tb.TenTB, 
                            ltb.TenLoai,
                            mt.MaGD_Muon + '-' + mt.MaPhong_Muon AS ViTri,
                            mt.TGMuon
                        FROM MUON_TRA mt
                        JOIN THIET_BI tb ON mt.MaTB = tb.MaTB
                        JOIN LOAI_THIET_BI ltb ON tb.MaLoai = ltb.MaLoai
                        WHERE mt.MaNguoiMuon = @Ma AND mt.TGTra IS NULL
                        ORDER BY mt.TGMuon DESC";

                    var cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Ma", maNguoiMuon);

                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        string danhSach = $"ℹ️ Đang mượn {dt.Rows.Count} thiết bị:\n\n";
                        foreach (DataRow row in dt.Rows)
                        {
                            danhSach += $"• {row["TenLoai"]} - {row["TenTB"]}\n" +
                                      $"  Tại: {row["ViTri"]} | " +
                                      $"Mượn lúc: {Convert.ToDateTime(row["TGMuon"]):dd/MM HH:mm}\n";
                        }

                        danhSach += "\n⚠️ LƯU Ý: Chỉ được mượn thêm thiết bị KHÁC LOẠI!";

                        lblDanhSachDangMuon.Text = danhSach;
                        lblDanhSachDangMuon.ForeColor = Color.DarkOrange;
                        pnlThongTinMuon.Visible = true;
                        pnlThongTinMuon.BackColor = Color.LightYellow;

                        btnLuu.Enabled = true;
                        btnLuu.BackColor = Color.Teal;
                    }
                    else
                    {
                        pnlThongTinMuon.Visible = false;
                        btnLuu.Enabled = true;
                        btnLuu.BackColor = Color.Teal;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi hiển thị danh sách: {ex.Message}");
            }
        }

        private void TxtMaNguoiMuon_Leave(object sender, EventArgs e) => CheckNguoiMuon();

        private void TxtMaNguoiMuon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckNguoiMuon();
                e.SuppressKeyPress = true;
            }
        }

        private void LoadComboboxGD()
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                {
                    conn.Open();

                    var cmd = new SqlCommand("sp_GetAllGiangDuong", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var dtGD = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dtGD);

                    cboGiangDuong.SelectedIndexChanged -= CboGiangDuong_SelectedIndexChanged;
                    cboGiangDuong.DisplayMember = "MaGD";
                    cboGiangDuong.ValueMember = "MaGD";
                    cboGiangDuong.DataSource = dtGD;
                    cboGiangDuong.SelectedIndexChanged += CboGiangDuong_SelectedIndexChanged;

                    if (cboGiangDuong.Items.Count > 0)
                    {
                        cboGiangDuong.SelectedIndex = 0;
                        CboGiangDuong_SelectedIndexChanged(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void CboGiangDuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGiangDuong.SelectedValue == null) return;
            string maGD = cboGiangDuong.SelectedValue.ToString();
            if (maGD.Contains("DataRowView")) return;

            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                {
                    conn.Open();

                    var cmdPhong = new SqlCommand("sp_GetPhongByGD", conn);
                    cmdPhong.CommandType = CommandType.StoredProcedure;
                    cmdPhong.Parameters.AddWithValue("@MaGD", maGD);

                    var dtPhong = new DataTable();
                    new SqlDataAdapter(cmdPhong).Fill(dtPhong);

                    cboPhong.DataSource = dtPhong;
                    cboPhong.DisplayMember = "MaPhong";
                    cboPhong.ValueMember = "MaPhong";

                    var cmdTB = new SqlCommand("sp_GetThietBiSanSangTheoGD", conn);
                    cmdTB.CommandType = CommandType.StoredProcedure;
                    cmdTB.Parameters.AddWithValue("@MaGD", maGD);

                    var dtTB = new DataTable();
                    new SqlDataAdapter(cmdTB).Fill(dtTB);

                    cboThietBi.DataSource = dtTB;
                    cboThietBi.DisplayMember = "TenTB";
                    cboThietBi.ValueMember = "MaTB";

                    if (dtTB.Rows.Count == 0)
                    {
                        MessageBox.Show($"Giảng đường {maGD} không có thiết bị nào sẵn sàng trong kho!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNguoiMuon.Text) ||
                string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã và Tên người mượn!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboThietBi.SelectedValue == null ||
                cboGiangDuong.SelectedValue == null ||
                cboPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Thiết bị và Vị trí!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                {
                    conn.Open();

                    if (_isNewUser)
                    {
                        string sqlInsertUser = @"
                    IF NOT EXISTS (SELECT 1 FROM NGUOI_MUON WHERE MaNguoiMuon = @Ma)
                    INSERT INTO NGUOI_MUON (MaNguoiMuon, HoTen, DonVi, SDT, TrangThai) 
                    VALUES (@Ma, @Ten, @DV, @SDT, 0)";

                        var cmdUser = new SqlCommand(sqlInsertUser, conn);
                        cmdUser.Parameters.AddWithValue("@Ma", txtMaNguoiMuon.Text.Trim());
                        cmdUser.Parameters.AddWithValue("@Ten", txtHoTen.Text.Trim());
                        cmdUser.Parameters.AddWithValue("@DV", txtDonVi.Text.Trim());
                        cmdUser.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                        cmdUser.ExecuteNonQuery();
                    }

                    var cmd = new SqlCommand("sp_MuonThietBi", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaDK", "PM" + DateTime.Now.ToString("yyyyMMddHHmmss"));
                    cmd.Parameters.AddWithValue("@MaNguoiMuon", txtMaNguoiMuon.Text.Trim());
                    cmd.Parameters.AddWithValue("@MaTB", cboThietBi.SelectedValue);
                    cmd.Parameters.AddWithValue("@MaGD_Muon", cboGiangDuong.SelectedValue);
                    cmd.Parameters.AddWithValue("@MaPhong_Muon", cboPhong.SelectedValue);

                    if (dtpHanTra.Value > DateTime.Now)
                        cmd.Parameters.AddWithValue("@TGTraDuKien", dtpHanTra.Value);
                    else
                        cmd.Parameters.AddWithValue("@TGTraDuKien", DBNull.Value);

                    cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text.Trim());

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(" Mượn thiết bị thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Không thể mượn",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
