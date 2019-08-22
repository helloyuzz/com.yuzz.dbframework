using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.yuzz.DbGenerator.vo {
    public class MySQLSchema {
        public MySQLSchema() {
        }

        public MySQLSchema(string schemaName,string tpnick,List<MySQLField> tag) {
            this.tbname = schemaName;
            this.tbnick = tpnick;
            this.tbfields = tag;
        }

        public virtual string tbname { get; set; }
        public virtual string tbnick { get; set; }
        public virtual List<MySQLField> tbfields { get; set; }
    }
}
