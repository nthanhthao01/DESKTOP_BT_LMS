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
    public partial class BT1 : Form
    {
        string strConnectionString = "Data Source=DESKTOP-PANO27V\\SQLEXPRESS;Initial Catalog=QLBH;Integrated Security=True;";
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet ds = null;
        public BT1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Khởi động kết nối
            conn = new SqlConnection(strConnectionString);
            //Mở kết nối 
            conn.Open();
            // Vận chuyển dữ liệu vào đối tượng DataSet ds
            da = new SqlDataAdapter("SELECT * FROM SanPham", conn);
            ds = new DataSet();
            da.Fill(ds);
            //……thực hiện đưa dữ liệu vào các đối tượng trên Form tại đây……
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Giải phóng tài nguyên 
            ds.Dispose();
            ds = null;
            // Đóng và hủy kết nối
            conn.Close();
            conn = null;
        }
    }
}
