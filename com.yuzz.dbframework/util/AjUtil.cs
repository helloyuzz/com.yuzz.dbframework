using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace com.yuzz.dbframework.util {
    class Ajutil {
        /// <summary>
        /// 将对象的方法转换为List对象
        /// </summary>
        /// <param name="getType"></param>
        /// <returns></returns>
        public static List<MethodInfo> GetMethodList(Type getType) {
            List<MethodInfo> ary_Methods = new List<MethodInfo>();  // 将数组转换为ArrayList，便于采用LINQ进行快速的查询            

            foreach(MethodInfo tmpMethodInfo in getType.GetMethods()) {
                ary_Methods.Add(tmpMethodInfo);
            }
            return ary_Methods;
        }

        /// <summary>
        /// 解析object主键字段名称
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetPkFieldName(object obj) {
            List<MethodInfo> execMethods = Ajutil.GetMethodList(obj.GetType());
            MethodInfo mdh_GetTableName = execMethods.Find(t => t.Name.Equals("get_PkFieldName",StringComparison.CurrentCultureIgnoreCase));
            string pkFieldName = (string)mdh_GetTableName.Invoke(obj,null);
            return pkFieldName;
        }
        /// <summary>
        /// 解析object数据库表名
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetSechemaName(object obj) {
            List<MethodInfo> execMethods = Ajutil.GetMethodList(obj.GetType());
            MethodInfo mdh_GetTableName = execMethods.Find(t => t.Name.Equals("get_tablename",StringComparison.CurrentCultureIgnoreCase));
            string dbname = (string)mdh_GetTableName.Invoke(obj,null);
            return dbname;
        }
        /// <summary>
        /// 解析object所有字段
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<SQLField> GetAllFields(object obj) {
            List<MethodInfo> execMethods = Ajutil.GetMethodList(obj.GetType());
            MethodInfo mdh_GetFields = execMethods.Find(t => t.Name.Equals("get_fields",StringComparison.CurrentCultureIgnoreCase));
            List<SQLField> sqlFields = (List<SQLField>)mdh_GetFields.Invoke(obj,null);
            return sqlFields;
        }

        internal static void ConvertAsObject<T>(DataTable dataTable,ref T item){
            List<MethodInfo> execMethods = Ajutil.GetMethodList(item.GetType());
            foreach(DataColumn col in dataTable.Columns) {  // 遍历数据库中所有列
                MethodInfo setMethod = execMethods.Find(t => t.Name.Equals("set_" + col.ColumnName,StringComparison.CurrentCultureIgnoreCase));
                object dbValue = dataTable.Rows[0][col.ColumnName];
                if(dbValue == DBNull.Value) {   // 数据库为null
                    if(col.DataType.Equals(typeof(DateTime))) { // 日期类型
                        dbValue = DateTime.Parse("1901-01-01 01:01:01");
                    }
                }
                setMethod.Invoke(item,new object[] { dbValue });
            }
        }
    }
}
