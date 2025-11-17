namespace QLBH
{
    partial class BT2
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
            this.lstSanPham = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbDanhMucSanPham
            // 
            this.lbDanhMucSanPham.AutoSize = true;
            this.lbDanhMucSanPham.Location = new System.Drawing.Point(30, 27);
            this.lbDanhMucSanPham.Name = "lbDanhMucSanPham";
            this.lbDanhMucSanPham.Size = new System.Drawing.Size(152, 16);
            this.lbDanhMucSanPham.TabIndex = 0;
            this.lbDanhMucSanPham.Text = "DANH MUC SAN PHAM";
            // 
            // lstSanPham
            // 
            this.lstSanPham.FormattingEnabled = true;
            this.lstSanPham.ItemHeight = 16;
            this.lstSanPham.Location = new System.Drawing.Point(33, 60);
            this.lstSanPham.Name = "lstSanPham";
            this.lstSanPham.Size = new System.Drawing.Size(444, 228);
            this.lstSanPham.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(509, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BT2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 317);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstSanPham);
            this.Controls.Add(this.lbDanhMucSanPham);
            this.Name = "BT2";
            this.Text = "Đưa dữ liệu vào Listbox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BT2_FormClosing);
            this.Load += new System.EventHandler(this.BT2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDanhMucSanPham;
        private System.Windows.Forms.ListBox lstSanPham;
        private System.Windows.Forms.Button button1;
    }
}