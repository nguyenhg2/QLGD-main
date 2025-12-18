using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QLGD_WinForm
{
    public class FormGiangDuong : BaseManagementForm
    {
        private TextBox txtTim;

        public FormGiangDuong() : base("Thống Kê Thiết Bị Theo Giảng Đường", "GiangDuong", new Size(1200, 650))
        {
            InitializeCustomToolbar();
            LoadData();
        }

        #region UI Setup
        private void InitializeCustomToolbar()
        {
            txtTim = new TextBox
            {
                Width = 200,
                PlaceholderText = "Tìm giảng đường...",
                Font = new Font("Segoe UI", 10)
            };

            var btnSearch = new Button
            {
                Text = "Tìm",
                Size = new Size(100, 32),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White
            };

            var btnRefresh = new Button
            {
                Text = "Làm mới",
                Size = new Size(110, 32)
            };

            btnSearch.Click += (s, e) => LoadData(txtTim.Text);
            btnRefresh.Click += (s, e) => { txtTim.Clear(); LoadData(); };

            pnlTop.Controls.Clear();

            Label lbl = new Label
            {
                Text = "Tìm kiếm:",
                Location = new Point(20, 22),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };

            txtTim.Location = new Point(100, 18);
            btnSearch.Location = new Point(310, 16);
            btnRefresh.Location = new Point(420, 16);

            pnlTop.Controls.AddRange(new Control[] { lbl, txtTim, btnSearch, btnRefresh });
        }
        #endregion

        #region Data Logic
        protected override void LoadData(string search = "")
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand("sp_ThongKeThietBiTheoPhong", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var adapter = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    dgvMain.AutoGenerateColumns = false;
                    dgvMain.Columns.Clear();

                    AddColumn("KhuVuc", "Giảng Đường", 150);
                    AddColumn("TongTB", "Tổng TB", 120);
                    AddColumn("Tot", "Tốt", 120, Color.Green);
                    AddColumn("Hong", "Hỏng", 120, Color.Red, FontStyle.Bold);
                    AddColumn("DangDung", "Đang Mượn", 140, Color.DarkBlue);
                    AddColumn("SuaChua", "Đang Sửa", 120, Color.DarkOrange);

                    if (dt.Columns.Contains("ChoThanhLy"))
                    {
                        AddColumn("ChoThanhLy", "Chờ Thanh Lý", 140, Color.Gray);
                    }

                    if (!string.IsNullOrEmpty(search))
                    {
                        dt.DefaultView.RowFilter = $"KhuVuc LIKE '%{search}%'";
                        dgvMain.DataSource = dt.DefaultView;
                    }
                    else
                    {
                        dgvMain.DataSource = dt;
                    }

                    HighlightProblems();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddColumn(string dataPropertyName, string headerText, int width,
                               Color? foreColor = null, FontStyle? fontStyle = null)
        {
            var column = new DataGridViewTextBoxColumn
            {
                Name = dataPropertyName,
                DataPropertyName = dataPropertyName,
                HeaderText = headerText,
                Width = width,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };

            if (foreColor.HasValue)
                column.DefaultCellStyle.ForeColor = foreColor.Value;

            if (fontStyle.HasValue)
                column.DefaultCellStyle.Font = new Font(dgvMain.Font, fontStyle.Value);

            dgvMain.Columns.Add(column);
        }

        private void HighlightProblems()
        {
            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["Hong"].Value != null)
                {
                    if (int.TryParse(row.Cells["Hong"].Value.ToString(), out int hong) && hong > 0)
                    {
                        row.Cells["Hong"].Style.BackColor = Color.MistyRose;
                    }
                }

                if (row.Cells["TongTB"].Value != null)
                {
                    if (int.TryParse(row.Cells["TongTB"].Value.ToString(), out int tong) && tong == 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                        row.DefaultCellStyle.ForeColor = Color.Gray;
                    }
                }
            }
        }
        #endregion
    }
}