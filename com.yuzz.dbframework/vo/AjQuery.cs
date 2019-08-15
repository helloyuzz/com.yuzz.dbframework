using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace com.yuzz.dbframework.vo {
    public class AjQuery {
        public DataTable DataTable { get; internal set; }
        public int RecordCount { get; set; }
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
    }
}
