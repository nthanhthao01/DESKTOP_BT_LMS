using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH
{
    public partial class BT10 : Form
    {
        public BT10()
        {
            InitializeComponent();

            IsMdiContainer = true;
        }

        private void mnQuanLy_SanPham_Click(object sender, EventArgs e)
        {
            QuanLySanPham spForm = new QuanLySanPham { MdiParent = this };
            spForm.Show();
        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aForm = new About { MdiParent = this };
            aForm.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien nvForm = new QuanLyNhanVien { MdiParent = this };
            nvForm.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang khForm = new QuanLyKhachHang { MdiParent = this };
            khForm.Show();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyHoaDon hdForm = new QuanLyHoaDon { MdiParent = this };    
            hdForm.Show();
        }
    }
}
