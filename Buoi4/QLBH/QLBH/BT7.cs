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
    public partial class BT7 : Form
    {
        //Chuỗi kết nối
        string strConnectionString = "Data Source=DESKTOP-PANO27V\\SQLEXPRESS; Initial Catalog = QLBH; Integrated Security=True;";
        // Đối tượng kết nối dữ liệu
        SqlConnection conn = null;
        // Đối tượng thực hiện vận chuyển dữ liệu  
        SqlDataAdapter da = null;
        // Đối tượng chứa dữ liệu trong bộ nhớ
        DataSet ds = null;

        public BT7()
        {
            InitializeComponent();
        }

        private void BT7_Load(object sender, EventArgs e)
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


            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!");
            }
        }

        void LoadSanPham(string maloai)
        {
            try
            {

                // Vận chuyển dữ liệu vào DataGridView 
                da = null;
                ds = new DataSet();
                da = new SqlDataAdapter("SELECT * FROM SanPham Where MaLoai='" + maloai + "'", conn);
                da.Fill(ds, "SanPham");
                dgSanPham.DataSource = ds.Tables["SanPham"];
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!");
            }

        }

        private void trvLoaiSanPham_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadSanPham(trvLoaiSanPham.SelectedNode.Tag.ToString());
        }
    }
}
