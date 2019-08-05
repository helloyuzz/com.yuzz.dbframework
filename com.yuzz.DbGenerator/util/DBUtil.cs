using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBFramework.vo;

namespace DBFramework.util {
    class DBUtil {
        static public bool Save(DBClass<BIMP_Test> getItem) {
            Console.Write(getItem.PrimaryKey);
            return false;
        }
    }
}
