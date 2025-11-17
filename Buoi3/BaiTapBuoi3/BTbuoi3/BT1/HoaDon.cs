using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT3
{
    public class HoaDon
    {
        public string MaHD { get; set; }
        public string TenKH { get; set; }
        public List<string> DanhSachSP { get; set; }
        public decimal TongTien { get; set; }
        public DateTime NgayIn { get; set; }

        public HoaDon()
        {
            DanhSachSP = new List<string>();
        }
    }
}
