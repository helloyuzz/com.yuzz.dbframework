using System;
using System.Collections.Generic;
using System.Text;

namespace com.yuzz.dbframework {
    public enum AjQueryType {
        /// <summary>
        /// 默认，查询所有字段
        /// </summary>
        QueryAll,
        /// <summary>
        /// 包括，查询包括的字段
        /// </summary>
        Query_Include,
        /// <summary>
        /// 不包括，也就是不查询后续字段
        /// </summary>
        Query_Exclude
    }
}