﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.yuzz.DbGenerator.vo {
    public class MySQLField {
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