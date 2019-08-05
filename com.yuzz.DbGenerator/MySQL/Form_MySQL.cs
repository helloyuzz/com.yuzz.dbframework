using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using com.yuzz.dbgenerator.Properties;
using System.IO;
using System.Threading;

namespace com.cgWorkstudio.BIMP.MySQL {
    public partial class Form_MySQL:Form {
        public Form_MySQL() {
            InitializeComponent();
        }

        private void btn_Build_Click(object sender,EventArgs e) {
            rtb_Code.Clear();
            StringBuilder sql = new StringBuilder();

            sql.Append("using System;\r\n");
            sql.Append("using System.Collections.Generic;\r\n");
            sql.Append("using System.Data;\r\n");
            sql.Append("using com.yuzz.dbframework;\r\n");
            sql.Append("using MySql.Data.MySqlClient;\r\n");

            //sql.Append("namespace JLJM {\r\n");
            sql.Append("[Serializable]\r\n");
            sql.Append("public class ").Append(tbx_TableName.Text).Append(" {\r\n");

            sql.Append("\tpublic static Type Type {").Append(Environment.NewLine);
            sql.Append("\t\tget {").Append(Environment.NewLine);
      
            sql.Append("\t\t\treturn typeof(").Append(tbx_TableName.Text).Append(");").Append(Environment.NewLine);
            sql.Append("\t\t}").Append(Environment.NewLine);
            sql.Append("\t}").Append(Environment.NewLine);

            sql.Append("\tpublic virtual string TableName {\r\n");
            sql.Append("\t\tget {\r\n");
            sql.Append("\t\t\treturn \"").Append(tbx_TableName.Text).Append("\";\r\n");
            sql.Append("\t\t}\r\n");
            sql.Append("\t}\r\n");

            MySqlField sqlField = mysqlFields.Find(t => t.Key.Equals("PRI"));
            if(sqlField == null) {
                rtb_Code.Clear();
                throw new Exception("数据表必须有主键Primary Key");
            }

            sql.Append("\tpublic virtual string PkFieldName {\r\n");
            sql.Append("\t\tget {\r\n");
            sql.Append("\t\t\treturn \"").Append(sqlField.Field).Append("\";\r\n");
            sql.Append("\t\t}\r\n");
            sql.Append("\t}\r\n");

            sql.Append("\tprivate List<SQLField> _Fields = null;\r\n");
            sql.Append("\tpublic List<SQLField> Fields{\r\n");
            sql.Append("\t\tget{\r\n");
            sql.Append("\t\t\tif(_Fields == null){\r\n");
            sql.Append("\t\t\t_Fields = new List<SQLField>();\r\n");

            foreach(MySqlField field in mysqlFields) {
                string isPRI = field.Key.Equals("PRI") ? "true" : "false";
                string dateformat = "";
                switch(field.Type) {
                    case "date":
                        dateformat = "yyyy-MM-dd";
                        break;
                    case "datetime":
                        dateformat = "yyyy-MM-dd HH:mm:ss";
                        break;
                }
                sql.Append("\t\t\t\t");
                sql.Append("_Fields.Add(new SQLField(\"").Append(field.Field).Append("\",").Append(GetMySqlDBType(field.Type,true)).Append(",").Append(isPRI).Append(",\"").Append(field.Comment.Trim()).Append("\"");
                //if(string.IsNullOrEmpty(dateformat) == false) {
                //    sql.Append(",\"").Append(dateformat).Append("\"");
                //}

                sql.Append("));\r\n");
            }
            sql.Append("\t\t\t}\r\n");
            sql.Append("\t\t\treturn _Fields;\r\n");
            sql.Append("\t\t}\r\n");
            sql.Append("\t}\r\n");

            foreach(MySqlField field in mysqlFields) {
                if(string.IsNullOrEmpty(field.Comment) == false) {
                    sql.Append("\t/// <summary>\r\n");
                    sql.Append("\t/// ").Append(field.Comment).Append("\r\n");
                    sql.Append("\t/// </summary>\r\n");
                }
                sql.Append("\tpublic virtual ").Append(GetMySqlDBType(field.Type,false)).Append(" ").Append(field.Field).Append(" {\r\n");
                sql.Append("\t\tget;set;\r\n");
                sql.Append("\t}\r\n");
            }
            sql.Append("}");
            //sql.Append("    }");

            rtb_Code.AppendText(sql.ToString());
        }

        private string GetMySqlDBType(string type,bool mysqlType) {
            string getTypeString = "";
            if(type.IndexOf('(') != -1) {
                type = type.Substring(0,type.IndexOf('('));
            }
            switch(type) {
                case "tinyint":
                    getTypeString = mysqlType ? "MySqlDbType.Bit" : "bool";
                    break;
                case "int":
                    getTypeString = mysqlType ? "MySqlDbType.Int32" : "int";
                    break;
                case "varchar":
                case "string":
                    getTypeString = mysqlType ? "MySqlDbType.VarChar" : "string";
                    break;
                case "date":
                    getTypeString = mysqlType ? "MySqlDbType.Date" : "DateTime";
                    break;
                case "datetime":
                    getTypeString = mysqlType ? "MySqlDbType.DateTime" : "DateTime";
                    break;
                case "decimal":
                case "float":
                    getTypeString = mysqlType ? "MySqlDbType.Float" : "float";
                    break;
                case "double":
                    getTypeString = mysqlType ? "MySqlDbType.Float" : "double";
                    break;
                case "bit":
                    getTypeString = mysqlType ? "MySqlDbType.Bit" : "bool";
                    break;
                case "longtext":
                    getTypeString = mysqlType ? "MySqlDbType.LongText" : "string";
                    break;
            }
            return getTypeString;
        }

        private void Form_MySQL_Load(object sender,EventArgs e) {
            this.Icon = Resources.mysql;
        }

        private void btn_Connect_Click(object sender,EventArgs e) {
            tvw.Nodes["rootNode"].Nodes.Clear();
            MySqlConnection dbConn = new MySqlConnection();
            try {
                dbConn.ConnectionString = comboBox2.Text;
                dbConn.Open();
                
                MySqlCommand dbCmd = new MySqlCommand();
                dbCmd.CommandText = "show tables";// ' like tb_tj%'";
                dbCmd.Connection = dbConn;

                MySqlDataReader dbReader = dbCmd.ExecuteReader();
                while(dbReader.Read()) {
                    TreeNode treeNode = new TreeNode();
                    treeNode.Text = dbReader[0].ToString();
                    tvw.Nodes[0].Nodes.Add(treeNode);
                }
                dbReader.Close();
                dbReader = null;
            } catch(Exception exc) {
                MessageBox.Show(exc.ToString());
            } finally {
                dbConn.Close();
                dbConn = null;
            }
            tvw.ExpandAll();
        }

        List<MySqlField> mysqlFields = new List<MySqlField>();
        DataTable dt = new DataTable();
        private void tvw_AfterSelect(object sender,TreeViewEventArgs e) {
            mysqlFields.Clear();

            tbx_TableName.Text = e.Node.Text;
            dt.Rows.Clear();
            //dgv.Rows.Clear();
            MySqlConnection dbConn = new MySqlConnection();
            try {
                dbConn.ConnectionString = comboBox2.Text;
                dbConn.Open();

                MySqlCommand dbCmd = new MySqlCommand();
                dbCmd.CommandText = "SHOW full COLUMNS FROM " + e.Node.Text;
                dbCmd.Connection = dbConn;

                MySqlDataAdapter dbAdapter = new MySqlDataAdapter(dbCmd);
                dbAdapter.Fill(dt);
                dt.TableName = Guid.NewGuid().ToString().Replace("-","");

                dgv.DataSource = dt;
                foreach(DataRow row in dt.Rows) {
                    MySqlField filed = new MySqlField();
                    filed.Field = row["field"].ToString();
                    filed.Type = row["type"].ToString();
                    filed.Key = row["key"].ToString();
                    filed.Comment = row["comment"].ToString();
                    mysqlFields.Add(filed);
                }
            } catch {
            } finally {
                dbConn.Close();
                dbConn = null;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender,EventArgs e) {
            //tbx_dbtext.Text = comboBox1.Text;
        }

        private void btn_Save_Click(object sender,EventArgs e) {
            StreamWriter file = File.CreateText(tbx_SavePath.Text + "\\" + tbx_TableName.Text + ".cs");
            file.Write(rtb_Code.Text);
            file.Flush();
            file.Close();
            this.Cursor = Cursors.WaitCursor;
            Thread.Sleep(500);
            Application.DoEvents();
            this.Cursor = Cursors.Default;
        }

        private void btn_html_Click(object sender,EventArgs e) {
            rtb_Code.Clear();
            rtb_Code.AppendText("<table width=\"100%\">");
            rtb_Code.AppendText(Environment.NewLine);
            foreach(MySqlField sqlField in mysqlFields) {
                string showField = sqlField.Comment;
                if(string.IsNullOrEmpty(showField)) {
                    showField = sqlField.Field;
                }

                string tbxid = "tbx__" + tbx_TableName.Text + "__" + sqlField.Field;
                rtb_Code.AppendText("\t<tr>");
                rtb_Code.AppendText(Environment.NewLine);
                rtb_Code.AppendText("\t\t<td width=\"150px\">" + showField + "</td>");
                rtb_Code.AppendText(Environment.NewLine);
                rtb_Code.AppendText("\t\t<td><input id=\"" + tbxid + "\" type=\"text\" name=\"" + tbxid + "\" comment=\"" + sqlField.Comment + "\" style=\"width:100%;\"></td>");
                rtb_Code.AppendText(Environment.NewLine);
                rtb_Code.AppendText("\t</tr>");
                rtb_Code.AppendText(Environment.NewLine);
            }
            rtb_Code.AppendText("</table>");
        }

        private void btn_dbname_Click(object sender,EventArgs e) {
            rtb_Code.Clear();


            foreach(TreeNode node in tvw.Nodes["rootNode"].Nodes) {
            }
        }
    }
}
