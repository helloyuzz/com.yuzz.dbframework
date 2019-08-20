using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.yuzz.DbGenerator.vo;

namespace com.yuzz.DbGenerator.uc {
    public partial class UC_Table:UserControl {
        public delegate void OnCloseAction(string key);
        public event OnCloseAction Close;

        public delegate void OnFieldClicked();
        public event OnFieldClicked ClickField;

        List<MySQLField> sqlFields = null;
        string tbname = "";
        string tbnick = "";
        public UC_Table(string tbname,string tbnick,object obj) {
            InitializeComponent();

            this.tipInfo.Text = tbname + "(" + tbnick + ")";
            int flagPos = this.tipInfo.Text.IndexOf("(");
            if(flagPos != -1) {
                this.tipInfo.LinkArea = new LinkArea(flagPos + 1,this.tipInfo.Text.Length - flagPos -2);
            }
            sqlFields = (List<MySQLField>)obj;

            this.tbname = tbname;
            this.tbnick = tbnick;

            checkedListBox1.Items.Clear();
            foreach(MySQLField sqlField in sqlFields) {
                checkedListBox1.Items.Add(sqlField.Field);
            }
        }
        int xPos;
        int yPos;
        bool MoveFlag = false;

        internal List<SelectedField> CheckedFields {
            get {
                List<SelectedField> selectedFields = new List<SelectedField>();
                foreach(int checkedIndex in checkedListBox1.CheckedIndices) {
                    SelectedField field = new SelectedField();
                    field.TableName = this.tbname;
                    field.TableNick = this.tbnick;
                    field.FieldName = checkedListBox1.Items[checkedIndex].ToString();
                    selectedFields.Add(field);
                }
                return selectedFields;
            }
        }

        private void label1_MouseMove(object sender,MouseEventArgs e) {
            if(MoveFlag) {
                this.Left += Convert.ToInt16(e.X - xPos);//设置x坐标.
                this.Top += Convert.ToInt16(e.Y - yPos);//设置y坐标.
            }
        }

        private void label1_MouseUp(object sender,MouseEventArgs e) {
            MoveFlag = false;
        }

        private void label1_MouseDown(object sender,MouseEventArgs e) {
            MoveFlag = true;//已经按下.
            xPos = e.X;//当前x坐标.
            yPos = e.Y;//当前y坐标.
        }

        private void linkLabel1_LinkClicked(object sender,LinkLabelLinkClickedEventArgs e) {
            Close(this.Name);
        }

        private void UC_Table_Enter(object sender,EventArgs e) {
            tipInfo.BackColor = SystemColors.ActiveCaption;
            linkLabel1.BackColor = SystemColors.ActiveCaption;
            tipInfo.Font = new Font(tipInfo.Font,FontStyle.Bold);
        }

        private void UC_Table_Leave(object sender,EventArgs e) {
            tipInfo.BackColor = SystemColors.InactiveCaption;
            linkLabel1.BackColor = SystemColors.InactiveCaption;
            tipInfo.Font = new Font(tipInfo.Font,FontStyle.Regular);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender,EventArgs e) {
            Application.DoEvents();
            ClickField();
        }
    }
}
