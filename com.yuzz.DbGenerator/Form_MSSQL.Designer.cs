namespace com.yuzz.DbGenerator {
    partial class Form_MSSQL {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MSSQL));
            this.showLeftPanel = new System.Windows.Forms.Panel();
            this.showDBPage = new System.Windows.Forms.TabControl();
            this.tp_表 = new System.Windows.Forms.TabPage();
            this.list_Schema = new System.Windows.Forms.ListBox();
            this.tp_存储过程 = new System.Windows.Forms.TabPage();
            this.list_StoreProcedure = new System.Windows.Forms.ListBox();
            this.img = new System.Windows.Forms.ImageList(this.components);
            this.showContentPanel = new System.Windows.Forms.Panel();
            this.showPage = new System.Windows.Forms.TabControl();
            this.tp_VO = new System.Windows.Forms.TabPage();
            this.tbx_VO_Code = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_Project_SavePath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbx_Prefix = new System.Windows.Forms.TextBox();
            this.btn_BatchExec = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_VO = new System.Windows.Forms.Button();
            this.tbx_VO_Filename = new System.Windows.Forms.TextBox();
            this.btn_SelectFolder = new System.Windows.Forms.Button();
            this.showTopPanel = new System.Windows.Forms.Panel();
            this.pneFile = new System.Windows.Forms.Panel();
            this.tbx_MSSQL_Schema = new System.Windows.Forms.TextBox();
            this.tbx_MSSQL_Pwd = new System.Windows.Forms.TextBox();
            this.tbx_MSSQL_User = new System.Windows.Forms.TextBox();
            this.tbx_MSSQL_Port = new System.Windows.Forms.TextBox();
            this.tbx_MSSQL_ServerIP = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pneButton = new System.Windows.Forms.Panel();
            this.btn_ConnectMSSQL = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dlg_OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.vline = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_授权码管理 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ctxMenu_Select = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxMenu_Select_ImageList = new System.Windows.Forms.ImageList(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_OpenFolder = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbx_AutoSaveToFile = new System.Windows.Forms.CheckBox();
            this.showLeftPanel.SuspendLayout();
            this.showDBPage.SuspendLayout();
            this.tp_表.SuspendLayout();
            this.tp_存储过程.SuspendLayout();
            this.showContentPanel.SuspendLayout();
            this.showPage.SuspendLayout();
            this.tp_VO.SuspendLayout();
            this.panel1.SuspendLayout();
            this.showTopPanel.SuspendLayout();
            this.pneFile.SuspendLayout();
            this.pneButton.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // showLeftPanel
            // 
            this.showLeftPanel.BackColor = System.Drawing.Color.White;
            this.showLeftPanel.Controls.Add(this.showDBPage);
            this.showLeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.showLeftPanel.Location = new System.Drawing.Point(3, 50);
            this.showLeftPanel.Name = "showLeftPanel";
            this.showLeftPanel.Padding = new System.Windows.Forms.Padding(3);
            this.showLeftPanel.Size = new System.Drawing.Size(331, 655);
            this.showLeftPanel.TabIndex = 0;
            // 
            // showDBPage
            // 
            this.showDBPage.Controls.Add(this.tp_表);
            this.showDBPage.Controls.Add(this.tp_存储过程);
            this.showDBPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showDBPage.Location = new System.Drawing.Point(3, 3);
            this.showDBPage.Name = "showDBPage";
            this.showDBPage.SelectedIndex = 0;
            this.showDBPage.Size = new System.Drawing.Size(325, 649);
            this.showDBPage.TabIndex = 9;
            // 
            // tp_表
            // 
            this.tp_表.Controls.Add(this.list_Schema);
            this.tp_表.Location = new System.Drawing.Point(4, 22);
            this.tp_表.Name = "tp_表";
            this.tp_表.Size = new System.Drawing.Size(317, 623);
            this.tp_表.TabIndex = 0;
            this.tp_表.Text = "表";
            this.tp_表.UseVisualStyleBackColor = true;
            // 
            // list_Schema
            // 
            this.list_Schema.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list_Schema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_Schema.FormattingEnabled = true;
            this.list_Schema.ItemHeight = 12;
            this.list_Schema.Location = new System.Drawing.Point(0, 0);
            this.list_Schema.Margin = new System.Windows.Forms.Padding(0);
            this.list_Schema.Name = "list_Schema";
            this.list_Schema.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.list_Schema.Size = new System.Drawing.Size(317, 623);
            this.list_Schema.TabIndex = 8;
            this.list_Schema.SelectedIndexChanged += new System.EventHandler(this.list_Schema_SelectedIndexChanged);
            this.list_Schema.DoubleClick += new System.EventHandler(this.list_Schema_DoubleClick);
            // 
            // tp_存储过程
            // 
            this.tp_存储过程.Controls.Add(this.list_StoreProcedure);
            this.tp_存储过程.Location = new System.Drawing.Point(4, 22);
            this.tp_存储过程.Name = "tp_存储过程";
            this.tp_存储过程.Size = new System.Drawing.Size(317, 623);
            this.tp_存储过程.TabIndex = 1;
            this.tp_存储过程.Text = "存储过程";
            this.tp_存储过程.UseVisualStyleBackColor = true;
            // 
            // list_StoreProcedure
            // 
            this.list_StoreProcedure.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list_StoreProcedure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_StoreProcedure.FormattingEnabled = true;
            this.list_StoreProcedure.ItemHeight = 12;
            this.list_StoreProcedure.Location = new System.Drawing.Point(0, 0);
            this.list_StoreProcedure.Name = "list_StoreProcedure";
            this.list_StoreProcedure.Size = new System.Drawing.Size(317, 623);
            this.list_StoreProcedure.TabIndex = 10;
            // 
            // img
            // 
            this.img.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img.ImageStream")));
            this.img.TransparentColor = System.Drawing.Color.Transparent;
            this.img.Images.SetKeyName(0, "db_default.png");
            this.img.Images.SetKeyName(1, "db.png");
            // 
            // showContentPanel
            // 
            this.showContentPanel.BackColor = System.Drawing.Color.White;
            this.showContentPanel.Controls.Add(this.showPage);
            this.showContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showContentPanel.Location = new System.Drawing.Point(334, 50);
            this.showContentPanel.Name = "showContentPanel";
            this.showContentPanel.Padding = new System.Windows.Forms.Padding(3);
            this.showContentPanel.Size = new System.Drawing.Size(1069, 655);
            this.showContentPanel.TabIndex = 1;
            // 
            // showPage
            // 
            this.showPage.Controls.Add(this.tp_VO);
            this.showPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showPage.ItemSize = new System.Drawing.Size(74, 23);
            this.showPage.Location = new System.Drawing.Point(3, 3);
            this.showPage.Name = "showPage";
            this.showPage.Padding = new System.Drawing.Point(19, 3);
            this.showPage.SelectedIndex = 0;
            this.showPage.Size = new System.Drawing.Size(1063, 649);
            this.showPage.TabIndex = 2;
            // 
            // tp_VO
            // 
            this.tp_VO.Controls.Add(this.tbx_VO_Code);
            this.tp_VO.Controls.Add(this.panel1);
            this.tp_VO.Location = new System.Drawing.Point(4, 27);
            this.tp_VO.Name = "tp_VO";
            this.tp_VO.Size = new System.Drawing.Size(1055, 618);
            this.tp_VO.TabIndex = 1;
            this.tp_VO.Text = "Model Generator";
            this.tp_VO.UseVisualStyleBackColor = true;
            // 
            // tbx_VO_Code
            // 
            this.tbx_VO_Code.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbx_VO_Code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_VO_Code.Location = new System.Drawing.Point(0, 0);
            this.tbx_VO_Code.Name = "tbx_VO_Code";
            this.tbx_VO_Code.Size = new System.Drawing.Size(1055, 513);
            this.tbx_VO_Code.TabIndex = 0;
            this.tbx_VO_Code.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbx_Project_SavePath);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbx_VO_Filename);
            this.panel1.Controls.Add(this.btn_SelectFolder);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 513);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1055, 105);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "工程文件夹：";
            // 
            // tbx_Project_SavePath
            // 
            this.tbx_Project_SavePath.Enabled = false;
            this.tbx_Project_SavePath.Location = new System.Drawing.Point(111, 31);
            this.tbx_Project_SavePath.Name = "tbx_Project_SavePath";
            this.tbx_Project_SavePath.Size = new System.Drawing.Size(564, 21);
            this.tbx_Project_SavePath.TabIndex = 1;
            this.tbx_Project_SavePath.Text = "D:\\bimpApp_wfx\\code\\web\\Hidistro.Web\\db_class";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.DarkGray;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1055, 1);
            this.label6.TabIndex = 5;
            // 
            // tbx_Prefix
            // 
            this.tbx_Prefix.Location = new System.Drawing.Point(1165, 14);
            this.tbx_Prefix.Name = "tbx_Prefix";
            this.tbx_Prefix.Size = new System.Drawing.Size(102, 21);
            this.tbx_Prefix.TabIndex = 4;
            this.tbx_Prefix.Visible = false;
            // 
            // btn_BatchExec
            // 
            this.btn_BatchExec.Enabled = false;
            this.btn_BatchExec.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_BatchExec.Location = new System.Drawing.Point(912, 16);
            this.btn_BatchExec.Name = "btn_BatchExec";
            this.btn_BatchExec.Size = new System.Drawing.Size(111, 28);
            this.btn_BatchExec.TabIndex = 9;
            this.btn_BatchExec.Text = "批量保存";
            this.btn_BatchExec.UseVisualStyleBackColor = true;
            this.btn_BatchExec.Click += new System.EventHandler(this.btn_BatchExec_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Model文件名：";
            // 
            // btn_VO
            // 
            this.btn_VO.Location = new System.Drawing.Point(1055, 13);
            this.btn_VO.Name = "btn_VO";
            this.btn_VO.Size = new System.Drawing.Size(140, 29);
            this.btn_VO.TabIndex = 8;
            this.btn_VO.Text = "生成Model文件(.cs)";
            this.btn_VO.UseVisualStyleBackColor = true;
            this.btn_VO.Visible = false;
            this.btn_VO.Click += new System.EventHandler(this.btn_Build_Clicked);
            // 
            // tbx_VO_Filename
            // 
            this.tbx_VO_Filename.Enabled = false;
            this.tbx_VO_Filename.Location = new System.Drawing.Point(111, 61);
            this.tbx_VO_Filename.Name = "tbx_VO_Filename";
            this.tbx_VO_Filename.Size = new System.Drawing.Size(293, 21);
            this.tbx_VO_Filename.TabIndex = 2;
            // 
            // btn_SelectFolder
            // 
            this.btn_SelectFolder.Location = new System.Drawing.Point(692, 27);
            this.btn_SelectFolder.Name = "btn_SelectFolder";
            this.btn_SelectFolder.Size = new System.Drawing.Size(111, 28);
            this.btn_SelectFolder.TabIndex = 1;
            this.btn_SelectFolder.Text = "选择...";
            this.btn_SelectFolder.UseVisualStyleBackColor = true;
            this.btn_SelectFolder.Click += new System.EventHandler(this.btn_File_Click);
            // 
            // showTopPanel
            // 
            this.showTopPanel.Controls.Add(this.pneFile);
            this.showTopPanel.Controls.Add(this.pneButton);
            this.showTopPanel.Controls.Add(this.label8);
            this.showTopPanel.Controls.Add(this.label4);
            this.showTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.showTopPanel.Location = new System.Drawing.Point(0, 0);
            this.showTopPanel.Name = "showTopPanel";
            this.showTopPanel.Size = new System.Drawing.Size(1403, 50);
            this.showTopPanel.TabIndex = 0;
            // 
            // pneFile
            // 
            this.pneFile.Controls.Add(this.tbx_MSSQL_Schema);
            this.pneFile.Controls.Add(this.tbx_MSSQL_Pwd);
            this.pneFile.Controls.Add(this.tbx_MSSQL_User);
            this.pneFile.Controls.Add(this.tbx_MSSQL_Port);
            this.pneFile.Controls.Add(this.tbx_Prefix);
            this.pneFile.Controls.Add(this.tbx_MSSQL_ServerIP);
            this.pneFile.Controls.Add(this.label9);
            this.pneFile.Controls.Add(this.btn_VO);
            this.pneFile.Controls.Add(this.label10);
            this.pneFile.Controls.Add(this.label11);
            this.pneFile.Controls.Add(this.label12);
            this.pneFile.Controls.Add(this.label13);
            this.pneFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pneFile.Location = new System.Drawing.Point(0, 1);
            this.pneFile.Name = "pneFile";
            this.pneFile.Padding = new System.Windows.Forms.Padding(9);
            this.pneFile.Size = new System.Drawing.Size(1273, 48);
            this.pneFile.TabIndex = 9;
            // 
            // tbx_MSSQL_Schema
            // 
            this.tbx_MSSQL_Schema.Location = new System.Drawing.Point(944, 13);
            this.tbx_MSSQL_Schema.Name = "tbx_MSSQL_Schema";
            this.tbx_MSSQL_Schema.Size = new System.Drawing.Size(93, 21);
            this.tbx_MSSQL_Schema.TabIndex = 22;
            // 
            // tbx_MSSQL_Pwd
            // 
            this.tbx_MSSQL_Pwd.Location = new System.Drawing.Point(738, 13);
            this.tbx_MSSQL_Pwd.Name = "tbx_MSSQL_Pwd";
            this.tbx_MSSQL_Pwd.Size = new System.Drawing.Size(123, 21);
            this.tbx_MSSQL_Pwd.TabIndex = 21;
            // 
            // tbx_MSSQL_User
            // 
            this.tbx_MSSQL_User.Location = new System.Drawing.Point(596, 13);
            this.tbx_MSSQL_User.Name = "tbx_MSSQL_User";
            this.tbx_MSSQL_User.Size = new System.Drawing.Size(71, 21);
            this.tbx_MSSQL_User.TabIndex = 20;
            // 
            // tbx_MSSQL_Port
            // 
            this.tbx_MSSQL_Port.Location = new System.Drawing.Point(413, 13);
            this.tbx_MSSQL_Port.Name = "tbx_MSSQL_Port";
            this.tbx_MSSQL_Port.Size = new System.Drawing.Size(100, 21);
            this.tbx_MSSQL_Port.TabIndex = 19;
            // 
            // tbx_MSSQL_ServerIP
            // 
            this.tbx_MSSQL_ServerIP.Location = new System.Drawing.Point(111, 13);
            this.tbx_MSSQL_ServerIP.Name = "tbx_MSSQL_ServerIP";
            this.tbx_MSSQL_ServerIP.Size = new System.Drawing.Size(231, 21);
            this.tbx_MSSQL_ServerIP.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(876, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "数据库：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(682, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "密码：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(528, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 15;
            this.label11.Text = "用户名：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(357, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 14;
            this.label12.Text = "端口：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 12);
            this.label13.TabIndex = 13;
            this.label13.Text = "数据库地址：";
            // 
            // pneButton
            // 
            this.pneButton.Controls.Add(this.btn_ConnectMSSQL);
            this.pneButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.pneButton.Location = new System.Drawing.Point(1273, 1);
            this.pneButton.Name = "pneButton";
            this.pneButton.Padding = new System.Windows.Forms.Padding(6);
            this.pneButton.Size = new System.Drawing.Size(130, 48);
            this.pneButton.TabIndex = 2;
            // 
            // btn_ConnectMSSQL
            // 
            this.btn_ConnectMSSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ConnectMSSQL.Location = new System.Drawing.Point(6, 6);
            this.btn_ConnectMSSQL.Name = "btn_ConnectMSSQL";
            this.btn_ConnectMSSQL.Size = new System.Drawing.Size(118, 36);
            this.btn_ConnectMSSQL.TabIndex = 2;
            this.btn_ConnectMSSQL.Text = "连接";
            this.btn_ConnectMSSQL.UseVisualStyleBackColor = true;
            this.btn_ConnectMSSQL.Click += new System.EventHandler(this.btn_连接_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.LightGray;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1403, 1);
            this.label8.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DarkGray;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Location = new System.Drawing.Point(0, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1403, 1);
            this.label4.TabIndex = 1;
            // 
            // vline
            // 
            this.vline.Location = new System.Drawing.Point(0, 50);
            this.vline.Name = "vline";
            this.vline.Size = new System.Drawing.Size(3, 691);
            this.vline.TabIndex = 1;
            this.vline.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_授权码管理);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 705);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1400, 36);
            this.panel3.TabIndex = 2;
            // 
            // btn_授权码管理
            // 
            this.btn_授权码管理.Location = new System.Drawing.Point(9, 6);
            this.btn_授权码管理.Name = "btn_授权码管理";
            this.btn_授权码管理.Size = new System.Drawing.Size(97, 25);
            this.btn_授权码管理.TabIndex = 3;
            this.btn_授权码管理.Text = "授权码管理";
            this.btn_授权码管理.UseVisualStyleBackColor = true;
            this.btn_授权码管理.Click += new System.EventHandler(this.btn_授权码管理_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DarkGray;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1400, 1);
            this.label5.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1403, 37);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // ctxMenu_Select
            // 
            this.ctxMenu_Select.Name = "ctxMenu_Select";
            this.ctxMenu_Select.Size = new System.Drawing.Size(61, 4);
            // 
            // ctxMenu_Select_ImageList
            // 
            this.ctxMenu_Select_ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ctxMenu_Select_ImageList.ImageStream")));
            this.ctxMenu_Select_ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ctxMenu_Select_ImageList.Images.SetKeyName(0, "png_pk.png");
            // 
            // btn_OpenFolder
            // 
            this.btn_OpenFolder.Location = new System.Drawing.Point(798, 16);
            this.btn_OpenFolder.Name = "btn_OpenFolder";
            this.btn_OpenFolder.Size = new System.Drawing.Size(111, 28);
            this.btn_OpenFolder.TabIndex = 1;
            this.btn_OpenFolder.Text = "打开文件夹";
            this.btn_OpenFolder.UseVisualStyleBackColor = true;
            this.btn_OpenFolder.Click += new System.EventHandler(this.btn_OpenFolder_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbx_AutoSaveToFile);
            this.groupBox1.Controls.Add(this.btn_BatchExec);
            this.groupBox1.Controls.Add(this.btn_OpenFolder);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(7, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1039, 77);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // cbx_AutoSaveToFile
            // 
            this.cbx_AutoSaveToFile.AutoSize = true;
            this.cbx_AutoSaveToFile.Location = new System.Drawing.Point(12, 0);
            this.cbx_AutoSaveToFile.Name = "cbx_AutoSaveToFile";
            this.cbx_AutoSaveToFile.Size = new System.Drawing.Size(108, 16);
            this.cbx_AutoSaveToFile.TabIndex = 0;
            this.cbx_AutoSaveToFile.Text = "自动保存到文件";
            this.cbx_AutoSaveToFile.UseVisualStyleBackColor = true;
            this.cbx_AutoSaveToFile.CheckedChanged += new System.EventHandler(this.cbx_AutoSaveToFile_CheckedChanged);
            // 
            // Form_MSSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1403, 741);
            this.Controls.Add(this.showContentPanel);
            this.Controls.Add(this.showLeftPanel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.vline);
            this.Controls.Add(this.showTopPanel);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_MSSQL";
            this.Text = "Dapper Model Generator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.showLeftPanel.ResumeLayout(false);
            this.showDBPage.ResumeLayout(false);
            this.tp_表.ResumeLayout(false);
            this.tp_存储过程.ResumeLayout(false);
            this.showContentPanel.ResumeLayout(false);
            this.showPage.ResumeLayout(false);
            this.tp_VO.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.showTopPanel.ResumeLayout(false);
            this.pneFile.ResumeLayout(false);
            this.pneFile.PerformLayout();
            this.pneButton.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel showLeftPanel;
        private System.Windows.Forms.Panel showContentPanel;
        private System.Windows.Forms.Panel showTopPanel;
        private System.Windows.Forms.Button btn_ConnectMSSQL;
        private System.Windows.Forms.OpenFileDialog dlg_OpenFile;
        private System.Windows.Forms.Panel pneFile;
        private System.Windows.Forms.Panel pneButton;
        private System.Windows.Forms.Splitter vline;
        private System.Windows.Forms.TabControl showPage;
        private System.Windows.Forms.TabPage tp_VO;
        private System.Windows.Forms.RichTextBox tbx_VO_Code;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList img;
        private System.Windows.Forms.TextBox tbx_Project_SavePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox list_Schema;
        private System.Windows.Forms.Button btn_VO;
        private System.Windows.Forms.TextBox tbx_VO_Filename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_BatchExec;
        private System.Windows.Forms.Button btn_授权码管理;
        private System.Windows.Forms.TabControl showDBPage;
        private System.Windows.Forms.TabPage tp_表;
        private System.Windows.Forms.TabPage tp_存储过程;
        private System.Windows.Forms.ListBox list_StoreProcedure;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem smenuItem_MySQL;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbx_MSSQL_Schema;
        private System.Windows.Forms.TextBox tbx_MSSQL_Pwd;
        private System.Windows.Forms.TextBox tbx_MSSQL_User;
        private System.Windows.Forms.TextBox tbx_MSSQL_Port;
        private System.Windows.Forms.TextBox tbx_MSSQL_ServerIP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ContextMenuStrip ctxMenu_Select;
        private System.Windows.Forms.ImageList ctxMenu_Select_ImageList;
        private System.Windows.Forms.TextBox tbx_Prefix;
        private System.Windows.Forms.Button btn_SelectFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_OpenFolder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbx_AutoSaveToFile;
    }
}

