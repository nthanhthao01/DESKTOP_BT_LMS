using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT2._5_QuanLy
{
    public partial class FormQuanLy : Form
    {
        public FormQuanLy()
        {
            InitializeComponent();

            toolTip1.SetToolTip(lbTenSP, "Nhập tên sản phẩm");
            toolTip1.SetToolTip(lbLoaiSP, "Chọn loại sản phẩm");
            toolTip1.SetToolTip(lbSoLuong, "Nhập số lượng sản phẩm");
            toolTip1.SetToolTip(gbTinhTrangSP, "Chọn tình trạng sản phẩm");
            toolTip1.SetToolTip(btnThem, "Thêm sản phẩm");
            toolTip1.SetToolTip(btnSua, "Sửa sản phẩm");
            toolTip1.SetToolTip(btnXoa, "Xóa sản phẩm");
        }

        private void CapNhatTongSanPham()
        {
            int tong = dgvSP.Rows.Count - 1;
            lblTongSanPham.Text = "Tổng sản phẩm: " + tong.ToString();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            string tenSP = txtTenSP.Text.Trim();
            string loaiSP = cbLoaiSP.SelectedItem?.ToString();
            int soLuong = (int)nudSoLuong.Value;
            string tinhTrang = rbtnCon.Checked ? "Còn" : "Hết";
            bool hasError = false;

            if (string.IsNullOrEmpty(tenSP))
            {
                errorProvider1.SetError(txtTenSP, "Vui lòng nhập tên sản phẩm!");
                hasError = true;
            }

            if (cbLoaiSP.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbLoaiSP, "Vui lòng chọn loại sản phẩm!");
                hasError = true;
            }

            if (nudSoLuong.Value <= 0)
            {
                errorProvider1.SetError(nudSoLuong, "Số lượng phải lớn hơn 0!");
                hasError = true;
            }

            if (hasError)
            {
                return;
            }

            dgvSP.Rows.Add(tenSP, loaiSP, soLuong, tinhTrang);

            CapNhatTongSanPham();

            errorProvider1.Clear();
            txtTenSP.Clear();
            cbLoaiSP.SelectedIndex = -1;
            nudSoLuong.Value = 0;
            rbtnCon.Checked = true;
            txtTenSP.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvSP.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng để sửa.",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }

            else
            {
                if (dgvSP.SelectedRows.Count == 1)
                {
                    dgvSP.CurrentRow.Cells[0].Value = txtTenSP.Text.Trim();
                    dgvSP.CurrentRow.Cells[1].Value = cbLoaiSP.SelectedItem?.ToString();
                    dgvSP.CurrentRow.Cells[2].Value = (int)nudSoLuong.Value;
                    dgvSP.CurrentRow.Cells[3].Value = rbtnCon.Checked ? "Còn" : "Hết";

                    errorProvider1.Clear();
                    txtTenSP.Clear();
                    cbLoaiSP.SelectedIndex = -1;
                    nudSoLuong.Value = 0;
                    rbtnCon.Checked = true;
                    txtTenSP.Focus();
                }
                else
                {
                    MessageBox.Show("Vui lòng chỉ chọn một dòng để sửa.",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSP.SelectedRows.Count != 0)
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc muốn xóa (những) dòng này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvSP.SelectedRows)
                        if (!row.IsNewRow) dgvSP.Rows.Remove(row);

                    CapNhatTongSanPham();
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
