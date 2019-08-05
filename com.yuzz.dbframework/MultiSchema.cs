using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.yuzz.dbframework
{
    [Serializable]
    public class MultiSchema
    {
        public virtual Type SchemaType
        {
            get;
            set;
        }
        public virtual string Nickname
        {
            get;
            set;
        }
    }
}
