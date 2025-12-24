using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLGD_WinForm
{
    public partial class FormChiTietMuonTra : Form
    {
        private string _maDK;

        public FormChiTietMuonTra(string maDK)
        {
            InitializeComponent();
            _maDK = maDK;
            this.Text = "Chi Tiết Phiếu Mượn: " + _maDK;

            btnClose.Click += (s, e) => this.Close();
            LoadDetail();
        }

        #region Data Logic
        private void LoadDetail()
        {
            using (var conn = new SqlConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT mt.MaDK, nm.HoTen, nm.DonVi, tb.TenTB, 
                           mt.TGMuon, mt.TGTraDuKien, mt.TGTra, mt.GhiChu,
                           CASE WHEN mt.TGTra IS NULL AND GETDATE() > mt.TGTraDuKien THEN N'QUÁ HẠN' 
                                WHEN mt.TGTra IS NULL THEN N'Đang mượn' 
                                ELSE N'Đã hoàn thành' END as TrangThai
                    FROM MUON_TRA mt
                    JOIN NGUOI_MUON nm ON mt.MaNguoiMuon = nm.MaNguoiMuon
                    JOIN THIET_BI tb ON mt.MaTB = tb.MaTB
                    WHERE mt.MaDK = @id";

                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", _maDK);

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        string fmt = "dd/MM/yyyy HH:mm";

                        lblMaDK.Text = dr["MaDK"].ToString();
                        lblNguoiMuon.Text = dr["HoTen"].ToString();
                        lblDonVi.Text = dr["DonVi"].ToString();
                        lblThietBi.Text = dr["TenTB"].ToString();
                        lblNgayMuon.Text = Convert.ToDateTime(dr["TGMuon"]).ToString(fmt);

                        if (dr["TGTraDuKien"] != DBNull.Value)
                            lblTraDuKien.Text = Convert.ToDateTime(dr["TGTraDuKien"]).ToString(fmt);
                        else
                            lblTraDuKien.Text = "Chưa xác định";

                        if (dr["TGTra"] != DBNull.Value)
                            lblTraThucTe.Text = Convert.ToDateTime(dr["TGTra"]).ToString(fmt);
                        else
                            lblTraThucTe.Text = "Chưa trả";

                        lblGhiChu.Text = dr["GhiChu"].ToString();
                        lblTrangThai.Text = dr["TrangThai"].ToString();
                        lblTrangThai.ForeColor = lblTrangThai.Text == "QUÁ HẠN" ? Color.Red : Color.Green;
                    }
                }
            }
        }
        #endregion
    }
}
