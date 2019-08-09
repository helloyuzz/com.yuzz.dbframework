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
            this.lst_表 = new System.Windows.Forms.ListBox();
            this.tp_存储过程 = new System.Windows.Forms.TabPage();
            this.lst_存储过程 = new System.Windows.Forms.ListBox();
            this.img = new System.Windows.Forms.ImageList(this.components);
            this.showContentPanel = new System.Windows.Forms.Panel();
            this.showPage = new System.Windows.Forms.TabControl();
            this.tp_DAO = new System.Windows.Forms.TabPage();
            this.tbx_DAO_Code = new System.Windows.Forms.RichTextBox();
            this.tp_load = new System.Windows.Forms.TabPage();
            this.tbx_Load = new System.Windows.Forms.RichTextBox();
            this.tp_save = new System.Windows.Forms.TabPage();
            this.tbx_Save = new System.Windows.Forms.RichTextBox();
            this.tp_VO = new System.Windows.Forms.TabPage();
            this.tbx_VO_Code = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tbx_VOFile = new System.Windows.Forms.TextBox();
            this.btn_File = new System.Windows.Forms.Button();
            this.tp_DGV = new System.Windows.Forms.TabPage();
            this.tbx_DGV_Code = new System.Windows.Forms.RichTextBox();
            this.tp_Form = new System.Windows.Forms.TabPage();
            this.tbx_Form_Code = new System.Windows.Forms.RichTextBox();
            this.tp_Field = new System.Windows.Forms.TabPage();
            this.tbx_字段列表 = new System.Windows.Forms.RichTextBox();
            this.tp_TableName = new System.Windows.Forms.TabPage();
            this.tbx_表名 = new System.Windows.Forms.RichTextBox();
            this.tp_常用数据 = new System.Windows.Forms.TabPage();
            this.tbx_常用数据 = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_aspnet = new System.Windows.Forms.Button();
            this.btn_table = new System.Windows.Forms.Button();
            this.btn_反向SQL = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_XmlInclude = new System.Windows.Forms.Button();
            this.btn_SoapTypes = new System.Windows.Forms.Button();
            this.btn_BatchExec = new System.Windows.Forms.Button();
            this.btn_VO = new System.Windows.Forms.Button();
            this.btn_DAO = new System.Windows.Forms.Button();
            this.btn_选择文件 = new System.Windows.Forms.Button();
            this.tbx_类前缀 = new System.Windows.Forms.TextBox();
            this.tbx_SavePath_VO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_类前缀 = new System.Windows.Forms.Label();
            this.showTopPanel = new System.Windows.Forms.Panel();
            this.pneFile = new System.Windows.Forms.Panel();
            this.tbx_Text = new System.Windows.Forms.ComboBox();
            this.pneButton = new System.Windows.Forms.Panel();
            this.btn_连接 = new System.Windows.Forms.Button();
            this.pneLeft = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dlg_OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.vline = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_授权码管理 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuItem_MySQL = new System.Windows.Forms.ToolStripMenuItem();
            this.showLeftPanel.SuspendLayout();
            this.showDBPage.SuspendLayout();
            this.tp_表.SuspendLayout();
            this.tp_存储过程.SuspendLayout();
            this.showContentPanel.SuspendLayout();
            this.showPage.SuspendLayout();
            this.tp_DAO.SuspendLayout();
            this.tp_load.SuspendLayout();
            this.tp_save.SuspendLayout();
            this.tp_VO.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tp_DGV.SuspendLayout();
            this.tp_Form.SuspendLayout();
            this.tp_Field.SuspendLayout();
            this.tp_TableName.SuspendLayout();
            this.tp_常用数据.SuspendLayout();
            this.panel2.SuspendLayout();
            this.showTopPanel.SuspendLayout();
            this.pneFile.SuspendLayout();
            this.pneButton.SuspendLayout();
            this.pneLeft.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // showLeftPanel
            // 
            this.showLeftPanel.BackColor = System.Drawing.Color.White;
            this.showLeftPanel.Controls.Add(this.showDBPage);
            this.showLeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.showLeftPanel.Location = new System.Drawing.Point(3, 75);
            this.showLeftPanel.Name = "showLeftPanel";
            this.showLeftPanel.Padding = new System.Windows.Forms.Padding(3);
            this.showLeftPanel.Size = new System.Drawing.Size(331, 478);
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
            this.showDBPage.Size = new System.Drawing.Size(325, 472);
            this.showDBPage.TabIndex = 9;
            // 
            // tp_表
            // 
            this.tp_表.Controls.Add(this.lst_表);
            this.tp_表.Location = new System.Drawing.Point(4, 22);
            this.tp_表.Name = "tp_表";
            this.tp_表.Size = new System.Drawing.Size(317, 446);
            this.tp_表.TabIndex = 0;
            this.tp_表.Text = "表";
            this.tp_表.UseVisualStyleBackColor = true;
            // 
            // lst_表
            // 
            this.lst_表.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lst_表.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_表.FormattingEnabled = true;
            this.lst_表.ItemHeight = 12;
            this.lst_表.Location = new System.Drawing.Point(0, 0);
            this.lst_表.Margin = new System.Windows.Forms.Padding(0);
            this.lst_表.Name = "lst_表";
            this.lst_表.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lst_表.Size = new System.Drawing.Size(317, 446);
            this.lst_表.TabIndex = 8;
            // 
            // tp_存储过程
            // 
            this.tp_存储过程.Controls.Add(this.lst_存储过程);
            this.tp_存储过程.Location = new System.Drawing.Point(4, 22);
            this.tp_存储过程.Name = "tp_存储过程";
            this.tp_存储过程.Size = new System.Drawing.Size(317, 446);
            this.tp_存储过程.TabIndex = 1;
            this.tp_存储过程.Text = "存储过程";
            this.tp_存储过程.UseVisualStyleBackColor = true;
            // 
            // lst_存储过程
            // 
            this.lst_存储过程.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lst_存储过程.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_存储过程.FormattingEnabled = true;
            this.lst_存储过程.ItemHeight = 12;
            this.lst_存储过程.Location = new System.Drawing.Point(0, 0);
            this.lst_存储过程.Name = "lst_存储过程";
            this.lst_存储过程.Size = new System.Drawing.Size(317, 446);
            this.lst_存储过程.TabIndex = 10;
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
            this.showContentPanel.Controls.Add(this.panel2);
            this.showContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showContentPanel.Location = new System.Drawing.Point(334, 75);
            this.showContentPanel.Name = "showContentPanel";
            this.showContentPanel.Padding = new System.Windows.Forms.Padding(3);
            this.showContentPanel.Size = new System.Drawing.Size(766, 478);
            this.showContentPanel.TabIndex = 1;
            // 
            // showPage
            // 
            this.showPage.Controls.Add(this.tp_DAO);
            this.showPage.Controls.Add(this.tp_load);
            this.showPage.Controls.Add(this.tp_save);
            this.showPage.Controls.Add(this.tp_VO);
            this.showPage.Controls.Add(this.tp_DGV);
            this.showPage.Controls.Add(this.tp_Form);
            this.showPage.Controls.Add(this.tp_Field);
            this.showPage.Controls.Add(this.tp_TableName);
            this.showPage.Controls.Add(this.tp_常用数据);
            this.showPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showPage.ItemSize = new System.Drawing.Size(74, 23);
            this.showPage.Location = new System.Drawing.Point(3, 168);
            this.showPage.Name = "showPage";
            this.showPage.Padding = new System.Drawing.Point(19, 3);
            this.showPage.SelectedIndex = 0;
            this.showPage.Size = new System.Drawing.Size(760, 307);
            this.showPage.TabIndex = 2;
            // 
            // tp_DAO
            // 
            this.tp_DAO.Controls.Add(this.tbx_DAO_Code);
            this.tp_DAO.Location = new System.Drawing.Point(4, 27);
            this.tp_DAO.Name = "tp_DAO";
            this.tp_DAO.Size = new System.Drawing.Size(752, 276);
            this.tp_DAO.TabIndex = 0;
            this.tp_DAO.Text = "DAO";
            this.tp_DAO.UseVisualStyleBackColor = true;
            // 
            // tbx_DAO_Code
            // 
            this.tbx_DAO_Code.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbx_DAO_Code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_DAO_Code.Location = new System.Drawing.Point(0, 0);
            this.tbx_DAO_Code.Name = "tbx_DAO_Code";
            this.tbx_DAO_Code.Size = new System.Drawing.Size(752, 276);
            this.tbx_DAO_Code.TabIndex = 0;
            this.tbx_DAO_Code.Text = "";
            // 
            // tp_load
            // 
            this.tp_load.Controls.Add(this.tbx_Load);
            this.tp_load.Location = new System.Drawing.Point(4, 27);
            this.tp_load.Name = "tp_load";
            this.tp_load.Size = new System.Drawing.Size(752, 276);
            this.tp_load.TabIndex = 7;
            this.tp_load.Text = "Asp.net Load";
            this.tp_load.UseVisualStyleBackColor = true;
            // 
            // tbx_Load
            // 
            this.tbx_Load.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_Load.Location = new System.Drawing.Point(0, 0);
            this.tbx_Load.Name = "tbx_Load";
            this.tbx_Load.Size = new System.Drawing.Size(752, 276);
            this.tbx_Load.TabIndex = 0;
            this.tbx_Load.Text = "";
            // 
            // tp_save
            // 
            this.tp_save.Controls.Add(this.tbx_Save);
            this.tp_save.Location = new System.Drawing.Point(4, 27);
            this.tp_save.Name = "tp_save";
            this.tp_save.Size = new System.Drawing.Size(752, 276);
            this.tp_save.TabIndex = 8;
            this.tp_save.Text = "Asp.net Save";
            this.tp_save.UseVisualStyleBackColor = true;
            // 
            // tbx_Save
            // 
            this.tbx_Save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_Save.Location = new System.Drawing.Point(0, 0);
            this.tbx_Save.Name = "tbx_Save";
            this.tbx_Save.Size = new System.Drawing.Size(752, 276);
            this.tbx_Save.TabIndex = 2;
            this.tbx_Save.Text = "";
            // 
            // tp_VO
            // 
            this.tp_VO.Controls.Add(this.tbx_VO_Code);
            this.tp_VO.Controls.Add(this.panel1);
            this.tp_VO.Location = new System.Drawing.Point(4, 27);
            this.tp_VO.Name = "tp_VO";
            this.tp_VO.Size = new System.Drawing.Size(752, 276);
            this.tp_VO.TabIndex = 1;
            this.tp_VO.Text = "VO";
            this.tp_VO.UseVisualStyleBackColor = true;
            // 
            // tbx_VO_Code
            // 
            this.tbx_VO_Code.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbx_VO_Code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_VO_Code.Location = new System.Drawing.Point(0, 0);
            this.tbx_VO_Code.Name = "tbx_VO_Code";
            this.tbx_VO_Code.Size = new System.Drawing.Size(752, 208);
            this.tbx_VO_Code.TabIndex = 0;
            this.tbx_VO_Code.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.tbx_VOFile);
            this.panel1.Controls.Add(this.btn_File);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 208);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(752, 68);
            this.panel1.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.DarkGray;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(752, 1);
            this.label6.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "文件名：";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(68, 40);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(168, 16);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "打开文件夹（保存成功时）";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // tbx_VOFile
            // 
            this.tbx_VOFile.Location = new System.Drawing.Point(68, 13);
            this.tbx_VOFile.Name = "tbx_VOFile";
            this.tbx_VOFile.Size = new System.Drawing.Size(293, 21);
            this.tbx_VOFile.TabIndex = 2;
            // 
            // btn_File
            // 
            this.btn_File.Location = new System.Drawing.Point(367, 13);
            this.btn_File.Name = "btn_File";
            this.btn_File.Size = new System.Drawing.Size(111, 31);
            this.btn_File.TabIndex = 1;
            this.btn_File.Text = "保存到文件";
            this.btn_File.UseVisualStyleBackColor = true;
            this.btn_File.Click += new System.EventHandler(this.btn_File_Click);
            // 
            // tp_DGV
            // 
            this.tp_DGV.Controls.Add(this.tbx_DGV_Code);
            this.tp_DGV.Location = new System.Drawing.Point(4, 27);
            this.tp_DGV.Name = "tp_DGV";
            this.tp_DGV.Size = new System.Drawing.Size(752, 276);
            this.tp_DGV.TabIndex = 2;
            this.tp_DGV.Text = "DGV";
            this.tp_DGV.UseVisualStyleBackColor = true;
            // 
            // tbx_DGV_Code
            // 
            this.tbx_DGV_Code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_DGV_Code.Location = new System.Drawing.Point(0, 0);
            this.tbx_DGV_Code.Name = "tbx_DGV_Code";
            this.tbx_DGV_Code.Size = new System.Drawing.Size(752, 276);
            this.tbx_DGV_Code.TabIndex = 0;
            this.tbx_DGV_Code.Text = "";
            // 
            // tp_Form
            // 
            this.tp_Form.Controls.Add(this.tbx_Form_Code);
            this.tp_Form.Location = new System.Drawing.Point(4, 27);
            this.tp_Form.Name = "tp_Form";
            this.tp_Form.Size = new System.Drawing.Size(752, 276);
            this.tp_Form.TabIndex = 3;
            this.tp_Form.Text = "Create Form Object";
            this.tp_Form.UseVisualStyleBackColor = true;
            // 
            // tbx_Form_Code
            // 
            this.tbx_Form_Code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_Form_Code.Location = new System.Drawing.Point(0, 0);
            this.tbx_Form_Code.Name = "tbx_Form_Code";
            this.tbx_Form_Code.Size = new System.Drawing.Size(752, 276);
            this.tbx_Form_Code.TabIndex = 0;
            this.tbx_Form_Code.Text = "";
            // 
            // tp_Field
            // 
            this.tp_Field.Controls.Add(this.tbx_字段列表);
            this.tp_Field.Location = new System.Drawing.Point(4, 27);
            this.tp_Field.Name = "tp_Field";
            this.tp_Field.Size = new System.Drawing.Size(752, 276);
            this.tp_Field.TabIndex = 4;
            this.tp_Field.Text = "字段列表";
            this.tp_Field.UseVisualStyleBackColor = true;
            // 
            // tbx_字段列表
            // 
            this.tbx_字段列表.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_字段列表.Location = new System.Drawing.Point(0, 0);
            this.tbx_字段列表.Name = "tbx_字段列表";
            this.tbx_字段列表.Size = new System.Drawing.Size(752, 276);
            this.tbx_字段列表.TabIndex = 0;
            this.tbx_字段列表.Text = "";
            // 
            // tp_TableName
            // 
            this.tp_TableName.Controls.Add(this.tbx_表名);
            this.tp_TableName.Location = new System.Drawing.Point(4, 27);
            this.tp_TableName.Name = "tp_TableName";
            this.tp_TableName.Size = new System.Drawing.Size(752, 276);
            this.tp_TableName.TabIndex = 5;
            this.tp_TableName.Text = "表名";
            this.tp_TableName.UseVisualStyleBackColor = true;
            // 
            // tbx_表名
            // 
            this.tbx_表名.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_表名.Location = new System.Drawing.Point(0, 0);
            this.tbx_表名.Name = "tbx_表名";
            this.tbx_表名.Size = new System.Drawing.Size(752, 276);
            this.tbx_表名.TabIndex = 0;
            this.tbx_表名.Text = "";
            // 
            // tp_常用数据
            // 
            this.tp_常用数据.BackColor = System.Drawing.Color.White;
            this.tp_常用数据.Controls.Add(this.tbx_常用数据);
            this.tp_常用数据.Location = new System.Drawing.Point(4, 27);
            this.tp_常用数据.Name = "tp_常用数据";
            this.tp_常用数据.Size = new System.Drawing.Size(752, 276);
            this.tp_常用数据.TabIndex = 6;
            this.tp_常用数据.Text = "常用数据";
            this.tp_常用数据.UseVisualStyleBackColor = true;
            // 
            // tbx_常用数据
            // 
            this.tbx_常用数据.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_常用数据.Location = new System.Drawing.Point(0, 0);
            this.tbx_常用数据.Name = "tbx_常用数据";
            this.tbx_常用数据.Size = new System.Drawing.Size(752, 276);
            this.tbx_常用数据.TabIndex = 0;
            this.tbx_常用数据.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_aspnet);
            this.panel2.Controls.Add(this.btn_table);
            this.panel2.Controls.Add(this.btn_反向SQL);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btn_XmlInclude);
            this.panel2.Controls.Add(this.btn_SoapTypes);
            this.panel2.Controls.Add(this.btn_BatchExec);
            this.panel2.Controls.Add(this.btn_VO);
            this.panel2.Controls.Add(this.btn_DAO);
            this.panel2.Controls.Add(this.btn_选择文件);
            this.panel2.Controls.Add(this.tbx_类前缀);
            this.panel2.Controls.Add(this.tbx_SavePath_VO);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txt_类前缀);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(6);
            this.panel2.Size = new System.Drawing.Size(760, 165);
            this.panel2.TabIndex = 1;
            // 
            // btn_aspnet
            // 
            this.btn_aspnet.Location = new System.Drawing.Point(401, 133);
            this.btn_aspnet.Name = "btn_aspnet";
            this.btn_aspnet.Size = new System.Drawing.Size(91, 23);
            this.btn_aspnet.TabIndex = 16;
            this.btn_aspnet.Text = "Aspnet Code";
            this.btn_aspnet.UseVisualStyleBackColor = true;
            this.btn_aspnet.Click += new System.EventHandler(this.btn_aspnet_Click);
            // 
            // btn_table
            // 
            this.btn_table.Location = new System.Drawing.Point(216, 133);
            this.btn_table.Name = "btn_table";
            this.btn_table.Size = new System.Drawing.Size(179, 23);
            this.btn_table.TabIndex = 15;
            this.btn_table.Text = "Html Table";
            this.btn_table.UseVisualStyleBackColor = true;
            this.btn_table.Click += new System.EventHandler(this.btn_table_Click);
            // 
            // btn_反向SQL
            // 
            this.btn_反向SQL.Location = new System.Drawing.Point(107, 133);
            this.btn_反向SQL.Name = "btn_反向SQL";
            this.btn_反向SQL.Size = new System.Drawing.Size(102, 23);
            this.btn_反向SQL.TabIndex = 14;
            this.btn_反向SQL.Text = "反向SQL";
            this.btn_反向SQL.UseVisualStyleBackColor = true;
            this.btn_反向SQL.Click += new System.EventHandler(this.btn_反向SQL_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(111, 69);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(468, 21);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "D:\\bimpApp_CloudPro\\code\\bimpApp_Client\\BIMP.Win.WinUI\\vo\\SoapString.cs";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "SoapString路径：";
            // 
            // btn_XmlInclude
            // 
            this.btn_XmlInclude.Location = new System.Drawing.Point(229, 32);
            this.btn_XmlInclude.Name = "btn_XmlInclude";
            this.btn_XmlInclude.Size = new System.Drawing.Size(91, 29);
            this.btn_XmlInclude.TabIndex = 11;
            this.btn_XmlInclude.Text = "XmlInclude";
            this.btn_XmlInclude.UseVisualStyleBackColor = true;
            this.btn_XmlInclude.Click += new System.EventHandler(this.btn_XmlInclude_Click);
            // 
            // btn_SoapTypes
            // 
            this.btn_SoapTypes.Location = new System.Drawing.Point(586, 65);
            this.btn_SoapTypes.Name = "btn_SoapTypes";
            this.btn_SoapTypes.Size = new System.Drawing.Size(89, 26);
            this.btn_SoapTypes.TabIndex = 10;
            this.btn_SoapTypes.Text = "SoapString";
            this.btn_SoapTypes.UseVisualStyleBackColor = true;
            this.btn_SoapTypes.Click += new System.EventHandler(this.btn_SoapTypes_Click);
            // 
            // btn_BatchExec
            // 
            this.btn_BatchExec.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_BatchExec.Location = new System.Drawing.Point(215, 102);
            this.btn_BatchExec.Name = "btn_BatchExec";
            this.btn_BatchExec.Size = new System.Drawing.Size(180, 28);
            this.btn_BatchExec.TabIndex = 9;
            this.btn_BatchExec.Text = "批量生成（并写入文件）";
            this.btn_BatchExec.UseVisualStyleBackColor = true;
            this.btn_BatchExec.Click += new System.EventHandler(this.btn_BatchExec_Click);
            // 
            // btn_VO
            // 
            this.btn_VO.Location = new System.Drawing.Point(107, 102);
            this.btn_VO.Name = "btn_VO";
            this.btn_VO.Size = new System.Drawing.Size(102, 29);
            this.btn_VO.TabIndex = 8;
            this.btn_VO.Text = "生成VO";
            this.btn_VO.UseVisualStyleBackColor = true;
            this.btn_VO.Click += new System.EventHandler(this.btn_Build_Clicked);
            // 
            // btn_DAO
            // 
            this.btn_DAO.Location = new System.Drawing.Point(612, 127);
            this.btn_DAO.Name = "btn_DAO";
            this.btn_DAO.Size = new System.Drawing.Size(102, 29);
            this.btn_DAO.TabIndex = 8;
            this.btn_DAO.Text = "生成DAO";
            this.btn_DAO.UseVisualStyleBackColor = true;
            this.btn_DAO.Click += new System.EventHandler(this.btn_Build_Clicked);
            // 
            // btn_选择文件
            // 
            this.btn_选择文件.Location = new System.Drawing.Point(612, 102);
            this.btn_选择文件.Name = "btn_选择文件";
            this.btn_选择文件.Size = new System.Drawing.Size(91, 28);
            this.btn_选择文件.TabIndex = 7;
            this.btn_选择文件.Text = "选择文件...";
            this.btn_选择文件.UseVisualStyleBackColor = true;
            this.btn_选择文件.Visible = false;
            this.btn_选择文件.Click += new System.EventHandler(this.btn_选择文件_Click);
            // 
            // tbx_类前缀
            // 
            this.tbx_类前缀.Location = new System.Drawing.Point(111, 40);
            this.tbx_类前缀.Name = "tbx_类前缀";
            this.tbx_类前缀.Size = new System.Drawing.Size(102, 21);
            this.tbx_类前缀.TabIndex = 4;
            // 
            // tbx_SavePath_VO
            // 
            this.tbx_SavePath_VO.Location = new System.Drawing.Point(111, 13);
            this.tbx_SavePath_VO.Name = "tbx_SavePath_VO";
            this.tbx_SavePath_VO.Size = new System.Drawing.Size(564, 21);
            this.tbx_SavePath_VO.TabIndex = 1;
            this.tbx_SavePath_VO.Text = "D:\\bimpApp_wfx\\code\\web\\Hidistro.Web\\db_class";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "vo类保存路径：";
            // 
            // txt_类前缀
            // 
            this.txt_类前缀.AutoSize = true;
            this.txt_类前缀.Location = new System.Drawing.Point(16, 43);
            this.txt_类前缀.Name = "txt_类前缀";
            this.txt_类前缀.Size = new System.Drawing.Size(65, 12);
            this.txt_类前缀.TabIndex = 3;
            this.txt_类前缀.Text = "vo类前缀：";
            // 
            // showTopPanel
            // 
            this.showTopPanel.Controls.Add(this.pneFile);
            this.showTopPanel.Controls.Add(this.pneButton);
            this.showTopPanel.Controls.Add(this.pneLeft);
            this.showTopPanel.Controls.Add(this.label8);
            this.showTopPanel.Controls.Add(this.label4);
            this.showTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.showTopPanel.Location = new System.Drawing.Point(0, 37);
            this.showTopPanel.Name = "showTopPanel";
            this.showTopPanel.Size = new System.Drawing.Size(1100, 38);
            this.showTopPanel.TabIndex = 0;
            // 
            // pneFile
            // 
            this.pneFile.Controls.Add(this.tbx_Text);
            this.pneFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pneFile.Location = new System.Drawing.Point(109, 1);
            this.pneFile.Name = "pneFile";
            this.pneFile.Padding = new System.Windows.Forms.Padding(9);
            this.pneFile.Size = new System.Drawing.Size(861, 36);
            this.pneFile.TabIndex = 9;
            // 
            // tbx_Text
            // 
            this.tbx_Text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_Text.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbx_Text.FormattingEnabled = true;
            this.tbx_Text.Location = new System.Drawing.Point(9, 9);
            this.tbx_Text.Name = "tbx_Text";
            this.tbx_Text.Size = new System.Drawing.Size(843, 20);
            this.tbx_Text.TabIndex = 0;
            // 
            // pneButton
            // 
            this.pneButton.Controls.Add(this.btn_连接);
            this.pneButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.pneButton.Location = new System.Drawing.Point(970, 1);
            this.pneButton.Name = "pneButton";
            this.pneButton.Padding = new System.Windows.Forms.Padding(6);
            this.pneButton.Size = new System.Drawing.Size(130, 36);
            this.pneButton.TabIndex = 2;
            // 
            // btn_连接
            // 
            this.btn_连接.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_连接.Location = new System.Drawing.Point(6, 6);
            this.btn_连接.Name = "btn_连接";
            this.btn_连接.Size = new System.Drawing.Size(118, 24);
            this.btn_连接.TabIndex = 2;
            this.btn_连接.Text = "连接数据库";
            this.btn_连接.UseVisualStyleBackColor = true;
            this.btn_连接.Click += new System.EventHandler(this.btn_连接_Click);
            // 
            // pneLeft
            // 
            this.pneLeft.Controls.Add(this.label2);
            this.pneLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pneLeft.Location = new System.Drawing.Point(0, 1);
            this.pneLeft.Name = "pneLeft";
            this.pneLeft.Size = new System.Drawing.Size(109, 36);
            this.pneLeft.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "数据库地址：";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.LightGray;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1100, 1);
            this.label8.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DarkGray;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Location = new System.Drawing.Point(0, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1100, 1);
            this.label4.TabIndex = 1;
            // 
            // vline
            // 
            this.vline.Location = new System.Drawing.Point(0, 75);
            this.vline.Name = "vline";
            this.vline.Size = new System.Drawing.Size(3, 514);
            this.vline.TabIndex = 1;
            this.vline.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_授权码管理);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 553);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1097, 36);
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
            this.label5.Size = new System.Drawing.Size(1097, 1);
            this.label5.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_MySQL});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1100, 37);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuItem_MySQL
            // 
            this.menuItem_MySQL.Margin = new System.Windows.Forms.Padding(6);
            this.menuItem_MySQL.Name = "menuItem_MySQL";
            this.menuItem_MySQL.Size = new System.Drawing.Size(84, 21);
            this.menuItem_MySQL.Text = "MySQL Util";
            this.menuItem_MySQL.Click += new System.EventHandler(this.menuItem_MySQL_Click);
            // 
            // Form_MSSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 589);
            this.Controls.Add(this.showContentPanel);
            this.Controls.Add(this.showLeftPanel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.vline);
            this.Controls.Add(this.showTopPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_MSSQL";
            this.Text = "Form_Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.showLeftPanel.ResumeLayout(false);
            this.showDBPage.ResumeLayout(false);
            this.tp_表.ResumeLayout(false);
            this.tp_存储过程.ResumeLayout(false);
            this.showContentPanel.ResumeLayout(false);
            this.showPage.ResumeLayout(false);
            this.tp_DAO.ResumeLayout(false);
            this.tp_load.ResumeLayout(false);
            this.tp_save.ResumeLayout(false);
            this.tp_VO.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tp_DGV.ResumeLayout(false);
            this.tp_Form.ResumeLayout(false);
            this.tp_Field.ResumeLayout(false);
            this.tp_TableName.ResumeLayout(false);
            this.tp_常用数据.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.showTopPanel.ResumeLayout(false);
            this.pneFile.ResumeLayout(false);
            this.pneButton.ResumeLayout(false);
            this.pneLeft.ResumeLayout(false);
            this.pneLeft.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel showLeftPanel;
        private System.Windows.Forms.Panel showContentPanel;
        private System.Windows.Forms.Panel showTopPanel;
        private System.Windows.Forms.RichTextBox tbx_DAO_Code;
        private System.Windows.Forms.Button btn_连接;
        private System.Windows.Forms.Label txt_类前缀;
        private System.Windows.Forms.TextBox tbx_类前缀;
        private System.Windows.Forms.Button btn_选择文件;
        private System.Windows.Forms.OpenFileDialog dlg_OpenFile;
        private System.Windows.Forms.Panel pneFile;
        private System.Windows.Forms.Panel pneLeft;
        private System.Windows.Forms.Panel pneButton;
        private System.Windows.Forms.Splitter vline;
        private System.Windows.Forms.TabControl showPage;
        private System.Windows.Forms.TabPage tp_DAO;
        private System.Windows.Forms.TabPage tp_VO;
        private System.Windows.Forms.RichTextBox tbx_VO_Code;
        private System.Windows.Forms.TabPage tp_DGV;
        private System.Windows.Forms.RichTextBox tbx_DGV_Code;
        private System.Windows.Forms.TabPage tp_Form;
        private System.Windows.Forms.RichTextBox tbx_Form_Code;
        private System.Windows.Forms.TabPage tp_Field;
        private System.Windows.Forms.RichTextBox tbx_字段列表;
        private System.Windows.Forms.TabPage tp_TableName;
        private System.Windows.Forms.RichTextBox tbx_表名;
        private System.Windows.Forms.TabPage tp_常用数据;
        private System.Windows.Forms.RichTextBox tbx_常用数据;
        private System.Windows.Forms.TabPage tp_load;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_File;
        private System.Windows.Forms.ImageList img;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbx_SavePath_VO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lst_表;
        private System.Windows.Forms.Button btn_VO;
        private System.Windows.Forms.Button btn_DAO;
        private System.Windows.Forms.TextBox tbx_VOFile;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_BatchExec;
        private System.Windows.Forms.Button btn_SoapTypes;
        private System.Windows.Forms.Button btn_XmlInclude;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_授权码管理;
        private System.Windows.Forms.Button btn_反向SQL;
        private System.Windows.Forms.TabControl showDBPage;
        private System.Windows.Forms.TabPage tp_表;
        private System.Windows.Forms.TabPage tp_存储过程;
        private System.Windows.Forms.ListBox lst_存储过程;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItem_MySQL;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_table;
        private System.Windows.Forms.Button btn_aspnet;
        private System.Windows.Forms.RichTextBox tbx_Load;
        private System.Windows.Forms.TabPage tp_save;
        private System.Windows.Forms.RichTextBox tbx_Save;
        private System.Windows.Forms.ComboBox tbx_Text;
    }
}

