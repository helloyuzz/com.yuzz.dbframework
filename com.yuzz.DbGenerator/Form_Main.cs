using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBFramework.vo;
using System.IO;
using System.Data.SqlClient;
using com.cgWorkstudio.BIMP.Client.db.vo;
using System.Diagnostics;
using com.cgWorkstudio.BIMP.MySQL;

namespace DBFramework {
    public partial class Form_Main:Form {
        delegate void OnSaveFileCallback(string filePath);

        public Form_Main() {
            InitializeComponent();
        }


        // 加载数据库表列表
        private void load_SchemaList() {
            SqlCommand dbCmd = new SqlCommand();
            using(SqlConnection dbConn = new SqlConnection(tbx_Text.Text)) {
                dbConn.Open();
                dbCmd.Connection = dbConn;

                // 表
                dbCmd.CommandText = "select [Id],[Name] from [SysObjects] where type='u' order by [name] asc"; // refdate
                DataTable dt = new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("Name");

                SqlDataReader dbReader = dbCmd.ExecuteReader();
                while(dbReader.Read()) {
                    DataRow newRow = dt.NewRow();
                    newRow["Id"] = Toolkit.IngoreNull(dbReader["Id"]);
                    newRow["Name"] = Toolkit.IngoreNull(dbReader["Name"]);

                    dt.Rows.Add(newRow);

                    //TreeNode node = new TreeNode() {
                    //    Name = Toolkit.IngoreNull(dbReader["Id"]),
                    //    Text = Toolkit.IngoreNull(dbReader["Name"])
                    //};
                    //tvw_View.Nodes["rootnode"].Nodes.Add(node);  
                }
                dbReader.Close();
                dbReader = null;
                lst_表.DataSource = dt;
                lst_表.DisplayMember = "Name";
                lst_表.ValueMember = "Id";

                DataTable dt_sp = new DataTable();
                dt_sp.Columns.Add("Id");
                dt_sp.Columns.Add("Name");

                // 存储过程
                dbCmd.CommandText = "select [Id],[Name] from [SysObjects] where type='p' and name like 'sp_%' order by [name] asc";
                dbReader = dbCmd.ExecuteReader();
                while(dbReader.Read()) {
                    DataRow newRow = dt_sp.NewRow();
                    newRow["Id"] = Toolkit.IngoreNull(dbReader["Id"]);
                    newRow["Name"] = Toolkit.IngoreNull(dbReader["Name"]);

                    dt_sp.Rows.Add(newRow);
                }
                dbReader.Close();
                dbReader = null;
                dbConn.Close();

                lst_存储过程.DataSource = dt_sp;
                lst_存储过程.DisplayMember = "Name";
                lst_存储过程.ValueMember = "Id";
            }
        }


        private SmTable getSmTable(string sechma_Name) {
            SmTable smTable = new SmTable();

            using(SqlConnection dbConn = new SqlConnection(tbx_Text.Text)) {
                dbConn.Open();
                SqlCommand selectCommand = new SqlCommand();
                selectCommand.Connection = dbConn;
                selectCommand.CommandText = "select t.name,e.value from sys.extended_properties e ,syscolumns t where e.name = 'MS_Description' and t.id = (select object_id('" + sechma_Name + "')) and e.major_id = t.id and e.minor_id = t.colorder";

                DataTable dt_Comment = new DataTable();
                SqlDataAdapter comment = new SqlDataAdapter();
                comment.SelectCommand = selectCommand;
                comment.Fill(dt_Comment);


                SqlDataAdapter dbAdapter = new SqlDataAdapter() {
                    //SelectCommand = new SqlCommand(String.Format("select * from [{0}]",sechma_Name),dbConn)
                    SelectCommand = new SqlCommand("sp_columns " + sechma_Name,dbConn)
                };
                DataTable dt = new DataTable();
                int getCount = dbAdapter.Fill(dt);

                SqlDataAdapter dbpk = new SqlDataAdapter() {
                    SelectCommand=new SqlCommand("sp_pkeys @table_name='" + sechma_Name + "'",dbConn)
                };
                DataTable dt_pk = new DataTable();
                dbpk.Fill(dt_pk);
                string pkname = "";
                if(dt_pk != null && dt_pk.Rows.Count > 0) {
                    pkname = Toolkit.IngoreNull(dt_pk.Rows[0]["Column_name"]);
                }
                
                smTable.Name = sechma_Name;
                foreach(DataRow getRow in dt.Rows) {
                    if(smTable.Columns == null) {
                        smTable.Columns = new List<SmColumn>();
                    }

                    string typeName = Toolkit.IngoreNull(getRow["Type_Name"]);
                    string isNullAble = Toolkit.IngoreNull(getRow["Is_Nullable"]);

                    SmColumn smColumn = new SmColumn();
                    smColumn.Name = Toolkit.IngoreNull(getRow["Column_Name"]);
                    smColumn.AllowDBNull = false;
                    smColumn.DbType = Toolkit.transTypeName(typeName);

                    DataRow[] commentRows = dt_Comment.Select("name='" + smColumn.Name + "'");
                    if(commentRows.Length > 0) {
                        DataRow commentRow = commentRows[0];
                        smColumn.Remarks = commentRow[1].ToString();
                    }
                    smColumn.MaxLength = Toolkit.ParseInt(getRow["Length"]);

                    if(typeName.IndexOf("identity") != -1 || smColumn.Name.Equals(pkname,StringComparison.CurrentCultureIgnoreCase)) {
                        smColumn.PrimaryKey = true;
                    }

                    smColumn.AllowDBNull = isNullAble.Equals("NO",StringComparison.CurrentCultureIgnoreCase) ? true : false;



                    if(smColumn.PrimaryKey == true) {   // 主键放在最开始的位置
                        smTable.Columns.Insert(0,smColumn);
                    } else {
                        smTable.Columns.Add(smColumn);
                    }
                }
                //foreach(DataColumn temp in dt.Columns) {
                //    if(smTable.Columns == null) {
                //        smTable.Columns = new List<SmColumn>();
                //    }


                //    SmColumn smColumn = new SmColumn();
                //    if(temp.Unique == true) {
                //        smColumn.PrimaryKey = true;
                //    }
                //    smColumn.Name = temp.ColumnName;
                //    smColumn.Type = temp.DataType;
                //    smColumn.DateTimeMode = temp.DateTimeMode;
                //    smColumn.DefaultValue = temp.DefaultValue;
                //    smColumn.MaxLength = temp.MaxLength;
                //    smColumn.AllowDBNull = temp.AllowDBNull;
                //    smColumn.Caption = temp.Caption;

                //    if(smColumn.PrimaryKey == true) {   // 主键放在最开始的位置
                //        smTable.Columns.Insert(0,smColumn);
                //    } else {
                //        smTable.Columns.Add(smColumn);
                //    }

                //    Console.WriteLine(smColumn.Type.ToString());
                //}
                dbConn.Close();
            }
            return smTable;
        }


        string createGetByIdMethod(SmTable smTable) {
            StringBuilder getMethod = new StringBuilder();

            getMethod.Append("\r\n");
            getMethod.Append("public static ").Append(tbx_类前缀.Text).Append(smTable.Name).Append(" Get").Append(tbx_类前缀.Text).Append(smTable.Name).Append("(string sqlCondition,bool getVoContent) {\r\n");
            getMethod.Append("   List<").Append(tbx_类前缀.Text).Append(smTable.Name).Append("> getList = Get").Append(tbx_类前缀.Text).Append(smTable.Name).Append("(sqlCondition,getVoContent,\"\");").Append("\r\n");
            getMethod.Append("   if(getList.Count > 0) {\r\n");
            getMethod.Append("      return getList[0];\r\n");
            getMethod.Append("   }else{\r\n");
            getMethod.Append("      return null;\r\n");
            getMethod.Append("   }\r\n");

            getMethod.Append("}\r\n");
            return getMethod.ToString();
        }

        string createGetListMethod(SmTable smTable) {
            StringBuilder getMethod = new StringBuilder();

            getMethod.Append("\r\n");
            getMethod.Append("// sqlCondition=查询条件\r\n");
            getMethod.Append("// getVoContent=true仅查询VoContent，=false查询展示字段（不包括VoContent）\r\n");
            getMethod.Append("// sortCodtion=排序条件\r\n");
            getMethod.Append("public static List<").Append(tbx_类前缀.Text).Append(smTable.Name).Append("> Get").Append(tbx_类前缀.Text).Append(smTable.Name).Append("(string sqlCondition,bool getVoContent,string sortCondition){\r\n");

            getMethod.Append("  List<").Append(tbx_类前缀.Text).Append(smTable.Name).Append("> getList = new List<").Append(tbx_类前缀.Text).Append(smTable.Name).Append(">();\r\n");
            getMethod.Append("  SqlCommand dbCmd = new SqlCommand();\r\n");
            getMethod.Append("  try{\r\n");
            getMethod.Append("      using(SqlConnection dbConn = new SqlConnection(DBUtil.MSSQLConnectionString)){\r\n");
            getMethod.Append("          dbConn.Open();\r\n");
            getMethod.Append("          dbCmd.Connection = dbConn;\r\n");
            getMethod.Append("  \r\n");
            getMethod.Append("          if(string.IsNullOrEmpty(sortCondition)) {\r\n");
            getMethod.Append("              sortCondition = \" Order by [ModifyTime] desc\";\r\n");
            getMethod.Append("          }\r\n");
            getMethod.Append("          if(getVoContent == true) {\r\n");
            getMethod.Append("              dbCmd.CommandText = \"select [VoContent] from [").Append(smTable.Name).Append("]").Append("\" + sqlCondition + sortCondition;\r\n");
            getMethod.Append("          }else{\r\n");
            getMethod.Append("              dbCmd.CommandText = \"select ").Append(getSelectFields(smTable.Columns)).Append(" from ").Append(smTable.Name).Append("\" + sqlCondition + sortCondition;\r\n");
            getMethod.Append("          }\r\n");
            getMethod.Append("  \r\n");
            getMethod.Append("          SqlDataReader dbReader = dbCmd.ExecuteReader();\r\n");
            getMethod.Append("          while(dbReader.Read()) {\r\n");
            getMethod.Append("              ").Append(tbx_类前缀.Text).Append(smTable.Name).Append("   getValue = new ").Append(tbx_类前缀.Text).Append(smTable.Name).Append("();\r\n");
            getMethod.Append("              if(getVoContent == true) {\r\n");
            getMethod.Append("                  string getXMLString = BIMPUtil.IngoreNull(dbReader[\"VoContent\"]);\r\n");
            getMethod.Append("                  getValue = (").Append(tbx_类前缀.Text).Append(smTable.Name).Append(")BIMPUtil.ParseObjectFromXMLString(getXMLString,typeof(").Append(tbx_类前缀.Text).Append(smTable.Name).Append("));\r\n");
            getMethod.Append("              }else{\r\n");
            getMethod.Append("                  getValue = new ").Append(tbx_类前缀.Text).Append(smTable.Name).Append("();\r\n");
            getMethod.Append(getChaXunFields(smTable.Columns));
            getMethod.Append("              }\r\n");
            getMethod.Append("              getList.Add(getValue);\r\n");
            getMethod.Append("          }\r\n");
            getMethod.Append("          dbReader.Close();\r\n");
            getMethod.Append("          dbReader = null;\r\n");
            getMethod.Append("      \r\n");
            getMethod.Append("          dbConn.Close();\r\n");
            getMethod.Append("      }");
            getMethod.Append("  }catch{\r\n");
            getMethod.Append("  }finally{\r\n");
            getMethod.Append("      dbCmd = null;\r\n");
            getMethod.Append("  }\r\n");
            getMethod.Append("  \r\n");
            getMethod.Append("  return getList;\r\n");
            getMethod.Append("}\r\n");

            return getMethod.ToString();
        }

        string getChaXunFields(List<SmColumn> smColumns) {
            StringBuilder temp = new StringBuilder();
            foreach(SmColumn smColumn in smColumns) {
                if(smColumn.Name.Equals("VoContent")) {
                    continue;
                }
                temp.Append("                  getValue.").Append(smColumn.Name).Append(" = ").Append(getToolkitMethod(smColumn));
            }
            return temp.ToString();
        }

        string getToolkitMethod(SmColumn smColumn) {
            string temp = "";
            if(smColumn.DbType.Equals(typeof(string))) {
                temp = "BIMPUtil.IngoreNull(dbReader[\"" + smColumn.Name + "\"]);\r\n";
            } else if(smColumn.DbType.Equals(typeof(int))) {
                temp = "BIMPUtil.ParseInt(dbReader[\"" + smColumn.Name + "\"]);\r\n";
            } else if(smColumn.DbType.Equals(typeof(Int16))) {
                temp = "BIMPUtil.ParseInt(dbReader[\"" + smColumn.Name + "\"]);\r\n";
            } else if(smColumn.DbType.Equals(typeof(DateTime))) {
                temp = "BIMPUtil.ParseDateTime(dbReader[\"" + smColumn.Name + "\"]);\r\n";
            } else if(smColumn.DbType.Equals(typeof(Single))) {
                temp = "BIMPUtil.ParseFloat(dbReader[\"" + smColumn.Name + "\"],2);\r\n";
            } else if(smColumn.DbType.Equals(typeof(bool))) {
                temp = "BIMPUtil.ParseBool(dbReader[\"" + smColumn.Name + "\"]);\r\n";
            }
            return temp;
        }

        string getSelectFields(List<SmColumn> smColumns) {
            string temp = "";

            foreach(SmColumn smColumn in smColumns) {
                if(smColumn.Name.Equals("VoContent")) {
                    continue;
                }
                if(string.IsNullOrEmpty(temp)) {
                    temp = "[" + smColumn.Name + "]";
                } else {
                    temp += ",[" + smColumn.Name + "]";
                }
            }

            return temp;
        }

        string getTypeString(Type getType) {
            string getString = "";

            if(getType.Equals(typeof(String))) {
                getString = "SqlDbType.NVarChar";
            } else if(getType.Equals(typeof(DateTime))) {
                getString = "SqlDbType.DateTime";
            } else if(getType.Equals(typeof(Single))) {
                getString = "SqlDbType.Real";
            } else if(getType.Equals(typeof(Int16))) {
                getString = "SqlDbType.Int";
            } else if(getType.Equals(typeof(int))) {
                getString = "SqlDbType.Int";
            } else if(getType.Equals(typeof(bool))) {
                getString = "SqlDbType.Bit";
            } else if(getType.Equals(typeof(Decimal))) {
                getString = "SqlDbType.Decimal";
            }

            return getString;
        }
        // 生成问号“?”占位字符
        private string getAskCode(int getCount) {
            string askCode = "";

            for(int n = 0;n < getCount;n++) {
                if(n > 0) {
                    askCode += ",";
                }
                askCode += "@Arg" + n;
            }

            return askCode;
        }


        // 解析OleDbType为System.Type
        string dbColumnType(SqlDbType getType) {
            string dbTypeString = "";

            switch(getType) {
                case SqlDbType.VarChar:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                case SqlDbType.NText:
                    dbTypeString = "string";
                    break;
                case SqlDbType.Int:
                    dbTypeString = "int";
                    break;
                case SqlDbType.Real:
                case SqlDbType.Money:
                    dbTypeString = "float";
                    break;
                case SqlDbType.DateTime:
                    dbTypeString = "DateTime";
                    break;
                case SqlDbType.Bit:
                    dbTypeString = "bool";
                    break;
                case SqlDbType.Decimal:
                    dbTypeString = "Decimal";
                    break;
                case SqlDbType.BigInt:
                    dbTypeString = "long";
                    break;
            }

            return dbTypeString;
        }

        private void Form_Main_Load(object sender,EventArgs e) {

        }

        private void btn_选择文件_Click(object sender,EventArgs e) {
            if(dlg_OpenFile.ShowDialog() == DialogResult.OK) {
                tbx_Text.Text = dlg_OpenFile.FileName;
            }
        }

        private void uc_Build_Dgv(object sender,EventArgs e) {
            StringBuilder temp = new StringBuilder();
            foreach(DataRow getRow in lst_表.SelectedIndices) {
                SmTable smTable = getSmTable(getRow["Name"].ToString());


                if(smTable == null) {
                    continue;
                }
                temp.Append("void loadList(){\r\n");
                temp.Append("   dgv.Rows.Clear();\r\n");
                temp.Append("\r\n");
                temp.Append("   string sqlCondition = \"\";\r\n");
                temp.Append("   string sortCondition = \"\";\r\n");
                temp.Append("   IList getList = DAOUtil.GetList(typeof(").Append(tbx_类前缀.Text).Append(smTable.Name).Append("),sqlCondition,sortCondition);\r\n");
                //temp.Append("   List<").Append(tbx_类前缀.Text).Append(smTable.Name).Append("> getList = DBToolkit.Get").Append(tbx_类前缀.Text).Append(smTable.Name).Append("(sqlCondition,false,sortCondition);\r\n");
                temp.Append("   foreach(").Append(tbx_类前缀.Text).Append(smTable.Name).Append(" getItem in getList) {\r\n");
                temp.Append("       dgv.Rows.Add();\r\n");

                foreach(SmColumn smColumn in smTable.Columns) {
                    if(smColumn.Name.Equals("VoContent")) {
                        continue;
                    }
                    if(smColumn.Name.Equals("ModifyTime")) {
                        continue;
                    }
                    temp.Append("       dgv.Rows[dgv.Rows.Count - 1].Cells[\"").Append(smColumn.Name).Append("_Column\"].Value = getItem.").Append(smColumn.Name).Append(";\r\n");
                }

                temp.Append("   }\r\n");
                temp.Append("}\r\n");
                temp.Append("\r\n");
                temp.Append("\r\n");
                temp.Append("\r\n");
                temp.Append("\r\n");

                temp.Append("   List<").Append(tbx_类前缀.Text).Append(smTable.Name).Append("> getList = new List<").Append(tbx_类前缀.Text).Append(smTable.Name).Append(">();\r\n");
                temp.Append("   foreach(DataGridViewRow getRow in dgv.Rows) {\r\n");
                temp.Append("       ").Append(tbx_类前缀.Text).Append(smTable.Name).Append(" getItem = new ").Append(tbx_类前缀.Text).Append(smTable.Name).Append("();\r\n");
                temp.Append("\r\n");
                foreach(SmColumn smColumn in smTable.Columns) {
                    if(smColumn.Name.Equals("VoContent")) {
                        continue;
                    }
                    if(smColumn.Name.Equals("ModifyTime")) {
                        continue;
                    }
                    temp.Append("       getItem.").Append(smColumn.Name).Append(" = ").Append(typeToControl("getRow.Cells[\"","_Column\"].Value",smColumn,true)).Append("\r\n");
                }
                temp.Append("       getList.Add(getItem);\r\n");
                temp.Append("   }\r\n");
            }
            tbx_DGV_Code.Text = temp.ToString();
            showPage.SelectedTab = tp_DGV;
        }

        private void uc_Build_Form(object sender,EventArgs e) {
            StringBuilder temp = new StringBuilder();
            foreach(DataRow getRow in lst_表.SelectedIndices) {
                SmTable smTable = getSmTable(getRow["Name"].ToString());

                if(smTable == null) {
                    return;
                }

                temp.Append(tbx_类前缀.Text).Append(smTable.Name).Append(" getValue = new ").Append(tbx_类前缀.Text).Append(smTable.Name).Append("();\r\n");
                temp.Append("\r\n");

                foreach(SmColumn smColumn in smTable.Columns) {
                    if(smColumn.Name.Equals("VoContent")) {
                        continue;
                    }
                    if(smColumn.Name.Equals("ModifyTime")) {
                        continue;
                    }
                    temp.Append("getValue.").Append(smColumn.Name).Append(" = ").Append(typeToControl("tbx_",".Text.Trim()",smColumn,false)).Append("\r\n");
                }
                temp.Append("\r\n");
                temp.Append("bool saveResult = DBToolkit.Save").Append(tbx_类前缀.Text).Append(smTable.Name).Append("(getValue);\r\n");
                temp.Append("\r\n");
                temp.Append("if(saveResult == true) {\r\n");
                temp.Append("   MessageBox.Show(this,\"操作成功\",\"系统提示\",MessageBoxButtons.OK,MessageBoxIcon.Information);\r\n");
                temp.Append("   loadList();\r\n");
                temp.Append("}\r\n");
                temp.Append("\r\n");
                temp.Append("\r\n");
                temp.Append("\r\n");
                temp.Append("\r\n");
                temp.Append("\r\n");

                temp.Append("string uuid = BIMPUtil.IngoreNull(dgv.Rows[e.RowIndex].Cells[\"UUID_Column\"].Value);\r\n");
                temp.Append(tbx_类前缀.Text).Append(smTable.Name).Append(" getItem = DBToolkit.Get").Append(tbx_类前缀.Text).Append(smTable.Name).Append("(uuid,false);\r\n");
                temp.Append("\r\n");

                foreach(SmColumn smColumn in smTable.Columns) {
                    string flowfix = getControlValuefix(smColumn.DbType);
                    temp.Append("tbx_").Append(smColumn.Name).Append(flowfix).Append("getItem.").Append(smColumn.Name).Append(";\r\n");
                }
            }
            //temp.Append("}\r\n");
            tbx_Form_Code.Text = temp.ToString();
        }

        private string getControlValuefix(SqlDbType type) {
            if(type == SqlDbType.DateTime) {
                return ".Value = ";
            }
            return ".Text = ";
        }

        string typeToControl(string prefix,string flowfix,SmColumn smColumn,bool getAction) {
            string temp = "";

            if(smColumn.DbType.Equals(typeof(string))) {
                if(getAction == false) {
                    temp = prefix + smColumn.Name + flowfix + ";";
                } else {
                    temp = "BIMPUtil.IngoreNull(" + prefix + smColumn.Name + flowfix + ");";
                }
            } else if(smColumn.DbType.Equals(typeof(DateTime))) {
                temp = "BIMPUtil.ParseDateTime(" + prefix + smColumn.Name + flowfix + ");";
            } else if(smColumn.DbType.Equals(typeof(Int16))) {
                temp = "BIMPUtil.ParseInt(" + prefix + smColumn.Name + flowfix + ");";
            } else if(smColumn.DbType.Equals(typeof(int))) {
                temp = "BIMPUtil.ParseInt(" + prefix + smColumn.Name + flowfix + ");";
            } else if(smColumn.DbType.Equals(typeof(float))) {
                temp = "BIMPUtil.ParseFloat(" + prefix + smColumn.Name + flowfix + ",2);";
            } else if(smColumn.DbType.Equals(typeof(bool))) {
                temp = "BIMPUtil.ParseBool(" + prefix + smColumn.Name + flowfix + ");";
            }

            return temp;
        }

        private void bbtn_BuildAll_Click(object sender,EventArgs e) {
            //btn_BuildDAO_Click(sender,e);
            //btn_BuildDgv_Click(sender,e);
            //btn_BuildForm_Click(sender,e);
            //btn_BuildVO_Click(sender,e);
            //btn_BuildFiled_Click(sender,e);
            //showPage.SelectedTab = VO_Page;
        }

        private void btn_BuildFiled_Click(object sender,EventArgs e) {
            StringBuilder temp = new StringBuilder();
            foreach(DataRow getRow in lst_表.SelectedIndices) {
                SmTable smTable = getSmTable(getRow["Name"].ToString());
                if(smTable == null) {
                    continue;
                }
                foreach(SmColumn smColumn in smTable.Columns) {
                    temp.Append(smColumn.Name).Append("\r\n");
                }

                temp.Append("\r\n");
                temp.Append("\r\n");
                temp.Append("\r\n");

                foreach(SmColumn smColumn in smTable.Columns) {
                    temp.Append(smColumn.Name).Append("_Column\r\n");
                }

                temp.Append("\r\n");
                temp.Append("\r\n");
                temp.Append("\r\n");

                foreach(SmColumn smColumn in smTable.Columns) {
                    temp.Append("tbx_").Append(smColumn.Name).Append("\r\n");
                }
            }
            tbx_字段列表.Text = temp.ToString();
        }

        private void btn_Create_Click(object sender,EventArgs e) {

        }

        private void uc_Build_TableName(object sender,EventArgs e) {
            StringBuilder temp = new StringBuilder();

            temp.Append("using System;\r\n");
            temp.Append("namespace com.cgWorkstudio.BIMP.Client.vo {\r\n");
            temp.Append("   [Serializable]\r\n");
            temp.Append("   internal class BIMPDict_Sechma {\r\n");

            int n = 0;
            foreach(DataRow node in lst_表.SelectedIndices) {
                string getText = node["Name"].ToString();

                Console.WriteLine(getText);
                if(getText.StartsWith("App_") || getText.StartsWith("Log_")) {
                } else {
                    char getChar;
                    char.TryParse(getText,out getChar);

                    if((getChar >= 'a' && getChar <= 'z') || getChar >= 'A' && getChar <= 'Z') {
                        continue;
                    }
                }

                temp.Append("   static string temp").Append(n).Append(" = string.Empty;\r\n");
                temp.Append("   internal static string ").Append(getText).Append(" {\r\n");
                temp.Append("       get {\r\n");
                temp.Append("           if(string.IsNullOrEmpty(temp").Append(n).Append(")) {\r\n");
                temp.Append("               temp").Append(n).Append(" = \"").Append(getText).Append("\";\r\n");
                temp.Append("           }\r\n");
                temp.Append("           return temp").Append(n).Append(";\r\n");
                temp.Append("       }\r\n");
                temp.Append("   }\r\n");
                n++;
            }
            temp.Append("    }\r\n");
            temp.Append("}\r\n");

            tbx_表名.Text = temp.ToString();

            showPage.SelectedTab = tp_TableName;
        }

        private void dbmenu_Click(object sender,EventArgs e) {

        }

        private void menuItem_ChangYong_Click(object sender,EventArgs e) {
            showPage.SelectedTab = tp_常用数据;

            StringBuilder tmp = new StringBuilder();
            tmp.Append("using System;\r\n");
            tmp.Append("using System.Collections.Generic;\r\n");
            tmp.Append("using System.Text;\r\n");

            tmp.Append("namespace com.cgWorkstudio.BIMP.Client.vo {\r\n");
            tmp.Append("    /// <summary>\r\n");
            tmp.Append("    /// 常量定义常用资料（基础数据）\r\n");
            tmp.Append("    /// </summary>\r\n");
            tmp.Append("    [Serializable]\r\n");
            tmp.Append("    public class BIMPDict_Common {\r\n");

            SqlCommand dbCmd = new SqlCommand();
            using(SqlConnection dbConn = new SqlConnection(tbx_Text.Text)) {
                dbConn.Open();
                dbCmd.Connection = dbConn;
                dbCmd.CommandText = "select [Code],[Text] from [基础数据_常用资料] where [Type] = 'Group'";

                SqlDataReader dbReader = dbCmd.ExecuteReader();
                while(dbReader.Read()) {
                    string uuid = Toolkit.IngoreNull(dbReader["Code"]);
                    string txt = Toolkit.IngoreNull(dbReader["Text"]);

                    tmp.Append("            public static string ").Append(txt).Append(" = \"").Append(uuid).Append("\";\r\n");
                }
                dbReader.Close();
                dbReader = null;

                tmp.Append("    }\r\n");
                tmp.Append("}\r\n");
                dbConn.Close();
            }
            tbx_常用数据.Text = tmp.ToString();
        }

        private void btn_连接_Click(object sender,EventArgs e) {
            this.Cursor = Cursors.WaitCursor;
            using(SqlConnection dbConn = new SqlConnection(tbx_Text.Text)) {
                try {
                    dbConn.Open();
                    dbConn.Close();
                    load_SchemaList();
                } catch(Exception ex) {
                    MessageBox.Show(this,ex.ToString(),"系统提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    tbx_Text.Focus();
                }
            }
            this.Cursor = Cursors.Default;
        }


        private void btn_Build_Clicked(object sender,EventArgs e) {
            Button btn = (Button)sender;
            uc_BuildAction(btn.Name,true);
        }

        private void uc_BuildAction(string buildType,bool showConfirm) {
            tbx_DAO_Code.Clear();
            tbx_VO_Code.Clear();

            foreach(DataRowView getRow in lst_表.SelectedItems) {
                string schemaName = getRow["Name"].ToString();
                string getBuildString = string.Empty;

                switch(buildType) {
                    case "btn_DAO":
                        getBuildString = createDAO(schemaName);

                        tbx_DAO_Code.AppendText(getBuildString);
                        tbx_DAO_Code.AppendText("\n\n");

                        showPage.SelectedTab = tp_DAO;
                        break;
                    case "btn_VO":
                        getBuildString = buildValueObject(schemaName);

                        if(showConfirm == false) {
                            string filePath = tbx_SavePath_VO.Text + "\\" + tbx_类前缀.Text + schemaName + ".cs";
                            bool saveResult = uc_SaveFile(filePath,getBuildString);

                            this.Invoke(new OnSaveFileCallback(showSaveFileMessage),new object[] { filePath });
                            Application.DoEvents();
                        } else {
                            tbx_VO_Code.AppendText(getBuildString);
                            tbx_VO_Code.AppendText("\n\n");
                        }
                        showPage.SelectedTab = tp_VO;
                        break;
                }
            }

            if(showConfirm == false) {
                MessageBox.Show("操作完成");
            }
        }

        void showSaveFileMessage(string filePath) {
            tbx_VO_Code.AppendText(filePath);
            tbx_VO_Code.AppendText(" - 已生成\n");
        }

        private bool uc_SaveFile(string filePath,string getBuildString) {
            bool saveResult = false;
            try {
                StreamWriter vofile = File.CreateText(filePath);
                vofile.Write(getBuildString);
                vofile.Flush();
                vofile.Close();
                vofile = null;

                saveResult = true;
            } catch {
                saveResult = false;
            }
            return saveResult;
        }

        private void btn_File_Click(object sender,EventArgs e) {
            string vofilepath = tbx_SavePath_VO.Text + "\\" + tbx_VOFile.Text.Trim();
            bool saveResult = uc_SaveFile(vofilepath,tbx_VO_Code.Text);
            if(saveResult == true) {
                if(MessageBox.Show(this,"文件已保存，是否打开文件夹？","系统提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) {
                    Process.Start(tbx_SavePath_VO.Text);
                }
            }
        }

        List<string> ingoreList = new List<string>() {
        "UUID","ShopId","ModifyTime","ShowIndex"};

        private string buildValueObject(string sechemaName) {
            SmTable smTable = getSmTable(sechemaName);

            StringBuilder temp = new StringBuilder();

            string vofile = tbx_类前缀.Text + smTable.Name;
            tbx_VOFile.Text = vofile + ".cs";
            temp.Append("using System;\r\n");
            temp.Append("using System.Collections.Generic;\r\n");
            temp.Append("using System.Text;\r\n");
            temp.Append("using com.yuzz.dbframework;\r\n");
            temp.Append("using System.Data;\r\n");

            //temp.Append("namespace com.jlkj.webapp {\r\n");
            temp.Append("   [Serializable]\r\n");
            temp.Append("   public class ").Append(tbx_类前缀.Text).Append(smTable.Name).Append(" {\r\n");//.Append(":DBItem{\r\n");
            //temp.Append("   public class ").Append(smTable.Name).Append(":DBItem{\r\n");
            temp.Append("      private string _TableName = string.Empty;\r\n");
            temp.Append("      public virtual string TableName {\r\n");
            temp.Append("          get{\r\n");
            temp.Append("              if(string.IsNullOrEmpty(_TableName)){\r\n");
            temp.Append("                  _TableName = \"" + smTable.Name + "\";\r\n");
            temp.Append("              }\r\n");
            temp.Append("              return _TableName;\r\n");
            temp.Append("          }\r\n");
            temp.Append("      }\r\n");

            foreach(SmColumn smColumn in smTable.Columns) {
                if(smColumn.PrimaryKey) {
                    temp.Append("      private string _PkFieldName = string.Empty;\r\n");
                    temp.Append("      public virtual string PkFieldName {\r\n");
                    temp.Append("          get{\r\n");
                    temp.Append("              if(string.IsNullOrEmpty(_PkFieldName)){\r\n");
                    temp.Append("                  _PkFieldName = \"" + smColumn.Name + "\";\r\n");
                    temp.Append("              }\r\n");
                    temp.Append("              return _PkFieldName;\r\n");
                    temp.Append("          }\r\n");
                    temp.Append("      }\r\n");
                    break;
                }
            }

            temp.Append("      private List<SQLField> _Fields = null;\r\n");
            temp.Append("      public List<SQLField> Fields{\r\n");
            temp.Append("          get{\r\n");
            temp.Append("              if(_Fields == null){\r\n");
            temp.Append("                  _Fields = new List<SQLField>();\r\n");

            string pkFieldType = string.Empty;
            foreach(SmColumn smColumn in smTable.Columns) {
                pkFieldType = Toolkit.ParseDbTypeString(smColumn.DbType);
                if(smColumn.PrimaryKey) {
                    temp.Append("                  _Fields.Add(new SQLField(\"" + smColumn.Name + "\"," + pkFieldType + ",true));\r\n");
                } else if(string.IsNullOrEmpty(smColumn.Remarks) == false) {
                    temp.Append("                  _Fields.Add(new SQLField(\"" + smColumn.Name + "\"," + pkFieldType + ",false,\"" + smColumn.Remarks.Trim().Replace("\r","").Replace("\n","") + "\"));\r\n");
                } else {
                    temp.Append("                  _Fields.Add(new SQLField(\"" + smColumn.Name + "\"," + pkFieldType + "));\r\n");
                }
            }
            temp.Append("              }\r\n");
            temp.Append("              return _Fields;\r\n");
            temp.Append("          }\r\n");
            temp.Append("      }\r\n");
            foreach(SmColumn smColumn in smTable.Columns) {
                switch(smColumn.Name) {
                    case "UUID":
                    case "ModifyTime":
                    //case "ShopId":
                    case "ShowIndex":
                        continue;
                }
                temp.Append("      public virtual ").Append(dbColumnType(smColumn.DbType)).Append(" ").Append(smColumn.Name).Append(" {\r\n");
                temp.Append("          get;\r\n");
                temp.Append("          set;\r\n");
                temp.Append("      }\r\n");
            }
            temp.Append("   }");
            //temp.Append("}");

            //if(saveToFile) {
            //    string filePath = Application.StartupPath + "\\makefile\\BIMP_" + smTable.Name + ".cs";
            //    StreamWriter streamWriter = File.CreateText(filePath);
            //    streamWriter.Write(temp.ToString());
            //    streamWriter.Flush();
            //    streamWriter.Close();
            //    streamWriter = null;
            //} else {
            //    tbx_VO_Code.Text = temp.ToString();
            //}

            return temp.ToString();
        }

        private string createDAO(string sechemaName) {
            SmTable smTable = getSmTable(sechemaName);

            StringBuilder code = new StringBuilder();

            code.Append(" #region -------------------------------------------------------------------").Append(smTable.Name).Append("-------------------------------------------------------------------\r\n");

            code.Append("public static bool Save").Append(tbx_类前缀.Text).Append(smTable.Name).Append("(").Append(tbx_类前缀.Text).Append(smTable.Name).Append(" getValue){\r\n");
            code.Append("   bool saveResult = false;\r\n");
            code.Append("   \r\n");
            code.Append("   SqlCommand dbCmd = new SqlCommand();\r\n");
            code.Append("   try{\r\n");
            code.Append("       using(SqlConnection dbConn = new SqlConnection(DBUtil.MSSQLConnectionString)){\r\n");
            code.Append("           dbConn.Open();\r\n");
            code.Append("           dbCmd.Connection = dbConn;\r\n");

            code.Append("           if(string.IsNullOrEmpty(getValue.UUID) == true){\r\n"); // 增加操作
            code.Append("               getValue.UUID = BIMPUtil.CreateUUID();\r\n");
            code.Append("               dbCmd.CommandText = \"");

            code.Append("insert into [").Append(smTable.Name).Append("]");          // 构建SQL
            code.Append("(");
            for(int n = 0;n < smTable.Columns.Count;n++) {
                SmColumn smColumn = smTable.Columns[n];
                if(n > 0) {
                    code.Append(",");
                }
                code.Append("[").Append(smColumn.Name).Append("]");
            }

            code.Append(") values(").Append(getAskCode(smTable.Columns.Count)).Append(")\";\r\n");
            code.Append("              dbCmd.Parameters.Clear();\r\n");
            code.Append("      \r\n");
            int argIndex = 0;
            foreach(SmColumn smColumn in smTable.Columns) {
                string getContentString = "getValue." + smColumn.Name;
                if(smColumn.DbType.Equals(typeof(string))) {
                    getContentString = "BIMPUtil.IngoreNull(" + getContentString + ")";
                }

                if(smColumn.Name.Equals("VoContent")) {
                    getContentString = "BIMPUtil.GetXMLString(getValue)";
                } else if(smColumn.Name.Equals("ModifyTime")) {
                    getContentString = "DateTime.Now";
                }
                code.Append("              dbCmd.Parameters.Add(\"@Arg").Append(argIndex++).Append("\",").Append(Toolkit.ParseDbTypeString(smColumn.DbType)).Append(").Value = ").Append(getContentString).Append(";\r\n");
            }

            code.Append("         }else{\r\n");   // 修改操作
            code.Append("              dbCmd.CommandText = \"update [").Append(smTable.Name).Append("] set ");

            argIndex = 0;
            for(int n = 0;n < smTable.Columns.Count;n++) {
                SmColumn smColumn = smTable.Columns[n];
                if(smColumn.PrimaryKey == true || smColumn.Name.Equals("UUID")) {   // 忽略主键
                    continue;
                }

                code.Append(String.Format("[{0}]=@Arg" + argIndex++ + "",smColumn.Name));
                if(n < smTable.Columns.Count - 1) {
                    code.Append(",");
                }
            }
            code.Append(" where [UUID]=@Arg" + argIndex + ";\";\r\n");
            code.Append("              dbCmd.Parameters.Clear();\r\n");

            argIndex = 0;
            foreach(SmColumn smColumn in smTable.Columns) {
                if(smColumn.PrimaryKey == true || smColumn.Name.Equals("UUID")) {   // 忽略主键
                    continue;
                }
                string getContentString = "getValue." + smColumn.Name;
                if(smColumn.Name.Equals("VoContent")) {
                    getContentString = "BIMPUtil.GetXMLString(getValue)";
                } else if(smColumn.Name.Equals("ModifyTime")) {
                    getContentString = "DateTime.Now";
                }
                code.Append("              dbCmd.Parameters.Add(\"@Arg").Append(argIndex++).Append("\",").Append(Toolkit.ParseDbTypeString(smColumn.DbType)).Append(").Value = ").Append(getContentString).Append(";\r\n");
            }
            code.Append("              dbCmd.Parameters.Add(\"@Arg" + argIndex + "\",OleDbType.VarChar).Value = getValue.UUID;\r\n");

            code.Append("          }\r\n");

            code.Append("          if(dbCmd.ExecuteNonQuery() > 0){\r\n");
            code.Append("              saveResult = true;\r\n");
            code.Append("          }\r\n");
            code.Append("          dbConn.Close();\r\n");
            code.Append("       }\r\n");
            code.Append("   }catch{\r\n");
            code.Append("       saveResult = false;\r\n");
            code.Append("   }finally{\r\n");
            code.Append("       dbCmd = null;\r\n");
            code.Append("   }\r\n");
            code.Append("   return saveResult;\r\n");
            code.Append("}");

            code.Append(createGetListMethod(smTable));
            code.Append(createGetByIdMethod(smTable));
            code.Append("#endregion --------------------------------------------------------------------------------------------------------------------------------------\r\n");

            return code.ToString();
        }

        private string uc_BuildVO(string sechemaName) {

            StringBuilder tmp = new StringBuilder();

            SmTable smTable = getSmTable(sechemaName);
            if(smTable != null) {
                tmp.Append("using System;\r\n");
                tmp.Append("using System.Collections.Generic;\r\n");
                tmp.Append("using System.Linq;\r\n");
                tmp.Append("using System.Text;\r\n");

                tmp.Append("namespace com.cgWorkstudio.BIMP.vo {\r\n");
                tmp.Append("    public class ").Append(smTable.Name).Append("{\r\n");

                foreach(SmColumn smColumn in smTable.Columns) {
                    tmp.Append("    SmColumn _").Append(smColumn.Name).Append(" = null;\r\n");
                    tmp.Append("    public virtual SmColumn ").Append(smColumn.Name).Append("{\r\n");
                    tmp.Append("        get{\r\n");
                    tmp.Append("            if(_").Append(smColumn.Name).Append(" == null){\r\n");
                    tmp.Append("                _").Append(smColumn.Name).Append(" = new SmColumn();\r\n");
                    tmp.Append("                _").Append(smColumn.Name).Append(".AllowDBNull = ").Append(smColumn.AllowDBNull.ToString().ToLower()).Append(";\r\n");
                    //tmp.Append("                _").Append(smColumn.Name).Append(".Caption = \"").Append(smColumn.Caption).Append("\";\r\n");
                    //tmp.Append("                _").Append(smColumn.Name).Append(".DateTimeMode = ").Append(smColumn.DateTimeMode).Append(";\r\n");
                    //tmp.Append("                _").Append(smColumn.Name).Append(".DefaultValue = ").Append(Toolkit.IngoreNull(smColumn.DefaultValue)).Append(";\r\n");
                    tmp.Append("                _").Append(smColumn.Name).Append(".MaxLength = ").Append(smColumn.MaxLength).Append(";\r\n");
                    tmp.Append("                _").Append(smColumn.Name).Append(".Name = \"").Append(smColumn.Name).Append("\";\r\n");
                    tmp.Append("                _").Append(smColumn.Name).Append(".PrimaryKey = ").Append(smColumn.PrimaryKey.ToString().ToLower()).Append(";\r\n");
                    tmp.Append("                _").Append(smColumn.Name).Append(".Type = typeof(").Append(smColumn.DbType).Append(");\r\n");
                    tmp.Append("            }\r\n");
                    tmp.Append("            return _").Append(smColumn.Name).Append(";\r\n");
                    tmp.Append("        }\r\n");
                    tmp.Append("    }\r\n");
                }

                tmp.Append("    }\r\n");
                tmp.Append("}\r\n");
            }

            return tmp.ToString();
            // showPage.SelectedTab = VO_Page;


            // StreamWriter txt = File.CreateText(Application.StartupPath + "\\makefile\\BIMP_" + smTable.Name + ".cs");
            // txt.Write(tmp.ToString());
            // txt.Flush();
            // txt.Close();
            // txt = null;
        }


        private void btn_BatchExec_Click(object sender,EventArgs e) {
            if(lst_表.SelectedItems.Count <= 0) {
                MessageBox.Show(this,"未选择要生成vo类的表。","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if(MessageBox.Show(this,"批量生成vo类，生成的vo类将直接写入本地文件。\r\n\r\n文件保存路径：" + tbx_SavePath_VO.Text + "\r\n类前缀：" + tbx_类前缀.Text + "\r\n共计：" + lst_表.SelectedItems.Count + "张表\r\n\r\n是否继续？","系统提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) {
                uc_BuildAction("btn_VO",false);
            }
        }

        private void btn_SoapTypes_Click(object sender,EventArgs e) {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("using System;\r\n");
            stringBuilder.Append("using BIMP.Win.WinUI.bimp_CloudPro;\r\n");
            stringBuilder.Append("namespace BIMP.Win.WinUI {\r\n");
            stringBuilder.Append("    public class SoapString {\r\n");

            foreach(DataRowView getRow in lst_表.SelectedItems) {
                string schemaName = getRow["Name"].ToString();

                stringBuilder.Append("\t").Append("public static string ").Append(schemaName.Replace("bimp_","")).Append(" {get {return typeof(").Append(schemaName).Append(").Name;}}").Append("\r\n");

            }

            foreach(DataRowView getRow in lst_存储过程.Items) {
                string getSp = getRow["Name"].ToString();
                stringBuilder.Append("\t").Append("public static string " + getSp + " {\r\n");
                stringBuilder.Append("\t").Append("    get {\r\n");
                stringBuilder.Append("\t").Append("        return \"" + getSp + "\";\r\n");
                stringBuilder.Append("\t").Append("    }\r\n");
                stringBuilder.Append("\t").Append("}   \r\n");
            }

            stringBuilder.Append("}}");
            tbx_DAO_Code.Clear();
            tbx_DAO_Code.Text = stringBuilder.ToString();
            showPage.SelectedTab = tp_DAO;

            //uc_SaveFile(textBox1.Text,tbx_DAO_Code.Text);
        }

        private void btn_XmlInclude_Click(object sender,EventArgs e) {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(DataRowView getRow in lst_表.SelectedItems) {
                string schemaName = getRow["Name"].ToString();
                stringBuilder.Append("[XmlInclude(typeof(").Append(schemaName).Append("))]\r\n");
            }

            tbx_DAO_Code.Clear();
            tbx_DAO_Code.Text = stringBuilder.ToString();
            showPage.SelectedTab = tp_DAO;
        }

        private void btn_授权码管理_Click(object sender,EventArgs e) {

        }

        private void btn_反向SQL_Click(object sender,EventArgs e) {
            if(lst_表.SelectedItems.Count > 1) {
                return;
            }

            foreach(DataRowView getRow in lst_表.SelectedItems) {
                string schemaName = getRow["Name"].ToString();
                SmTable smTable = getSmTable(schemaName);

                StringBuilder getString = new StringBuilder();
                getString.Append("CREATE TABLE [dbo].[").Append(smTable.Name).Append("] (\r\n");
                foreach(SmColumn getColumn in smTable.Columns) {
                    getString.Append("[").Append(getColumn.Name).Append("] ").Append(getColumn.DbType.ToString());
                    if(getColumn.PrimaryKey == true) {
                        getString.Append(" NOT NULL IDENTITY(1,1) ,\r\n");
                    } else {
                        getString.Append(" NULL,\r\n");
                    }
                }
                getString.Append(")");

                tbx_VO_Code.Text = getString.ToString();
                showPage.SelectedTab = tp_VO;
                break;
            }
        }

        private void menuItem_MySQL_Click(object sender,EventArgs e) {
            Form_MySQL frmMySQL = new Form_MySQL();
            frmMySQL.ShowDialog();
        }

        private void btn_table_Click(object sender,EventArgs e) {
            if(lst_表.SelectedItems.Count > 1) {
                MessageBox.Show("只支持单表。");
                return;
            }

            StringBuilder txt = new StringBuilder();

            //txt.Append("<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">\r\n");
            //txt.Append("\t<tr>\r\n");
            //txt.Append("\t\t<td><asp:Button ID=\"btn_submit\" Text=\"保存\"  runat=\"server\"/><asp:Button ID=\"btn_cancel\" Text=\"取消\"  runat=\"server\"/></td>\r\n");
            //txt.Append("\t</tr>\r\n");
            //txt.Append("</table>\r\n");

            txt.Append("<fieldset>\r\n");
            txt.Append("\t<legend>xxx详细信息：</legend>\r\n");

            txt.Append("\t<table id=\"editTable\" width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">\r\n");
            foreach(DataRowView getRow in lst_表.SelectedItems) {
                string schemaName = getRow["Name"].ToString();
                SmTable smTable = getSmTable(schemaName);
                foreach(SmColumn smColumn in smTable.Columns) {
                    string title = smColumn.Remarks;
                    if(string.IsNullOrEmpty(title)) {
                        title = smColumn.Name;
                    }
                    txt.Append("\t\t<tr>\r\n");
                    txt.Append("\t\t\t<td width=\"100px\" style=\"text-align:center;\">").Append(title).Append("：</td>\r\n");
                    txt.Append("\t\t\t<td>").Append("<asp:TextBox ID=\"tbx_").Append(smColumn.Name).Append("\" runat=\"server\" CssClass=\"tbx\"></asp:TextBox></td>\r\n");
                    //txt.Append("\t\t\t<td>").Append(smColumn.Name).Append("</td>\r\n");
                    txt.Append("\t\t</tr>\r\n");
                }
                //txt.Append("\t\t<tr>\r\n");
                //txt.Append("\t\t\t<td></td>\r\n");
                //txt.Append("\t\t\t<td>").Append(smTable.Columns.Count).Append("</td>\r\n");
                //txt.Append("\t\t</tr>\r\n");
            }
            txt.Append("\t</table>\r\n");
            txt.Append("</fieldset> ");
            tbx_DAO_Code.Clear();
            tbx_DAO_Code.AppendText(txt.ToString());
        }

        /// <summary>
        /// Asp.net Code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_aspnet_Click(object sender,EventArgs e) {
            if(lst_表.SelectedItems.Count > 1) {
                MessageBox.Show("只支持单表。");
                return;
            }

            // Asp.net Code
            StringBuilder txt_load = new StringBuilder();
            StringBuilder txt_save = new StringBuilder();
            txt_load.Append("int id = -1;\r\n");

            foreach(DataRowView getRow in lst_表.SelectedItems) {
                string schemaName = getRow["Name"].ToString();
                SmTable smTable = getSmTable(schemaName);

                // txt_load
                txt_load.Append("protected void Page_Load(object sender,EventArgs e) {\r\n");
                txt_load.Append("\t  id = WebUtil.ParseRequestInt(Request,\"id\");\r\n");
                txt_load.Append("\t  if(!Page.IsPostBack) {\r\n");
                txt_load.Append("\t\t    if(id > 0) {\r\n");
                txt_load.Append("\t\t\t      ").Append(schemaName).Append(" item = DBUtil.GetItem<").Append(schemaName).Append(">(id);\r\n");

                // txt_save
                txt_save.Append("id = WebUtil.ParseRequestInt(Request,\"id\");\r\n");
                txt_save.Append(schemaName).Append(" saveItem = null;\r\n");
                txt_save.Append("if(id > 0) {\r\n");
                txt_save.Append("\t     saveItem = DBUtil.GetItem<").Append(schemaName).Append(">(id);\r\n");
                txt_save.Append("} else {\r\n");
                txt_save.Append("\t     saveItem = new ").Append(schemaName).Append("();\r\n");
                txt_save.Append("\t     saveItem.shopid = shopid;\r\n");
                txt_save.Append("}\r\n");

                

                foreach(SmColumn smColumn in smTable.Columns) {
                    string loadString = "item." + smColumn.Name;
                    string saveString = "tbx_" + smColumn.Name + ".Text.Trim()";
                    switch(smColumn.DbType) {
                        case SqlDbType.Int:
                            loadString += ".ToString()";
                            saveString = "WebUtil.ParseInt(" + saveString + ")";
                            break;
                        case SqlDbType.Float:
                        case SqlDbType.Real:
                            loadString += ".ToString()";
                            saveString = "WebUtil.ParseFloat(" + saveString + ")";
                            break;
                        case SqlDbType.Date:
                            loadString += ".ToString(\"yyyy-MM-dd\")";
                            saveString = "WebUtil.ParseDate(" + saveString + ")";
                            break;
                        case SqlDbType.DateTime:
                            loadString += ".ToString(\"yyyy-MM-dd HH:mm:ss\")";
                            saveString = "WebUtil.ParseDateTime(" + saveString + ")";
                            break;
                    }
                    txt_load.Append("\t\t\t      tbx_").Append(smColumn.Name).Append(".Text = ").Append(loadString).Append(";\r\n");

                    txt_save.Append(" saveItem.").Append(smColumn.Name).Append(" = ").Append(saveString).Append(";\r\n");
                }

                // txt_load
                txt_load.Append("\t\t    }\r\n");
                txt_load.Append("\t  }\r\n");
                txt_load.Append("}\r\n");

                // txt_save
                txt_save.Append("\r\nSaveResult result = DBUtil.Save(saveItem);\r\n");
                txt_save.Append("if(result.Id > 0) {\r\n");
                txt_save.Append("\t     Response.Write(\"<script>alert('操作成功。');window.location='XXX.aspx';</script>\");\r\n");
                txt_save.Append("}\r\n");
            }
            tbx_Load.Clear();
            tbx_Load.AppendText(txt_load.ToString());

            tbx_Save.Clear();
            tbx_Save.AppendText(txt_save.ToString());
            showPage.SelectedTab = tp_load;
        }
    }
}