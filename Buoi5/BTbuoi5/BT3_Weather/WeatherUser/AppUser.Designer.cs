namespace WeatherUser
{
    partial class AppUser
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
            lstMessages = new ListBox();
            SuspendLayout();
            // 
            // lstMessages
            // 
            lstMessages.Dock = DockStyle.Fill;
            lstMessages.FormattingEnabled = true;
            lstMessages.Location = new Point(0, 0);
            lstMessages.Name = "lstMessages";
            lstMessages.Size = new Size(800, 450);
            lstMessages.TabIndex = 0;
            // 
            // AppUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstMessages);
            Name = "AppUser";
            Text = "AppUser";
            Load += AppUser_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstMessages;
    }
}
