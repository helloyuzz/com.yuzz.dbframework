using System;
using System.Collections.Generic;
using System.Text;

namespace com.yuzz.dbframework {
    [Serializable]
    public class SaveResult {
        public virtual int PK_Int {
            get;
            set;
        } = -1;
        public virtual string PK_UUID {
            get;
            set;
        }
        public virtual string SchemaName {
            get;
            set;
        }
        public virtual string Msg {
            get;
            set;
        }
    }
}