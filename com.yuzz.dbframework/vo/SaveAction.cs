using System;
using System.Collections.Generic;
using System.Text;

namespace com.yuzz.dbframework {
    /// <summary>
    /// 保存操作的类型，默认为Insert，可根据用户手动设置为Update
    /// </summary>
    public enum SaveAction {
        /// <summary>
        /// 向数据库添加记录（默认Insert操作）
        /// </summary>
        Insert,
        /// <summary>
        /// 更新对象中值发生变化的字段
        /// </summary>
        UpdateChangeField
    }
}