using System;
using System.Collections.Generic;
using System.Web;

namespace com.yuzz.dbframework
{
    [Serializable]
    public class SpCondition
    {
        public virtual string Key
        {
            get;
            set;
        }
        public virtual string Value
        {
            get;
            set;
        }
    }
}
