namespace BT1
{
    partial class FrmMayTinhBoTui
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
            this.SoThuNhat = new System.Windows.Forms.Label();
            this.SoThuHai = new System.Windows.Forms.Label();
            this.txtSoThuNhat = new System.Windows.Forms.TextBox();
            this.txtSoThuHai = new System.Windows.Forms.TextBox();
            this.btnAddition = new System.Windows.Forms.Button();
            this.btnSubtraction = new System.Windows.Forms.Button();
            this.btnMultiplication = new System.Windows.Forms.Button();
            this.btnDivision = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.KetQua = new System.Windows.Forms.Label();
            this.txtKetQua = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SoThuNhat
            // 
            this.SoThuNhat.AutoSize = true;
            this.SoThuNhat.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoThuNhat.Location = new System.Drawing.Point(42, 53);
            this.SoThuNhat.Name = "SoThuNhat";
            this.SoThuNhat.Size = new System.Drawing.Size(177, 33);
            this.SoThuNhat.TabIndex = 0;
            this.SoThuNhat.Text = "Số thứ nhất: ";
            this.SoThuNhat.Click += new System.EventHandler(this.label1_Click);
            // 
            // SoThuHai
            // 
            this.SoThuHai.AutoSize = true;
            this.SoThuHai.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoThuHai.Location = new System.Drawing.Point(42, 102);
            this.SoThuHai.Name = "SoThuHai";
            this.SoThuHai.Size = new System.Drawing.Size(159, 33);
            this.SoThuHai.TabIndex = 1;
            this.SoThuHai.Text = "Số thứ hai: ";
            this.SoThuHai.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtSoThuNhat
            // 
            this.txtSoThuNhat.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoThuNhat.Location = new System.Drawing.Point(225, 47);
            this.txtSoThuNhat.Name = "txtSoThuNhat";
            this.txtSoThuNhat.Size = new System.Drawing.Size(208, 39);
            this.txtSoThuNhat.TabIndex = 2;
            this.txtSoThuNhat.Click += new System.EventHandler(this.txtSoThuNhat_Click);
            this.txtSoThuNhat.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtSoThuNhat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSoThuNhat_KeyDown);
            this.txtSoThuNhat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoThuNhat_KeyPress);
            // 
            // txtSoThuHai
            // 
            this.txtSoThuHai.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoThuHai.Location = new System.Drawing.Point(225, 99);
            this.txtSoThuHai.Name = "txtSoThuHai";
            this.txtSoThuHai.Size = new System.Drawing.Size(208, 39);
            this.txtSoThuHai.TabIndex = 3;
            this.txtSoThuHai.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.txtSoThuHai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSoThuHai_KeyDown);
            this.txtSoThuHai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoThuHai_KeyPress);
            // 
            // btnAddition
            // 
            this.btnAddition.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddition.Location = new System.Drawing.Point(48, 164);
            this.btnAddition.Name = "btnAddition";
            this.btnAddition.Size = new System.Drawing.Size(50, 50);
            this.btnAddition.TabIndex = 4;
            this.btnAddition.Text = "+";
            this.btnAddition.UseVisualStyleBackColor = true;
            this.btnAddition.Click += new System.EventHandler(this.btnAddition_Click);
            // 
            // btnSubtraction
            // 
            this.btnSubtraction.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubtraction.Location = new System.Drawing.Point(117, 164);
            this.btnSubtraction.Name = "btnSubtraction";
            this.btnSubtraction.Size = new System.Drawing.Size(50, 50);
            this.btnSubtraction.TabIndex = 5;
            this.btnSubtraction.Text = "-";
            this.btnSubtraction.UseVisualStyleBackColor = true;
            this.btnSubtraction.Click += new System.EventHandler(this.btnSubtraction_Click);
            // 
            // btnMultiplication
            // 
            this.btnMultiplication.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMultiplication.Location = new System.Drawing.Point(188, 164);
            this.btnMultiplication.Name = "btnMultiplication";
            this.btnMultiplication.Size = new System.Drawing.Size(50, 50);
            this.btnMultiplication.TabIndex = 6;
            this.btnMultiplication.Text = "*";
            this.btnMultiplication.UseVisualStyleBackColor = true;
            this.btnMultiplication.Click += new System.EventHandler(this.btnMultiplication_Click);
            // 
            // btnDivision
            // 
            this.btnDivision.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDivision.Location = new System.Drawing.Point(259, 164);
            this.btnDivision.Name = "btnDivision";
            this.btnDivision.Size = new System.Drawing.Size(50, 50);
            this.btnDivision.TabIndex = 7;
            this.btnDivision.Text = "/";
            this.btnDivision.UseVisualStyleBackColor = true;
            this.btnDivision.Click += new System.EventHandler(this.btnDivision_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(351, 164);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(82, 50);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Del";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // KetQua
            // 
            this.KetQua.AutoSize = true;
            this.KetQua.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KetQua.Location = new System.Drawing.Point(42, 243);
            this.KetQua.Name = "KetQua";
            this.KetQua.Size = new System.Drawing.Size(128, 33);
            this.KetQua.TabIndex = 9;
            this.KetQua.Text = "Kết quả: ";
            // 
            // txtKetQua
            // 
            this.txtKetQua.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKetQua.Location = new System.Drawing.Point(225, 243);
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.Size = new System.Drawing.Size(208, 39);
            this.txtKetQua.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 332);
            this.Controls.Add(this.txtKetQua);
            this.Controls.Add(this.KetQua);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnDivision);
            this.Controls.Add(this.btnMultiplication);
            this.Controls.Add(this.btnSubtraction);
            this.Controls.Add(this.btnAddition);
            this.Controls.Add(this.txtSoThuHai);
            this.Controls.Add(this.txtSoThuNhat);
            this.Controls.Add(this.SoThuHai);
            this.Controls.Add(this.SoThuNhat);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SoThuNhat;
        private System.Windows.Forms.Label SoThuHai;
        private System.Windows.Forms.TextBox txtSoThuNhat;
        private System.Windows.Forms.TextBox txtSoThuHai;
        private System.Windows.Forms.Button btnAddition;
        private System.Windows.Forms.Button btnSubtraction;
        private System.Windows.Forms.Button btnMultiplication;
        private System.Windows.Forms.Button btnDivision;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label KetQua;
        private System.Windows.Forms.TextBox txtKetQua;
    }
}

