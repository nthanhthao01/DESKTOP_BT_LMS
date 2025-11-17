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
    public partial class QuanLySanPham : Form
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
        //Bảng chứa Sản phẩm để thuận tiện trong quá trình di chuyển mẩu tin
        DataTable dtSP;
        //Biến lưu vị trí dòng
        int vitri = -1;

        public QuanLySanPham()
        {
            InitializeComponent();
        }

        private void QuanLySanPham_Load(object sender, EventArgs e)
        {
            try
            {
                //Khởi tạo kết nối
                conn = new SqlConnection(strConnectionString);
                //Mở kết nối
                conn.Open();
                // Vận chuyển dữ liệu vào TreeView
                da = new SqlDataAdapter("SELECT * FROM LoaiSanPham", conn);
                ds = new DataSet();
                da.Fill(ds, "LoaiSanPham");
                trvLoaiSanPham.Nodes.Clear();
                TreeNode node;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    node = new TreeNode();
                    node.Text = dr["TenLoai"].ToString(); //hiển thị ra bên ngoài
                    node.Tag = dr["MaLoai"].ToString(); //giá trị khi được chọn
                    trvLoaiSanPham.Nodes.Add(node);
                }
                cbLoaiSP.DataSource = ds.Tables["LoaiSanPham"];
                cbLoaiSP.DisplayMember = "TenLoai";
                cbLoaiSP.ValueMember = "MaLoai";
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!");
            }
        }
        private void trvLoaiSanPham_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string maloai = e.Node.Tag.ToString();
            LoadSanPham(maloai); 
        }

        void LoadSanPham(string maloai)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Vận chuyển dữ liệu vào DataGridView 
                da = new SqlDataAdapter("SELECT * FROM SanPham Where MaLoai='" + maloai + "'", conn);
                ds = new DataSet();
                da.Fill(ds, "SanPham");
                dgSanPham.DataSource = ds.Tables["SanPham"];

                // GÁN dtSP
                dtSP = ds.Tables["SanPham"];
                vitri = 0;

                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không lấy được dữ liệu: " + ex.Message);
            }
        }

        private void dgSanPham_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra RowIndex hợp lệ
                if (e.RowIndex < 0 || e.RowIndex >= dgSanPham.Rows.Count)
                    return;

                DataGridViewRow row = dgSanPham.Rows[e.RowIndex];

                // Kiểm tra dòng không phải là dòng mới (new row)
                if (row.IsNewRow)
                    return;

                // Kiểm tra null và gán giá trị bằng TÊN CỘT
                txtMaSP.Text = row.Cells["MaSP"].Value?.ToString() ?? "";
                txtTenSP.Text = row.Cells["TenSP"].Value?.ToString() ?? "";
                txtDVT.Text = row.Cells["DVTinh"].Value?.ToString() ?? "";
                txtDonGia.Text = row.Cells["DonGia"].Value?.ToString() ?? "";

                // Cập nhật ComboBox với kiểm tra null
                if (row.Cells["MaLoai"].Value != null && cbLoaiSP.Items.Count > 0)
                {
                    cbLoaiSP.SelectedValue = row.Cells["MaLoai"].Value.ToString();
                }

                // Cập nhật vị trí
                vitri = e.RowIndex;

                // Vô hiệu hóa txtMaSP khi xem dữ liệu
                txtMaSP.Enabled = false;
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
                    sql = "SELECT * FROM SanPham Where TenSP like N'%" + keyword + "%'";
                }
                else
                {
                    sql = "SELECT * FROM SanPham";
                }

                // Vận chuyển dữ liệu vào DataGridView dgSanPham
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "SanPham");
                dgSanPham.DataSource = ds.Tables["SanPham"];

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

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaSP.Enabled = true;
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtDVT.Text = "";
            txtDonGia.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommandBuilder(da);
            DataRow row = ds.Tables["SanPham"].NewRow();
            row["MaSP"] = txtMaSP.Text;
            row["TenSP"] = txtTenSP.Text;
            row["DVTinh"] = txtDVT.Text;
            row["DonGia"] = txtDonGia.Text;
            row["MaLoai"] = cbLoaiSP.SelectedValue.ToString();
            ds.Tables["SanPham"].Rows.Add(row);
            if (da.Update(ds, "SanPham") > 0)
            {
                MessageBox.Show("Luu thanh cong!");
            }
            else
            {
                MessageBox.Show("Luu khong thanh cong!");
            }
            LoadSanPham(cbLoaiSP.SelectedValue.ToString());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommandBuilder(da);
            int pos = dgSanPham.CurrentRow.Index;
            DataRow row = ds.Tables["SanPham"].Rows[pos];
            row["MaSP"] = txtMaSP.Text;
            row["TenSP"] = txtTenSP.Text;
            row["DVTinh"] = txtDVT.Text;
            row["DonGia"] = txtDonGia.Text;
            row["MaLoai"] = cbLoaiSP.SelectedValue.ToString();
            if (da.Update(ds, "SanPham") > 0)
            {
                MessageBox.Show("Cap nhat thanh cong!");
            }
            else
            {
                MessageBox.Show("Cap nhat khong thanh cong!");
            }

            LoadSanPham(cbLoaiSP.SelectedValue.ToString());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommandBuilder(da);
            int pos = dgSanPham.CurrentRow.Index;
            ds.Tables["SanPham"].Rows[pos].Delete();
            if (da.Update(ds, "SanPham") > 0)
            {
                MessageBox.Show("Xoa thanh cong!");
            }
            else
            {
                MessageBox.Show("Xoa khong thanh cong!");
            }
            LoadSanPham(cbLoaiSP.SelectedValue.ToString());
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
