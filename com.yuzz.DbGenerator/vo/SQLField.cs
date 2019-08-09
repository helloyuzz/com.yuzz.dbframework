using System;
using System.Collections.Generic;
using System.Data;

namespace com.yuzz.DbGenerator.vo {
    [Serializable]
    public class SQLField {
        public SQLField() {
        }
        public SQLField(string name,SqlDbType dbType) {
            Name = name;
            DbType = dbType;
        }
        public string Name {
            get;
            set;
        }
        public SqlDbType DbType {
            get;
            set;
        }
    }
}