namespace QLBH
{
    partial class BT3
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
            this.lbDanhMucSanPham = new System.Windows.Forms.Label();
            this.cbSanPham = new System.Windows.Forms.ComboBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbDanhMucSanPham
            // 
            this.lbDanhMucSanPham.AutoSize = true;
            this.lbDanhMucSanPham.Location = new System.Drawing.Point(60, 41);
            this.lbDanhMucSanPham.Name = "lbDanhMucSanPham";
            this.lbDanhMucSanPham.Size = new System.Drawing.Size(152, 16);
            this.lbDanhMucSanPham.TabIndex = 0;
            this.lbDanhMucSanPham.Text = "DANH MỤC SẢN PHẨM";
            // 
            // cbSanPham
            // 
            this.cbSanPham.FormattingEnabled = true;
            this.cbSanPham.Location = new System.Drawing.Point(63, 85);
            this.cbSanPham.Name = "cbSanPham";
            this.cbSanPham.Size = new System.Drawing.Size(249, 24);
            this.cbSanPham.TabIndex = 1;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(371, 80);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(87, 33);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // BT3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 352);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.cbSanPham);
            this.Controls.Add(this.lbDanhMucSanPham);
            this.Name = "BT3";
            this.Text = "Đưa dữ liệu vào ComboBox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BT3_FormClosing);
            this.Load += new System.EventHandler(this.BT3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDanhMucSanPham;
        private System.Windows.Forms.ComboBox cbSanPham;
        private System.Windows.Forms.Button btnThoat;
    }
}