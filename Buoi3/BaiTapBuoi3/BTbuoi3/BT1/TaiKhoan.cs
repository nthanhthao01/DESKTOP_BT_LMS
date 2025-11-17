using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT3
{
    public class TaiKhoan
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Quyen { get; set; } 

        public TaiKhoan() { }

        public TaiKhoan(string tenDangNhap, string matKhau, string quyen)
        {
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            Quyen = quyen;
        }
    }
}
