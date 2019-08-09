using System;
using System.Collections.Generic;
using System.Text;

namespace com.yuzz.dbframework {
    public enum SQLAction {
        /// <summary>
        /// 默认查询
        /// </summary>
        Default,
        /// <summary>
        /// 不包括，也就是不查询后续字段
        /// </summary>
        NotInclude
    }
}