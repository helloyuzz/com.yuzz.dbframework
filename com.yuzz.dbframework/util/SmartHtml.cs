using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Collections;
using com.yuzz.dbframework.util;

namespace com.yuzz.dbframework {
    public static class SmartHtml {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="getList"></param>
        /// <param name="htmlType"></param>
        /// <param name="ingoreFields"></param>
        /// <param name="startRow"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string ConvertToHtmlDataTable(IList getList,Type htmlType,List<string> ingoreFields,int startRow,int count) {
            if(ingoreFields == null) {
                ingoreFields = new List<string>();
            }
            StringBuilder tmp = new StringBuilder();

            List<MethodInfo> ary_Methods = dbframework.util.AjUtil.GetMethodList(htmlType);

            MethodInfo mdh_GetFields = ary_Methods.Find(t => t.Name.Equals("get_fields",StringComparison.CurrentCultureIgnoreCase));        // 获取表格所有字段的方法

            List<SQLField> sqlFields = (List<SQLField>)mdh_GetFields.Invoke(htmlType.Assembly.CreateInstance(htmlType.FullName),null);

            tmp.Append("{Items:[");
            int index = 0;
            int n = 0;
            foreach(object html in getList) {
                if(startRow != -1) {
                    if(n < startRow || n > startRow + count) {
                        n++;
                        continue;
                    }
                    n++;
                }

                if(index++ > 0) {
                    tmp.Append(",");
                }

                tmp.Append("{");
                bool added = false;
                foreach(SQLField sqlField in sqlFields) {
                    if(ingoreFields.Contains(sqlField.Name)) {
                        continue;
                    }

                    if(sqlField.Name.StartsWith("FK_") && sqlField.Name.EndsWith("_Id")) {
                        continue;
                    }
                    switch(sqlField.Name) {
                        case "UUID":
                        case "ModifyTime":
                            continue;
                    }
                    if(added == true) {
                        tmp.Append(",");
                    }
                    tmp.Append("'" + sqlField.Name + "'");
                    string methodName = "get_" + sqlField.Name;
                    MethodInfo methodInfo = ary_Methods.Find(t => t.Name.Equals(methodName));

                    object getValue = methodInfo.Invoke(html,null);
                    tmp.Append(":'" + getValue.ToString() + " '");
                    added = true;
                }
                tmp.Append("}");

                tmp.Append("\r\n");
            }
            tmp.Append("]}");

            return tmp.ToString();
        }
    }
}