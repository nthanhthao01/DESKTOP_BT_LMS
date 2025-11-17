namespace QLBH
{
    partial class BT7
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
            this.lbLoaiSanPham = new System.Windows.Forms.Label();
            this.trvLoaiSanPham = new System.Windows.Forms.TreeView();
            this.lbSanPham = new System.Windows.Forms.Label();
            this.dgSanPham = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // lbLoaiSanPham
            // 
            this.lbLoaiSanPham.AutoSize = true;
            this.lbLoaiSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoaiSanPham.Location = new System.Drawing.Point(26, 47);
            this.lbLoaiSanPham.Name = "lbLoaiSanPham";
            this.lbLoaiSanPham.Size = new System.Drawing.Size(124, 20);
            this.lbLoaiSanPham.TabIndex = 0;
            this.lbLoaiSanPham.Text = "Loại sản phẩm:";
            // 
            // trvLoaiSanPham
            // 
            this.trvLoaiSanPham.Location = new System.Drawing.Point(30, 84);
            this.trvLoaiSanPham.Name = "trvLoaiSanPham";
            this.trvLoaiSanPham.Size = new System.Drawing.Size(247, 341);
            this.trvLoaiSanPham.TabIndex = 1;
            this.trvLoaiSanPham.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvLoaiSanPham_AfterSelect);
            // 
            // lbSanPham
            // 
            this.lbSanPham.AutoSize = true;
            this.lbSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSanPham.Location = new System.Drawing.Point(288, 47);
            this.lbSanPham.Name = "lbSanPham";
            this.lbSanPham.Size = new System.Drawing.Size(89, 20);
            this.lbSanPham.TabIndex = 2;
            this.lbSanPham.Text = "Sản phẩm:";
            // 
            // dgSanPham
            // 
            this.dgSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSanPham.Location = new System.Drawing.Point(292, 84);
            this.dgSanPham.Name = "dgSanPham";
            this.dgSanPham.RowHeadersWidth = 51;
            this.dgSanPham.RowTemplate.Height = 24;
            this.dgSanPham.Size = new System.Drawing.Size(734, 341);
            this.dgSanPham.TabIndex = 3;
            // 
            // BT7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 450);
            this.Controls.Add(this.dgSanPham);
            this.Controls.Add(this.lbSanPham);
            this.Controls.Add(this.trvLoaiSanPham);
            this.Controls.Add(this.lbLoaiSanPham);
            this.Name = "BT7";
            this.Text = "TreeView và DataGridView";
            this.Load += new System.EventHandler(this.BT7_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbLoaiSanPham;
        private System.Windows.Forms.TreeView trvLoaiSanPham;
        private System.Windows.Forms.Label lbSanPham;
        private System.Windows.Forms.DataGridView dgSanPham;
    }
}