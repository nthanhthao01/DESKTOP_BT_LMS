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
    public partial class FormDangNhapBT3 : Form
    {
        public FormDangNhapBT3()
        {
            InitializeComponent();
        }

        private List<TaiKhoan> danhSachTaiKhoan = new List<TaiKhoan>
        {
            new TaiKhoan("admin", "123", "Admin"),
            new TaiKhoan("user", "456", "User")
        };

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            errorProvider1.Clear();
            if (string.IsNullOrEmpty(tenDangNhap))
            {
                errorProvider1.SetError(txtTenDangNhap, "Vui lòng nhập tên đăng nhập.");
                return;
            }
            if (string.IsNullOrEmpty(matKhau))
            {
                errorProvider1.SetError(txtMatKhau, "Vui lòng nhập mật khẩu.");
                return;
            }

            var tk = danhSachTaiKhoan.FirstOrDefault(t =>
                t.TenDangNhap == tenDangNhap && t.MatKhau == matKhau);

            if (tk != null)
            {
                TaiKhoanHienTai.TenDangNhap = tk.TenDangNhap;
                TaiKhoanHienTai.Quyen = tk.Quyen;

                MessageBox.Show($"Đăng nhập thành công ({tk.Quyen})!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
