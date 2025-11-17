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
    public partial class QuanLyNhanVien : Form
    {
        //Chuỗi kết nối
        string strConnectionString = "Data Source=DESKTOP-PANO27V\\SQLEXPRESS; Initial Catalog = QLBH; Integrated Security=True;";
        // Đối tượng kết nối dữ liệu
        SqlConnection conn = null;
        // Đối tượng thực hiện vận chuyển dữ liệu  
        SqlDataAdapter da = null;
        // Đối tượng chứa dữ liệu trong bộ nhớ
        DataSet ds = null;
        //Đối tượng tự động cập nhật dữ liệu
        SqlCommandBuilder cmd = null;
        //Bảng chứa Nhân Viên để thuận tiện trong quá trình di chuyển mẩu tin
        DataTable dtNV;
        //Biến lưu vị trí dòng
        int vitri = -1;
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                //Khởi tạo kết nối
                conn = new SqlConnection(strConnectionString);
                //Mở kết nối
                conn.Open();
                // Vận chuyển dữ liệu vào TreeView
                da = new SqlDataAdapter("SELECT * FROM NhanVien", conn);
                ds = new DataSet();
                da.Fill(ds, "NhanVien");
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!");
            }
        }

        void LoadNhanVien(string manv)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Vận chuyển dữ liệu vào DataGridView 
                da = new SqlDataAdapter("SELECT * FROM NhanVien Where MaNV='" + manv + "'", conn);
                ds = new DataSet();
                da.Fill(ds, "NhanVien");
                dgNhanVien.DataSource = ds.Tables["NhanVien"];

                // GÁN dtNV
                dtNV = ds.Tables["NhanVien"];
                vitri = 0;

                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không lấy được dữ liệu: " + ex.Message);
            }
        }

        private void dgNhanVien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra RowIndex hợp lệ
                if (e.RowIndex < 0 || e.RowIndex >= dgNhanVien.Rows.Count)
                    return;

                DataGridViewRow row = dgNhanVien.Rows[e.RowIndex];

                // Kiểm tra dòng không phải là dòng mới (new row)
                if (row.IsNewRow)
                    return;

                // Kiểm tra null và gán giá trị bằng TÊN CỘT
                txtMaNV.Text = row.Cells["MaNV"].Value?.ToString() ?? "";
                txtTenNV.Text = row.Cells["TenNV"].Value?.ToString() ?? "";
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString() ?? "";
                txtDienThoai.Text = row.Cells["DienThoai"].Value?.ToString() ?? "";
                string gioiTinh = row.Cells["GioiTinh"].Value?.ToString() ?? "";

                // Gán cho RadioButton
                if (gioiTinh == "Nam" || gioiTinh == "1" || gioiTinh.ToLower() == "nam")
                {
                    rbtnNam.Checked = true;
                    rbtnNu.Checked = false; 
                }
                else if (gioiTinh == "Nữ" || gioiTinh == "0" || gioiTinh.ToLower() == "nữ" || gioiTinh.ToLower() == "nu")
                {
                    rbtnNu.Checked = true;
                    rbtnNam.Checked = false;
                }
                else
                {
                    // Giá trị mặc định nếu không rõ
                    rbtnNam.Checked = true;
                }


                // Cập nhật vị trí
                vitri = e.RowIndex;

                // Vô hiệu hóa txtMaSP khi xem dữ liệu
                txtMaNV.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị dữ liệu: " + ex.Message);
            }
        }

        void TimKiem(string keyword)
        {
            try
            {
                //Khởi tạo kết nối
                conn = new SqlConnection(strConnectionString);
                //Mở kết nối
                conn.Open();

                //Khai báo câu truy vấn
                string sql = "";
                if (keyword != "")
                {
                    sql = "SELECT * FROM NhanVien Where TenNV like N'%" + keyword + "%'";
                }
                else
                {
                    sql = "SELECT * FROM NhanVien";
                }

                // Vận chuyển dữ liệu vào DataGridView dgSanPham
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "NhanVien");
                dgNhanVien.DataSource = ds.Tables["NhanVien"];

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            TimKiem(txtKeyWord.Text);
        }
    }
}
