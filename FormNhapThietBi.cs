using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace QLGD_WinForm
{
    public partial class FormNhapThietBi : Form
    {
        private string _maTB = null;

        public FormNhapThietBi(string maTB = null)
        {
            InitializeComponent();
            _maTB = maTB;

            if (_maTB != null)
            {
                this.Text = "Cập Nhật Thiết Bị";
                txtMaTB.ReadOnly = true;
            }

            LoadComboboxes();
            if (_maTB != null) LoadDataDetail();

            btnLuu.Click += BtnLuu_Click;
        }

        #region Data Logic
        private void LoadComboboxes()
        {
            using (var conn = new SqlConnection(AppConfig.ConnectionString))
            {
                conn.Open();

                var daLoai = new SqlDataAdapter("SELECT MaLoai, TenLoai FROM LOAI_THIET_BI", conn);
                var dtLoai = new DataTable();
                daLoai.Fill(dtLoai);
                cboLoai.DataSource = dtLoai;
                cboLoai.DisplayMember = "TenLoai";
                cboLoai.ValueMember = "MaLoai";

                var daPhong = new SqlDataAdapter(
                    "SELECT MaGD, MaPhong, (MaGD + ' - ' + MaPhong) as TenHienThi FROM GIANG_DUONG",
                    conn
                );
                var dtPhong = new DataTable();
                daPhong.Fill(dtPhong);
                cboPhong.DataSource = dtPhong;
                cboPhong.DisplayMember = "TenHienThi";
            }
        }

        private void LoadDataDetail()
        {
            using (var conn = new SqlConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM THIET_BI WHERE MaTB = @id", conn);
                cmd.Parameters.AddWithValue("@id", _maTB);

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        txtMaTB.Text = dr["MaTB"].ToString();
                        txtTenTB.Text = dr["TenTB"].ToString();
                        txtGiaTri.Text = dr["GiaTri"].ToString();
                        cboLoai.SelectedValue = dr["MaLoai"].ToString();

                        string maGD = dr["MaGD"].ToString();
                        string maPhong = dr["MaPhong"].ToString();

                        foreach (DataRowView item in cboPhong.Items)
                        {
                            if (item["MaGD"].ToString() == maGD &&
                                item["MaPhong"].ToString() == maPhong)
                            {
                                cboPhong.SelectedItem = item;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTB.Text) ||
                string.IsNullOrWhiteSpace(txtTenTB.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã và Tên thiết bị!");
                return;
            }

            if (cboLoai.SelectedValue == null || cboPhong.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn Loại thiết bị và Vị trí!");
                return;
            }

            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                {
                    conn.Open();
                    string sql;

                    if (_maTB == null)
                    {
                        sql = @"INSERT INTO THIET_BI 
                                (MaTB, TenTB, MaLoai, MaGD, MaPhong, GiaTri, TrangThai) 
                                VALUES (@MaTB, @TenTB, @MaLoai, @MaGD, @MaPhong, @GiaTri, 0)";
                    }
                    else
                    {
                        sql = @"UPDATE THIET_BI 
                                SET TenTB=@TenTB, MaLoai=@MaLoai, MaGD=@MaGD, 
                                    MaPhong=@MaPhong, GiaTri=@GiaTri 
                                WHERE MaTB=@MaTB";
                    }

                    var cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaTB", txtMaTB.Text.Trim());
                    cmd.Parameters.AddWithValue("@TenTB", txtTenTB.Text.Trim());
                    cmd.Parameters.AddWithValue("@MaLoai", cboLoai.SelectedValue);

                    DataRowView drv = (DataRowView)cboPhong.SelectedItem;
                    cmd.Parameters.AddWithValue("@MaGD", drv["MaGD"]);
                    cmd.Parameters.AddWithValue("@MaPhong", drv["MaPhong"]);

                    decimal giaTri = 0;
                    decimal.TryParse(txtGiaTri.Text, out giaTri);
                    cmd.Parameters.AddWithValue("@GiaTri", giaTri);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Lưu thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
