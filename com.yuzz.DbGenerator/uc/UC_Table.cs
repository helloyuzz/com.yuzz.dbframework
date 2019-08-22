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

        public delegate void OnFieldClicked(string tbname,string fieldname,bool clicked);
        public event OnFieldClicked ClickField;

        public delegate void OnAddJoin(MySQLReleationShip item);
        public event OnAddJoin AddJoin;

        private MySQLSchema mysqlSchema = null;
        public UC_Table(MySQLSchema mysqlSchema) {
            InitializeComponent();
            this.mysqlSchema = mysqlSchema;

            this.tipInfo.Text = mysqlSchema.tbname + "(" + mysqlSchema.tbnick + ")";
            int flagPos = this.tipInfo.Text.IndexOf("(");
            if(flagPos != -1) {
                this.tipInfo.LinkArea = new LinkArea(flagPos + 1,this.tipInfo.Text.Length - flagPos - 2);
            }
            
            checkedListBox1.Items.Clear();
            foreach(MySQLField sqlField in mysqlSchema.tbfields) {
                checkedListBox1.Items.Add(sqlField.FieldName);
            }
        }

        public void AddSubMenu(List<MySQLSchema> _SelectedFields) {
            stripMenu_INNER_JOIN.DropDownItems.Clear();
            stripMenu_LEFT_JOIN.DropDownItems.Clear();
            stripMenu_RIGHT_JOIN.DropDownItems.Clear();
            foreach(MySQLSchema item in _SelectedFields) {
                if(item.tbname.Equals(mysqlSchema.tbname) == true) {
                    continue;
                }
                ToolStripMenuItem subMenu = new ToolStripMenuItem();
                subMenu.Text = item.tbnick + ".(" + item.tbname + ")";

                stripMenu_INNER_JOIN.DropDownItems.Add(subMenu);
                foreach(MySQLField sqlField in item.tbfields) {
                    MySQLReleationShip join = new MySQLReleationShip();
                    join.ToTable = item.tbname;
                    join.ToNick = item.tbnick;
                    join.ToField = sqlField.FieldName;

                    ToolStripMenuItem sqlMenu = new ToolStripMenuItem();
                    sqlMenu.Text = sqlField.FieldName;
                    sqlMenu.Tag = join;
                    sqlMenu.Click += SqlMenu_Click;
                    subMenu.DropDownItems.Add(sqlMenu);
                }
            }      
        }

        private void SqlMenu_Click(object sender,EventArgs e) {
            ToolStripMenuItem sqlMenu = (ToolStripMenuItem)sender;
            MySQLReleationShip join = (MySQLReleationShip)sqlMenu.Tag;

            join.FromTable = mysqlSchema.tbname;
            join.FromNick = mysqlSchema.tbnick;
            join.FromField = checkedListBox1.Items[checkedListBox1.SelectedIndex].ToString();

            AddJoin(join);
        }
        
        int xPos;
        int yPos;
        bool MoveFlag = false;

        //List<SelectedField> _CheckedFields = null;

        //public virtual List<SelectedField> CheckedFields {
        //    get {
        //        if(_CheckedFields == null) {
        //            _CheckedFields = new List<SelectedField>();
        //        }
        //        _CheckedFields.Clear();
        //        foreach(int checkedIndex in checkedListBox1.CheckedIndices) {
        //            SelectedField field = new SelectedField();
        //            field.TableName = mysqlSchema.tbname;
        //            field.TableNick = mysqlSchema.tbnick;
        //            field.FieldName = this.checkedListBox1.Items[checkedIndex].ToString();
        //            //field.SQLField = tb_sqlFields[tb_sqlFields.FindIndex(t => t.Field.Equals(field.FieldName,StringComparison.CurrentCultureIgnoreCase))];
        //            _CheckedFields.Add(field);
        //        }
        //        return _CheckedFields;
        //    }
        //}

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
            bool clicked = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
            string fieldname = checkedListBox1.Items[checkedListBox1.SelectedIndex].ToString();

            ClickField(mysqlSchema.tbname,fieldname,clicked);
            if(clicked == true) {
                stripMenu_Main.Text = mysqlSchema.tbnick + "." + fieldname;
                contextMenuStrip1.Show(checkedListBox1,checkedListBox1.PointToClient(MousePosition));
            }
        }

        private void checkedListBox1_MouseClick(object sender,MouseEventArgs e) {
         
        }
    }
}
