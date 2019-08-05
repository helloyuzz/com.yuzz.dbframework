﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBFramework.vo {
    class SmTable {
        public virtual string Name {
            get;
            set;
        }
        public virtual SmColumn PrimaryKey {
            get;
            set;
        }
        public virtual List<SmColumn> Columns {
            get;
            set;
        }
    }
}
