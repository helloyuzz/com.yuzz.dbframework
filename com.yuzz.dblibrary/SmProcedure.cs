using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.yuzz.dblibrary
{
    public class SmProcedure
    {
        public SmProcedure() {
        }
        public SmProcedure(String p_Name) {
            ProcedureName = p_Name;
        }
        public virtual string ProcedureName { get; set; }
        public string SQLText { get; set; }
    }
}
