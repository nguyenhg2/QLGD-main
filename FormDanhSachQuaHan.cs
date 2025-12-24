using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QLGD_WinForm
{
    public partial class FormDanhSachQuaHan : Form
    {
        public FormDanhSachQuaHan()
        {
            InitializeComponent();
            SetupEvents();
            LoadData();
        }

        #region Events Setup
        private void SetupEvents()
        {
            btnRefresh.Click += (s, e) => LoadData();
            btnClose.Click += (s, e) => this.Close();
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
