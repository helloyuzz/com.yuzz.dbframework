namespace com.yuzz.DbGenerator.uc {
    partial class UC_Table {
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tipInfo = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stripMenu_Main = new System.Windows.Forms.ToolStripMenuItem();
            this.stripMenu_INNER_JOIN = new System.Windows.Forms.ToolStripMenuItem();
            this.stripMenu_RIGHT_JOIN = new System.Windows.Forms.ToolStripMenuItem();
            this.stripMenu_LEFT_JOIN = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "aa",
            "bb",
            "cc",
            "dd",
            "ee",
            "ff",
            "gg",
            "hh",
            "ii",
            "jj",
            "kk"});
            this.checkedListBox1.Location = new System.Drawing.Point(0, 16);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(146, 190);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.checkedListBox1_MouseClick);
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.linkLabel1.Location = new System.Drawing.Point(127, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(19, 16);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "X";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tipInfo);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(146, 16);
            this.panel1.TabIndex = 3;
            // 
            // tipInfo
            // 
            this.tipInfo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tipInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tipInfo.Location = new System.Drawing.Point(0, 0);
            this.tipInfo.Name = "tipInfo";
            this.tipInfo.Size = new System.Drawing.Size(127, 16);
            this.tipInfo.TabIndex = 3;
            this.tipInfo.TabStop = true;
            this.tipInfo.Text = "a1";
            this.tipInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tipInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.tipInfo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            this.tipInfo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripMenu_Main});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(193, 48);
            // 
            // stripMenu_Main
            // 
            this.stripMenu_Main.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripMenu_INNER_JOIN,
            this.stripMenu_LEFT_JOIN,
            this.stripMenu_RIGHT_JOIN});
            this.stripMenu_Main.Name = "stripMenu_Main";
            this.stripMenu_Main.Size = new System.Drawing.Size(192, 22);
            this.stripMenu_Main.Text = "toolStripMenuItem1";
            // 
            // stripMenu_INNER_JOIN
            // 
            this.stripMenu_INNER_JOIN.Name = "stripMenu_INNER_JOIN";
            this.stripMenu_INNER_JOIN.Size = new System.Drawing.Size(180, 22);
            this.stripMenu_INNER_JOIN.Text = "INNER JOIN";
            // 
            // stripMenu_RIGHT_JOIN
            // 
            this.stripMenu_RIGHT_JOIN.Name = "stripMenu_RIGHT_JOIN";
            this.stripMenu_RIGHT_JOIN.Size = new System.Drawing.Size(180, 22);
            this.stripMenu_RIGHT_JOIN.Text = "RIGHT JOIN";
            // 
            // stripMenu_LEFT_JOIN
            // 
            this.stripMenu_LEFT_JOIN.Name = "stripMenu_LEFT_JOIN";
            this.stripMenu_LEFT_JOIN.Size = new System.Drawing.Size(180, 22);
            this.stripMenu_LEFT_JOIN.Text = "LEFT JOIN";
            // 
            // UC_Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.panel1);
            this.Name = "UC_Table";
            this.Size = new System.Drawing.Size(146, 206);
            this.Enter += new System.EventHandler(this.UC_Table_Enter);
            this.Leave += new System.EventHandler(this.UC_Table_Leave);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel tipInfo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem stripMenu_Main;
        private System.Windows.Forms.ToolStripMenuItem stripMenu_INNER_JOIN;
        private System.Windows.Forms.ToolStripMenuItem stripMenu_LEFT_JOIN;
        private System.Windows.Forms.ToolStripMenuItem stripMenu_RIGHT_JOIN;
    }
}
