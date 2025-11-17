using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLBH
{
    public partial class BT9 : Form
    {
        //Chuỗi kết nối
        string strConnectionString = "Data Source = DESKTOP-PANO27V\\SQLEXPRESS; Initial Catalog = QLBH; Integrated Security=True; User Id =sa; Password = 123456";
        // Đối tượng kết nối dữ liệu
        SqlConnection conn = null;
        // Đối tượng thực hiện vận chuyển dữ liệu  
        SqlDataAdapter da = null;
        // Đối tượng chứa dữ liệu trong bộ nhớ
        DataSet ds = null;
        //Đối tượng tự động cập nhật dữ liệu
        SqlCommandBuilder cmd = null;

        public BT9()
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

        void LoadSanPham()
        {
            // Vận chuyển dữ liệu vào ComboBox
            da = new SqlDataAdapter("SELECT * FROM SanPham", conn);
            ds = new DataSet();
            da.Fill(ds, "SanPham");
            dgSanPham.DataSource = ds.Tables["SanPham"];

        }

        private void BT9_Load(object sender, EventArgs e)
        {
            //Khởi tạo kết nối
            conn = new SqlConnection(strConnectionString);
            //Mở kết nối
            conn.Open();
            LoadLoaiSanPham();
            LoadSanPham();
            conn.Close();

        }

        private void dgSanPham_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSP.Text = dgSanPham.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenSP.Text = dgSanPham.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDVT.Text = dgSanPham.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDonGia.Text = dgSanPham.Rows[e.RowIndex].Cells[3].Value.ToString();
            cbLoaiSP.SelectedValue = dgSanPham.Rows[e.RowIndex].Cells[4].Value.ToString();
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
            LoadSanPham();
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

            LoadSanPham();

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
            LoadSanPham();
        }
    }
}
