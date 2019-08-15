using System;
using System.Collections.Generic;
using System.Data;
using com.yuzz.dbframework;
using MySql.Data.MySqlClient;
[Serializable]
public class sys_uuid {
    List<string> _UpdateFields = new List<string>();
    public virtual List<string> UpdateFields {
        get { return _UpdateFields; }
        set { _UpdateFields = value; }
    }
    public static Type Type {
        get {
            return typeof(sys_uuid);
        }
    }
    public virtual string TableName {
        get {
            return "sys_uuid";
        }
    }
    public virtual string PkFieldName {
        get {
            return "uuid";
        }
    }
    private List<SQLField> _Fields = null;
    public List<SQLField> Fields {
        get {
            if(_Fields == null) {
                _Fields = new List<SQLField>();
                _Fields.Add(new SQLField("uuid",MySqlDbType.VarChar,true,""));
                _Fields.Add(new SQLField("name",MySqlDbType.VarChar,false,""));
                _Fields.Add(new SQLField("count",MySqlDbType.Int32,false,""));
                _Fields.Add(new SQLField("money",MySqlDbType.Float,false,""));
                _Fields.Add(new SQLField("comment",MySqlDbType.Bit,false,""));
            }
            return _Fields;
        }
    }
    string _uuid;
    public virtual string uuid {
        get {
            return _uuid;
        }
        set {
            _uuid = value;
        }
    }
    string _name;
    public virtual string name {
        get {
            return _name;
        }
        set {
            if(value != this._name) {
                UpdateFields.Add("name");
            }
            _name = value;
        }
    }
    int _count;
    public virtual int count {
        get {
            return _count;
        }
        set {
            if(value != this._count) {
                UpdateFields.Add("count");
            }
            _count = value;
        }
    }
    float _money;
    public virtual float money {
        get {
            return _money;
        }
        set {
            if(value != this._money) {
                UpdateFields.Add("money");
            }
            _money = value;
        }
    }
    bool _comment;
    public virtual bool comment {
        get {
            return _comment;
        }
        set {
            if(value != this._comment) {
                UpdateFields.Add("comment");
            }
            _comment = value;
        }
    }
}