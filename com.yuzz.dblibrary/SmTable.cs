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

        public virtual string TableName {
            get;
            set;
        }
        public virtual string Nickname { get; set; }
        public virtual SmField PrimaryKey {
            get;
            set;
        }
        public virtual List<SmField> Fields {
            get;
            set;
        }
    }
}
