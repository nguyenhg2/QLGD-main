using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QLGD_WinForm
{
    public class FormThemSuCo : Form
    {
        private TextBox txtMaTB;
        private Button btnLoadTB;
        private ComboBox cboThietBi;
        private ComboBox cboLoaiSuKien;
        private DateTimePicker dtpNgay;
        private TextBox txtMoTa;
        private TextBox txtNguoiBao;
        private Button btnLuu;
        private Button btnHuy;
        private Label lblCanhBao;
        private Label lblThongTinTB;

        public FormThemSuCo()
        {
            InitializeUI();
        }

        #region UI Setup
        private void InitializeUI()
        {
            this.Text = "KHAI BÁO SỰ CỐ / BẢO TRÌ";
            this.Size = new Size(700, 580);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.Firebrick
            };
            Label lblHeader = new Label
            {
                Text = "THÔNG TIN SỰ CỐ",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White
            };
            pnlHeader.Controls.Add(lblHeader);

            Panel pnlBody = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(30, 20, 30, 20),
                AutoScroll = true
            };

            int y = 10;
            int labelWidth = 150;
            int controlWidth = 450;

            AddLabel(pnlBody, "Chọn Thiết Bị (*):", y);
            txtMaTB = new TextBox
            {
                Location = new Point(labelWidth, y),
                Width = 200,
                Font = new Font("Segoe UI", 10),
                PlaceholderText = "Nhập mã TB..."
            };
            btnLoadTB = new Button
            {
                Text = "Tải TB",
                Location = new Point(labelWidth + 210, y - 2),
                Size = new Size(80, 28),
                BackColor = Color.Teal,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            btnLoadTB.FlatAppearance.BorderSize = 0;
            btnLoadTB.Click += BtnLoadTB_Click;

            pnlBody.Controls.Add(txtMaTB);
            pnlBody.Controls.Add(btnLoadTB);
            y += 35;

            cboThietBi = new ComboBox
            {
                Location = new Point(labelWidth, y),
                Width = controlWidth,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10),
                Enabled = false
            };
            cboThietBi.SelectedIndexChanged += CboThietBi_SelectedIndexChanged;
            pnlBody.Controls.Add(cboThietBi);
            y += 40;

            lblCanhBao = new Label
            {
                Location = new Point(labelWidth, y),
                Width = controlWidth,
                Height = 50,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.Red,
                Text = "",
                Visible = false,
                AutoSize = false
            };
            pnlBody.Controls.Add(lblCanhBao);
            y += 55;

            lblThongTinTB = new Label
            {
                Location = new Point(labelWidth, y),
                Width = controlWidth,
                Height = 40,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.DarkBlue,
                Text = "",
                Visible = false,
                AutoSize = false
            };
            pnlBody.Controls.Add(lblThongTinTB);
            y += 45;

            AddLabel(pnlBody, "Loại Sự Kiện:", y);
            cboLoaiSuKien = new ComboBox
            {
                Location = new Point(labelWidth, y),
                Width = controlWidth,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10)
            };
            cboLoaiSuKien.Items.AddRange(new object[] { "Sự cố", "Bảo trì định kỳ", "Bảo trì đột xuất" });
            cboLoaiSuKien.SelectedIndex = 0;
            pnlBody.Controls.Add(cboLoaiSuKien);
            y += 40;

            AddLabel(pnlBody, "Thời Gian:", y);
            dtpNgay = new DateTimePicker
            {
                Location = new Point(labelWidth, y),
                Width = 250,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy HH:mm",
                Font = new Font("Segoe UI", 10)
            };
            pnlBody.Controls.Add(dtpNgay);
            y += 40;

            AddLabel(pnlBody, "Người Báo/Xử Lý:", y);
            txtNguoiBao = new TextBox
            {
                Location = new Point(labelWidth, y),
                Width = controlWidth,
                Font = new Font("Segoe UI", 10)
            };
            pnlBody.Controls.Add(txtNguoiBao);
            y += 40;

            AddLabel(pnlBody, "Mô Tả Chi Tiết:", y);
            txtMoTa = new TextBox
            {
                Location = new Point(labelWidth, y),
                Width = controlWidth,
                Height = 80,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Segoe UI", 10)
            };
            pnlBody.Controls.Add(txtMoTa);

            Panel pnlFooter = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 70,
                BackColor = Color.WhiteSmoke
            };

            btnLuu = new Button
            {
                Text = "LƯU SỰ CỐ",
                Location = new Point(430, 18),
                Size = new Size(120, 38),
                BackColor = Color.Firebrick,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Enabled = false
            };
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.Click += BtnLuu_Click;

            btnHuy = new Button
            {
                Text = "Hủy",
                Location = new Point(560, 18),
                Size = new Size(90, 38),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                DialogResult = DialogResult.Cancel
            };
            btnHuy.FlatAppearance.BorderSize = 0;

            pnlFooter.Controls.Add(btnLuu);
            pnlFooter.Controls.Add(btnHuy);

            this.Controls.Add(pnlBody);
            this.Controls.Add(pnlFooter);
            this.Controls.Add(pnlHeader);
        }

        private void AddLabel(Panel parent, string text, int y)
        {
            Label lbl = new Label
            {
                Text = text,
                Location = new Point(10, y + 3),
                Width = 140,
                Font = new Font("Segoe UI", 10),
                TextAlign = ContentAlignment.MiddleLeft
            };
            parent.Controls.Add(lbl);
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
                    {
                        cboThietBi.SelectedIndex = 0;
                    }
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

                    string sqlCheck = @"
                        SELECT TOP 1 MaSuKien, NgayPhatSinh, TrangThai
                        FROM SU_CO_BAO_TRI
                        WHERE MaTB = @MaTB 
                          AND TrangThai IN (0, 1)
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