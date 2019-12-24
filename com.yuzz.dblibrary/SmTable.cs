using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.yuzz.dblibrary
{
    [Serializable]
    public class SmTable
    {
        public SmTable() {
        }

        public SmTable(string tableName) {
            TableName = tableName;
        }
        public SmTable(string tableId,string tableName) {
            TableId = tableId;
            TableName = tableName;
        }

        public virtual string TableId { get; set; }
        public virtual string TableName {
            get;
            set;
        }
        public virtual string Nickname { get; set; } = "";
        public virtual SmField PrimaryKey {
            get;
            set;
        }
        public virtual List<SmField> Fields {
            get;
            set;
        }
        public virtual bool ActiveUsing { get; set; }
        /// <summary>
        /// 使用的索引次序
        /// </summary>
        public virtual int UsingIndex { get; set; }
        public string Remarks { get; set; }
    }
}
