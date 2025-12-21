using QLGD_WinForm;
using System;
using System.Windows.Forms;

static class Program
{
    [STAThread]
    static void Main()
    {
        // Global error handler
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += Application_ThreadException;
        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new FormMain());
    }

    private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
    {
        HandleException(e.Exception);
    }

    private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        HandleException((Exception)e.ExceptionObject);
    }

    private static void HandleException(Exception ex)
    {
        string message = "❌ LỖI HỆ THỐNG\n\n";

        if (ex.Message.Contains("not a valid value for Int32"))
        {
            message += "NGUYÊN NHÂN:\n" +
                      "Database có dữ liệu TEXT chưa chuyển sang số.\n\n" +
                      "GIẢI PHÁP:\n" +
                      "1. Kiểm tra cột TrangThai trong DB\n" +
                      "2. Chạy script chuyển đổi dữ liệu\n" +
                      "3. Hoặc liên hệ admin\n\n";
        }
        else if (ex.Message.Contains("DataGridView"))
        {
            message += "NGUYÊN NHÂN:\n" +
                      "Lỗi hiển thị dữ liệu trên DataGridView.\n\n" +
                      "GIẢI PHÁP:\n" +
                      "1. Tắt AutoGenerateColumns\n" +
                      "2. Định nghĩa thủ công các cột\n\n";
        }

        message += $"CHI TIẾT KỸ THUẬT:\n{ex.Message}\n\n";
        message += $"STACK TRACE:\n{ex.StackTrace}";

        MessageBox.Show(message, "Lỗi Nghiêm Trọng",
            MessageBoxButtons.OK, MessageBoxIcon.Error);

        // Log to file (optional)
        try
        {
            string logPath = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                $"QLGD_Error_{DateTime.Now:yyyyMMdd_HHmmss}.log"
            );
            System.IO.File.WriteAllText(logPath, message);
        }
        catch { }
    }
}
