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
            // -----------------demo----------------------
            // 1、init 操作
            // -------------------------------------------
            Ajdb.Init(DbType.Mysql,"127.0.0.1",3306,"root","jlkj111111","guangjuqili");

            SysDept dept = new SysDept();
            dept.Name = "aaa" + Guid.NewGuid().ToString();
            
            // -----------------demo----------------------
            // 2、insert 操作
            // -------------------------------------------
            SaveResult saveResult = Ajdb.Insert(dept);

            if(saveResult.PK_Int > 0) {
                MessageBox.Show("OK");

                // -----------------demo----------------------
                // 3、select 单行操作
                // -------------------------------------------
                SysDept getDept = Ajdb.GetItem<SysDept>(saveResult.PK_Int);


                getDept.Name += DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                getDept.modifytime = DateTime.Now;

                // -----------------demo----------------------
                // 4、update 操作
                // -------------------------------------------
                saveResult = Ajdb.Update(getDept);


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
