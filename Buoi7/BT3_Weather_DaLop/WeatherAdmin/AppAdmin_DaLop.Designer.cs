namespace WeatherAdmin
{
    partial class AppAdmin_DaLop
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
            lblTemp = new Label();
            lblCountdown = new Label();
            SuspendLayout();
            // 
            // lblTemp
            // 
            lblTemp.AutoSize = true;
            lblTemp.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTemp.Location = new Point(183, 173);
            lblTemp.Name = "lblTemp";
            lblTemp.Size = new Size(423, 28);
            lblTemp.TabIndex = 0;
            lblTemp.Text = "Nhiệt độ Hà Nội: 23 độ C -Thời tiêt dễ chịu";
            // 
            // lblCountdown
            // 
            lblCountdown.AutoSize = true;
            lblCountdown.Location = new Point(306, 227);
            lblCountdown.Name = "lblCountdown";
            lblCountdown.Size = new Size(87, 20);
            lblCountdown.TabIndex = 1;
            lblCountdown.Text = "count down";
            // 
            // AppAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblCountdown);
            Controls.Add(lblTemp);
            Name = "AppAdmin";
            Text = "AppAdmin";
            Load += AppAdmin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTemp;
        private Label lblCountdown;
    }
}
