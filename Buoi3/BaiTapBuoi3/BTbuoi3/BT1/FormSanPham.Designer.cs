namespace BT3
{
    partial class FormSanPham
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Thực Phẩm");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Đồ uống");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Gia vị");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Đồ gia dụng");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Tất cả danh mục", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbCRUD = new System.Windows.Forms.GroupBox();
            this.cbDanhMuc = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.nudGia = new System.Windows.Forms.NumericUpDown();
            this.nudTonKho = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbTuyChon = new System.Windows.Forms.GroupBox();
            this.pgbMoPhongExport = new System.Windows.Forms.ProgressBar();
            this.btnMoPhongExport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.lvSP = new System.Windows.Forms.ListView();
            this.colMa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTonKho = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctmnsXemXoa = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xemChiTiếtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tvDanhMucSP = new System.Windows.Forms.TreeView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbCRUD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTonKho)).BeginInit();
            this.gbTuyChon.SuspendLayout();
            this.ctmnsXemXoa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbCRUD);
            this.splitContainer1.Panel1.Controls.Add(this.gbTuyChon);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvSP);
            this.splitContainer1.Panel2.Controls.Add(this.tvDanhMucSP);
            this.splitContainer1.Size = new System.Drawing.Size(1033, 496);
            this.splitContainer1.SplitterDistance = 409;
            this.splitContainer1.TabIndex = 0;
            // 
            // gbCRUD
            // 
            this.gbCRUD.Controls.Add(this.cbDanhMuc);
            this.gbCRUD.Controls.Add(this.label4);
            this.gbCRUD.Controls.Add(this.btnSua);
            this.gbCRUD.Controls.Add(this.btnXoa);
            this.gbCRUD.Controls.Add(this.btnThem);
            this.gbCRUD.Controls.Add(this.nudGia);
            this.gbCRUD.Controls.Add(this.nudTonKho);
            this.gbCRUD.Controls.Add(this.label3);
            this.gbCRUD.Controls.Add(this.label2);
            this.gbCRUD.Controls.Add(this.txtTenSP);
            this.gbCRUD.Controls.Add(this.label1);
            this.gbCRUD.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCRUD.Location = new System.Drawing.Point(0, 0);
            this.gbCRUD.Name = "gbCRUD";
            this.gbCRUD.Size = new System.Drawing.Size(409, 317);
            this.gbCRUD.TabIndex = 2;
            this.gbCRUD.TabStop = false;
            this.gbCRUD.Text = "CRUDSanPham";
            // 
            // cbDanhMuc
            // 
            this.cbDanhMuc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbDanhMuc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDanhMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDanhMuc.FormattingEnabled = true;
            this.cbDanhMuc.Items.AddRange(new object[] {
            "Thực phẩm",
            "Đồ uống",
            "Gia vị",
            "Đồ gia dụng"});
            this.cbDanhMuc.Location = new System.Drawing.Point(167, 82);
            this.cbDanhMuc.Name = "cbDanhMuc";
            this.cbDanhMuc.Size = new System.Drawing.Size(221, 33);
            this.cbDanhMuc.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Danh mục: ";
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(298, 256);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 35);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(150, 256);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 35);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(13, 256);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 35);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // nudGia
            // 
            this.nudGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudGia.Location = new System.Drawing.Point(167, 138);
            this.nudGia.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudGia.Name = "nudGia";
            this.nudGia.Size = new System.Drawing.Size(221, 30);
            this.nudGia.TabIndex = 5;
            // 
            // nudTonKho
            // 
            this.nudTonKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTonKho.Location = new System.Drawing.Point(167, 185);
            this.nudTonKho.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTonKho.Name = "nudTonKho";
            this.nudTonKho.Size = new System.Drawing.Size(221, 30);
            this.nudTonKho.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tồn kho: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Giá: ";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSP.Location = new System.Drawing.Point(167, 29);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(221, 30);
            this.txtTenSP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên sản phẩm: ";
            // 
            // gbTuyChon
            // 
            this.gbTuyChon.Controls.Add(this.pgbMoPhongExport);
            this.gbTuyChon.Controls.Add(this.btnMoPhongExport);
            this.gbTuyChon.Controls.Add(this.btnExport);
            this.gbTuyChon.Controls.Add(this.btnImport);
            this.gbTuyChon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbTuyChon.Location = new System.Drawing.Point(0, 323);
            this.gbTuyChon.Name = "gbTuyChon";
            this.gbTuyChon.Size = new System.Drawing.Size(409, 173);
            this.gbTuyChon.TabIndex = 1;
            this.gbTuyChon.TabStop = false;
            this.gbTuyChon.Text = "Tùy chọn";
            // 
            // pgbMoPhongExport
            // 
            this.pgbMoPhongExport.Location = new System.Drawing.Point(13, 132);
            this.pgbMoPhongExport.Name = "pgbMoPhongExport";
            this.pgbMoPhongExport.Size = new System.Drawing.Size(376, 23);
            this.pgbMoPhongExport.TabIndex = 3;
            // 
            // btnMoPhongExport
            // 
            this.btnMoPhongExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoPhongExport.Location = new System.Drawing.Point(13, 78);
            this.btnMoPhongExport.Name = "btnMoPhongExport";
            this.btnMoPhongExport.Size = new System.Drawing.Size(376, 41);
            this.btnMoPhongExport.TabIndex = 2;
            this.btnMoPhongExport.Text = "Mô phỏng Export";
            this.btnMoPhongExport.UseVisualStyleBackColor = true;
            this.btnMoPhongExport.Click += new System.EventHandler(this.btnMoPhongExport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(218, 25);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(171, 47);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(13, 25);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(186, 47);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lvSP
            // 
            this.lvSP.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMa,
            this.colTen,
            this.colGia,
            this.colTonKho});
            this.lvSP.ContextMenuStrip = this.ctmnsXemXoa;
            this.lvSP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvSP.FullRowSelect = true;
            this.lvSP.HideSelection = false;
            this.lvSP.Location = new System.Drawing.Point(0, 202);
            this.lvSP.Name = "lvSP";
            this.lvSP.Size = new System.Drawing.Size(620, 294);
            this.lvSP.TabIndex = 0;
            this.lvSP.UseCompatibleStateImageBehavior = false;
            this.lvSP.View = System.Windows.Forms.View.Details;
            // 
            // colMa
            // 
            this.colMa.Text = "Mã";
            this.colMa.Width = 100;
            // 
            // colTen
            // 
            this.colTen.Text = "Tên";
            this.colTen.Width = 120;
            // 
            // colGia
            // 
            this.colGia.Text = "Giá";
            this.colGia.Width = 100;
            // 
            // colTonKho
            // 
            this.colTonKho.Text = "Tồn kho";
            this.colTonKho.Width = 100;
            // 
            // ctmnsXemXoa
            // 
            this.ctmnsXemXoa.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctmnsXemXoa.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xemChiTiếtToolStripMenuItem,
            this.xóaSảnPhẩmToolStripMenuItem});
            this.ctmnsXemXoa.Name = "ctmnsXemXoa";
            this.ctmnsXemXoa.Size = new System.Drawing.Size(173, 52);
            // 
            // xemChiTiếtToolStripMenuItem
            // 
            this.xemChiTiếtToolStripMenuItem.Name = "xemChiTiếtToolStripMenuItem";
            this.xemChiTiếtToolStripMenuItem.Size = new System.Drawing.Size(172, 24);
            this.xemChiTiếtToolStripMenuItem.Text = "Xem chi tiết";
            this.xemChiTiếtToolStripMenuItem.Click += new System.EventHandler(this.xemChiTiếtToolStripMenuItem_Click);
            // 
            // xóaSảnPhẩmToolStripMenuItem
            // 
            this.xóaSảnPhẩmToolStripMenuItem.Name = "xóaSảnPhẩmToolStripMenuItem";
            this.xóaSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(172, 24);
            this.xóaSảnPhẩmToolStripMenuItem.Text = "Xóa sản phẩm";
            this.xóaSảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.xóaSảnPhẩmToolStripMenuItem_Click);
            // 
            // tvDanhMucSP
            // 
            this.tvDanhMucSP.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.tvDanhMucSP.Dock = System.Windows.Forms.DockStyle.Top;
            this.tvDanhMucSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvDanhMucSP.Location = new System.Drawing.Point(0, 0);
            this.tvDanhMucSP.Name = "tvDanhMucSP";
            treeNode1.Name = "ThucPham";
            treeNode1.Tag = "Thực phẩm";
            treeNode1.Text = "Thực Phẩm";
            treeNode2.Name = "DoUong";
            treeNode2.Tag = "Đồ uống";
            treeNode2.Text = "Đồ uống";
            treeNode3.Name = "GiaVi";
            treeNode3.Tag = "Gia vị";
            treeNode3.Text = "Gia vị";
            treeNode4.Name = "DoGiaDung";
            treeNode4.Tag = "Đồ gia dụng";
            treeNode4.Text = "Đồ gia dụng";
            treeNode5.Name = "TatCaDanhMuc";
            treeNode5.Tag = "Tất cả danh mục";
            treeNode5.Text = "Tất cả danh mục";
            this.tvDanhMucSP.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.tvDanhMucSP.Size = new System.Drawing.Size(620, 196);
            this.tvDanhMucSP.TabIndex = 0;
            this.tvDanhMucSP.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDanhMucSP_AfterSelect);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 496);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormSanPham";
            this.Text = "FormQuanLySanPham";
            this.Load += new System.EventHandler(this.FormSanPham_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbCRUD.ResumeLayout(false);
            this.gbCRUD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTonKho)).EndInit();
            this.gbTuyChon.ResumeLayout(false);
            this.ctmnsXemXoa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvDanhMucSP;
        private System.Windows.Forms.ListView lvSP;
        private System.Windows.Forms.GroupBox gbTuyChon;
        private System.Windows.Forms.ColumnHeader colMa;
        private System.Windows.Forms.ColumnHeader colTen;
        private System.Windows.Forms.ColumnHeader colGia;
        private System.Windows.Forms.ColumnHeader colTonKho;
        private System.Windows.Forms.ContextMenuStrip ctmnsXemXoa;
        private System.Windows.Forms.ToolStripMenuItem xemChiTiếtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.Button btnMoPhongExport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ProgressBar pgbMoPhongExport;
        private System.Windows.Forms.GroupBox gbCRUD;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.NumericUpDown nudGia;
        private System.Windows.Forms.NumericUpDown nudTonKho;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.ComboBox cbDanhMuc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}