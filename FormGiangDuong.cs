using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QLGD_WinForm
{
    public partial class FormGiangDuong : BaseManagementForm
    {
        public FormGiangDuong()
        {
            InitializeComponent();
            SetupEvents();
            LoadData();
        }

        #region Events Setup
        private void SetupEvents()
        {
            btnSearch.Click += (s, e) => LoadData(txtTim.Text);
            btnRefresh.Click += (s, e) => { txtTim.Clear(); LoadData(); };
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
