﻿namespace com.yuzz.DbGenerator {
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("数据库");
            this.dgv = new System.Windows.Forms.DataGridView();
            this.rtb_Code = new System.Windows.Forms.RichTextBox();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.showContent_Panel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_dbname = new System.Windows.Forms.Button();
            this.btn_html = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Build = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_TableName = new System.Windows.Forms.TextBox();
            this.tbx_SavePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.showTop_Panel = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rtb_MultiSQLCode = new System.Windows.Forms.RichTextBox();
            this.tvw = new System.Windows.Forms.TreeView();
            this.showLeft_Panel = new System.Windows.Forms.Panel();
            this.showRight_Panel = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tp_voBuilder = new System.Windows.Forms.TabPage();
            this.tp_selectBuilder = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tp_VisualEditor = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_BuildSQL = new System.Windows.Forms.Button();
            this.btn_TestSQL = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rtx_WHERE = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.rtx_ORDERBY = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.rtx_FORM = new System.Windows.Forms.RichTextBox();
            this.rtx_SELECT = new System.Windows.Forms.RichTextBox();
            this.tp_TestSQL = new System.Windows.Forms.TabPage();
            this.rtx_SQLCode = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbx_schema = new System.Windows.Forms.TextBox();
            this.tbx_pwd = new System.Windows.Forms.TextBox();
            this.tbx_user = new System.Windows.Forms.TextBox();
            this.tbx_port = new System.Windows.Forms.TextBox();
            this.tbx_dbip = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.dgv_Join = new System.Windows.Forms.DataGridView();
            this.dgvColumn_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumn_OP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenu_Join = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolstrip_Join = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.showContent_Panel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.showTop_Panel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.showLeft_Panel.SuspendLayout();
            this.showRight_Panel.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tp_voBuilder.SuspendLayout();
            this.tp_selectBuilder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tp_VisualEditor.SuspendLayout();
            this.tp_TestSQL.SuspendLayout();
            this.panel3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Join)).BeginInit();
            this.contextMenu_Join.SuspendLayout();
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv.Location = new System.Drawing.Point(3, 3);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(1007, 345);
            this.dgv.TabIndex = 0;
            // 
            // rtb_Code
            // 
            this.rtb_Code.BackColor = System.Drawing.Color.White;
            this.rtb_Code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Code.Location = new System.Drawing.Point(2, 75);
            this.rtb_Code.Name = "rtb_Code";
            this.rtb_Code.Size = new System.Drawing.Size(1027, 76);
            this.rtb_Code.TabIndex = 1;
            this.rtb_Code.Text = "";
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(1001, 16);
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
            this.showContent_Panel.Location = new System.Drawing.Point(3, 390);
            this.showContent_Panel.Name = "showContent_Panel";
            this.showContent_Panel.Padding = new System.Windows.Forms.Padding(2);
            this.showContent_Panel.Size = new System.Drawing.Size(1031, 153);
            this.showContent_Panel.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btn_dbname);
            this.panel2.Controls.Add(this.btn_html);
            this.panel2.Controls.Add(this.btn_Save);
            this.panel2.Controls.Add(this.btn_Build);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tbx_TableName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1027, 73);
            this.panel2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(798, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
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
            // tbx_SavePath
            // 
            this.tbx_SavePath.Location = new System.Drawing.Point(493, 59);
            this.tbx_SavePath.Multiline = true;
            this.tbx_SavePath.Name = "tbx_SavePath";
            this.tbx_SavePath.Size = new System.Drawing.Size(487, 35);
            this.tbx_SavePath.TabIndex = 4;
            this.tbx_SavePath.Text = "D:\\svn_shtcrane\\com.sht.library\\db_class";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "class文件保存路径：";
            // 
            // showTop_Panel
            // 
            this.showTop_Panel.Controls.Add(this.tabControl1);
            this.showTop_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.showTop_Panel.Location = new System.Drawing.Point(3, 3);
            this.showTop_Panel.Name = "showTop_Panel";
            this.showTop_Panel.Padding = new System.Windows.Forms.Padding(5);
            this.showTop_Panel.Size = new System.Drawing.Size(1031, 387);
            this.showTop_Panel.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(5, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1021, 377);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgv);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1013, 351);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据库字段属性";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rtb_MultiSQLCode);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1013, 351);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "多表SQL代码（复杂查询，直接粘贴SQL代码）";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rtb_MultiSQLCode
            // 
            this.rtb_MultiSQLCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_MultiSQLCode.Location = new System.Drawing.Point(3, 3);
            this.rtb_MultiSQLCode.Name = "rtb_MultiSQLCode";
            this.rtb_MultiSQLCode.Size = new System.Drawing.Size(1007, 345);
            this.rtb_MultiSQLCode.TabIndex = 0;
            this.rtb_MultiSQLCode.Text = "";
            // 
            // tvw
            // 
            this.tvw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvw.HideSelection = false;
            this.tvw.Location = new System.Drawing.Point(0, 0);
            this.tvw.Name = "tvw";
            treeNode4.Name = "rootNode";
            treeNode4.Text = "数据库";
            this.tvw.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
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
            this.showRight_Panel.Controls.Add(this.tabControl2);
            this.showRight_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showRight_Panel.Location = new System.Drawing.Point(266, 106);
            this.showRight_Panel.Name = "showRight_Panel";
            this.showRight_Panel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.showRight_Panel.Size = new System.Drawing.Size(1051, 575);
            this.showRight_Panel.TabIndex = 6;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tp_voBuilder);
            this.tabControl2.Controls.Add(this.tp_selectBuilder);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1045, 572);
            this.tabControl2.TabIndex = 9;
            // 
            // tp_voBuilder
            // 
            this.tp_voBuilder.Controls.Add(this.showContent_Panel);
            this.tp_voBuilder.Controls.Add(this.showTop_Panel);
            this.tp_voBuilder.Location = new System.Drawing.Point(4, 22);
            this.tp_voBuilder.Name = "tp_voBuilder";
            this.tp_voBuilder.Padding = new System.Windows.Forms.Padding(3);
            this.tp_voBuilder.Size = new System.Drawing.Size(1037, 546);
            this.tp_voBuilder.TabIndex = 0;
            this.tp_voBuilder.Text = "vo Builder";
            this.tp_voBuilder.UseVisualStyleBackColor = true;
            // 
            // tp_selectBuilder
            // 
            this.tp_selectBuilder.Controls.Add(this.splitContainer1);
            this.tp_selectBuilder.Location = new System.Drawing.Point(4, 22);
            this.tp_selectBuilder.Name = "tp_selectBuilder";
            this.tp_selectBuilder.Padding = new System.Windows.Forms.Padding(3);
            this.tp_selectBuilder.Size = new System.Drawing.Size(1037, 546);
            this.tp_selectBuilder.TabIndex = 1;
            this.tp_selectBuilder.Text = "select Builder";
            this.tp_selectBuilder.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.tabControl3);
            this.splitContainer1.Size = new System.Drawing.Size(1031, 540);
            this.splitContainer1.SplitterDistance = 140;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tp_VisualEditor);
            this.tabControl3.Controls.Add(this.tp_TestSQL);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(0, 0);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(1031, 396);
            this.tabControl3.TabIndex = 6;
            // 
            // tp_VisualEditor
            // 
            this.tp_VisualEditor.Controls.Add(this.label14);
            this.tp_VisualEditor.Controls.Add(this.textBox2);
            this.tp_VisualEditor.Controls.Add(this.textBox1);
            this.tp_VisualEditor.Controls.Add(this.btn_BuildSQL);
            this.tp_VisualEditor.Controls.Add(this.btn_TestSQL);
            this.tp_VisualEditor.Controls.Add(this.label8);
            this.tp_VisualEditor.Controls.Add(this.label12);
            this.tp_VisualEditor.Controls.Add(this.label13);
            this.tp_VisualEditor.Controls.Add(this.label9);
            this.tp_VisualEditor.Controls.Add(this.rtx_WHERE);
            this.tp_VisualEditor.Controls.Add(this.label10);
            this.tp_VisualEditor.Controls.Add(this.rtx_ORDERBY);
            this.tp_VisualEditor.Controls.Add(this.label11);
            this.tp_VisualEditor.Controls.Add(this.rtx_FORM);
            this.tp_VisualEditor.Controls.Add(this.rtx_SELECT);
            this.tp_VisualEditor.Location = new System.Drawing.Point(4, 22);
            this.tp_VisualEditor.Name = "tp_VisualEditor";
            this.tp_VisualEditor.Padding = new System.Windows.Forms.Padding(3);
            this.tp_VisualEditor.Size = new System.Drawing.Size(1023, 370);
            this.tp_VisualEditor.TabIndex = 0;
            this.tp_VisualEditor.Text = "可视化编辑";
            this.tp_VisualEditor.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(897, 294);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 12);
            this.label14.TabIndex = 8;
            this.label14.Text = "(rows.)";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(842, 290);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(45, 21);
            this.textBox2.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(791, 290);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(45, 21);
            this.textBox1.TabIndex = 7;
            // 
            // btn_BuildSQL
            // 
            this.btn_BuildSQL.Location = new System.Drawing.Point(29, 188);
            this.btn_BuildSQL.Name = "btn_BuildSQL";
            this.btn_BuildSQL.Size = new System.Drawing.Size(78, 34);
            this.btn_BuildSQL.TabIndex = 6;
            this.btn_BuildSQL.Text = "Build SQL";
            this.btn_BuildSQL.UseVisualStyleBackColor = true;
            // 
            // btn_TestSQL
            // 
            this.btn_TestSQL.Location = new System.Drawing.Point(29, 148);
            this.btn_TestSQL.Name = "btn_TestSQL";
            this.btn_TestSQL.Size = new System.Drawing.Size(78, 34);
            this.btn_TestSQL.TabIndex = 5;
            this.btn_TestSQL.Text = "Test SQL";
            this.btn_TestSQL.UseVisualStyleBackColor = true;
            this.btn_TestSQL.Click += new System.EventHandler(this.btn_TestSQL_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label8.Location = new System.Drawing.Point(6, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "SELECT";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(59, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 4;
            this.label12.Text = "<Distinct>";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label13.Location = new System.Drawing.Point(725, 294);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "LIMIT";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label9.Location = new System.Drawing.Point(426, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "FROM";
            // 
            // rtx_WHERE
            // 
            this.rtx_WHERE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtx_WHERE.Location = new System.Drawing.Point(485, 151);
            this.rtx_WHERE.Name = "rtx_WHERE";
            this.rtx_WHERE.ReadOnly = true;
            this.rtx_WHERE.Size = new System.Drawing.Size(227, 212);
            this.rtx_WHERE.TabIndex = 3;
            this.rtx_WHERE.Text = "";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label10.Location = new System.Drawing.Point(426, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "WHERE";
            // 
            // rtx_ORDERBY
            // 
            this.rtx_ORDERBY.Location = new System.Drawing.Point(791, 151);
            this.rtx_ORDERBY.Name = "rtx_ORDERBY";
            this.rtx_ORDERBY.ReadOnly = true;
            this.rtx_ORDERBY.Size = new System.Drawing.Size(220, 123);
            this.rtx_ORDERBY.TabIndex = 2;
            this.rtx_ORDERBY.Text = "";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label11.Location = new System.Drawing.Point(724, 159);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "ORDER BY";
            // 
            // rtx_FORM
            // 
            this.rtx_FORM.Location = new System.Drawing.Point(485, 17);
            this.rtx_FORM.Name = "rtx_FORM";
            this.rtx_FORM.ReadOnly = true;
            this.rtx_FORM.Size = new System.Drawing.Size(526, 109);
            this.rtx_FORM.TabIndex = 2;
            this.rtx_FORM.Text = "";
            // 
            // rtx_SELECT
            // 
            this.rtx_SELECT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtx_SELECT.Location = new System.Drawing.Point(130, 17);
            this.rtx_SELECT.Name = "rtx_SELECT";
            this.rtx_SELECT.ReadOnly = true;
            this.rtx_SELECT.Size = new System.Drawing.Size(290, 346);
            this.rtx_SELECT.TabIndex = 1;
            this.rtx_SELECT.Text = "";
            // 
            // tp_TestSQL
            // 
            this.tp_TestSQL.Controls.Add(this.rtx_SQLCode);
            this.tp_TestSQL.Location = new System.Drawing.Point(4, 22);
            this.tp_TestSQL.Name = "tp_TestSQL";
            this.tp_TestSQL.Padding = new System.Windows.Forms.Padding(3);
            this.tp_TestSQL.Size = new System.Drawing.Size(1023, 370);
            this.tp_TestSQL.TabIndex = 1;
            this.tp_TestSQL.Text = "Test SQL预览";
            this.tp_TestSQL.UseVisualStyleBackColor = true;
            // 
            // rtx_SQLCode
            // 
            this.rtx_SQLCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtx_SQLCode.Location = new System.Drawing.Point(3, 3);
            this.rtx_SQLCode.Name = "rtx_SQLCode";
            this.rtx_SQLCode.Size = new System.Drawing.Size(1017, 364);
            this.rtx_SQLCode.TabIndex = 0;
            this.rtx_SQLCode.Text = "";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbx_schema);
            this.panel3.Controls.Add(this.tbx_pwd);
            this.panel3.Controls.Add(this.tbx_user);
            this.panel3.Controls.Add(this.tbx_SavePath);
            this.panel3.Controls.Add(this.label2);
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
            this.panel3.Size = new System.Drawing.Size(1311, 100);
            this.panel3.TabIndex = 7;
            // 
            // tbx_schema
            // 
            this.tbx_schema.Location = new System.Drawing.Point(110, 59);
            this.tbx_schema.Name = "tbx_schema";
            this.tbx_schema.Size = new System.Drawing.Size(231, 21);
            this.tbx_schema.TabIndex = 12;
            // 
            // tbx_pwd
            // 
            this.tbx_pwd.Location = new System.Drawing.Point(880, 18);
            this.tbx_pwd.Name = "tbx_pwd";
            this.tbx_pwd.Size = new System.Drawing.Size(100, 21);
            this.tbx_pwd.TabIndex = 11;
            // 
            // tbx_user
            // 
            this.tbx_user.Location = new System.Drawing.Point(638, 18);
            this.tbx_user.Name = "tbx_user";
            this.tbx_user.Size = new System.Drawing.Size(118, 21);
            this.tbx_user.TabIndex = 10;
            // 
            // tbx_port
            // 
            this.tbx_port.Location = new System.Drawing.Point(419, 18);
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
            this.label6.Location = new System.Drawing.Point(833, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "密码：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(579, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "用户名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(372, 22);
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem1.Text = "添加";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.dgv_Join);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(724, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 140);
            this.panel1.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(307, 23);
            this.label15.TabIndex = 0;
            this.label15.Text = "关联查询";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_Join
            // 
            this.dgv_Join.AllowUserToAddRows = false;
            this.dgv_Join.AllowUserToDeleteRows = false;
            this.dgv_Join.AllowUserToResizeRows = false;
            this.dgv_Join.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Join.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Join.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Join.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColumn_Title,
            this.dgvColumn_OP});
            this.dgv_Join.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Join.Location = new System.Drawing.Point(0, 23);
            this.dgv_Join.Name = "dgv_Join";
            this.dgv_Join.ReadOnly = true;
            this.dgv_Join.RowHeadersVisible = false;
            this.dgv_Join.RowTemplate.Height = 23;
            this.dgv_Join.Size = new System.Drawing.Size(307, 117);
            this.dgv_Join.TabIndex = 1;
            this.dgv_Join.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Join_CellClick);
            // 
            // dgvColumn_Title
            // 
            this.dgvColumn_Title.HeaderText = "标题";
            this.dgvColumn_Title.Name = "dgvColumn_Title";
            // 
            // dgvColumn_OP
            // 
            this.dgvColumn_OP.HeaderText = "操作";
            this.dgvColumn_OP.Name = "dgvColumn_OP";
            this.dgvColumn_OP.Visible = false;
            // 
            // contextMenu_Join
            // 
            this.contextMenu_Join.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstrip_Join});
            this.contextMenu_Join.Name = "contextMenu_Join";
            this.contextMenu_Join.Size = new System.Drawing.Size(181, 48);
            // 
            // toolstrip_Join
            // 
            this.toolstrip_Join.Name = "toolstrip_Join";
            this.toolstrip_Join.Size = new System.Drawing.Size(180, 22);
            this.toolstrip_Join.Text = "删除";
            this.toolstrip_Join.Click += new System.EventHandler(this.toolstrip_Join_Click);
            // 
            // Form_MySQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 687);
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.showLeft_Panel.ResumeLayout(false);
            this.showRight_Panel.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tp_voBuilder.ResumeLayout(false);
            this.tp_selectBuilder.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tp_VisualEditor.ResumeLayout(false);
            this.tp_VisualEditor.PerformLayout();
            this.tp_TestSQL.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Join)).EndInit();
            this.contextMenu_Join.ResumeLayout(false);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox rtb_MultiSQLCode;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tp_voBuilder;
        private System.Windows.Forms.TabPage tp_selectBuilder;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox rtx_WHERE;
        private System.Windows.Forms.RichTextBox rtx_ORDERBY;
        private System.Windows.Forms.RichTextBox rtx_FORM;
        private System.Windows.Forms.RichTextBox rtx_SELECT;
        private System.Windows.Forms.RichTextBox rtx_SQLCode;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tp_VisualEditor;
        private System.Windows.Forms.Button btn_BuildSQL;
        private System.Windows.Forms.Button btn_TestSQL;
        private System.Windows.Forms.TabPage tp_TestSQL;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dgv_Join;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumn_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumn_OP;
        private System.Windows.Forms.ContextMenuStrip contextMenu_Join;
        private System.Windows.Forms.ToolStripMenuItem toolstrip_Join;
    }
}