using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT3
{
    public static class TaiKhoanHienTai
    {
        public static string TenDangNhap { get; set; } = "";
        public static string Quyen { get; set; } = "";

        public static bool DaDangNhap => !string.IsNullOrEmpty(TenDangNhap);

        public static bool KiemTraDangNhap()
        {
            return DaDangNhap;
        }

        public static string LayThongTinHienThi()
        {
            if (DaDangNhap)
                return $"Người dùng: {TenDangNhap} ({Quyen})";
            else
                return "Người dùng: Chưa đăng nhập";
        }

        public static void DangXuat()
        {
            TenDangNhap = "";
            Quyen = "";
        }
    }

}
