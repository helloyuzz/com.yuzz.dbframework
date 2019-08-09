namespace com.yuzz.DbGenerator {
    partial class Form_MySQL {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("数据库");
            this.dgv = new System.Windows.Forms.DataGridView();
            this.rtb_Code = new System.Windows.Forms.RichTextBox();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.showContent_Panel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_dbname = new System.Windows.Forms.Button();
            this.btn_html = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.tbx_SavePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Build = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_TableName = new System.Windows.Forms.TextBox();
            this.showTop_Panel = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tvw = new System.Windows.Forms.TreeView();
            this.showLeft_Panel = new System.Windows.Forms.Panel();
            this.showRight_Panel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbx_pwd = new System.Windows.Forms.TextBox();
            this.tbx_user = new System.Windows.Forms.TextBox();
            this.tbx_port = new System.Windows.Forms.TextBox();
            this.tbx_dbip = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_schema = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.showContent_Panel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.showTop_Panel.SuspendLayout();
            this.showLeft_Panel.SuspendLayout();
            this.showRight_Panel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv.Location = new System.Drawing.Point(5, 25);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(824, 357);
            this.dgv.TabIndex = 0;
            // 
            // rtb_Code
            // 
            this.rtb_Code.BackColor = System.Drawing.Color.White;
            this.rtb_Code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Code.Location = new System.Drawing.Point(2, 75);
            this.rtb_Code.Name = "rtb_Code";
            this.rtb_Code.Size = new System.Drawing.Size(830, 111);
            this.rtb_Code.TabIndex = 1;
            this.rtb_Code.Text = "";
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(966, 16);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(109, 25);
            this.btn_Connect.TabIndex = 2;
            this.btn_Connect.Text = "连接...";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // showContent_Panel
            // 
            this.showContent_Panel.Controls.Add(this.rtb_Code);
            this.showContent_Panel.Controls.Add(this.panel2);
            this.showContent_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showContent_Panel.Location = new System.Drawing.Point(0, 387);
            this.showContent_Panel.Name = "showContent_Panel";
            this.showContent_Panel.Padding = new System.Windows.Forms.Padding(2);
            this.showContent_Panel.Size = new System.Drawing.Size(834, 188);
            this.showContent_Panel.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_dbname);
            this.panel2.Controls.Add(this.btn_html);
            this.panel2.Controls.Add(this.btn_Save);
            this.panel2.Controls.Add(this.tbx_SavePath);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btn_Build);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tbx_TableName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(830, 73);
            this.panel2.TabIndex = 3;
            // 
            // btn_dbname
            // 
            this.btn_dbname.Location = new System.Drawing.Point(488, 7);
            this.btn_dbname.Name = "btn_dbname";
            this.btn_dbname.Size = new System.Drawing.Size(92, 27);
            this.btn_dbname.TabIndex = 7;
            this.btn_dbname.Text = "生成DBName";
            this.btn_dbname.UseVisualStyleBackColor = true;
            this.btn_dbname.Click += new System.EventHandler(this.btn_dbname_Click);
            // 
            // btn_html
            // 
            this.btn_html.Location = new System.Drawing.Point(390, 7);
            this.btn_html.Name = "btn_html";
            this.btn_html.Size = new System.Drawing.Size(92, 27);
            this.btn_html.TabIndex = 6;
            this.btn_html.Text = "生成Html";
            this.btn_html.UseVisualStyleBackColor = true;
            this.btn_html.Click += new System.EventHandler(this.btn_html_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(6, 39);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(100, 27);
            this.btn_Save.TabIndex = 5;
            this.btn_Save.Text = "保存到文件";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // tbx_SavePath
            // 
            this.tbx_SavePath.Location = new System.Drawing.Point(177, 42);
            this.tbx_SavePath.Name = "tbx_SavePath";
            this.tbx_SavePath.Size = new System.Drawing.Size(487, 21);
            this.tbx_SavePath.TabIndex = 4;
            this.tbx_SavePath.Text = "D:\\svn_shtcrane\\com.sht.library\\db_class";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "保存路径：";
            // 
            // btn_Build
            // 
            this.btn_Build.Location = new System.Drawing.Point(6, 7);
            this.btn_Build.Name = "btn_Build";
            this.btn_Build.Size = new System.Drawing.Size(100, 27);
            this.btn_Build.TabIndex = 0;
            this.btn_Build.Text = "生成代码";
            this.btn_Build.UseVisualStyleBackColor = true;
            this.btn_Build.Click += new System.EventHandler(this.btn_Build_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "表名：";
            // 
            // tbx_TableName
            // 
            this.tbx_TableName.Location = new System.Drawing.Point(177, 10);
            this.tbx_TableName.Name = "tbx_TableName";
            this.tbx_TableName.Size = new System.Drawing.Size(207, 21);
            this.tbx_TableName.TabIndex = 2;
            this.tbx_TableName.Text = "tb_";
            // 
            // showTop_Panel
            // 
            this.showTop_Panel.Controls.Add(this.dgv);
            this.showTop_Panel.Controls.Add(this.comboBox1);
            this.showTop_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.showTop_Panel.Location = new System.Drawing.Point(0, 0);
            this.showTop_Panel.Name = "showTop_Panel";
            this.showTop_Panel.Padding = new System.Windows.Forms.Padding(5);
            this.showTop_Panel.Size = new System.Drawing.Size(834, 387);
            this.showTop_Panel.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Server=192.168.1.221;User Id=root;Password=20127163;Persist Security Info=True;Da" +
                "tabase=shtcrane;Connect Timeout=10;charset=utf8",
            "Server=127.0.0.1;User Id=root;Password=wangmo123wm;Persist Security Info=True;Dat" +
                "abase=wangmo;Connect Timeout=10;charset=utf8"});
            this.comboBox1.Location = new System.Drawing.Point(5, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(824, 20);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tvw
            // 
            this.tvw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvw.HideSelection = false;
            this.tvw.Location = new System.Drawing.Point(0, 0);
            this.tvw.Name = "tvw";
            treeNode2.Name = "rootNode";
            treeNode2.Text = "数据库";
            this.tvw.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.tvw.Size = new System.Drawing.Size(260, 575);
            this.tvw.TabIndex = 2;
            this.tvw.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvw_AfterSelect);
            // 
            // showLeft_Panel
            // 
            this.showLeft_Panel.Controls.Add(this.tvw);
            this.showLeft_Panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.showLeft_Panel.Location = new System.Drawing.Point(6, 106);
            this.showLeft_Panel.Name = "showLeft_Panel";
            this.showLeft_Panel.Size = new System.Drawing.Size(260, 575);
            this.showLeft_Panel.TabIndex = 5;
            // 
            // showRight_Panel
            // 
            this.showRight_Panel.Controls.Add(this.showContent_Panel);
            this.showRight_Panel.Controls.Add(this.showTop_Panel);
            this.showRight_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showRight_Panel.Location = new System.Drawing.Point(266, 106);
            this.showRight_Panel.Name = "showRight_Panel";
            this.showRight_Panel.Size = new System.Drawing.Size(834, 575);
            this.showRight_Panel.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbx_schema);
            this.panel3.Controls.Add(this.tbx_pwd);
            this.panel3.Controls.Add(this.tbx_user);
            this.panel3.Controls.Add(this.tbx_port);
            this.panel3.Controls.Add(this.tbx_dbip);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btn_Connect);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(6, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1094, 100);
            this.panel3.TabIndex = 7;
            // 
            // tbx_pwd
            // 
            this.tbx_pwd.Location = new System.Drawing.Point(795, 18);
            this.tbx_pwd.Name = "tbx_pwd";
            this.tbx_pwd.Size = new System.Drawing.Size(100, 21);
            this.tbx_pwd.TabIndex = 11;
            // 
            // tbx_user
            // 
            this.tbx_user.Location = new System.Drawing.Point(598, 18);
            this.tbx_user.Name = "tbx_user";
            this.tbx_user.Size = new System.Drawing.Size(118, 21);
            this.tbx_user.TabIndex = 10;
            // 
            // tbx_port
            // 
            this.tbx_port.Location = new System.Drawing.Point(412, 18);
            this.tbx_port.Name = "tbx_port";
            this.tbx_port.Size = new System.Drawing.Size(100, 21);
            this.tbx_port.TabIndex = 9;
            // 
            // tbx_dbip
            // 
            this.tbx_dbip.Location = new System.Drawing.Point(110, 18);
            this.tbx_dbip.Name = "tbx_dbip";
            this.tbx_dbip.Size = new System.Drawing.Size(231, 21);
            this.tbx_dbip.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "数据库：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(748, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "密码：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(539, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "用户名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(365, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "端口：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "服务器地址：";
            // 
            // tbx_schema
            // 
            this.tbx_schema.Location = new System.Drawing.Point(110, 59);
            this.tbx_schema.Name = "tbx_schema";
            this.tbx_schema.Size = new System.Drawing.Size(231, 21);
            this.tbx_schema.TabIndex = 12;
            // 
            // Form_MySQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 687);
            this.Controls.Add(this.showRight_Panel);
            this.Controls.Add(this.showLeft_Panel);
            this.Controls.Add(this.panel3);
            this.Name = "Form_MySQL";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MySQL DbGenerator v1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_MySQL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.showContent_Panel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.showTop_Panel.ResumeLayout(false);
            this.showLeft_Panel.ResumeLayout(false);
            this.showRight_Panel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.RichTextBox rtb_Code;
        private System.Windows.Forms.Panel showContent_Panel;
        private System.Windows.Forms.Button btn_Build;
        private System.Windows.Forms.TextBox tbx_TableName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel showTop_Panel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.TreeView tvw;
        private System.Windows.Forms.Panel showLeft_Panel;
        private System.Windows.Forms.Panel showRight_Panel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox tbx_SavePath;
        private System.Windows.Forms.Button btn_html;
        private System.Windows.Forms.Button btn_dbname;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_pwd;
        private System.Windows.Forms.TextBox tbx_user;
        private System.Windows.Forms.TextBox tbx_port;
        private System.Windows.Forms.TextBox tbx_dbip;
        private System.Windows.Forms.TextBox tbx_schema;
    }
}