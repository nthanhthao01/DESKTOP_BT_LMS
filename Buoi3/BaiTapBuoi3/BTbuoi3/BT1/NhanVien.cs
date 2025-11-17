using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT3
{
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public string ChucVu { get; set; }
        public string SDT { get; set; }

        public NhanVien(string ma, string ten, string gt, string cv, string sdt)
        {
            MaNV = ma;
            HoTen = ten;
            GioiTinh = gt;
            ChucVu = cv;
            SDT = sdt;
        }
    }
}
