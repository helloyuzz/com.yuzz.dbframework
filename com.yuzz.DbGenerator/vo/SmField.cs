using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.yuzz.DbGenerator.vo {
    public class SmField {
        public SmField() {
        }
        public SmField(string text) {
            FiledName = text;
        }
        public virtual string FiledName {
            get;
            set;
        }
    }
}
