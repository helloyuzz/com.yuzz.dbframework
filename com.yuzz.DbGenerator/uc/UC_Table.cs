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
        List<MySQLField> sqlFields = null;
        public UC_Table(string tbname,object obj) {
            InitializeComponent();
            this.label1.Text = tbname;
            sqlFields = (List<MySQLField>)obj;

            checkedListBox1.Items.Clear();
            foreach(MySQLField sqlField in sqlFields) {
                checkedListBox1.Items.Add(sqlField.Field);
            }
        }
        int xPos;
        int yPos;
        bool MoveFlag = false;
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
            label1.BackColor = SystemColors.ActiveCaption;
            linkLabel1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font(label1.Font,FontStyle.Bold);
        }

        private void UC_Table_Leave(object sender,EventArgs e) {
            label1.BackColor = SystemColors.InactiveCaption;
            linkLabel1.BackColor = SystemColors.InactiveCaption;
            label1.Font = new Font(label1.Font,FontStyle.Regular);
        }
    }
}
