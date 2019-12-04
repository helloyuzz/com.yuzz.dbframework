using System;
using System.Data.OleDb;
using System.Data;
namespace com.yuzz.dblibrary
{
    [Serializable]
    public class SmField
    {
        public virtual string Name {
            get;
            set;
        }
        public virtual SqlDbType DbType {
            get;
            set;
        }
        public virtual bool PrimaryKey {
            get;
            set;
        }
        public string Remarks {
            get;
            set;
        }
        public bool AllowDBNull {
            get;
            set;
        }
        public int MaxLength {
            get;
            set;
        }
        public bool ActiveUsing { get; set; }
        public SelectFunction Func { get; set; }
        public string FieldAs { get; set; }
    }
}