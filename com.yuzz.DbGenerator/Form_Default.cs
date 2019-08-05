using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DBFramework;

namespace com.cgWorkstudio.BIMP {
    public partial class Form_Default:Form {
        public Form_Default() {
            InitializeComponent();
        }

        private void btn_Connect_Click(object sender,EventArgs e) {
            using(SqlConnection dbConn = new SqlConnection(tbx_Text.Text)) {
                try {
                    dbConn.Open();
                    dbConn.Close();
                    MessageBox.Show(this,"数据库连接成功","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                } catch(Exception exc) {
                    MessageBox.Show(this,"数据库连接失败：\r\n" + exc.ToString(),"系统提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_Default_Click(object sender,EventArgs e) {
            List<string> ingoreList = new List<string>();

            ingoreList.Add("基础数据_常用资料");
            ingoreList.Add("系统数据_操作员");
            ingoreList.Add("系统数据_数据源");
            ingoreList.Add("系统数据_权限");
            ingoreList.Add("系统设置_排班设置");

            if(MessageBox.Show(this,"是否初始化数据库？","系统提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) {
                List<string> getList = new List<string>();
                SqlCommand dbCmd = new SqlCommand();
                try {
                    using(SqlConnection dbConn = new SqlConnection(tbx_Text.Text)) {
                        dbConn.Open();
                        dbCmd.Connection = dbConn;
                        dbCmd.CommandText = "select [Id],[Name] from [SysObjects] where type='u' order by [refdate] desc";

                        SqlDataReader dbReader = dbCmd.ExecuteReader();

                        while(dbReader.Read()) {
                            string tmp = Toolkit.IngoreNull(dbReader["Name"]);

                            if(ingoreList.Contains(tmp)) {
                                continue;
                            }

                            getList.Add(tmp);
                        }

                        dbReader.Close();
                        dbReader = null;

                        foreach(string tmp in getList) {
                            dbCmd.Parameters.Clear();
                            dbCmd.CommandText = "delete from [" + tmp + "]";

                            dbCmd.ExecuteNonQuery();
                        }

                        dbConn.Close();
                    }
                    MessageBox.Show(this,"操作成功","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                } catch {
                } finally {
                    dbCmd = null;
                }
            }
        }

        private void Form_Default_Load(object sender,EventArgs e) {

        }

        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            btn_Default.Focus();
        }
    }
}