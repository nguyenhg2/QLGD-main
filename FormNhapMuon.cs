using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QLGD_WinForm
{
    public class FormNhapMuon : Form
    {
        private TextBox txtMaNguoiMuon, txtHoTen, txtDonVi, txtSDT;
        private ComboBox cboThietBi, cboGiangDuong, cboPhong;
        private DateTimePicker dtpHanTra;
        private TextBox txtGhiChu;
        private Button btnLuu, btnHuy;
        private bool _isNewUser = false;
        private Panel pnlThongTinMuon;
        private Label lblDanhSachDangMuon;

        public FormNhapMuon()
        {
            InitializeUI();
            LoadComboboxGD();
        }

        #region UI Setup
        private void InitializeUI()
        {
            this.Text = "Đăng Ký Mượn Thiết Bị Mới";
            this.Size = new Size(700, 750);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            Label lblHeader = new Label
            {
                Text = "PHIẾU MƯỢN THIẾT BỊ",
                Dock = DockStyle.Top,
                Height = 60,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Teal
            };

            TableLayoutPanel table = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 450,
                ColumnCount = 2,
                Padding = new Padding(20),
                RowCount = 9
            };
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));

            txtMaNguoiMuon = new TextBox { Height = 30, Font = new Font("Segoe UI", 10), PlaceholderText = "Nhập mã & Enter..." };
            txtMaNguoiMuon.KeyDown += TxtMaNguoiMuon_KeyDown;
            txtMaNguoiMuon.Leave += TxtMaNguoiMuon_Leave;
            AddRow(table, "Mã Người Mượn (*):", txtMaNguoiMuon);

            txtHoTen = new TextBox { Height = 30, Font = new Font("Segoe UI", 10), ReadOnly = true, BackColor = Color.WhiteSmoke };
            AddRow(table, "Họ Tên:", txtHoTen);

            txtDonVi = new TextBox { Height = 30, Font = new Font("Segoe UI", 10), ReadOnly = true, BackColor = Color.WhiteSmoke };
            AddRow(table, "Đơn Vị / Lớp:", txtDonVi);

            txtSDT = new TextBox { Height = 30, Font = new Font("Segoe UI", 10), ReadOnly = true, BackColor = Color.WhiteSmoke };
            AddRow(table, "Số Điện Thoại:", txtSDT);

            cboGiangDuong = CreateComboBox();
            cboGiangDuong.SelectedIndexChanged += CboGiangDuong_SelectedIndexChanged;
            AddRow(table, "Tại Giảng Đường (*):", cboGiangDuong);

            cboPhong = CreateComboBox();
            AddRow(table, "Tại Phòng (*):", cboPhong);

            cboThietBi = CreateComboBox();
            cboThietBi.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboThietBi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AddRow(table, "Thiết Bị (Kho) (*):", cboThietBi);

            dtpHanTra = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy HH:mm",
                Width = 250,
                Value = DateTime.Now.AddHours(4)
            };
            AddRow(table, "Hạn Trả Dự Kiến:", dtpHanTra);

            txtGhiChu = new TextBox { Multiline = true, Height = 60, ScrollBars = ScrollBars.Vertical };
            AddRow(table, "Ghi Chú:", txtGhiChu);

            // Panel hiển thị thông tin đang mượn
            pnlThongTinMuon = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                Padding = new Padding(20, 5, 20, 5),
                BackColor = Color.LightYellow,
                Visible = false
            };

            lblDanhSachDangMuon = new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.DarkBlue,
                AutoSize = false
            };
            pnlThongTinMuon.Controls.Add(lblDanhSachDangMuon);

            btnLuu = new Button
            {
                Text = "MƯỢN NGAY",
                DialogResult = DialogResult.None,
                BackColor = Color.Teal,
                ForeColor = Color.White,
                Height = 45,
                Width = 140,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnHuy = new Button
            {
                Text = "Hủy Bỏ",
                DialogResult = DialogResult.Cancel,
                Height = 45,
                Width = 100
            };
            btnLuu.Click += BtnLuu_Click;

            FlowLayoutPanel pnlBtn = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.RightToLeft,
                Dock = DockStyle.Bottom,
                Height = 80,
                Padding = new Padding(20)
            };
            pnlBtn.Controls.Add(btnHuy);
            pnlBtn.Controls.Add(btnLuu);

            this.Controls.Add(pnlBtn);
            this.Controls.Add(pnlThongTinMuon);
            this.Controls.Add(table);
            this.Controls.Add(lblHeader);
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

        private ComboBox CreateComboBox()
        {
            return new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Height = 32,
                Font = new Font("Segoe UI", 10)
            };
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
                        string danhSach = $"📋 Đang mượn {dt.Rows.Count} thiết bị:\n\n";
                        foreach (DataRow row in dt.Rows)
                        {
                            danhSach += $"• {row["TenLoai"]} - {row["TenTB"]}\n  Tại: {row["ViTri"]} | Mượn lúc: {Convert.ToDateTime(row["TGMuon"]):dd/MM HH:mm}\n";
                        }

                        lblDanhSachDangMuon.Text = danhSach;
                        pnlThongTinMuon.Visible = true;

                        MessageBox.Show(
                            $"⚠ CẢNH BÁO: Người này đang mượn {dt.Rows.Count} thiết bị!\n\n" +
                            "Theo quy định, mỗi người chỉ được mượn 1 thiết bị tại 1 thời điểm.\n" +
                            "Vui lòng yêu cầu trả thiết bị trước khi mượn mới.",
                            "Không Thể Mượn",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        btnLuu.Enabled = false;
                        btnLuu.BackColor = Color.Gray;
                    }
                    else
                    {
                        pnlThongTinMuon.Visible = false;
                        btnLuu.Enabled = true;
                        btnLuu.BackColor = Color.Teal;
                    }
                }
            }
            catch { }
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

                    var cmd = new SqlCommand("sp_GetPhongByGD", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaGD", maGD);

                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    cboPhong.DataSource = dt;
                    cboPhong.DisplayMember = "MaPhong";
                    cboPhong.ValueMember = "MaPhong";

                    LoadThietBiSanSang();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void LoadThietBiSanSang()
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                {
                    conn.Open();

                    var cmd = new SqlCommand("sp_GetThietBiSanSang", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var dtTB = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dtTB);

                    cboThietBi.DataSource = dtTB;
                    cboThietBi.DisplayMember = "TenTB";
                    cboThietBi.ValueMember = "MaTB";

                    if (dtTB.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có thiết bị nào sẵn sàng trong kho!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thiết bị: " + ex.Message);
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtMaNguoiMuon.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã và Tên người mượn!");
                return;
            }

            if (cboThietBi.SelectedValue == null || cboGiangDuong.SelectedValue == null || cboPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Thiết bị và Vị trí!");
                return;
            }

            using (var conn = new SqlConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Nếu là người mượn mới
                    if (_isNewUser)
                    {
                        string sqlInsertUser = @"
                            INSERT INTO NGUOI_MUON (MaNguoiMuon, HoTen, DonVi, SDT, TrangThai) 
                            VALUES (@Ma, @Ten, @DV, @SDT, 0)";

                        var cmdUser = new SqlCommand(sqlInsertUser, conn, transaction);
                        cmdUser.Parameters.AddWithValue("@Ma", txtMaNguoiMuon.Text.Trim());
                        cmdUser.Parameters.AddWithValue("@Ten", txtHoTen.Text.Trim());
                        cmdUser.Parameters.AddWithValue("@DV", txtDonVi.Text.Trim());
                        cmdUser.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                        cmdUser.ExecuteNonQuery();
                    }

                    // Tạo phiếu mượn
                    var cmd = new SqlCommand("sp_MuonThietBi", conn, transaction);
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

                    transaction.Commit();
                    MessageBox.Show("✅ Mượn thiết bị thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    MessageBox.Show(ex.Message, "Không thể mượn",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}
