using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.yuzz.DbGenerator.vo {
    public class DBClass<T> {
        string _SechmaName = string.Empty;

        public string SechmaName {
            get {
                return _SechmaName;
            }
            set {
                _SechmaName = value;
            }
        }
        SmField _PrimaryKey = null;

        public SmField PrimaryKey {
            get {
                return _PrimaryKey;
            }
            set {
                _PrimaryKey = value;
            }
        }
        List<SmField> _Fileds = null;

        public List<SmField> Fileds {
            get {
                return _Fileds;
            }
            set {
                _Fileds = value;
            }
        }
    }
}
