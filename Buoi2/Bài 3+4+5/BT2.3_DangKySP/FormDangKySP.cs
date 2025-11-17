using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT2._3
{
    public partial class FormDangKySP : Form
    {
        public FormDangKySP()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenSP = txtTenSP.Text.Trim();
            string loaiSP = cbLoaiSP.SelectedItem?.ToString();
            int soLuong = (int)nudSoLuong.Value;

            if (string.IsNullOrEmpty(tenSP))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm.", 
                                "Lỗi", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
                return;
            }

            if (cbLoaiSP.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm.",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (nudSoLuong.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0.",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            dgvSP.Rows.Add(tenSP, loaiSP, soLuong);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenSP.Clear();
            cbLoaiSP.SelectedIndex = -1;
            nudSoLuong.Value = 0;

            txtTenSP.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSP.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc muốn xóa dòng này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    dgvSP.Rows.Remove(dgvSP.CurrentRow);
                }
            }
            else
            {
                MessageBox.Show(
                    "Vui lòng chọn dòng để xóa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
    }
}
