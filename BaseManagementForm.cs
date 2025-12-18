using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLGD_WinForm
{
    public class BaseManagementForm : Form
    {
        protected DataGridView dgvMain;
        protected Panel pnlTop;

        #region Constructor & UI Init
        public BaseManagementForm(string title, string configName, Size size)
        {
            this.Text = title;
            this.Size = size;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10F);

            dgvMain = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false, // ⚠️ QUAN TRỌNG
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White,
                RowTemplate = { Height = 35 },
                ColumnHeadersHeight = 45,
                EnableHeadersVisualStyles = false
            };

            // Header style
            dgvMain.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            // Bắt lỗi DataError
            dgvMain.DataError += DgvMain_DataError;

            pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.WhiteSmoke
            };

            this.Controls.Add(dgvMain);
            this.Controls.Add(pnlTop);
        }

        private void DgvMain_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Ngăn crash
            e.ThrowException = false;
            e.Cancel = true;

            // Log chi tiết
            string columnName = dgvMain.Columns[e.ColumnIndex].Name;
            string rowIndex = (e.RowIndex + 1).ToString();
            string errorDetail = e.Exception.Message;

            string errorMsg = $"⚠ LỖI DỮ LIỆU\n\n" +
                            $"Vị trí: Dòng {rowIndex}, Cột '{columnName}'\n" +
                            $"Chi tiết: {errorDetail}\n\n" +
                            $"Nguyên nhân có thể:\n" +
                            $"• Kiểu dữ liệu không khớp (TEXT vs số)\n" +
                            $"• Giá trị NULL không hợp lệ\n" +
                            $"• Dữ liệu trong DB chưa được chuyển đổi";

            MessageBox.Show(errorMsg, "Lỗi Dữ Liệu",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // Log to console for debugging
            Console.WriteLine($"[DataError] Row:{e.RowIndex} Col:{columnName} - {errorDetail}");
        }

        protected void SetupToolbar(TextBox txtSearch, Button btnSearch, Button btnAdd, Button btnEdit, Button btnDel, string lblText)
        {
            Label lbl = new Label { Text = lblText, Location = new Point(20, 20), AutoSize = true };

            txtSearch.Location = new Point(lbl.Right + 10, 18);
            txtSearch.Width = 200;

            btnSearch.Text = "Tìm kiếm";
            btnSearch.Location = new Point(txtSearch.Right + 10, 16);

            btnAdd.Text = "Thêm";
            btnAdd.Location = new Point(btnSearch.Right + 20, 16);
            btnAdd.BackColor = Color.Teal;
            btnAdd.ForeColor = Color.White;

            btnEdit.Text = "Sửa";
            btnEdit.Location = new Point(btnAdd.Right + 10, 16);

            btnDel.Text = "Xóa";
            btnDel.Location = new Point(btnEdit.Right + 10, 16);
            btnDel.BackColor = Color.IndianRed;
            btnDel.ForeColor = Color.White;

            foreach (var btn in new[] { btnSearch, btnAdd, btnEdit, btnDel })
            {
                btn.Size = new Size(90, 32);
            }

            pnlTop.Controls.AddRange(new Control[] { lbl, txtSearch, btnSearch, btnAdd, btnEdit, btnDel });
        }
        #endregion

        #region Virtual Methods
        protected virtual void LoadData(string search = "") { }
        protected virtual void AddNew() { }
        protected virtual void EditSelected() { }
        protected virtual void DeleteSelected() { }
        #endregion
    }
}
