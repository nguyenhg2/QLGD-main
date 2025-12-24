using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace QLGD_WinForm
{
    public partial class FormCapNhatSuCo : Form
    {
        private string _maSuKien;

        public FormCapNhatSuCo(string maSuKien, string tenTB, string trangThaiCu, decimal chiPhiCu)
        {
            InitializeComponent();
            _maSuKien = maSuKien;

            lblThongTin.Text = $"Sự kiện: {maSuKien}\nThiết bị: {tenTB}";

            cboTrangThai.SelectedIndex = trangThaiCu switch
            {
                "Chờ xử lý" => 0,
                "Đang sửa chữa" => 0,
                "Đã xử lý" => 1,
                _ => 0
            };

            numChiPhi.Value = chiPhiCu;

            btnLuu.Click += BtnLuu_Click;
        }

        #region Actions
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand("sp_CapNhatSuCo", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaSuKien", _maSuKien);

                    int trangThaiInt = cboTrangThai.SelectedIndex + 1;
                    cmd.Parameters.AddWithValue("@TrangThai", trangThaiInt);

                    cmd.Parameters.AddWithValue("@ChiPhi", numChiPhi.Value);
                    cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text.Trim());
                    cmd.Parameters.AddWithValue("@NguoiXuLy", txtNguoiXuLy.Text.Trim());

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cập nhật thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        #endregion
    }
}
