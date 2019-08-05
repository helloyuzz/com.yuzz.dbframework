using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.cgWorkstudio.BIMP.MySQL {
    public class MySqlField {
        public virtual string Field {
            get;
            set;
        }
        public virtual string Type {
            get;
            set;
        }
        public virtual string Key {
            get;
            set;
        }
        public virtual string Comment {
            get;
            set;
        }
    }
}
