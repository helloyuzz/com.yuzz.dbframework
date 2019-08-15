using System;
using System.Collections.Generic;
using System.Text;

namespace com.yuzz.dbframework {
    [Serializable]
    public class SaveResult {
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public virtual bool OK { get; set; }
        public virtual int PK_Int {
            get;
            set;
        } = -1;
        public virtual string PK_Varchar {
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