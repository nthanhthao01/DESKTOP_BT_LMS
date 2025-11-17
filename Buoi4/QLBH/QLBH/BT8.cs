using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLBH
{
    public partial class BT8 : Form
    {
        //Chuỗi kết nối
        string strConnectionString = "Data Source = DESKTOP-PANO27V\\SQLEXPRESS; Initial Catalog = QLBH; Integrated Security=True;";
        // Đối tượng kết nối dữ liệu
        SqlConnection conn = null;
        // Đối tượng thực hiện vận chuyển dữ liệu  
        SqlDataAdapter da = null;
        // Đối tượng chứa dữ liệu trong bộ nhớ
        DataSet ds = null;
        //Bảng chứa Sản phẩm để thuận tiện trong quá trình di chuyển mẩu tin
        DataTable dtSP;
        //Biến lưu vị trí dòng
        int vitri = -1;

        public BT8()
        {
            InitializeComponent();
        }

        void LoadLoaiSanPham()
        {
            // Vận chuyển dữ liệu vào ComboBox
            da = new SqlDataAdapter("SELECT * FROM LoaiSanPham", conn);
            ds = new DataSet();
            da.Fill(ds, "LoaiSanPham");
            cbLoaiSP.DataSource = ds.Tables["LoaiSanPham"];
            cbLoaiSP.DisplayMember = "TenLoai";
            cbLoaiSP.ValueMember = "MaLoai";
        }

        private void BT8_Load(object sender, EventArgs e)
        {
            //Khởi tạo kết nối
            conn = new SqlConnection(strConnectionString);
            //Mở kết nối
            conn.Open();
            // Đưa dữ liệu vào Bảng sản phẩm dtSP
            da = new SqlDataAdapter("SELECT * FROM SanPham", conn);
            ds = new DataSet();
            da.Fill(ds, "SanPham");
            dtSP = ds.Tables["SanPham"];
            btFirst.PerformClick(); //thực hiện chọn nút First đầu tiên
            LoadLoaiSanPham();

        }

        private void btFirst_Click(object sender, EventArgs e)
        {
            if (dtSP.Rows.Count == 0) return;
            vitri = 0;
            txtMaSP.Text = dtSP.Rows[vitri]["MaSP"].ToString();
            txtTenSP.Text = dtSP.Rows[vitri]["TenSP"].ToString();
            txtDVT.Text = dtSP.Rows[vitri]["DVTinh"].ToString();
            txtDonGia.Text = dtSP.Rows[vitri]["DonGia"].ToString();
            cbLoaiSP.SelectedValue = dtSP.Rows[vitri]["MaLoai"].ToString();
        }

        private void btLast_Click(object sender, EventArgs e)
        {
            if (dtSP.Rows.Count == 0) return;
            vitri = dtSP.Rows.Count - 1;
            txtMaSP.Text = dtSP.Rows[vitri]["MaSP"].ToString();
            txtTenSP.Text = dtSP.Rows[vitri]["TenSP"].ToString();
            txtDVT.Text = dtSP.Rows[vitri]["DVTinh"].ToString();
            txtDonGia.Text = dtSP.Rows[vitri]["DonGia"].ToString();
            cbLoaiSP.SelectedValue = dtSP.Rows[vitri]["MaLoai"].ToString();
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            if (dtSP.Rows.Count == 0) return;
            vitri++;
            if (vitri > dtSP.Rows.Count - 1) vitri = dtSP.Rows.Count - 1;
            txtMaSP.Text = dtSP.Rows[vitri]["MaSP"].ToString();
            txtTenSP.Text = dtSP.Rows[vitri]["TenSP"].ToString();
            txtDVT.Text = dtSP.Rows[vitri]["DVTinh"].ToString();
            txtDonGia.Text = dtSP.Rows[vitri]["DonGia"].ToString();
            cbLoaiSP.SelectedValue = dtSP.Rows[vitri]["MaLoai"].ToString();
        }

        private void btPrevious_Click(object sender, EventArgs e)
        {
            if (dtSP.Rows.Count == 0) return;
            vitri--;
            if (vitri < 0) vitri = 0;
            txtMaSP.Text = dtSP.Rows[vitri]["MaSP"].ToString();
            txtTenSP.Text = dtSP.Rows[vitri]["TenSP"].ToString();
            txtDVT.Text = dtSP.Rows[vitri]["DVTinh"].ToString();
            txtDonGia.Text = dtSP.Rows[vitri]["DonGia"].ToString();
            cbLoaiSP.SelectedValue = dtSP.Rows[vitri]["MaLoai"].ToString();
        }
    }
}
