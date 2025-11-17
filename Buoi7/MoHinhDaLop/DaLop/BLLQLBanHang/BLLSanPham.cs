using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DALQLBanHang;
using DTOQLBanHang;

namespace BLLQLBanHang
{
    public class BLLSanPham
    {
        DALSanPham dALSanPham = new DALSanPham();
        public DataTable SelectSanPham()
        {
            DataTable dt = dALSanPham.SelectSanPham();
            return dt;
        }
        public bool InsertSP(DTOSanPham sp)
        {
            return dALSanPham.InsertSanPham(sp);
        }
    }
}
