using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.yuzz.dbframework
{
    [Serializable]
    public class MultiField
    {
        public virtual string nickname
        {
            get;
            set;
        }
        List<string> _Fields = null;
        public virtual List<string> Fields
        {
            get
            {
                if (_Fields == null)
                {
                    _Fields = new List<string>();
                }
                return _Fields;
            }
        }
    }
}
