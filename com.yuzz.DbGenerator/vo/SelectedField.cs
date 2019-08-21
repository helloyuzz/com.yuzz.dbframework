using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.yuzz.DbGenerator.vo {
   public class SelectedField {
        public string TableName { get; internal set; }
        public string FieldName { get; internal set; }
        public string TableNick { get; internal set; }
        public MySQLField SQLField { get; internal set; }
    }
}
