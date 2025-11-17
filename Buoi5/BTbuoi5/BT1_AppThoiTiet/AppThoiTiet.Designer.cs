namespace WinFormsApp1
{
    partial class AppThoiTiet
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbThanhPho = new Label();
            lbKinhDo = new Label();
            lbViDo = new Label();
            lbNhietDo = new Label();
            lbGio = new Label();
            lbThoiGianCapNhat = new Label();
            cbThanhPho = new ComboBox();
            txtKinhDo = new TextBox();
            txtViDo = new TextBox();
            txtNhietDo = new TextBox();
            txtGio = new TextBox();
            txtThoiGianCapNhat = new TextBox();
            btnCapNhat = new Button();
            picWeatherIcon = new PictureBox();
            picWindIcon = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picWeatherIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picWindIcon).BeginInit();
            SuspendLayout();
            // 
            // lbThanhPho
            // 
            lbThanhPho.AutoSize = true;
            lbThanhPho.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbThanhPho.Location = new Point(31, 29);
            lbThanhPho.Name = "lbThanhPho";
            lbThanhPho.Size = new Size(118, 28);
            lbThanhPho.TabIndex = 0;
            lbThanhPho.Text = "Thành phố:";
            // 
            // lbKinhDo
            // 
            lbKinhDo.AutoSize = true;
            lbKinhDo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbKinhDo.Location = new Point(31, 85);
            lbKinhDo.Name = "lbKinhDo";
            lbKinhDo.Size = new Size(91, 28);
            lbKinhDo.TabIndex = 1;
            lbKinhDo.Text = "Kinh độ:";
            // 
            // lbViDo
            // 
            lbViDo.AutoSize = true;
            lbViDo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbViDo.Location = new Point(31, 141);
            lbViDo.Name = "lbViDo";
            lbViDo.Size = new Size(68, 28);
            lbViDo.TabIndex = 2;
            lbViDo.Text = "Vĩ độ:";
            // 
            // lbNhietDo
            // 
            lbNhietDo.AutoSize = true;
            lbNhietDo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbNhietDo.Location = new Point(31, 197);
            lbNhietDo.Name = "lbNhietDo";
            lbNhietDo.Size = new Size(101, 28);
            lbNhietDo.TabIndex = 3;
            lbNhietDo.Text = "Nhiệt độ:";
            // 
            // lbGio
            // 
            lbGio.AutoSize = true;
            lbGio.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbGio.Location = new Point(31, 253);
            lbGio.Name = "lbGio";
            lbGio.Size = new Size(49, 28);
            lbGio.TabIndex = 4;
            lbGio.Text = "Gió:";
            // 
            // lbThoiGianCapNhat
            // 
            lbThoiGianCapNhat.AutoSize = true;
            lbThoiGianCapNhat.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbThoiGianCapNhat.Location = new Point(31, 309);
            lbThoiGianCapNhat.Name = "lbThoiGianCapNhat";
            lbThoiGianCapNhat.Size = new Size(135, 28);
            lbThoiGianCapNhat.TabIndex = 5;
            lbThoiGianCapNhat.Text = "Cập nhật lúc:";
            // 
            // cbThanhPho
            // 
            cbThanhPho.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbThanhPho.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbThanhPho.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbThanhPho.FormattingEnabled = true;
            cbThanhPho.Items.AddRange(new object[] { "TP.HCM", "Hà Nội", "Đà Nẵng", "Khác" });
            cbThanhPho.Location = new Point(215, 29);
            cbThanhPho.Name = "cbThanhPho";
            cbThanhPho.Size = new Size(244, 31);
            cbThanhPho.TabIndex = 6;
            cbThanhPho.SelectedIndexChanged += cbThanhPho_SelectedIndexChanged;
            // 
            // txtKinhDo
            // 
            txtKinhDo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtKinhDo.Location = new Point(216, 84);
            txtKinhDo.Name = "txtKinhDo";
            txtKinhDo.ReadOnly = true;
            txtKinhDo.Size = new Size(243, 34);
            txtKinhDo.TabIndex = 7;
            // 
            // txtViDo
            // 
            txtViDo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtViDo.Location = new Point(215, 141);
            txtViDo.Name = "txtViDo";
            txtViDo.ReadOnly = true;
            txtViDo.Size = new Size(243, 34);
            txtViDo.TabIndex = 8;
            // 
            // txtNhietDo
            // 
            txtNhietDo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNhietDo.Location = new Point(215, 194);
            txtNhietDo.Name = "txtNhietDo";
            txtNhietDo.ReadOnly = true;
            txtNhietDo.Size = new Size(196, 34);
            txtNhietDo.TabIndex = 9;
            // 
            // txtGio
            // 
            txtGio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGio.Location = new Point(216, 250);
            txtGio.Name = "txtGio";
            txtGio.ReadOnly = true;
            txtGio.Size = new Size(195, 34);
            txtGio.TabIndex = 10;
            // 
            // txtThoiGianCapNhat
            // 
            txtThoiGianCapNhat.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtThoiGianCapNhat.Location = new Point(216, 306);
            txtThoiGianCapNhat.Name = "txtThoiGianCapNhat";
            txtThoiGianCapNhat.ReadOnly = true;
            txtThoiGianCapNhat.Size = new Size(243, 34);
            txtThoiGianCapNhat.TabIndex = 11;
            // 
            // btnCapNhat
            // 
            btnCapNhat.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCapNhat.Location = new Point(136, 375);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(182, 43);
            btnCapNhat.TabIndex = 12;
            btnCapNhat.Text = "Cập nhật lại dữ liệu";
            btnCapNhat.UseVisualStyleBackColor = true;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // picWeatherIcon
            // 
            picWeatherIcon.Location = new Point(417, 191);
            picWeatherIcon.Name = "picWeatherIcon";
            picWeatherIcon.Size = new Size(42, 37);
            picWeatherIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            picWeatherIcon.TabIndex = 14;
            picWeatherIcon.TabStop = false;
            // 
            // picWindIcon
            // 
            picWindIcon.Location = new Point(417, 250);
            picWindIcon.Name = "picWindIcon";
            picWindIcon.Size = new Size(42, 34);
            picWindIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            picWindIcon.TabIndex = 15;
            picWindIcon.TabStop = false;
            // 
            // AppThoiTiet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(902, 462);
            Controls.Add(picWindIcon);
            Controls.Add(picWeatherIcon);
            Controls.Add(btnCapNhat);
            Controls.Add(txtThoiGianCapNhat);
            Controls.Add(txtGio);
            Controls.Add(txtNhietDo);
            Controls.Add(txtViDo);
            Controls.Add(txtKinhDo);
            Controls.Add(cbThanhPho);
            Controls.Add(lbThoiGianCapNhat);
            Controls.Add(lbGio);
            Controls.Add(lbNhietDo);
            Controls.Add(lbViDo);
            Controls.Add(lbKinhDo);
            Controls.Add(lbThanhPho);
            Name = "AppThoiTiet";
            Text = "AppThoiTiet";
            ((System.ComponentModel.ISupportInitialize)picWeatherIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)picWindIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbThanhPho;
        private Label lbKinhDo;
        private Label lbViDo;
        private Label lbNhietDo;
        private Label lbGio;
        private Label lbThoiGianCapNhat;
        private ComboBox cbThanhPho;
        private TextBox txtKinhDo;
        private TextBox txtViDo;
        private TextBox txtNhietDo;
        private TextBox txtGio;
        private TextBox txtThoiGianCapNhat;
        private Button btnCapNhat;
        private PictureBox picWeatherIcon;
        private PictureBox picWindIcon;
    }
}
