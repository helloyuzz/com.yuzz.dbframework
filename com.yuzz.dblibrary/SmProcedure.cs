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
        public SmProcedure(string p_Id,String p_Name) {
            ProcedureId = p_Id;
            ProcedureName = p_Name;
        }
        public virtual string ProcedureId { get; set; }
        public virtual string ProcedureName { get; set; }
    }
}
