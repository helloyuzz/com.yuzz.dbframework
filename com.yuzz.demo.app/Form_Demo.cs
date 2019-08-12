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

        /// <summary>
        /// Form_Demo_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Demo_Load(object sender,EventArgs e) {
            Ajdb.Init(DbType.Mysql,"127.0.0.1",3306,"root","jlkj111111","guangjuqili");

            SysDept dept = new SysDept();
            dept.Name = "aaa" + Guid.NewGuid().ToString();
            
            // -----------------demo----------------------
            // insert 操作
            // -------------------------------------------
            SaveResult result = Ajdb.Insert(dept);

            if(result.Pk_Int > 0) {
                MessageBox.Show("OK");

                // -----------------demo----------------------
                // select 单行操作
                // -------------------------------------------
                SysDept getDept = Ajdb.GetItem<SysDept>(result.Pk_Int);
                getDept.UpdateFields.Clear();

                getDept.Name += DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                getDept.ModifyTime = DateTime.Now;

                // -----------------demo----------------------
                // update 操作
                // -------------------------------------------
                result = Ajdb.Update(getDept);


                // -----------------demo----------------------
                // select 多行操作
                // -------------------------------------------
                List<SysDept> getList = Ajdb.GetList<SysDept>("","");
                foreach(SysDept getItem in getList) {
                    Console.WriteLine(getItem.Name);
                }

                MessageBox.Show(getDept.Name);
            }
        }
    }
}
