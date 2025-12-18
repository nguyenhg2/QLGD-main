using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QLGD_WinForm
{
    public class FormDanhSachQuaHan : Form
    {
        private DataGridView dgvList;
        private Button btnRefresh;
        private Button btnClose;

        public FormDanhSachQuaHan()
        {
            InitializeUI();
            LoadData();
        }

        #region UI Setup
        private void InitializeUI()
        {
            this.Text = "DANH SÁCH QUÁ HẠN (TÍNH THEO GIỜ)";
            this.Size = new Size(1100, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            Label lblHeader = new Label
            {
                Text = "THIẾT BỊ QUÁ HẠN CHƯA TRẢ",
                Dock = DockStyle.Top,
                Height = 60,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Firebrick,
                BackColor = Color.MistyRose
            };

            Panel pnlBody = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10) };
            dgvList = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowTemplate = { Height = 35 }
            };
            pnlBody.Controls.Add(dgvList);

            Panel pnlFooter = new Panel { Dock = DockStyle.Bottom, Height = 60, BackColor = Color.White };

            btnRefresh = new Button
            {
                Text = "Làm Mới",
                Location = new Point(840, 12),
                Size = new Size(100, 35),
                BackColor = Color.Teal,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnRefresh.Click += (s, e) => LoadData();

            btnClose = new Button
            {
                Text = "Đóng",
                Location = new Point(950, 12),
                Size = new Size(100, 35)
            };
            btnClose.Click += (s, e) => this.Close();

            pnlFooter.Controls.Add(btnRefresh);
            pnlFooter.Controls.Add(btnClose);

            this.Controls.Add(pnlBody);
            this.Controls.Add(pnlFooter);
            this.Controls.Add(lblHeader);
        }
        #endregion

        #region Data Logic
        private void LoadData()
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand("sp_GetDanhSachQuaHan", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    dgvList.DataSource = dt;
                    SafeConfigureGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void SafeConfigureGrid()
        {
            if (dgvList.Columns.Count == 0) return;

            try
            {
                dgvList.EnableHeadersVisualStyles = false;
                dgvList.ColumnHeadersDefaultCellStyle.BackColor = Color.Firebrick;
                dgvList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvList.ColumnHeadersHeight = 40;

                if (dgvList.Columns.Contains("MaPhieu"))
                    dgvList.Columns["MaPhieu"].HeaderText = "Mã Phiếu";

                if (dgvList.Columns.Contains("NguoiMuon"))
                    dgvList.Columns["NguoiMuon"].HeaderText = "Người Mượn";

                if (dgvList.Columns.Contains("DonVi"))
                    dgvList.Columns["DonVi"].HeaderText = "Đơn Vị";

                if (dgvList.Columns.Contains("SDT"))
                    dgvList.Columns["SDT"].HeaderText = "Số Điện Thoại";

                if (dgvList.Columns.Contains("TenThietBi"))
                    dgvList.Columns["TenThietBi"].HeaderText = "Tên Thiết Bị";

                string dateFmt = "dd/MM/yyyy HH:mm";
                if (dgvList.Columns.Contains("NgayMuon"))
                {
                    dgvList.Columns["NgayMuon"].HeaderText = "Ngày Mượn";
                    dgvList.Columns["NgayMuon"].DefaultCellStyle.Format = dateFmt;
                }

                if (dgvList.Columns.Contains("HanTra"))
                {
                    dgvList.Columns["HanTra"].HeaderText = "Hạn Trả";
                    dgvList.Columns["HanTra"].DefaultCellStyle.Format = dateFmt;
                }

                if (dgvList.Columns.Contains("SoGioQuaHan"))
                {
                    var col = dgvList.Columns["SoGioQuaHan"];
                    col.HeaderText = "Quá Hạn (Giờ)";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    col.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
            catch { }
        }

        #endregion
    }
}