using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BT3
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            CapNhatThongTinNguoiDung();
            tslbForm.Text = "Form hiện tại: Màn hình chính";

            this.MdiChildActivate += FrmMain_MdiChildActivate;
            timer1.Tick += timer1_Tick; // đảm bảo timer hoạt động
            timer1.Start();
        }

        private void CapNhatThongTinNguoiDung()
        {
            if (TaiKhoanHienTai.DaDangNhap)
                tslbTenNguoiDung.Text = TaiKhoanHienTai.LayThongTinHienThi();
            else
                tslbTenNguoiDung.Text = "Người dùng: Chưa đăng nhập";
        }

        private void FrmMain_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                tslbForm.Text = $"Form hiện tại: {LayTenForm(this.ActiveMdiChild)}";
            }
            else
            {
                tslbForm.Text = "Form hiện tại: Màn hình chính";
            }
        }

        private string LayTenForm(Form form)
        {
            if (form is FormSanPham) return "Quản lý Sản phẩm";
            if (form is FormNhanVien) return "Quản lý Nhân viên";
            if (form is frmDSHoaDon) return "Danh sách Hóa đơn";
            if (form is FormDangNhapBT3) return "Đăng nhập";
            return form.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tslbTime.Text = "Thời gian: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void tsbtnSanPham_Click(object sender, EventArgs e)
        {
            if (!TaiKhoanHienTai.KiemTraDangNhap())
            {
                MessageBox.Show("Vui lòng đăng nhập trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (Form f in this.MdiChildren)
                if (f is FormSanPham) { f.Activate(); return; }

            FormSanPham spForm = new FormSanPham { MdiParent = this };
            spForm.Show();
        }

        private void tsbtnNhanVien_Click(object sender, EventArgs e)
        {
            if (!TaiKhoanHienTai.KiemTraDangNhap())
            {
                MessageBox.Show("Vui lòng đăng nhập trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (Form f in this.MdiChildren)
                if (f is FormNhanVien) { f.Activate(); return; }

            FormNhanVien nvForm = new FormNhanVien { MdiParent = this };
            nvForm.Show();
        }

        private void tsbtnHoaDon_Click(object sender, EventArgs e)
        {
            if (!TaiKhoanHienTai.KiemTraDangNhap())
            {
                MessageBox.Show("Vui lòng đăng nhập trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (Form f in this.MdiChildren)
                if (f is frmDSHoaDon) { f.Activate(); return; }

            frmDSHoaDon hdForm = new frmDSHoaDon { MdiParent = this };
            hdForm.Show();
        }

        private void tsbtnDangNhap_Click(object sender, EventArgs e)
        {
            if (TaiKhoanHienTai.DaDangNhap)
            {
                MessageBox.Show($"Bạn đã đăng nhập: {TaiKhoanHienTai.TenDangNhap}", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (FormDangNhapBT3 dnForm = new FormDangNhapBT3())
            {
                if (dnForm.ShowDialog() == DialogResult.OK)
                    CapNhatThongTinNguoiDung();
            }
        }

        private void tsbtnDangXuat_Click(object sender, EventArgs e)
        {
            if (!TaiKhoanHienTai.KiemTraDangNhap())
            {
                MessageBox.Show("Bạn chưa đăng nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TaiKhoanHienTai.DangXuat();
            CapNhatThongTinNguoiDung();

            foreach (Form f in this.MdiChildren)
                f.Close();

            tslbForm.Text = "Form hiện tại: Màn hình chính";
            MessageBox.Show("Đã đăng xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000, "Hệ thống quản lý",
                    "Ứng dụng đang chạy trong khay hệ thống", ToolTipIcon.Info);
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tstbTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                string keyword = tstbTimKiem.Text.Trim().ToLower();

                if (this.ActiveMdiChild is FormSanPham sanPhamForm)
                {
                    sanPhamForm.TimKiem(keyword);
                }
                else if (this.ActiveMdiChild is FormNhanVien nhanVienForm)
                {
                    nhanVienForm.TimKiem(keyword);
                }
                else if (this.ActiveMdiChild is frmDSHoaDon hoaDonForm)
                {
                    hoaDonForm.TimKiem(keyword);
                }
            }
        }

        private void tstbTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tstbTimKiem.Text))
            {
                if (this.ActiveMdiChild is FormNhanVien nhanVienForm)
                {
                    nhanVienForm.TimKiem("");
                }

                else if (this.ActiveMdiChild is FormSanPham sanPhamForm)
                {
                    sanPhamForm.TimKiem("");
                }
                else if (this.ActiveMdiChild is frmDSHoaDon hoaDonForm)
                {
                    hoaDonForm.TimKiem("");
                }
            }
        }

        private void tsbtnDangXuat_Click_1(object sender, EventArgs e)
        {
            if (!TaiKhoanHienTai.KiemTraDangNhap())
            {
                MessageBox.Show("Bạn chưa đăng nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn đăng xuất?\nTài khoản: {TaiKhoanHienTai.TenDangNhap}",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            TaiKhoanHienTai.DangXuat();
            CapNhatThongTinNguoiDung();

            foreach (Form f in this.MdiChildren)
                f.Close();

            if (tstbTimKiem != null)
                tstbTimKiem.Text = "";

            tslbForm.Text = "Form hiện tại: Màn hình chính";

            MessageBox.Show("Đã đăng xuất thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
