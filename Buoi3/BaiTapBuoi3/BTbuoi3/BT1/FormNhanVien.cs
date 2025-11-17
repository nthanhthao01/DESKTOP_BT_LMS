using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT3
{
    public partial class FormNhanVien : Form
    {
        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            if (TaiKhoanHienTai.Quyen == "User")
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool hasError = false;

            string hoTen = txtHoTenNV.Text.Trim();
            string gioiTinh = rbtnNam.Checked ? "Nam" : (rbtnNu.Checked ? "Nữ" : "");
            string chucVu = txtChucVu.SelectedItem != null ? txtChucVu.SelectedItem.ToString() : "";
            string sdt = txtSDT.Text.Trim();

            if (string.IsNullOrEmpty(hoTen))
            {
                errorProvider1.SetError(txtHoTenNV, "Vui lòng nhập họ tên nhân viên!");
                hasError = true;
            }

            if (string.IsNullOrEmpty(gioiTinh))
            {
                errorProvider1.SetError(rbtnNam, "Vui lòng chọn giới tính!");
                hasError = true;
            }

            if (string.IsNullOrEmpty(chucVu))
            {
                errorProvider1.SetError(txtChucVu, "Vui lòng chọn chức vụ!");
                hasError = true;
            }

            if (string.IsNullOrEmpty(sdt))
            {
                errorProvider1.SetError(txtSDT, "Vui lòng nhập số điện thoại!");
                hasError = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^(0\d{9,10})$"))
            {
                errorProvider1.SetError(txtSDT, "Số điện thoại không hợp lệ!");
                hasError = true;
            }

            if (hasError)
                return;

            dgvDSNV.Rows.Add(hoTen, gioiTinh, chucVu, sdt);

            LamMoiForm();

            MessageBox.Show("Thêm nhân viên thành công!", 
                            "Thông báo", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDSNV.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc muốn xóa nhân viên đã chọn?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvDSNV.SelectedRows)
                    {
                        dgvDSNV.Rows.Remove(row);
                    }
                    MessageBox.Show("Đã xóa nhân viên thành công!", 
                                    "Thông báo", 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa!", 
                                "Thông báo", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool hasError = false;

            if (dgvDSNV.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hoTen = txtHoTenNV.Text.Trim();
            string gioiTinh = rbtnNam.Checked ? "Nam" : (rbtnNu.Checked ? "Nữ" : "");
            string chucVu = txtChucVu.SelectedItem != null ? txtChucVu.SelectedItem.ToString() : "";
            string sdt = txtSDT.Text.Trim();

            if (string.IsNullOrEmpty(hoTen))
            {
                errorProvider1.SetError(txtHoTenNV, "Vui lòng nhập họ tên nhân viên!");
                hasError = true;
            }

            if (string.IsNullOrEmpty(gioiTinh))
            {
                errorProvider1.SetError(rbtnNam, "Vui lòng chọn giới tính!");
                hasError = true;
            }

            if (string.IsNullOrEmpty(chucVu))
            {
                errorProvider1.SetError(txtChucVu, "Vui lòng chọn chức vụ!");
                hasError = true;
            }

            if (string.IsNullOrEmpty(sdt))
            {
                errorProvider1.SetError(txtSDT, "Vui lòng nhập số điện thoại!");
                hasError = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^(0\d{9,10})$"))
            {
                errorProvider1.SetError(txtSDT, "Số điện thoại không hợp lệ!");
                hasError = true;
            }

            if (hasError)
                return;

            int rowIndex = dgvDSNV.CurrentRow.Index;

            dgvDSNV.Rows[rowIndex].Cells[0].Value = hoTen;
            dgvDSNV.Rows[rowIndex].Cells[1].Value = gioiTinh;
            dgvDSNV.Rows[rowIndex].Cells[2].Value = chucVu;
            dgvDSNV.Rows[rowIndex].Cells[3].Value = sdt;

            MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LamMoiForm();
        }

        private void LamMoiForm()
        {
            txtHoTenNV.Clear();
            txtSDT.Clear();
            txtChucVu.SelectedIndex = -1;
            rbtnNam.Checked = false;
            rbtnNu.Checked = false;
        }
        public void TimKiem(string keyword)
        {
            foreach (DataGridViewRow row in dgvDSNV.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    row.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                    row.DefaultCellStyle.SelectionForeColor = Color.White;
                }
            }

            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvDSNV.ClearSelection();
                return;
            }

            keyword = keyword.ToLower();
            List<int> matchedRows = new List<int>();

            foreach (DataGridViewRow row in dgvDSNV.Rows)
            {
                if (row.IsNewRow) continue;

                string rowData = string.Join(" ", row.Cells
                    .Cast<DataGridViewCell>()
                    .Select(c => c.Value?.ToString().ToLower() ?? ""));

                if (rowData.Contains(keyword))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 200); 
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    row.DefaultCellStyle.SelectionBackColor = Color.Orange;
                    row.DefaultCellStyle.SelectionForeColor = Color.White;

                    matchedRows.Add(row.Index);
                }
            }

            if (matchedRows.Count > 0)
            {
                dgvDSNV.ClearSelection();
                dgvDSNV.CurrentCell = dgvDSNV.Rows[matchedRows[0]].Cells[0];
                dgvDSNV.FirstDisplayedScrollingRowIndex = matchedRows[0];

                foreach (int index in matchedRows)
                {
                    dgvDSNV.Rows[index].Selected = true;
                }
            }

            if (matchedRows.Count == 0)
            {
                MessageBox.Show($"Không tìm thấy nhân viên nào!",
                                "Kết quả tìm kiếm",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }
    }  
}
