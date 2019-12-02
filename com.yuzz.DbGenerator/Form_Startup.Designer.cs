namespace com.yuzz.DbGenerator {
    partial class Form_Startup {
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
            this.btn_MySQL = new System.Windows.Forms.Button();
            this.btn_MsSQL = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_MySQL
            // 
            this.btn_MySQL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_MySQL.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_MySQL.Location = new System.Drawing.Point(167, 167);
            this.btn_MySQL.Name = "btn_MySQL";
            this.btn_MySQL.Size = new System.Drawing.Size(202, 68);
            this.btn_MySQL.TabIndex = 0;
            this.btn_MySQL.Text = "Launch MySQL DbGenerator";
            this.btn_MySQL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_MySQL.UseVisualStyleBackColor = true;
            this.btn_MySQL.Click += new System.EventHandler(this.btn_MySQL_Click);
            // 
            // btn_MsSQL
            // 
            this.btn_MsSQL.Location = new System.Drawing.Point(409, 167);
            this.btn_MsSQL.Name = "btn_MsSQL";
            this.btn_MsSQL.Size = new System.Drawing.Size(210, 68);
            this.btn_MsSQL.TabIndex = 1;
            this.btn_MsSQL.Text = "Launch MSSQL DbGenerator";
            this.btn_MsSQL.UseVisualStyleBackColor = true;
            this.btn_MsSQL.Click += new System.EventHandler(this.btn_MsSQL_Click);
            // 
            // Form_Startup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_MsSQL);
            this.Controls.Add(this.btn_MySQL);
            this.MaximizeBox = false;
            this.Name = "Form_Startup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Startup";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_MySQL;
        private System.Windows.Forms.Button btn_MsSQL;
    }
}