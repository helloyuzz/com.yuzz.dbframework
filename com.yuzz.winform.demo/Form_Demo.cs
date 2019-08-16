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
using com.yuzz.dbframework.vo;
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

            //SysDept dept = new SysDept();
            //dept.Name = "aaa" + Guid.NewGuid().ToString();
            
            //// -----------------demo----------------------
            //// 2、insert 操作
            //// -------------------------------------------
            //SaveResult saveResult = Ajdb.Insert(dept);

            //if(saveResult.OK) {
            //    MessageBox.Show("OK");

            //    // -----------------demo----------------------
            //    // 3、select 单行操作
            //    // -------------------------------------------
            //    SysDept getDept = Ajdb.GetItem<SysDept>(saveResult.PK_Int);


            //    getDept.Name += DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //    getDept.modifytime = DateTime.Now;

            //    // -----------------demo----------------------
            //    // 4、update 操作
            //    // -------------------------------------------
            //    saveResult = Ajdb.Update(getDept);


            //    // -----------------demo----------------------
            //    // select 多行操作
            //    // -------------------------------------------
            //    List<SysDept> getList = Ajdb.GetList<SysDept>("","");
            //    foreach(SysDept getItem in getList) {
            //        Console.WriteLine(getItem.Name);
            //    }

            //    getList = Ajdb.GetList<SysDept>("","",1,100);

            //    MessageBox.Show(getDept.Name);                
            //}

           
        }

        private void btn_AddUUID_Click(object sender,EventArgs e) {
            sys_uuid addItem = new sys_uuid();
            addItem.uuid = Guid.NewGuid().ToString();
            addItem.name = "aa";
            addItem.money = 1000;

            SaveResult addResult = Ajdb.Insert(addItem);
            if(addResult.OK) {
                MessageBox.Show(addResult.PK_Varchar);
            }
        }

        private void btn_AddInt_Click(object sender,EventArgs e) {
            SysDept dept = new SysDept();
            dept.Name = "aaa" + Guid.NewGuid().ToString();

            SaveResult saveResult = Ajdb.Insert(dept);
            if(saveResult.OK) {
                MessageBox.Show(saveResult.PK_Int.ToString());
            } else {
                MessageBox.Show(saveResult.Msg);
            }
        }

        private void btn_UpdateInt_Click(object sender,EventArgs e) {

        }
        string tablename = "";
        private void btn_getDatatableUUID_Click(object sender,EventArgs e) {
            tablename = "sys_uuid";
            btn_FirstPage_Click(sender,e);
        }
        private void btn_getDatatable_Int_Click(object sender,EventArgs e) {
            tablename = "sysdept";
            btn_FirstPage_Click(sender,e);
        }

        int pageIndex = 1;
        int pageSize = 10;
        int pageCount = 1000;
        private void btn_FirstPage_Click(object sender,EventArgs e) {
            pageIndex = 1;
            doQuery();
        }

        private void btn_PrevPage_Click(object sender,EventArgs e) {
            pageIndex--;
            if(pageIndex <=0) {
                btn_FirstPage_Click(sender,e);
            } else {
                doQuery();
            }
        }

        private void btn_NextPage_Click(object sender,EventArgs e) {
            pageIndex++;
            if(pageIndex > pageCount) {
                pageIndex = pageCount;
            }
            doQuery();
        }

        private void btn_LastPage_Click(object sender,EventArgs e) {
            pageIndex = pageCount;
            doQuery();
        }
        void doQuery() {
            AjQuery ajResult = null;
            switch(tablename) {
                case "sys_uuid":
                    ajResult = Ajdb.Query<sys_uuid>("","",pageIndex,pageSize,AjQueryType.QueryAll,null);
                    break;
                case "sysdept":
                    ajResult = Ajdb.Query<SysDept>("","",pageIndex,pageSize,AjQueryType.QueryAll,null);
                    break;
            }
            dgv_int.Columns.Clear();
            dgv_int.AutoGenerateColumns = true;
            dgv_int.DataSource = ajResult.DataTable;
            pageCount = ajResult.PageCount;

            txt_PageTip.Text = "共：" + ajResult.RecordCount + "条记录，当前第：" + ajResult.PageIndex + "页，共：" + ajResult.PageCount + "，每页显示：" + ajResult.PageSize + "条记录";
        }

        private void btn_GetItem_Click(object sender,EventArgs e) {
            SysDept dept = Ajdb.GetItem<SysDept>(AdobeUtil.ParseInt(tbx_id.Text));
            MessageBox.Show(dept.Name);
        }

        private void btn_getuuid_Click(object sender,EventArgs e) {
            sys_uuid uuid = Ajdb.GetItem<sys_uuid>(tbx_uuid.Text);
            MessageBox.Show(uuid.name);
        }

        private void btn_AddUser_Click(object sender,EventArgs e) {
            for(int n = 0;n <= 10;n++) {
                sysuser user = new sysuser();
                user.name = "aa" + AdobeUtil.RandomNumber();
                Ajdb.Insert(user);
            }
        }

        private void btn_MultiQuery_Click(object sender,EventArgs e) {
            Ajdb.Query<sysuser>("","");
        }
    }
}