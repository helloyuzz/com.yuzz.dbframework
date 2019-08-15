namespace com.yuzz.demo.app {
    partial class Form_Demo {
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.btn_AddUUID = new System.Windows.Forms.Button();
            this.btn_AddInt = new System.Windows.Forms.Button();
            this.btn_UpdateInt = new System.Windows.Forms.Button();
            this.btn_getDatatable_Int = new System.Windows.Forms.Button();
            this.dgv_int = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_FirstPage = new System.Windows.Forms.Button();
            this.btn_PrevPage = new System.Windows.Forms.Button();
            this.btn_NextPage = new System.Windows.Forms.Button();
            this.btn_LastPage = new System.Windows.Forms.Button();
            this.txt_PageTip = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_int)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_AddUUID
            // 
            this.btn_AddUUID.Location = new System.Drawing.Point(605, 449);
            this.btn_AddUUID.Name = "btn_AddUUID";
            this.btn_AddUUID.Size = new System.Drawing.Size(91, 30);
            this.btn_AddUUID.TabIndex = 0;
            this.btn_AddUUID.Text = "add uuid";
            this.btn_AddUUID.UseVisualStyleBackColor = true;
            this.btn_AddUUID.Click += new System.EventHandler(this.btn_AddUUID_Click);
            // 
            // btn_AddInt
            // 
            this.btn_AddInt.Location = new System.Drawing.Point(940, 106);
            this.btn_AddInt.Name = "btn_AddInt";
            this.btn_AddInt.Size = new System.Drawing.Size(116, 30);
            this.btn_AddInt.TabIndex = 0;
            this.btn_AddInt.Text = "add Int";
            this.btn_AddInt.UseVisualStyleBackColor = true;
            this.btn_AddInt.Click += new System.EventHandler(this.btn_AddInt_Click);
            // 
            // btn_UpdateInt
            // 
            this.btn_UpdateInt.Location = new System.Drawing.Point(940, 157);
            this.btn_UpdateInt.Name = "btn_UpdateInt";
            this.btn_UpdateInt.Size = new System.Drawing.Size(116, 30);
            this.btn_UpdateInt.TabIndex = 1;
            this.btn_UpdateInt.Text = "Update Int";
            this.btn_UpdateInt.UseVisualStyleBackColor = true;
            this.btn_UpdateInt.Click += new System.EventHandler(this.btn_UpdateInt_Click);
            // 
            // btn_getDatatable_Int
            // 
            this.btn_getDatatable_Int.Location = new System.Drawing.Point(940, 40);
            this.btn_getDatatable_Int.Name = "btn_getDatatable_Int";
            this.btn_getDatatable_Int.Size = new System.Drawing.Size(170, 30);
            this.btn_getDatatable_Int.TabIndex = 2;
            this.btn_getDatatable_Int.Text = "getDatatable Int";
            this.btn_getDatatable_Int.UseVisualStyleBackColor = true;
            this.btn_getDatatable_Int.Click += new System.EventHandler(this.btn_getDatatable_Int_Click);
            // 
            // dgv_int
            // 
            this.dgv_int.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_int.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgv_int.Location = new System.Drawing.Point(12, 40);
            this.dgv_int.Name = "dgv_int";
            this.dgv_int.RowTemplate.Height = 23;
            this.dgv_int.Size = new System.Drawing.Size(910, 274);
            this.dgv_int.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "id";
            this.Column1.HeaderText = "id";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Name";
            this.Column2.HeaderText = "Name";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Manager";
            this.Column3.HeaderText = "Manager";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "EmpNumber";
            this.Column4.HeaderText = "EmpNumber";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Money";
            this.Column5.HeaderText = "Money";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Comment";
            this.Column6.HeaderText = "Comment";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "modifytime";
            this.Column7.HeaderText = "modifytime";
            this.Column7.Name = "Column7";
            // 
            // btn_FirstPage
            // 
            this.btn_FirstPage.Location = new System.Drawing.Point(78, 326);
            this.btn_FirstPage.Name = "btn_FirstPage";
            this.btn_FirstPage.Size = new System.Drawing.Size(75, 23);
            this.btn_FirstPage.TabIndex = 4;
            this.btn_FirstPage.Text = "第一页";
            this.btn_FirstPage.UseVisualStyleBackColor = true;
            this.btn_FirstPage.Click += new System.EventHandler(this.btn_FirstPage_Click);
            // 
            // btn_PrevPage
            // 
            this.btn_PrevPage.Location = new System.Drawing.Point(159, 326);
            this.btn_PrevPage.Name = "btn_PrevPage";
            this.btn_PrevPage.Size = new System.Drawing.Size(75, 23);
            this.btn_PrevPage.TabIndex = 5;
            this.btn_PrevPage.Text = "上一页";
            this.btn_PrevPage.UseVisualStyleBackColor = true;
            this.btn_PrevPage.Click += new System.EventHandler(this.btn_PrevPage_Click);
            // 
            // btn_NextPage
            // 
            this.btn_NextPage.Location = new System.Drawing.Point(240, 326);
            this.btn_NextPage.Name = "btn_NextPage";
            this.btn_NextPage.Size = new System.Drawing.Size(75, 23);
            this.btn_NextPage.TabIndex = 6;
            this.btn_NextPage.Text = "下一页";
            this.btn_NextPage.UseVisualStyleBackColor = true;
            this.btn_NextPage.Click += new System.EventHandler(this.btn_NextPage_Click);
            // 
            // btn_LastPage
            // 
            this.btn_LastPage.Location = new System.Drawing.Point(321, 326);
            this.btn_LastPage.Name = "btn_LastPage";
            this.btn_LastPage.Size = new System.Drawing.Size(75, 23);
            this.btn_LastPage.TabIndex = 7;
            this.btn_LastPage.Text = "最后一页";
            this.btn_LastPage.UseVisualStyleBackColor = true;
            this.btn_LastPage.Click += new System.EventHandler(this.btn_LastPage_Click);
            // 
            // txt_PageTip
            // 
            this.txt_PageTip.AutoSize = true;
            this.txt_PageTip.Location = new System.Drawing.Point(435, 331);
            this.txt_PageTip.Name = "txt_PageTip";
            this.txt_PageTip.Size = new System.Drawing.Size(65, 12);
            this.txt_PageTip.TabIndex = 8;
            this.txt_PageTip.Text = "分页提示：";
            // 
            // Form_Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 641);
            this.Controls.Add(this.txt_PageTip);
            this.Controls.Add(this.btn_LastPage);
            this.Controls.Add(this.btn_NextPage);
            this.Controls.Add(this.btn_PrevPage);
            this.Controls.Add(this.btn_FirstPage);
            this.Controls.Add(this.dgv_int);
            this.Controls.Add(this.btn_getDatatable_Int);
            this.Controls.Add(this.btn_UpdateInt);
            this.Controls.Add(this.btn_AddInt);
            this.Controls.Add(this.btn_AddUUID);
            this.Name = "Form_Demo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Demo";
            this.Load += new System.EventHandler(this.Form_Demo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_int)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_AddUUID;
        private System.Windows.Forms.Button btn_AddInt;
        private System.Windows.Forms.Button btn_UpdateInt;
        private System.Windows.Forms.Button btn_getDatatable_Int;
        private System.Windows.Forms.DataGridView dgv_int;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Button btn_FirstPage;
        private System.Windows.Forms.Button btn_PrevPage;
        private System.Windows.Forms.Button btn_NextPage;
        private System.Windows.Forms.Button btn_LastPage;
        private System.Windows.Forms.Label txt_PageTip;
    }
}

