using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.yuzz.dbframework;
using DbType = com.yuzz.dbframework.DbType;

namespace com.yuzz.demo.app {
    public partial class Form_Demo:Form {
        public Form_Demo() {
            InitializeComponent();
        }

        private void Form_Demo_Load(object sender,EventArgs e) {
            Ajdb.Init(DbType.Mysql,"127.0.0.1",3306,"root","jlkj111111","guangjuqili");

            SysDept dept = new SysDept();
            dept.Name = "aaa" + Guid.NewGuid().ToString();
            
            SaveResult result = Ajdb.Insert(dept);
            
            result = Ajdb.Update(dept);

            if(result.Pk_Int > 0) {
                MessageBox.Show("OK");

                SysDept getDept = Ajdb.GetItem<SysDept>(result.Pk_Int);
                MessageBox.Show(getDept.Name);
            }
        }
    }
}
