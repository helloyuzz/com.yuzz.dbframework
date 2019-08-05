using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.yuzz.dbframework
{
    [Serializable]
    public class MultiOn
    {
        public virtual string t1_field
        {
            get;
            set;
        }
        public virtual string t2_field
        {
            get;
            set;
        }

        /// <summary>
        /// 格式：join.On = new MultiOn("t1.id","t2.fk_id");
        /// </summary>
        /// <param name="t1_field"></param>
        /// <param name="t2_field"></param>
        public MultiOn(string t1_field, string t2_field)
        {
            this.t1_field = t1_field;
            this.t2_field = t2_field;
        }
    }
}
