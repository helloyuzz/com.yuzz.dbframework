using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using com.yuzz.DbGenerator.Properties;
using System.IO;
using System.Threading;
using com.yuzz.DbGenerator.vo;
using System.Xml;
using Newtonsoft.Json;

namespace com.yuzz.DbGenerator {
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

            // 更新字段
            //sql.Append("\tpublic List<string> UpdateFields = new List<string>();").Append(Environment.NewLine);
            sql.Append("\tList<string> _UpdateFields = new List<string>();\r\n");
            sql.Append("\tpublic virtual List<string> UpdateFields {\r\n");
            sql.Append("\t\tget { return _UpdateFields; }\r\n");
            sql.Append("\t\tset { _UpdateFields = value; }\r\n");
            sql.Append("\t}\r\n");

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

            MySQLField sqlField = mysqlFields.Find(t => t.Key.Equals("PRI"));
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




            foreach(MySQLField field in mysqlFields) {
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
                sql.Append("_Fields.Add(new SQLField(\"").Append(field.Field).Append("\",").Append(ParseCSharpRuntimeType(field.Type,true)).Append(",").Append(isPRI).Append(",\"").Append(field.Comment.Trim()).Append("\"");
                //if(string.IsNullOrEmpty(dateformat) == false) {
                //    sql.Append(",\"").Append(dateformat).Append("\"");
                //}

                sql.Append("));\r\n");
            }
            sql.Append("\t\t\t}\r\n");
            sql.Append("\t\t\treturn _Fields;\r\n");
            sql.Append("\t\t}\r\n");
            sql.Append("\t}\r\n");

            foreach(MySQLField field in mysqlFields) {
                string getCSharpType = ParseCSharpRuntimeType(field.Type,false);
                sql.Append("\t").Append(getCSharpType + " _" + field.Field + ";").Append(Environment.NewLine);
                if(string.IsNullOrEmpty(field.Comment) == false) {  //  字段如果有备注就添加备注信息
                    sql.Append("\t/// <summary>\r\n");
                    sql.Append("\t/// ").Append(field.Comment).Append("\r\n");
                    sql.Append("\t/// </summary>\r\n");
                }
                sql.Append("\tpublic virtual ").Append(getCSharpType).Append(" ").Append(field.Field).Append(" {\r\n");
                sql.Append("\t\tget{").Append(Environment.NewLine);
                sql.Append("\t\t\treturn _" + field.Field + ";").Append(Environment.NewLine);
                sql.Append("\t\t}").Append(Environment.NewLine);


                sql.Append("\t\tset{").Append(Environment.NewLine);
                if("PRI".Equals(field.Key) == false) {  // 非主键
                    sql.Append("\t\t\tif(value != this._" + field.Field + ") {").Append(Environment.NewLine);
                    sql.Append("\t\t\t    UpdateFields.Add(\"" + field.Field + "\");").Append(Environment.NewLine);
                    sql.Append("\t\t\t}").Append(Environment.NewLine);
                }
                sql.Append("\t\t\t_" + field.Field + " = value;").Append(Environment.NewLine);
                sql.Append("\t\t}").Append(Environment.NewLine);
                sql.Append("\t}\r\n");
            }
            sql.Append("}");
            //sql.Append("    }");

            rtb_Code.AppendText(sql.ToString());
        }

        private string ParseCSharpRuntimeType(string type,bool mysqlType) {
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
            string xmlFilePath = Application.StartupPath + "\\xml\\mysql.xml";
            
            if(File.Exists(xmlFilePath) == true) {
                StreamReader streamReader = File.OpenText(xmlFilePath);
                string getXmlString = streamReader.ReadToEnd();
                MySQLXmlFile xmlFile = (MySQLXmlFile)JsonConvert.DeserializeObject(getXmlString,typeof(MySQLXmlFile));
                if(xmlFile != null) {
                    tbx_dbip.Text = xmlFile.dbip;
                    tbx_port.Text = xmlFile.port;
                    tbx_user.Text = xmlFile.user;
                    tbx_pwd.Text = xmlFile.pwd;
                    tbx_schema.Text = xmlFile.schema;
                }
                streamReader.Close();
            }
        }

        private void btn_Connect_Click(object sender,EventArgs e) {
            if(string.IsNullOrEmpty(tbx_dbip.Text.Trim())) {
                MessageBox.Show(this,"服务器地址不能为空");
                tbx_dbip.Focus();
                return;
            }
            saveXmlFile();
            tvw.Nodes["rootNode"].Nodes.Clear();
            MySqlConnection dbConn = new MySqlConnection();
            try {
                dbConn.ConnectionString = getConnectionString();
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

                if(tvw.Nodes["rootNode"].Nodes.Count <= 0) {
                    tvw.Nodes["rootNode"].Nodes.Add("该数据库为空!");
                }
            } catch(Exception exc) {
                MessageBox.Show(exc.ToString());
            } finally {
                dbConn.Close();
                dbConn = null;
            }
            tvw.ExpandAll();
        }

        private void saveXmlFile() {
            string xmlDir = Application.StartupPath + "\\xml\\";
            if(Directory.Exists(xmlDir) == false) {
                Directory.CreateDirectory(xmlDir);
            }

            MySQLXmlFile xmlFile = new MySQLXmlFile();
            xmlFile.dbip = tbx_dbip.Text;
            xmlFile.port = tbx_port.Text;
            xmlFile.user = tbx_user.Text;
            xmlFile.pwd = tbx_pwd.Text;
            xmlFile.schema = tbx_schema.Text;

            string xmlString = JsonConvert.SerializeObject(xmlFile);
            StreamWriter streamWriter = File.CreateText(Application.StartupPath + "\\xml\\mysql.xml");
            streamWriter.Write(xmlString);
            streamWriter.Flush();
            streamWriter.Close();            
        }

        private string getConnectionString() {
            return string.Format("Server={0};User Id={1};Password={2};port={3};Persist Security Info=True;Database={4};Connect Timeout=10;charset=utf8",tbx_dbip.Text,tbx_user.Text,tbx_pwd.Text,tbx_port.Text,tbx_schema.Text);
        }

        List<MySQLField> mysqlFields = new List<MySQLField>();
        DataTable dt = new DataTable();
        private void tvw_AfterSelect(object sender,TreeViewEventArgs e) {
            mysqlFields.Clear();

            tbx_TableName.Text = e.Node.Text;
            dt.Rows.Clear();
            //dgv.Rows.Clear();
            MySqlConnection dbConn = new MySqlConnection();
            try {
                dbConn.ConnectionString = getConnectionString();
                dbConn.Open();

                MySqlCommand dbCmd = new MySqlCommand();
                dbCmd.CommandText = "SHOW full COLUMNS FROM " + e.Node.Text;
                dbCmd.Connection = dbConn;

                MySqlDataAdapter dbAdapter = new MySqlDataAdapter(dbCmd);
                dbAdapter.Fill(dt);
                dt.TableName = Guid.NewGuid().ToString().Replace("-","");

                dgv.DataSource = dt;
                foreach(DataRow row in dt.Rows) {
                    MySQLField filed = new MySQLField();
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
            foreach(MySQLField sqlField in mysqlFields) {
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
