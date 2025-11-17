using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT3
{
    public partial class frmDSHoaDon : Form
    {
        public frmDSHoaDon()
        {
            InitializeComponent();

            if (FormSanPham.DanhSachSanPhamChung.Count == 0)
            {
                new FormSanPham();
            }

            cbDanhMucSP.DataSource = FormSanPham.DanhSachSanPhamChung.Keys.ToList();

        }

        private List<SanPham> sanPhamChon = new List<SanPham>();
        private DateTime ngayIn;
        private List<HoaDon> danhSachHoaDon = new List<HoaDon>();

        private HoaDon currentHoaDon;

        private void frmDSHoaDon_Load(object sender, EventArgs e)
        {
            if (TaiKhoanHienTai.Quyen == "User")
            {
                btnTaoHoaDon.Enabled = false;
                button2.Enabled = false;
            }

            cbDanhMucSP.DataSource = FormSanPham.DanhSachSanPhamChung.Keys.ToList();

            cbDanhMucSP.SelectedIndexChanged += cbDanhMucSP_SelectedIndexChanged;


            if (cbDanhMucSP.Items.Count > 0)
            {
                cbDanhMucSP.SelectedIndex = 0;
            }
        }

        private void cbDanhMucSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string danhMucChon = cbDanhMucSP.SelectedItem?.ToString();
            clbSP.Items.Clear();

            if (!string.IsNullOrEmpty(danhMucChon) && FormSanPham.DanhSachSanPhamChung.ContainsKey(danhMucChon))
            {
                var dsSP = FormSanPham.DanhSachSanPhamChung[danhMucChon];

                foreach (var sp in dsSP)
                {
                    clbSP.Items.Add($"{sp.TenSP}");
                }
            }
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            string tenKhachHang = txtTenKH.Text.Trim();
            if (string.IsNullOrEmpty(tenKhachHang))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!");
                return;
            }

            string danhMucChon = cbDanhMucSP.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(danhMucChon))
            {
                MessageBox.Show("Vui lòng chọn danh mục sản phẩm!");
                return;
            }

            sanPhamChon.Clear();
            foreach (var item in clbSP.CheckedItems)
            {
                string tenSP = item.ToString();
                var sp = FormSanPham.DanhSachSanPhamChung[danhMucChon]
                    .FirstOrDefault(x => x.TenSP == tenSP);

                if (sp != null)
                    sanPhamChon.Add(sp);
            }

            if (sanPhamChon.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm!");
                return;
            }

            decimal tongTien = sanPhamChon.Sum(sp => sp.Gia);
            ngayIn = DateTime.Now;
            string maHD = $"HD{(danhSachHoaDon.Count + 1).ToString("D3")}";

            HoaDon hd = new HoaDon
            {
                MaHD = maHD,
                TenKH = tenKhachHang,
                DanhSachSP = sanPhamChon.Select(sp => sp.TenSP).ToList(),
                TongTien = tongTien,
                NgayIn = ngayIn
            };

            danhSachHoaDon.Add(hd);
            currentHoaDon = hd;
            dgvHoaDon.Rows.Add(hd.MaHD, hd.TenKH,
                string.Join(", ", hd.DanhSachSP),
                hd.TongTien.ToString("N0"),
                hd.NgayIn.ToString("dd/MM/yyyy HH:mm"));

            MessageBox.Show("Tạo hóa đơn thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần in!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                previewDialog.Document = printDocument1;
                previewDialog.Width = 900;
                previewDialog.Height = 700;
                previewDialog.Text = "Xem trước hóa đơn";

                DialogResult result = previewDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    printDocument1.Print();
                    MessageBox.Show("In hóa đơn thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi in: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
                return;

            DataGridViewRow row = dgvHoaDon.SelectedRows[0];

            string maHD = row.Cells[0].Value?.ToString() ?? "";
            string tenKH = row.Cells[1].Value?.ToString() ?? "";
            string sanPham = row.Cells[2].Value?.ToString() ?? "";
            string tongTien = row.Cells[3].Value?.ToString() ?? "0";

            Graphics g = e.Graphics;
            Font fontTitle = new Font("Arial", 20, FontStyle.Bold);
            Font fontHeader = new Font("Arial", 12, FontStyle.Bold);
            Font fontContent = new Font("Arial", 10);
            Font fontSmall = new Font("Arial", 9);

            int y = 50;
            int x = 50;

            g.DrawString("HÓA ĐƠN BÁN HÀNG", fontTitle, Brushes.Black, 250, y);
            y += 50;

            g.DrawString($"Mã HĐ: {maHD}", fontHeader, Brushes.Black, x, y);
            y += 30;
            g.DrawString($"Khách hàng: {tenKH}", fontContent, Brushes.Black, x, y);
            y += 25;
            g.DrawString($"Sản phẩm: {sanPham}", fontContent, Brushes.Black, x, y);
            y += 25;
            g.DrawString($"Ngày: {DateTime.Now:dd/MM/yyyy HH:mm}", fontContent, Brushes.Black, x, y);
            y += 40;

            g.DrawLine(Pens.Black, x, y, 750, y);
            y += 30;

            g.DrawString($"TỔNG TIỀN: {tongTien} VNĐ", fontHeader, Brushes.Black, x + 400, y);
            y += 60;

            g.DrawString("Cảm ơn quý khách!", fontContent, Brushes.Black, 300, y);
        }

        public void TimKiem(string keyword)
        {
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
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
                dgvHoaDon.ClearSelection();
                return;
            }

            keyword = keyword.ToLower();
            List<int> matchedRows = new List<int>();

            foreach (DataGridViewRow row in dgvHoaDon.Rows)
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
                dgvHoaDon.ClearSelection();
                dgvHoaDon.CurrentCell = dgvHoaDon.Rows[matchedRows[0]].Cells[0];
                dgvHoaDon.FirstDisplayedScrollingRowIndex = matchedRows[0];

                foreach (int index in matchedRows)
                {
                    dgvHoaDon.Rows[index].Selected = true;
                }
            }

            if (matchedRows.Count == 0)
            {
                MessageBox.Show($"Không tìm thấy hóa đơn nào!",
                                "Kết quả tìm kiếm",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Đã highlight {matchedRows.Count} hóa đơn!",
                                "Kết quả tìm kiếm",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }
    }
}