using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLQLBanHang;
using DTOQLBanHang;

namespace DaLop
{
    public partial class frmSanPham : Form
    {
        BLLSanPham bLLSP = new BLLSanPham();
        DTOSanPham sp = null;
        public frmSanPham()
        {
            InitializeComponent();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bLLSP.SelectSanPham();

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoResizeColumn(0);
            dataGridView1.AutoResizeColumn(2);
            dataGridView1.AutoResizeColumn(3);
            dataGridView1.AutoResizeColumn(4);
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void frmSanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
        
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiem tra du lieu tren Form
            sp = new DTOSanPham();
            sp.MaSp = txtMaSP.Text;
            sp.TenSP = txtTenSP.Text;
            sp.DVTinh = txtDVT.Text;
            sp.DonGia = int.Parse((txtDonGia.Text==null)?"0":txtDonGia.Text);
            sp.MaLoai = txtMaLoai.Text;

            //sp = new DTOSanPham(txtMaLoai...)

            if (bLLSP.InsertSP(sp))
                dataGridView1.DataSource = bLLSP.SelectSanPham();
            else
                MessageBox.Show("Loi thêm mới...");
        }
    }
}
