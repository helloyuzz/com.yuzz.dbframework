using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.yuzz.DbGenerator.vo {
    public class MySQLReleationShip {
        public virtual string FromTable { get; set; }
        public virtual string FromNick { get; set; }
        public virtual string FromField { get; set; }
        public virtual string ToTable { get; set; }
        public virtual string ToNick { get; set; }
        public virtual string ToField { get; set; }
        public virtual MySQLJoin JoinType { get; set; }

    }
}
