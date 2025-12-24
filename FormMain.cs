using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLGD_WinForm
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            SetupEvents();
        }

        #region Event Setup
        private void SetupEvents()
        {
            // Button click events
            btnThietBi.Click += (s, e) => OpenForm(new FormThietBi());
            btnMuonTra.Click += (s, e) => OpenForm(new FormMuonTra());
            btnGiangDuong.Click += (s, e) => OpenForm(new FormGiangDuong());
            btnSuCo.Click += (s, e) => OpenForm(new FormSuCo());
            btnThoat.Click += (s, e) => Application.Exit();

            // Hover effects
            SetupHoverEffect(btnThietBi, Color.Teal);
            SetupHoverEffect(btnMuonTra, Color.DarkOrange);
            SetupHoverEffect(btnGiangDuong, Color.SteelBlue);
            SetupHoverEffect(btnSuCo, Color.Firebrick);

            btnThoat.MouseEnter += (s, e) => btnThoat.BackColor = Color.FromArgb(192, 0, 0);
            btnThoat.MouseLeave += (s, e) => btnThoat.BackColor = Color.Gray;
        }

        private void SetupHoverEffect(Button btn, Color baseColor)
        {
            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = baseColor;
                btn.ForeColor = Color.White;
            };
            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = Color.White;
                btn.ForeColor = baseColor;
            };
        }
        #endregion

        #region Helpers
        private void OpenForm(Form f)
        {
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        #endregion
    }
}
