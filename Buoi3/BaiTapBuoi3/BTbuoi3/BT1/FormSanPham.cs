using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT3
{
    public partial class FormSanPham : Form
    {
        public static Dictionary<string, List<SanPham>> DanhSachSanPhamChung = new Dictionary<string, List<SanPham>>();

        private Dictionary<string, List<SanPham>> danhSachSanPham;

        public FormSanPham()
        {
            InitializeComponent();
            LoadDuLieuMau();
            DanhSachSanPhamChung = danhSachSanPham;
        }

        private void FormSanPham_Load(object sender, EventArgs e)
        {
            if (TaiKhoanHienTai.Quyen == "User")
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                btnImport.Enabled = false;
                btnExport.Enabled = false;
                btnMoPhongExport.Enabled = false;
            }
        }

        private void LoadDuLieuMau()
        {
            danhSachSanPham = new Dictionary<string, List<SanPham>>();


            danhSachSanPham["Thực phẩm"] = new List<SanPham>
            {
                new SanPham("TP001", "Gạo ST25", "Thực phẩm", 25000, 500),
                new SanPham("TP002", "Thịt heo", "Thực phẩm", 95000, 200),
                new SanPham("TP003", "Cá hồi", "Thực phẩm", 350000, 50),
                new SanPham("TP004", "Tôm sú", "Thực phẩm", 280000, 80)
            };

            danhSachSanPham["Đồ uống"] = new List<SanPham>
            {
                new SanPham("DU001", "Coca Cola", "Đồ uống", 10000, 1000),
                new SanPham("DU002", "Pepsi", "Đồ uống", 10000, 800),
                new SanPham("DU003", "Nước suối Lavie", "Đồ uống", 5000, 2000),
                new SanPham("DU004", "Trà xanh C2", "Đồ uống", 8000, 500)
            };


            danhSachSanPham["Gia vị"] = new List<SanPham>
            {
                new SanPham("GV001", "Muối iod", "Gia vị", 8000, 300),
                new SanPham("GV002", "Đường trắng", "Gia vị", 20000, 250),
                new SanPham("GV003", "Nước mắm Nam Ngư", "Gia vị", 35000, 150),
                new SanPham("GV004", "Tiêu đen", "Gia vị", 45000, 100)
            };

            danhSachSanPham["Đồ gia dụng"] = new List<SanPham>
            {
                new SanPham("GD001", "Bát sứ", "Đồ gia dụng", 25000, 400),
                new SanPham("GD002", "Đũa gỗ", "Đồ gia dụng", 15000, 600),
                new SanPham("GD003", "Nồi cơm điện", "Đồ gia dụng", 850000, 50),
                new SanPham("GD004", "Chảo chống dính", "Đồ gia dụng", 350000, 80)
            };
        }

        private void AddProductToListView(SanPham sp)
        {
            ListViewItem item = new ListViewItem(sp.MaSP);
            item.SubItems.Add(sp.TenSP);
            item.SubItems.Add(sp.Gia.ToString("N0"));
            item.SubItems.Add(sp.TonKho.ToString());
            item.Tag = sp;
            lvSP.Items.Add(item);
        }


        private void tvDanhMucSP_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lvSP.Items.Clear();

            if (danhSachSanPham == null)
                return;

            if (e.Node.Tag != null)
            {
                string danhMuc = e.Node.Tag.ToString();
                if (danhSachSanPham.ContainsKey(danhMuc))
                {
                    foreach (SanPham sp in danhSachSanPham[danhMuc])
                    {
                        ListViewItem item = new ListViewItem(sp.MaSP);
                        item.SubItems.Add(sp.TenSP);
                        item.SubItems.Add(sp.Gia.ToString("N0"));
                        item.SubItems.Add(sp.TonKho.ToString());
                        item.Tag = sp;
                        lvSP.Items.Add(item);
                    }
                }
                else if (e.Node.Text == "Tất cả danh mục")
                {
                    foreach (var danhMucSP in danhSachSanPham)
                    {
                        foreach (SanPham sp in danhMucSP.Value)
                        {
                            AddProductToListView(sp);
                        }
                    }
                }
            }
        }

        private void xemChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvSP.SelectedItems.Count > 0)
            {
                SanPham sp = (SanPham)lvSP.SelectedItems[0].Tag;

                string thongTin = $"THÔNG TIN CHI TIẾT SẢN PHẨM\n\n" +
                                $"Mã sản phẩm: {sp.MaSP}\n" +
                                $"Tên sản phẩm: {sp.TenSP}\n" +
                                $"Giá: {sp.Gia:N0} VNĐ\n" +
                                $"Tồn kho: {sp.TonKho} sản phẩm\n" +
                                $"Tổng giá trị: {(sp.Gia * sp.TonKho):N0} VNĐ";

                MessageBox.Show(thongTin, "Chi tiết sản phẩm",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void xóaSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvSP.SelectedItems.Count > 0)
            {
                SanPham sp = (SanPham)lvSP.SelectedItems[0].Tag;

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc muốn xóa sản phẩm '{sp.TenSP}'?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    lvSP.Items.Remove(lvSP.SelectedItems[0]);

                    foreach (var danhMuc in danhSachSanPham.Values)
                    {
                        danhMuc.RemoveAll(x => x.MaSP == sp.MaSP);
                    }

                    MessageBox.Show("Đã xóa sản phẩm thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            openFile.Title = "Chọn file CSV để import";
            openFile.ShowDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            saveFile.Title = "Chọn vị trí để lưu file CSV";
            saveFile.ShowDialog();

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = saveFile.FileName;
                    ExportToCSV(filePath);

                    MessageBox.Show($"Export thành công!\nFile đã được lưu tại:\n{filePath}",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    System.Diagnostics.Process.Start("explorer.exe",
                        $"/select,\"{filePath}\"");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi export file:\n{ex.Message}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExportToCSV(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                sw.WriteLine("Mã SP,Tên Sản Phẩm,Giá,Tồn Kho,Doanh Thu");

                decimal tongDoanhThu = 0;

                foreach (ListViewItem item in lvSP.Items)
                {
                    SanPham sp = (SanPham)item.Tag;
                    decimal doanhThu = sp.Gia * sp.TonKho;
                    tongDoanhThu += doanhThu;

                    sw.WriteLine($"{sp.MaSP},{sp.TenSP},{sp.Gia},{sp.TonKho},{doanhThu}");
                }

                sw.WriteLine();
                sw.WriteLine($"TỔNG DOANH THU:,,,,{tongDoanhThu}");
            }
        }

        private async void btnMoPhongExport_Click(object sender, EventArgs e)
        {
            int totalProducts = lvSP.Items.Count;

            btnMoPhongExport.Enabled = false;
            btnImport.Enabled = false;
            btnExport.Enabled = false;

            pgbMoPhongExport.Value = 0;
            pgbMoPhongExport.Maximum = totalProducts;

            try
            {
                string tempFile = Path.Combine(Path.GetTempPath(),
                    $"MoPhongExport_{DateTime.Now:yyyyMMdd_HHmmss}.csv");

                using (StreamWriter sw = new StreamWriter(tempFile, false, Encoding.UTF8))
                {
                    sw.WriteLine("Mã SP,Tên Sản Phẩm,Giá,Tồn Kho,Doanh Thu");

                    int currentProduct = 0;

                    foreach (ListViewItem item in lvSP.Items)
                    {
                        currentProduct++;
                        SanPham sp = (SanPham)item.Tag;

                        decimal doanhThu = sp.Gia * sp.TonKho;
                        sw.WriteLine($"{sp.MaSP},{sp.TenSP},{sp.Gia},{sp.TonKho},{doanhThu}");

                        pgbMoPhongExport.Value = currentProduct;

                        int percent = (currentProduct * 100) / totalProducts;
                        this.Text = $"Quản lý Sản phẩm - Đang export: {percent}%";

                        await Task.Delay(1000);
                    }
                }

                pgbMoPhongExport.Value = totalProducts;
                this.Text = "Quản lý Sản phẩm";

                MessageBox.Show($"Mô phỏng export hoàn tất!\n" +
                              $"Tổng số sản phẩm: {totalProducts}\n" +
                              $"File tạm: {tempFile}",
                    "Hoàn thành", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnMoPhongExport.Enabled = true;
                btnImport.Enabled = true;
                btnExport.Enabled = true;

                pgbMoPhongExport.Value = 0;
                this.Text = "Quản lý Sản phẩm";
            }
        }

        private void CapNhatListView()
        {
            lvSP.Items.Clear();

            foreach (var danhMuc in danhSachSanPham)
            {
                foreach (SanPham sp in danhMuc.Value)
                {
                    ListViewItem item = new ListViewItem(sp.MaSP);
                    item.SubItems.Add(sp.TenSP);
                    item.SubItems.Add(danhMuc.Key);
                    item.SubItems.Add(sp.Gia.ToString("N0"));
                    item.SubItems.Add(sp.TonKho.ToString());
                    item.Tag = sp;
                    lvSP.Items.Add(item);
                }
            }
        }

        string TaoMaSanPham(string danhMuc)
        {
            string prefix = "";
            switch (danhMuc)
            {
                case "Thực phẩm": prefix = "TP"; break;
                case "Đồ uống": prefix = "DU"; break;
                case "Gia vị": prefix = "GV"; break;
                case "Đồ gia dụng": prefix = "DG"; break;
            }

            int count = danhSachSanPham
                .SelectMany(pair => pair.Value)
                .Count(sp => sp.MaSP.StartsWith(prefix));

            return prefix + (count + 1).ToString("000");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ten = txtTenSP.Text.Trim();
            string danhMuc = cbDanhMuc.SelectedItem?.ToString();
            decimal gia = nudGia.Value;
            int ton = (int)nudTonKho.Value;

            bool hasError = false;

            if (string.IsNullOrEmpty(ten))
            {
                errorProvider1.SetError(txtTenSP, "Vui lòng nhập tên sản phẩm!");
                hasError = true;
            }

            if (string.IsNullOrEmpty(danhMuc))
            {
                errorProvider1.SetError(cbDanhMuc, "Vui lòng chọn danh mục!");
                hasError = true;
            }

            if (gia <= 0)
            {
                errorProvider1.SetError(nudGia, "Giá phải lớn hơn 0!");
                hasError = true;
            }

            if (ton < 0)
            {
                errorProvider1.SetError(nudTonKho, "Tồn kho không được âm!");
                hasError = true;
            }

            if (hasError) return;

            string ma = TaoMaSanPham(danhMuc);

            // Tạo sản phẩm và thêm vào danh sách
            SanPham sp = new SanPham(ma, ten, danhMuc, gia, ton);
            if (!danhSachSanPham.ContainsKey(danhMuc))
            {
                danhSachSanPham[danhMuc] = new List<SanPham>();
            }
            danhSachSanPham[danhMuc].Add(sp);
            CapNhatListView();
            LamMoi();
        }

        private void LamMoi()
        {
            txtTenSP.Clear();
            cbDanhMuc.SelectedIndex = -1;
            nudGia.Value = 0;
            nudTonKho.Value = 0;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvSP.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm để xóa!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa {lvSP.SelectedItems.Count} sản phẩm đã chọn?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                foreach (ListViewItem item in lvSP.SelectedItems)
                {
                    SanPham sp = (SanPham)item.Tag;
                    if (sp != null && danhSachSanPham.ContainsKey(sp.DanhMuc))
                    {
                        danhSachSanPham[sp.DanhMuc].Remove(sp);
                    }
                    lvSP.Items.Remove(item);
                }

                MessageBox.Show("Đã xóa sản phẩm thành công!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (lvSP.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để sửa!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lvSP.SelectedItems.Count > 1)
            {
                MessageBox.Show("Chỉ được phép sửa một sản phẩm tại một thời điểm!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenSP = txtTenSP.Text.Trim();
            string danhMucMoi = cbDanhMuc.SelectedItem?.ToString();
            decimal gia = nudGia.Value;
            int tonKho = (int)nudTonKho.Value;
            bool hasError = false;

            if (string.IsNullOrEmpty(tenSP))
            {
                errorProvider1.SetError(txtTenSP, "Vui lòng nhập tên sản phẩm!");
                hasError = true;
            }

            if (string.IsNullOrEmpty(danhMucMoi))
            {
                errorProvider1.SetError(cbDanhMuc, "Vui lòng chọn danh mục!");
                hasError = true;
            }

            if (gia < 0)
            {
                errorProvider1.SetError(nudGia, "Giá phải là số dương!");
                hasError = true;
            }

            if (hasError) return;

            ListViewItem item = lvSP.SelectedItems[0];
            SanPham sp = (SanPham)item.Tag;
            if (sp == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm tương ứng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string danhMucCu = sp.DanhMuc;

            if (!string.Equals(danhMucCu, danhMucMoi, StringComparison.Ordinal))
            {
                if (danhSachSanPham.ContainsKey(danhMucCu))
                {
                    danhSachSanPham[danhMucCu].Remove(sp);
                }

                string maMoi = TaoMaSanPham(danhMucMoi);

                sp.MaSP = maMoi;
                sp.DanhMuc = danhMucMoi;
                sp.TenSP = tenSP;
                sp.Gia = gia;
                sp.TonKho = tonKho;

                if (!danhSachSanPham.ContainsKey(danhMucMoi))
                    danhSachSanPham[danhMucMoi] = new List<SanPham>();

                danhSachSanPham[danhMucMoi].Add(sp);

                CapNhatListView();

                MessageBox.Show("Cập nhật sản phẩm thành công (đổi danh mục và mã mới)!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sp.TenSP = tenSP;
                sp.Gia = gia;
                sp.TonKho = tonKho;

                while (item.SubItems.Count < 5)
                    item.SubItems.Add("");

                item.SubItems[1].Text = tenSP;
                item.SubItems[2].Text = danhMucMoi; 
                item.SubItems[3].Text = gia.ToString("N0");
                item.SubItems[4].Text = tonKho.ToString();

                MessageBox.Show("Cập nhật sản phẩm thành công!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        public void TimKiem(string keyword)
        {
            foreach (ListViewItem item in lvSP.Items)
            {
                item.BackColor = Color.White;
                item.ForeColor = Color.Black;
            }

            if (string.IsNullOrWhiteSpace(keyword))
            {
                lvSP.SelectedItems.Clear();
                tvDanhMucSP.SelectedNode = null;
                return;
            }

            keyword = keyword.ToLower();
            List<ListViewItem> matchedItems = new List<ListViewItem>();
            TreeNode matchedNode = null;

            foreach (TreeNode parentNode in tvDanhMucSP.Nodes)
            {
                if (parentNode.Text.ToLower().Contains(keyword))
                {
                    matchedNode = parentNode;
                    break;
                }

                foreach (TreeNode childNode in parentNode.Nodes)
                {
                    if (childNode.Text.ToLower().Contains(keyword))
                    {
                        matchedNode = childNode;
                        break;
                    }
                }

                if (matchedNode != null) break;
            }

            if (matchedNode != null)
            {
                tvDanhMucSP.SelectedNode = matchedNode;
                tvDanhMucSP.Focus();

                tvDanhMucSP_AfterSelect(tvDanhMucSP, new TreeViewEventArgs(matchedNode));
                return;
            }

            foreach (ListViewItem item in lvSP.Items)
            {
                bool isMatch = false;

                if (item.Text.ToLower().Contains(keyword))
                    isMatch = true;

                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    if (subItem.Text.ToLower().Contains(keyword))
                    {
                        isMatch = true;
                        break;
                    }
                }

                if (isMatch)
                {
                    item.BackColor = Color.FromArgb(255, 255, 200);
                    item.ForeColor = Color.Black;
                    matchedItems.Add(item);
                }
            }

            if (matchedItems.Count > 0)
            {
                lvSP.SelectedItems.Clear();
                matchedItems[0].Selected = true;
                matchedItems[0].EnsureVisible();
                lvSP.Focus();

                MessageBox.Show($"Đã tìm thấy {matchedItems.Count} sản phẩm!",
                                "Kết quả tìm kiếm",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Không tìm thấy kết quả nào!",
                                "Kết quả tìm kiếm",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }
    }
}
