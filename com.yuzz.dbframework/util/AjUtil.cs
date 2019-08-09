using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace com.yuzz.dbframework.util {
    class AjUtil {
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
        /// <param name="item"></param>
        /// <returns></returns>
        public static string GetPkFieldName(object item) {
            List<MethodInfo> execMethods = AjUtil.GetMethodList(item.GetType());
            MethodInfo mdh_GetTableName = execMethods.Find(t => t.Name.Equals("get_PkFieldName",StringComparison.CurrentCultureIgnoreCase));
            string pkFieldName = (string)mdh_GetTableName.Invoke(item,null);
            return pkFieldName;
        }

    }
}
