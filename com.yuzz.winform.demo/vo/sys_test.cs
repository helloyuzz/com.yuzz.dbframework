using System;
using System.Collections.Generic;
using System.Data;
using com.yuzz.dbframework;
using MySql.Data.MySqlClient;
[Serializable]
public class aaaaaaaaaaaaaaaa {
    public static Type Type {
        get {
            return typeof(aaaaaaaaaaaaaaaa);
        }
    }
    private List<SQLField> _Fields = null;
    public List<SQLField> Fields {
        get {
            if(_Fields == null) {
                _Fields = new List<SQLField>();
                _Fields.Add(new SQLField("a1_id",MySqlDbType.Int32,true,""));
                _Fields.Add(new SQLField("a1_name",MySqlDbType.VarChar,false,""));
                _Fields.Add(new SQLField("a1_sex",MySqlDbType.VarChar,false,""));
                _Fields.Add(new SQLField("a1_fk_deptid",MySqlDbType.Int32,false,""));
                _Fields.Add(new SQLField("a1_address",MySqlDbType.VarChar,false,""));
                _Fields.Add(new SQLField("a1_girlfriend",MySqlDbType.VarChar,false,""));
            }
            return _Fields;
        }
    }
    public virtual int a1_id { get; set; }
    public virtual string a1_name { get; set; }
    public virtual string a1_sex { get; set; }
    public virtual int a1_fk_deptid { get; set; }
    public virtual string a1_address { get; set; }
    public virtual string a1_girlfriend { get; set; }
    public virtual string SQLString {
        get {
            return @"SELECT 
	a1.id as `a1_id`
	,a1.name as `a1_name`
	,a1.sex as `a1_sex`
	,a1.fk_deptid as `a1_fk_deptid`
	,a1.address as `a1_address`
	,a1.girlfriend as `a1_girlfriend`
 FROM 
	
 WHERE 
 ORDER BY ";

        }

    }
}