namespace com.cgWorkstudio.BIMP {
    partial class Form_Default {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tbx_Text = new System.Windows.Forms.TextBox();
            this.txt_db = new System.Windows.Forms.Label();
            this.btn_Default = new System.Windows.Forms.Button();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbx_Text
            // 
            this.tbx_Text.Location = new System.Drawing.Point(80,39);
            this.tbx_Text.Name = "tbx_Text";
            this.tbx_Text.Size = new System.Drawing.Size(647,21);
            this.tbx_Text.TabIndex = 7;
            this.tbx_Text.Text = "Data Source=localhost;Initial Catalog=bimp;Persist Security Info=True;User ID=sa;" +
                "Password=bimp.com";
            // 
            // txt_db
            // 
            this.txt_db.AutoSize = true;
            this.txt_db.Location = new System.Drawing.Point(21,42);
            this.txt_db.Name = "txt_db";
            this.txt_db.Size = new System.Drawing.Size(53,12);
            this.txt_db.TabIndex = 8;
            this.txt_db.Text = "数据库：";
            // 
            // btn_Default
            // 
            this.btn_Default.Location = new System.Drawing.Point(225,76);
            this.btn_Default.Name = "btn_Default";
            this.btn_Default.Size = new System.Drawing.Size(139,35);
            this.btn_Default.TabIndex = 9;
            this.btn_Default.Text = "初始化Default数据";
            this.btn_Default.UseVisualStyleBackColor = true;
            this.btn_Default.Click += new System.EventHandler(this.btn_Default_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(80,76);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(139,35);
            this.btn_Connect.TabIndex = 10;
            this.btn_Connect.Text = "连接到SQL数据库";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // Form_Default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F,12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749,174);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.btn_Default);
            this.Controls.Add(this.txt_db);
            this.Controls.Add(this.tbx_Text);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form_Default";
            this.Text = "Form_Default";
            this.Load += new System.EventHandler(this.Form_Default_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_Text;
        private System.Windows.Forms.Label txt_db;
        private System.Windows.Forms.Button btn_Default;
        private System.Windows.Forms.Button btn_Connect;
    }
}