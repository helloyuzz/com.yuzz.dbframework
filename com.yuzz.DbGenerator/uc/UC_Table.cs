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

        List<MySQLField> tb_sqlFields = null;
        string tbname = "";
        string tbnick = "";
        public UC_Table(string tbname,string tbnick,object obj) {
            InitializeComponent();

            this.tipInfo.Text = tbname + "(" + tbnick + ")";
            int flagPos = this.tipInfo.Text.IndexOf("(");
            if(flagPos != -1) {
                this.tipInfo.LinkArea = new LinkArea(flagPos + 1,this.tipInfo.Text.Length - flagPos -2);
            }
            tb_sqlFields = (List<MySQLField>)obj;

            this.tbname = tbname;
            this.tbnick = tbnick;

            checkedListBox1.Items.Clear();
            foreach(MySQLField sqlField in tb_sqlFields) {                
                checkedListBox1.Items.Add(sqlField.FieldName);                
            }
        }

        public void AddSubMenu(SelectedMySQLFields _SelectedFields) {
            stripMenu_INNER_JOIN.DropDownItems.Clear();
            stripMenu_LEFT_JOIN.DropDownItems.Clear();
            stripMenu_RIGHT_JOIN.DropDownItems.Clear();
            foreach(string key in _SelectedFields.Keys) {
                List<MySQLField> _list = _SelectedFields[key];

                ToolStripMenuItem subMenu = new ToolStripMenuItem();
                subMenu.Text = key;

                stripMenu_INNER_JOIN.DropDownItems.Add(subMenu);
                foreach(MySQLField sqlField in _list) {
                    ToolStripMenuItem sqlMenu = new ToolStripMenuItem();
                    sqlMenu.Text = sqlField.FieldName;
                    subMenu.DropDownItems.Add(sqlMenu);
                }
            }      
        }

        int xPos;
        int yPos;
        bool MoveFlag = false;

        List<SelectedField> _CheckedFields = null;
        public virtual List<SelectedField> CheckedFields {
            get {
                if(_CheckedFields == null) {
                    _CheckedFields = new List<SelectedField>();
                }
                _CheckedFields.Clear();
                foreach(int checkedIndex in checkedListBox1.CheckedIndices) {
                    SelectedField field = new SelectedField();
                    field.TableName = this.tbname;
                    field.TableNick = this.tbnick;
                    field.FieldName = this.checkedListBox1.Items[checkedIndex].ToString();
                    //field.SQLField = tb_sqlFields[tb_sqlFields.FindIndex(t => t.Field.Equals(field.FieldName,StringComparison.CurrentCultureIgnoreCase))];
                    _CheckedFields.Add(field);
                }
                return _CheckedFields;
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
            ClickField();
            stripMenu_Main.Text = tbnick + "." + checkedListBox1.Items[checkedListBox1.SelectedIndex].ToString();
            contextMenuStrip1.Show(checkedListBox1,checkedListBox1.PointToClient(MousePosition));
        }

        private void checkedListBox1_MouseClick(object sender,MouseEventArgs e) {
            //if(e.Button == MouseButtons.Right) {
            //    contextMenuStrip1.Show(checkedListBox1,checkedListBox1.PointToClient(MousePosition));
            //}
        }
    }
}
