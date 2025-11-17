using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOQLBanHang
{
    public class DTOSanPham
    {
        private string _MaSp;
        private string _TenSP;
        private string _DVTinh;
        private int _DonGia;
        private string _MaLoai;
        public string MaSp
        {
            get
            {
                return _MaSp;
            }

            set
            {
                _MaSp = value;
            }
        }
        public string TenSP
        {
            get
            {
                return _TenSP;
            }

            set
            {
                _TenSP = value;
            }
        }
        public string DVTinh
        {
            get
            {
                return _DVTinh;
            }

            set
            {
                _DVTinh = value;
            }
        }
        public int DonGia
        {
            get
            {
                return _DonGia;
            }

            set
            {
                _DonGia = value;
            }
        }
        public string MaLoai
        {
            get
            {
                return _MaLoai;
            }

            set
            {
                _MaLoai = value;
            }
        }
        public DTOSanPham()
        {
        }
        public DTOSanPham(string maSP, string tenSP, string dVTinh, int donGia, string maLoai)
        {
            _MaSp = maSP;
            _TenSP = tenSP;
            _DVTinh = dVTinh;
            _DonGia = donGia;
            _MaLoai = maLoai;
        }
    }
    public class DTOLoaiSanPham
    {
        private string _MaLoai;
        private string _TenLoai;
        public string MaLoai
        {
            get
            {
                return _MaLoai;
            }

            set
            {
                _MaLoai = value;
            }
        }
        public string TenLoai
        {
            get
            {
                return _TenLoai;
            }

            set
            {
                _TenLoai = value;
            }
        }
    }
}
