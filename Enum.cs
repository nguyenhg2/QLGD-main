namespace QLGD_WinForm
{
    public enum TrangThaiThietBi
    {
        Tot = 0,
        DangSuDung = 1,
        Hong = 2,
        DangSuaChua = 3,
        ChoThanhLy = 4
    }

    public enum LoaiSuKien
    {
        SuCo = 0,
        BaoTriDinhKy = 1,
        BaoTriDotXuat = 2
    }

    public enum TrangThaiSuCo
    {
        ChoXuLy = 0,
        DangSuaChua = 1,
        DaXuLy = 2
    }

    public enum TrangThaiNguoiMuon
    {
        ConCongTac = 0,
        NghiViec = 1,
        TamNghi = 2
    }

    public static class TrangThaiHelper
    {
        public static string GetTenTrangThai(int maTrangThai, Type enumType)
        {
            if (enumType == typeof(TrangThaiThietBi))
            {
                return maTrangThai switch
                {
                    0 => "Tốt",
                    1 => "Đang sử dụng",
                    2 => "Hỏng",
                    3 => "Đang sửa chữa",
                    4 => "Chờ thanh lý",
                    _ => "Không xác định"
                };
            }
            else if (enumType == typeof(TrangThaiSuCo))
            {
                return maTrangThai switch
                {
                    0 => "Chờ xử lý",
                    1 => "Đang sửa chữa",
                    2 => "Đã xử lý",
                    _ => "Không xác định"
                };
            }
            else if (enumType == typeof(LoaiSuKien))
            {
                return maTrangThai switch
                {
                    0 => "Sự cố",
                    1 => "Bảo trì định kỳ",
                    2 => "Bảo trì đột xuất",
                    _ => "Không xác định"
                };
            }
            else if (enumType == typeof(TrangThaiNguoiMuon))
            {
                return maTrangThai switch
                {
                    0 => "Còn công tác",
                    1 => "Nghỉ việc",
                    2 => "Tạm nghỉ",
                    _ => "Không xác định"
                };
            }

            return "Không xác định";
        }

        public static System.Drawing.Color GetMauTrangThai(int maTrangThai, Type enumType)
        {
            if (enumType == typeof(TrangThaiThietBi))
            {
                return maTrangThai switch
                {
                    0 => System.Drawing.Color.Green,
                    1 => System.Drawing.Color.DarkBlue,
                    2 => System.Drawing.Color.Red,
                    3 => System.Drawing.Color.DarkOrange,
                    4 => System.Drawing.Color.Gray,
                    _ => System.Drawing.Color.Black
                };
            }
            else if (enumType == typeof(TrangThaiSuCo))
            {
                return maTrangThai switch
                {
                    0 => System.Drawing.Color.Red,
                    1 => System.Drawing.Color.DarkOrange,
                    2 => System.Drawing.Color.Green,
                    _ => System.Drawing.Color.Black
                };
            }

            return System.Drawing.Color.Black;
        }
    }
}
