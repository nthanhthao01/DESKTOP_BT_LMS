using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT3
{
    public class SanPham
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string DanhMuc { get; set; }
        public decimal Gia { get; set; }
        public int TonKho { get; set; }

        public SanPham(string ma, string ten, string danhMuc, decimal gia, int tonKho)
        {
            MaSP = ma;
            TenSP = ten;
            DanhMuc = danhMuc;
            Gia = gia;
            TonKho = tonKho;
        }
    }

}
