using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace com.yuzz.DbGenerator {
    public partial class Form_Startup:Form {
        public Form_Startup() {
            InitializeComponent();
        }

        private void btn_MySQL_Click(object sender,EventArgs e) {
            Form_MySQL frmMySQL = new Form_MySQL();
            frmMySQL.Owner = this;
            frmMySQL.Show();
        }

        private void btn_MsSQL_Click(object sender,EventArgs e) {
            Form_MSSQL frmMSSQL = new Form_MSSQL();
            frmMSSQL.ShowDialog();
        }
    }
}
