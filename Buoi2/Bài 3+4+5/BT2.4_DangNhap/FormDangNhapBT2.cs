using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BT2._3;

namespace BT2._4_DangNhap
{
    public partial class FormDangNhapBT2 : Form
    {
        public FormDangNhapBT2()
        {
            InitializeComponent();

            toolTip1.SetToolTip(lbUser, "Tài khoản mặc định: admin");
            toolTip1.SetToolTip(lbPass, "Mật khẩu mặc định: 123");

            txtPass.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            string txtUser = this.txtUser.Text.Trim();
            string txtPass = this.txtPass.Text.Trim();
            bool hasError = false;


            if (string.IsNullOrEmpty(txtUser))
            {
                errorProvider1.SetError(this.txtUser, "Vui lòng nhập tài khoản!");
                hasError = true;
            }

            if (string.IsNullOrEmpty(txtPass))
            {
                errorProvider1.SetError(this.txtPass, "Vui lòng nhập mật khẩu!");
                hasError = true;
            }

            if (hasError)
            {
                return;
            }

            if (txtUser == "admin" && txtPass == "123")
            {
                MessageBox.Show("Đăng nhập thành công!", 
                                "Thông báo", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);

                FormDangKySP formDangKySP = new FormDangKySP();
                formDangKySP.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", 
                                "Lỗi", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
            }
            
        }
    }
}
