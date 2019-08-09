using System;
using System.Collections.Generic;
using System.Data;
using com.yuzz.dbframework;
using MySql.Data.MySqlClient;
[Serializable]
public class SysDept {
    public List<string> UpdateFields = new List<string>();

    /// <summary>
    /// 默认构造函数
    /// </summary>
    public SysDept() {
    }

    public static Type Type {
        get {
            return typeof(SysDept);
        }
    }
    public virtual string TableName {
        get {
            return "sysdept";
        }
    }
    public virtual string PkFieldName {
        get {
            return "id";
        }
    }
    private List<SQLField> _Fields = null;
    public List<SQLField> Fields {
        get {
            if(_Fields == null) {
                _Fields = new List<SQLField>();
                _Fields.Add(new SQLField("id",MySqlDbType.Int32,true,""));
                _Fields.Add(new SQLField("Name",MySqlDbType.VarChar,false,""));
                _Fields.Add(new SQLField("Manager",MySqlDbType.VarChar,false,""));
                _Fields.Add(new SQLField("EmpNumber",MySqlDbType.Int32,false,""));
                _Fields.Add(new SQLField("Money",MySqlDbType.Float,false,""));
                _Fields.Add(new SQLField("Comment",MySqlDbType.VarChar,false,""));
            }
            return _Fields;
        }
    }
    int _id;
    public virtual int id {
        get {
            return _id;
        }
        set {
            _id = value;
        }
    }
    string _Name;
    public virtual string Name {
        get {
            return _Name;
        }
        set {
            if(value != this._Name) {
                UpdateFields.Add("Name");
            }
            _Name = value;
        }
    }
    string _Manager;
    public virtual string Manager {
        get {
            return _Manager;
        }
        set {
            if(value != this._Manager) {
                UpdateFields.Add("Manager");
            }
            _Manager = value;
        }
    }
    int _EmpNumber;
    public virtual int EmpNumber {
        get {
            return _EmpNumber;
        }
        set {
            if(value != this._EmpNumber) {
                UpdateFields.Add("EmpNumber");
            }
            _EmpNumber = value;
        }
    }
    float _Money;
    public virtual float Money {
        get {
            return _Money;
        }
        set {
            if(value != this._Money) {
                UpdateFields.Add("Money");
            }
            _Money = value;
        }
    }
    string _Comment;

    public virtual string Comment {
        get {
            return _Comment;
        }
        set {
            if(value != this._Comment) {
                UpdateFields.Add("Comment");
            }
            _Comment = value;
        }
    }
}