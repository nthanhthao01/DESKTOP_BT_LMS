namespace BT3
{
    partial class frmDSHoaDon
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button2 = new System.Windows.Forms.Button();
            this.btnTaoHoaDon = new System.Windows.Forms.Button();
            this.gbDSSP = new System.Windows.Forms.GroupBox();
            this.clbSP = new System.Windows.Forms.CheckedListBox();
            this.lbSP = new System.Windows.Forms.Label();
            this.lbDanhMucSP = new System.Windows.Forms.Label();
            this.cbDanhMucSP = new System.Windows.Forms.ComboBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.lbTenKH = new System.Windows.Forms.Label();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.colMaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2TenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbDSSP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.btnTaoHoaDon);
            this.splitContainer1.Panel1.Controls.Add(this.gbDSSP);
            this.splitContainer1.Panel1.Controls.Add(this.txtTenKH);
            this.splitContainer1.Panel1.Controls.Add(this.lbTenKH);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvHoaDon);
            this.splitContainer1.Size = new System.Drawing.Size(1121, 447);
            this.splitContainer1.SplitterDistance = 462;
            this.splitContainer1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(245, 343);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 45);
            this.button2.TabIndex = 7;
            this.button2.Text = "In";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnTaoHoaDon
            // 
            this.btnTaoHoaDon.Location = new System.Drawing.Point(63, 343);
            this.btnTaoHoaDon.Name = "btnTaoHoaDon";
            this.btnTaoHoaDon.Size = new System.Drawing.Size(113, 45);
            this.btnTaoHoaDon.TabIndex = 6;
            this.btnTaoHoaDon.Text = "Tạo";
            this.btnTaoHoaDon.UseVisualStyleBackColor = true;
            this.btnTaoHoaDon.Click += new System.EventHandler(this.btnTaoHoaDon_Click);
            // 
            // gbDSSP
            // 
            this.gbDSSP.Controls.Add(this.clbSP);
            this.gbDSSP.Controls.Add(this.lbSP);
            this.gbDSSP.Controls.Add(this.lbDanhMucSP);
            this.gbDSSP.Controls.Add(this.cbDanhMucSP);
            this.gbDSSP.Location = new System.Drawing.Point(16, 72);
            this.gbDSSP.Name = "gbDSSP";
            this.gbDSSP.Size = new System.Drawing.Size(394, 252);
            this.gbDSSP.TabIndex = 4;
            this.gbDSSP.TabStop = false;
            this.gbDSSP.Text = "Danh sách sản phẩm";
            // 
            // clbSP
            // 
            this.clbSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbSP.FormattingEnabled = true;
            this.clbSP.Location = new System.Drawing.Point(132, 83);
            this.clbSP.Name = "clbSP";
            this.clbSP.Size = new System.Drawing.Size(243, 156);
            this.clbSP.TabIndex = 5;
            // 
            // lbSP
            // 
            this.lbSP.AutoSize = true;
            this.lbSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSP.Location = new System.Drawing.Point(11, 83);
            this.lbSP.Name = "lbSP";
            this.lbSP.Size = new System.Drawing.Size(79, 18);
            this.lbSP.TabIndex = 4;
            this.lbSP.Text = "Sản phẩm:";
            // 
            // lbDanhMucSP
            // 
            this.lbDanhMucSP.AutoSize = true;
            this.lbDanhMucSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDanhMucSP.Location = new System.Drawing.Point(11, 35);
            this.lbDanhMucSP.Name = "lbDanhMucSP";
            this.lbDanhMucSP.Size = new System.Drawing.Size(80, 18);
            this.lbDanhMucSP.TabIndex = 2;
            this.lbDanhMucSP.Text = "Danh mục:";
            // 
            // cbDanhMucSP
            // 
            this.cbDanhMucSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDanhMucSP.FormattingEnabled = true;
            this.cbDanhMucSP.Location = new System.Drawing.Point(132, 32);
            this.cbDanhMucSP.Name = "cbDanhMucSP";
            this.cbDanhMucSP.Size = new System.Drawing.Size(243, 26);
            this.cbDanhMucSP.TabIndex = 3;
            this.cbDanhMucSP.SelectedIndexChanged += new System.EventHandler(this.cbDanhMucSP_SelectedIndexChanged);
            // 
            // txtTenKH
            // 
            this.txtTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKH.Location = new System.Drawing.Point(148, 27);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(262, 24);
            this.txtTenKH.TabIndex = 1;
            // 
            // lbTenKH
            // 
            this.lbTenKH.AutoSize = true;
            this.lbTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenKH.Location = new System.Drawing.Point(15, 27);
            this.lbTenKH.Name = "lbTenKH";
            this.lbTenKH.Size = new System.Drawing.Size(117, 18);
            this.lbTenKH.TabIndex = 0;
            this.lbTenKH.Text = "Tên khách hàng:";
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaHD,
            this.col2TenKH,
            this.colSP,
            this.colTongTien});
            this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDon.Location = new System.Drawing.Point(0, 0);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.RowTemplate.Height = 24;
            this.dgvHoaDon.Size = new System.Drawing.Size(655, 447);
            this.dgvHoaDon.TabIndex = 0;
            // 
            // colMaHD
            // 
            this.colMaHD.HeaderText = "Mã HĐ";
            this.colMaHD.MinimumWidth = 6;
            this.colMaHD.Name = "colMaHD";
            this.colMaHD.Width = 125;
            // 
            // col2TenKH
            // 
            this.col2TenKH.HeaderText = "Tên khách hàng";
            this.col2TenKH.MinimumWidth = 6;
            this.col2TenKH.Name = "col2TenKH";
            this.col2TenKH.Width = 125;
            // 
            // colSP
            // 
            this.colSP.HeaderText = "Sản phẩm";
            this.colSP.MinimumWidth = 6;
            this.colSP.Name = "colSP";
            this.colSP.Width = 125;
            // 
            // colTongTien
            // 
            this.colTongTien.HeaderText = "Tổng tiền";
            this.colTongTien.MinimumWidth = 6;
            this.colTongTien.Name = "colTongTien";
            this.colTongTien.Width = 125;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // frmDSHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 447);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmDSHoaDon";
            this.Text = "FormDSHoaDon";
            this.Load += new System.EventHandler(this.frmDSHoaDon_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbDSSP.ResumeLayout(false);
            this.gbDSSP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label lbTenKH;
        private System.Windows.Forms.GroupBox gbDSSP;
        private System.Windows.Forms.ComboBox cbDanhMucSP;
        private System.Windows.Forms.Label lbDanhMucSP;
        private System.Windows.Forms.CheckedListBox clbSP;
        private System.Windows.Forms.Label lbSP;
        private System.Windows.Forms.Button btnTaoHoaDon;
        private System.Windows.Forms.Button button2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2TenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTien;
        private System.Windows.Forms.PrintDialog printDialog1;
    }
}