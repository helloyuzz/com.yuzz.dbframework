using System;
using System.Collections.Generic;
using System.Data;
using com.yuzz.dbframework;
using MySql.Data.MySqlClient;
[Serializable]
public class sysuser {
	List<string> _UpdateFields = new List<string>();
	public virtual List<string> UpdateFields {
		get { return _UpdateFields; }
		set { _UpdateFields = value; }
	}
	public static Type Type {
		get {
			return typeof(sysuser);
		}
	}
	public virtual string TableName {
		get {
			return "sysuser";
		}
	}
	public virtual string PkFieldName {
		get {
			return "id";
		}
	}
	private List<SQLField> _Fields = null;
	public List<SQLField> Fields{
		get{
			if(_Fields == null){
			_Fields = new List<SQLField>();
				_Fields.Add(new SQLField("id",MySqlDbType.Int32,true,""));
				_Fields.Add(new SQLField("name",MySqlDbType.VarChar,false,""));
				_Fields.Add(new SQLField("sex",MySqlDbType.VarChar,false,""));
				_Fields.Add(new SQLField("fk_deptid",MySqlDbType.Int32,false,""));
				_Fields.Add(new SQLField("address",MySqlDbType.VarChar,false,""));
				_Fields.Add(new SQLField("girlfriend",MySqlDbType.VarChar,false,""));
			}
			return _Fields;
		}
	}
	int _id;
	public virtual int id {
		get{
			return _id;
		}
		set{
			_id = value;
		}
	}
	string _name;
	public virtual string name {
		get{
			return _name;
		}
		set{
			if(value != this._name) {
			    UpdateFields.Add("name");
			}
			_name = value;
		}
	}
	string _sex;
	public virtual string sex {
		get{
			return _sex;
		}
		set{
			if(value != this._sex) {
			    UpdateFields.Add("sex");
			}
			_sex = value;
		}
	}
	int _fk_deptid;
	public virtual int fk_deptid {
		get{
			return _fk_deptid;
		}
		set{
			if(value != this._fk_deptid) {
			    UpdateFields.Add("fk_deptid");
			}
			_fk_deptid = value;
		}
	}
	string _address;
	public virtual string address {
		get{
			return _address;
		}
		set{
			if(value != this._address) {
			    UpdateFields.Add("address");
			}
			_address = value;
		}
	}
	string _girlfriend;
	public virtual string girlfriend {
		get{
			return _girlfriend;
		}
		set{
			if(value != this._girlfriend) {
			    UpdateFields.Add("girlfriend");
			}
			_girlfriend = value;
		}
	}
}