using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace com.yuzz.DbGenerator {
    public class MyToolkit {
        public MyToolkit() {

        }

        internal static string IngoreNull(object getValue) {
            if(getValue == null || getValue == DBNull.Value) {
                return "";
            }
            return getValue.ToString();
        }

        internal static string GetType(Type type) {
            string tmp = "";

            if(type.Equals(typeof(string))) {
                tmp = "String";
            } else if(type.Equals(typeof(DateTime))) {
                tmp = "DateTime";
            }
            return tmp;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static string ParseToDbTypeString(SqlDbType type) {
            string dbTypeString = "";

            switch(type) {
                case SqlDbType.NVarChar:
                    dbTypeString = "SqlDbType.NVarChar";
                    break;
                case SqlDbType.Int:
                    dbTypeString = "SqlDbType.Int";
                    break;
                case SqlDbType.Real:
                    dbTypeString = "SqlDbType.Real";
                    break;
                case SqlDbType.DateTime:
                    dbTypeString = "SqlDbType.DateTime";
                    break;
                case SqlDbType.Bit:
                    dbTypeString = "SqlDbType.Bit";
                    break;
                case SqlDbType.Text:
                    dbTypeString = "SqlDbType.Text";
                    break;
                case SqlDbType.NText:
                    dbTypeString = "SqlDbType.NText";
                    break;
                case SqlDbType.Money:
                    dbTypeString = "SqlDbType.Money";
                    break;
                case SqlDbType.Decimal:
                    dbTypeString = "SqlDbType.Decimal";                    
                    break;
                case SqlDbType.BigInt:
                    dbTypeString = "SqlDbType.BigInt";                    
                    break;
            }

            return dbTypeString;
        }

        internal static SqlDbType ParseToSqlDbType(string typeName) {
            SqlDbType dbType = SqlDbType.Int;
            switch(typeName) {
                case "varchar":
                case "nvarchar":
                    dbType = SqlDbType.NVarChar;
                    break;
                case "datetime":
                    dbType = SqlDbType.DateTime;
                    break;
                case "bit":
                    dbType = SqlDbType.Bit;
                    break;
                case "int":
                    dbType = SqlDbType.Int;
                    break;
                case "real":
                case "float":
                    dbType = SqlDbType.Real;
                    break;
                case "text":
                    dbType = SqlDbType.Text;
                    break;
                case "ntext":
                    dbType = SqlDbType.NText;
                    break;
                case "money":
                    dbType = SqlDbType.Decimal;
                    break;
                case "bigint":
                    dbType = SqlDbType.BigInt;
                    break;
                case "decimal":
                    dbType = SqlDbType.Decimal;
                    break;
            }
            return dbType;
        }

        internal static int ParseInt(object obj) {
            int value;
            int.TryParse(IngoreNull(obj),out value);
            return value;
        }
    }
}
