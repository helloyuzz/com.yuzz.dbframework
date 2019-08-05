namespace com.cgWorkstudio.BIMP.MySQL {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("数据库");
            this.dgv = new System.Windows.Forms.DataGridView();
            this.rtb_Code = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tvw = new System.Windows.Forms.TreeView();
            this.showLeft_Panel = new System.Windows.Forms.Panel();
            this.showRight_Panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.showContent_Panel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.showTop_Panel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.showLeft_Panel.SuspendLayout();
            this.showRight_Panel.SuspendLayout();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv.Location = new System.Drawing.Point(5, 201);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(680, 181);
            this.dgv.TabIndex = 0;
            // 
            // rtb_Code
            // 
            this.rtb_Code.BackColor = System.Drawing.Color.White;
            this.rtb_Code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Code.Location = new System.Drawing.Point(2, 75);
            this.rtb_Code.Name = "rtb_Code";
            this.rtb_Code.Size = new System.Drawing.Size(686, 211);
            this.rtb_Code.TabIndex = 1;
            this.rtb_Code.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Connect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(956, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 675);
            this.panel1.TabIndex = 2;
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(20, 20);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(109, 23);
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
            this.showContent_Panel.Size = new System.Drawing.Size(690, 288);
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
            this.panel2.Size = new System.Drawing.Size(686, 73);
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
            this.showTop_Panel.Controls.Add(this.panel4);
            this.showTop_Panel.Controls.Add(this.comboBox1);
            this.showTop_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.showTop_Panel.Location = new System.Drawing.Point(0, 0);
            this.showTop_Panel.Name = "showTop_Panel";
            this.showTop_Panel.Padding = new System.Windows.Forms.Padding(5);
            this.showTop_Panel.Size = new System.Drawing.Size(690, 387);
            this.showTop_Panel.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.textBox1);
            this.panel4.Controls.Add(this.comboBox2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(5, 25);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(1);
            this.panel4.Size = new System.Drawing.Size(680, 176);
            this.panel4.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(1, 1);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(678, 153);
            this.textBox1.TabIndex = 5;
            // 
            // comboBox2
            // 
            this.comboBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.comboBox2.Location = new System.Drawing.Point(1, 154);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(678, 21);
            this.comboBox2.TabIndex = 4;
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
            this.comboBox1.Size = new System.Drawing.Size(680, 20);
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
            treeNode1.Name = "rootNode";
            treeNode1.Text = "数据库";
            this.tvw.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvw.Size = new System.Drawing.Size(260, 675);
            this.tvw.TabIndex = 2;
            this.tvw.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvw_AfterSelect);
            // 
            // showLeft_Panel
            // 
            this.showLeft_Panel.Controls.Add(this.tvw);
            this.showLeft_Panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.showLeft_Panel.Location = new System.Drawing.Point(6, 6);
            this.showLeft_Panel.Name = "showLeft_Panel";
            this.showLeft_Panel.Size = new System.Drawing.Size(260, 675);
            this.showLeft_Panel.TabIndex = 5;
            // 
            // showRight_Panel
            // 
            this.showRight_Panel.Controls.Add(this.showContent_Panel);
            this.showRight_Panel.Controls.Add(this.showTop_Panel);
            this.showRight_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showRight_Panel.Location = new System.Drawing.Point(266, 6);
            this.showRight_Panel.Name = "showRight_Panel";
            this.showRight_Panel.Size = new System.Drawing.Size(690, 675);
            this.showRight_Panel.TabIndex = 6;
            // 
            // Form_MySQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 687);
            this.Controls.Add(this.showRight_Panel);
            this.Controls.Add(this.showLeft_Panel);
            this.Controls.Add(this.panel1);
            this.Name = "Form_MySQL";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MySQL DbGenerator v1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_MySQL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.showContent_Panel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.showTop_Panel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.showLeft_Panel.ResumeLayout(false);
            this.showRight_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.RichTextBox rtb_Code;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel showContent_Panel;
        private System.Windows.Forms.Button btn_Build;
        private System.Windows.Forms.TextBox tbx_TableName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel showTop_Panel;
        private System.Windows.Forms.Panel panel4;
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
        private System.Windows.Forms.TextBox comboBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}