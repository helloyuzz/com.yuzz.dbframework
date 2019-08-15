/* SmartDB功能说明
 * 实现原理：
 *          数据库表  --> vo  --> dao.save()
 *          vo  <-- dao.get()   <-- 数据库表
 *          list<vo>    <-- dao.get()   <-- db
 *          
 * 使用方法很简单，只需通过dbframework工具将数据库表映射为对应的vo类即可，也即：db --> vo
 * 
 * SmartDB会自动解析生成的vo类，vo类中主要包括数据库表的相关描述信息，SmartDB负责完成相应的数据库操作，同时用户可指定查询的条件（sqlCondition）
 * 为了提高SmartDB在使用过程中的灵活性，对sqlCondition不作任何的限制，针对sqlCondition用户可自由随意的发挥
 * 例：
 *  
 *  Sm_Dept dept = SmartDB.Get<Sm_Dept>(id);
 *  
 *  DataTable dt = SmartDB.GetDataTable<Sm_Dept>(sqlCondition,sortCondition);
 *  foreach(DataRow row in dt.rows){
 *      ... ... ...
 *  }
 *  
 *  Sm_Dept newDept = new Sm_Dept();
 *  bool saveResult = SmartDB.Save(newDept);
 *  
 *  bool delResult = SmartDB.Delete<Sm_Dept>(id);
 */
using System;
using System.Data.SqlClient;
using System.Reflection;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Linq;
using DbType = com.yuzz.dbframework.DbType;
using com.yuzz.dbframework.util;
using com.yuzz.dbframework.vo;

namespace com.yuzz.dbframework {
    public static class Ajdb {
        static DbType _DbType {
            get; set;
        }
        static string _DbIP {
            get; set;
        }
        static string _DbSchema {
            get; set;
        }
        static string _DbAccount {
            get; set;
        }
        static string _DbPwd {
            get; set;
        }
        static int _Port { get; set; }
        static string dbPrefix {
            get {
                return _DbType == DbType.Mssql ? "[" : "`";
            }
        }
        static string dbSuffix {
            get {
                return _DbType == DbType.Mssql ? "]" : "`";
            }
        }

        public static string _DbConnectionString {
            get {
                if(_DbType == DbType.Mssql) {
                    return String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",_DbIP,_DbSchema,_DbAccount,_DbPwd);
                } else {
                    return string.Format("Server={0};User Id={1};Password={2};Persist Security Info=True;Database={3};Port={4};charset=utf8;Allow User Variables=True;default command timeout=120;Connection Timeout=120;",_DbIP,_DbAccount,_DbPwd,_DbSchema,_Port);
                }
            }
        }
        public static void Init(DbType dbType,string dbip,int port,string dbaccount,string dbpwd,string dbschema) {
            _DbType = dbType;
            _DbIP = dbip;
            _DbSchema = dbschema;
            _DbAccount = dbaccount;
            _DbPwd = dbpwd;
            _Port = port;
        }
        /// <summary>
        /// 保存数据库，默认为新增操作（Insert）
        /// </summary>
        /// <param name="valueObject"></param>
        /// <returns></returns>
        public static SaveResult Insert(object valueObject) {
            return Save(valueObject,SaveAction.Insert);
        }
        public static SaveResult Update(object obj) {
            return Save(obj,SaveAction.UpdateChangeField);
        }
        /// <summary>
        /// 保存数据库对象，系统会自动判断是添加或修改操作
        /// </summary>
        /// <param name="valueObject">也就是VO，注意是有值的VO</param>
        /// <param name="SaveAction">saveAction</param>
        /// <returns></returns>
        public static SaveResult Save(object valueObject,SaveAction saveAction) {
            SaveResult saveResult = new SaveResult();

            object getPKValue = 0;                  // 主键Primary Key实际的变量值
            string getPKFieldName = "";             // 主键Primary Key字段名称
            bool intTypePK = false;                 // 是否int整形Primary Key主键
            string getTableName = string.Empty;     // 表格的名称

            List<SQLField> getAllFields = null;     // 表格所有的字段 
            List<string> getUpdatedFields = null; // 仅仅对象值发生变化或更新的字段

            Type getType = valueObject.GetType();

            List<MethodInfo> methodList = Ajutil.GetMethodList(valueObject.GetType());

            MethodInfo mdh_GetPkFiledName = methodList.Find(t => t.Name.Equals("get_pkfieldname",StringComparison.CurrentCultureIgnoreCase));
            MethodInfo mdh_GetTableName = methodList.Find(t => t.Name.Equals("get_tablename",StringComparison.CurrentCultureIgnoreCase));               // 获取表格名称的方法
            MethodInfo mdh_GetAllFields = methodList.Find(t => t.Name.Equals("get_fields",StringComparison.CurrentCultureIgnoreCase));                  // 获取表格所有字段的方法
            MethodInfo mdh_GetUpdateFields = methodList.Find(t => t.Name.Equals("get_updatefields",StringComparison.CurrentCultureIgnoreCase));         // 获取UpdateFields
            MethodInfo mdh_SetUUID = methodList.Find(t => t.Name.Equals("set_uuid",StringComparison.CurrentCultureIgnoreCase));                         // Set方法是为了在添加时设置UUID

            getPKFieldName = (string)mdh_GetPkFiledName.Invoke(valueObject,null);               // 主键名称，不同表的主键名称不一定相同，但推荐设计表时主键统一设置为“id”
            MethodInfo mdh_GetPkFieldValue = methodList.Find(t => t.Name.Equals("get_" + getPKFieldName,StringComparison.CurrentCultureIgnoreCase)); // Get方法是为了获取修改时的UUID

            getTableName = (string)mdh_GetTableName.Invoke(valueObject,null);                   // 取得表名   
            getAllFields = (List<SQLField>)mdh_GetAllFields.Invoke(valueObject,null);           // 取得表格中所有的字段列表
            getUpdatedFields = (List<string>)mdh_GetUpdateFields.Invoke(valueObject,null);    // 取得仅仅对象值发生变化的字段列表，目的是构造update tb set xxx=xxx，时仅仅只更新值发生变化的字段，无需所有更新
            
            
            intTypePK = mdh_GetPkFieldValue.ReturnType.Equals(typeof(int)) ? true : false;      // 是否为int型主键
                 
            // 本框架仅支持int类型、varchar类型作为表格的主键，暂不支持其它数据类型作为表格的主键
            // table.pk(type=int,type=varchar)
            if(intTypePK == true) {                                                             // 取得int类型的pkValue
                getPKValue = (int)mdh_GetPkFieldValue.Invoke(valueObject,null);
            } else {                                                                            // 取得varchar类型的pkValue
                getPKValue = (string)mdh_GetPkFieldValue.Invoke(valueObject,null);
            }

            // ------------------------------------------------------------------------------------------------------------------------
            // 整套框架最为重要的代码，也就是根据不同的操作类型，构造真实的SQL代码
            // 会自适应操作类型
            // 返回结果：insert tb(filed1,field2,fieldxxx) values(@arg1,@arg2,@argxxx)
            // 或者：update tb set filed1=@arg1,field2=@arg2,fieldxxx=@argxxx where pk=@argid
            // ------------------------------------------------------------------------------------------------------------------------
            string execSQLString = BuildSQLCommandText(getTableName,getPKFieldName,getAllFields,getUpdatedFields,saveAction);
            Ajdb.CommandText = execSQLString;

            Console.WriteLine("\n\nSQL:\t" + execSQLString);
            saveResult.SchemaName = getTableName;
            try {
                int arguIndex = 0;
                if(_DbType == DbType.Mssql) {
                    using(SqlConnection dbConn = new SqlConnection(_DbConnectionString)) {
                        dbConn.Open();
                        SqlCommand mssqlCmd = new SqlCommand();
                        mssqlCmd.Connection = dbConn;
                        mssqlCmd.CommandText = execSQLString;

                        // 构造实际的参数
                        mssqlCmd.Parameters.Clear();
                        arguIndex = 0;
                        foreach(SQLField sqlField in getAllFields) {
                            if(sqlField.Identity == true) { // 主键
                                continue;
                            }
                            string getMethodName = "get_" + sqlField.Name;
                            MethodInfo sqlMethod = methodList.Find(t => t.Name.Equals(getMethodName,StringComparison.CurrentCultureIgnoreCase));
                            object getValue = sqlMethod.Invoke(valueObject,null);

                            mssqlCmd.Parameters.Add("@Arg" + arguIndex,sqlField.MsDbType).Value = ParseSQLFiledValues(sqlField,getValue);
                            arguIndex++;
                        }
                        //if(pkIsNull == false) {
                        //    if(isIntPK == true) {
                        //        mssqlCmd.Parameters.Add("@Arg" + index,SqlDbType.Int).Value = pk_Value;
                        //    } else {
                        //        mssqlCmd.Parameters.Add("@Arg" + index,SqlDbType.VarChar).Value = pk_Value;
                        //    }
                        //}

                        //if(mssqlCmd.ExecuteNonQuery() > 0) {
                        //    if(isIntPK == true) {
                        //        if(pkIsNull == false) {   // 修改
                        //            saveResult.Pk_Int = (int)pk_Value;
                        //        } else {
                        //            mssqlCmd.CommandText = "select max(" + pk_FieldName + ") from " + sechma_Name;
                        //            saveResult.Pk_Int = AdobeUtil.ParseInt(mssqlCmd.ExecuteScalar());
                        //        }
                        //    } else {
                        //        saveResult.Pk_UUID = pk_Value.ToString();
                        //    }
                        //}
                        dbConn.Close();
                        mssqlCmd = null;
                    }
                } else {
                    using(MySqlConnection dbConn = new MySqlConnection(_DbConnectionString)) {
                        dbConn.Open();
                        MySqlCommand mysqlCmd = new MySqlCommand();
                        mysqlCmd.Connection = dbConn;
                        mysqlCmd.CommandText = execSQLString;

                        // 构造实际的参数
                        mysqlCmd.Parameters.Clear();
                        arguIndex = 0;
                        foreach(SQLField sqlField in getAllFields) {
                            // 新增操作时，如果是int类型的主键（且为自增类型），泽忽略对主键的操作，也就是不插入主键的值（由数据库自动生成主键，Auto increasement）
                            if(sqlField.Identity == true && sqlField.MyDbType.Equals(MySqlDbType.Int32)) {
                                continue;
                            }

                            // 修改操作时，仅更新值发生变化的字段
                            if(saveAction == SaveAction.UpdateChangeField && getUpdatedFields.Contains(sqlField.Name)==false) {    
                                continue;
                            }

                            string getMethodName = "get_" + sqlField.Name;
                            MethodInfo sqlMethod = methodList.Find(t => t.Name.Equals(getMethodName,StringComparison.CurrentCultureIgnoreCase));
                            object getValue = sqlMethod.Invoke(valueObject,null);

                            mysqlCmd.Parameters.Add("@Arg" + arguIndex,sqlField.MyDbType).Value = ParseSQLFiledValues(sqlField,getValue);
                            arguIndex++;
                        }

                        // ------------------------------------------------------------------------------------
                        // 更新update操作，前面是设置参数值，也就是set xxx=xxx
                        // 需设置where id=xxx，也就是设置主键
                        // ------------------------------------------------------------------------------------
                        if(saveAction == SaveAction.UpdateChangeField) {
                            if(intTypePK == true) {
                                mysqlCmd.Parameters.Add("@Arg" + arguIndex,MySqlDbType.Int32).Value = getPKValue;
                            } else {
                                mysqlCmd.Parameters.Add("@Arg" + arguIndex,MySqlDbType.VarChar).Value = getPKValue;
                            }
                        }

                        // --------------------------------执行sql写入数据库中----------------------------------
                        if(mysqlCmd.ExecuteNonQuery() > 0) {
                            saveResult.OK = true;   // 操作成功

                            switch(saveAction) {
                                case SaveAction.Insert:
                                    if(intTypePK == true) { // 新增操作且为int主键（自增长类型），返回max(int)主键
                                        mysqlCmd.CommandText = "select max(" + getPKFieldName + ") from " + getTableName;
                                        saveResult.PK_Int = AdobeUtil.ParseInt(mysqlCmd.ExecuteScalar());
                                    } else {
                                        saveResult.PK_Varchar = getPKValue.ToString();
                                    }
                                    break;
                                case SaveAction.UpdateChangeField:
                                    if(intTypePK == true) {
                                        saveResult.PK_Int = AdobeUtil.ParseInt(getPKValue);
                                    } else {
                                        saveResult.PK_Varchar = getPKValue.ToString();
                                    }
                                    break;
                            }
                        }
                        mysqlCmd = null;
                    }
                }
            } catch(Exception exc) {
                Ajdb.ExcString = exc;
                saveResult.PK_Int = -1;
                saveResult.Msg = exc.Message;
            } finally {
            }

            return saveResult;
        }

        /// <summary>
        /// 构造SQL insert或则update字符串，也就是构造insert into xxx(field1,field2,filed...) values(value1,value2,value...)        /// 或者update xxx set field1=value1,field2=value2,... where id=xxx
        /// </summary>
        /// <param name="sechma_Name"></param>
        /// <param name="pk_FieldName"></param>
        /// <param name="allSQLFields"></param>
        /// <param name="saveAction"></param>
        /// <returns></returns>
        private static string BuildSQLCommandText(string sechma_Name,string pk_FieldName,List<SQLField> getAllFields,List<string> getUpdatedFields,SaveAction saveAction) {
            string execSQLString = "";
            string getCondFields = string.Empty;
            string getCondValues = string.Empty;

            // 构造Fields
            int arguIndex = 0;  // 参数索引
            switch(saveAction) {
                case SaveAction.Insert:
                    foreach(SQLField sqlField in getAllFields) {
                        // 新增操作时，如果是int类型的主键（且为自增类型），泽忽略对主键的操作，也就是不插入主键的值（由数据库自动生成主键，Auto increasement）
                        if(sqlField.Identity == true && sqlField.MyDbType.Equals(MySqlDbType.Int32)) { // 主键
                            continue;
                        }
                        if(string.IsNullOrEmpty(getCondFields)) {
                            getCondFields = dbPrefix + sqlField.Name + dbSuffix;
                            getCondValues = "@Arg" + arguIndex;
                        } else {
                            getCondFields += "," + dbPrefix + sqlField.Name + dbSuffix;
                            getCondValues += ",@Arg" + arguIndex;
                        }
                        arguIndex++;
                    }

                    // 构造SQL代码，格式为：insert into [DBName](Fields) values(@ArgList,@ArgList,@ArgList);
                    execSQLString = "insert into " + dbPrefix + sechma_Name + dbSuffix + "(" + getCondFields + ") values(" + getCondValues + ")";
                    break;
                case SaveAction.UpdateChangeField:
                    List<SQLField> checkRepeat = new List<SQLField>();  // 过滤重复

                    foreach(SQLField sqlField in getAllFields) {   // 构造Update代码
                        // 不更新主键
                        if(sqlField.Identity == true) {
                            continue;
                        }

                        // 过滤重复
                        if(checkRepeat.Find(t => t.Name.Equals(sqlField.Name)) != null) {
                            continue;
                        } else {
                            checkRepeat.Add(sqlField);
                        }

                        // 组装Update SQL String
                        if(string.IsNullOrEmpty(execSQLString)) {
                            execSQLString = dbPrefix + sqlField.Name + dbSuffix + "=@Arg" + arguIndex++;
                        } else if(getUpdatedFields.Contains(sqlField.Name)) {   // 仅仅更新字段值发生变化的字段
                            execSQLString += "," + dbPrefix + sqlField.Name + dbSuffix + "=@Arg" + arguIndex++;
                        }
                    }

                    execSQLString = "update " + dbPrefix + sechma_Name + dbSuffix + " set " + execSQLString + " where " + pk_FieldName + " = @Arg" + arguIndex;
                    break;
            }
            return execSQLString;
        }

        /// <summary>
        /// 获取dbCmd.Parameters.Add(...) = 的值
        /// </summary>
        /// <param name="sqlField"></param>
        /// <param name="getValue"></param>
        /// <returns></returns>
        private static object ParseSQLFiledValues(SQLField sqlField,object getValue) {
            object tmp = "";

            if(_DbType == DbType.Mssql) {
                switch(sqlField.MsDbType) {
                    case SqlDbType.Text:
                    case SqlDbType.NText:
                    case SqlDbType.NVarChar:
                        tmp = AdobeUtil.IngoreNull(getValue);
                        break;
                    case SqlDbType.DateTime:
                        if(sqlField.Name.Equals("ModifyTime",StringComparison.CurrentCultureIgnoreCase)) {
                            tmp = DateTime.Now;
                        } else {
                            DateTime tmpDateTime = AdobeUtil.ParseDateTime(getValue);

                            if(tmpDateTime < DateTime.Parse("1989-12-31 23:59:59")) {
                                tmp = DBNull.Value;//DateTime.Parse("1989-12-31 00:00:00");
                            } else {
                                tmp = tmpDateTime;
                            }
                        }
                        break;
                    case SqlDbType.Money:
                    case SqlDbType.Real:
                        tmp = AdobeUtil.ParseFloat(getValue,2);
                        break;
                    case SqlDbType.Int:
                        tmp = AdobeUtil.ParseInt(getValue);
                        break;
                    case SqlDbType.Bit:
                        tmp = AdobeUtil.ParseBool(getValue);
                        break;
                    case SqlDbType.Decimal:
                        tmp = AdobeUtil.ParseDecimal(getValue);
                        break;
                    case SqlDbType.BigInt:
                        tmp = AdobeUtil.ParseBigInt(getValue);
                        break;
                }
            } else {
                switch(sqlField.MyDbType) {
                    case MySqlDbType.Text:
                    case MySqlDbType.VarChar:
                        tmp = AdobeUtil.IngoreNull(getValue);
                        break;
                    case MySqlDbType.DateTime:
                        if(sqlField.Name.Equals("ModifyTime",StringComparison.CurrentCultureIgnoreCase)) {
                            tmp = DateTime.Now;
                        } else {
                            DateTime tmpDateTime = AdobeUtil.ParseDateTime(getValue);

                            if(tmpDateTime < DateTime.Parse("1989-12-31 23:59:59")) {
                                tmp = DBNull.Value;//DateTime.Parse("1989-12-31 00:00:00");
                            } else {
                                tmp = tmpDateTime;
                            }
                        }
                        break;
                    case MySqlDbType.Float:
                    case MySqlDbType.Double:
                        tmp = AdobeUtil.ParseFloat(getValue,2);
                        break;
                    case MySqlDbType.Int32:
                        tmp = AdobeUtil.ParseInt(getValue);
                        break;
                    case MySqlDbType.Bit:
                        tmp = AdobeUtil.ParseBool(getValue);
                        break;
                    case MySqlDbType.Decimal:
                        tmp = AdobeUtil.ParseDecimal(getValue);
                        break;
                    case MySqlDbType.Int64:
                        tmp = AdobeUtil.ParseBigInt(getValue);
                        break;
                }
            }

            return tmp;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="dbConn">数据库连接</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="shopid">shopid</param>
        /// <param name="sqlCondition">sql查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="currentPage">当前页码</param>
        /// <returns></returns>
        //private static DataTable ExecuteSP(SqlConnection dbConn,string spName,int shopid,string sqlCondition,int pageSize,int currentPage) {
        //    DataTable dt = new DataTable();
        //    SqlCommand dbCmd = new SqlCommand();
        //    try {
        //        dbCmd.Connection = dbConn;
        //        dbCmd.CommandType = CommandType.StoredProcedure;
        //        dbCmd.CommandText = spName;
        //        dbCmd.Parameters.Add("@shopid",SqlDbType.NVarChar);
        //        dbCmd.Parameters.Add("@sqlCondition",SqlDbType.NVarChar);
        //        dbCmd.Parameters.Add("@currentPage",SqlDbType.NVarChar);
        //        dbCmd.Parameters.Add("@pageSize",SqlDbType.NVarChar);
        //        dbCmd.Parameters.Add("@isCount",SqlDbType.NVarChar);

        //        dbCmd.Parameters["@shopid"].Value = shopid;
        //        dbCmd.Parameters["@sqlCondition"].Value = sqlCondition;
        //        dbCmd.Parameters["@currentPage"].Value = currentPage;
        //        dbCmd.Parameters["@pageSize"].Value = pageSize;
        //        dbCmd.Parameters["@isCount"].Value = 0;

        //        SqlDataAdapter dbAdapter = new SqlDataAdapter();
        //        dbAdapter.SelectCommand = dbCmd;

        //        dbAdapter.Fill(dt);
        //        dt.TableName = spName;
        //    } catch {
        //    } finally {
        //        dbCmd = null;
        //    }
        //    return dt;
        //}

        /// <summary>
        /// 执行存储过程，返回执行结果
        /// </summary>
        /// <param name="dbConn"></param>
        /// <param name="spResult"></param>
        /// <param name="shopid"></param>
        /// <param name="sqlConditions"></param>
        /// <returns></returns>
        //private static DataTable ExecuteSP(SqlConnection dbConn,string spName,int shopid,List<SpCondition> spConditions) {
        //    // DataTable dt = null;
        //    DataTable dt = new DataTable();
        //    SqlCommand dbCmd = new SqlCommand();
        //    try {
        //        dbCmd.Connection = dbConn;
        //        dbCmd.CommandType = CommandType.StoredProcedure;
        //        dbCmd.CommandText = spName;

        //        dbCmd.Parameters.Add("@shopid",SqlDbType.NVarChar);
        //        dbCmd.Parameters["@shopid"].Value = shopid;

        //        foreach(SpCondition spCondition in spConditions) {
        //            dbCmd.Parameters.Add("@" + spCondition.Key,SqlDbType.NVarChar);
        //            dbCmd.Parameters["@" + spCondition.Key].Value = spCondition.Value;
        //        }

        //        SqlDataAdapter dbAdapter = new SqlDataAdapter();
        //        dbAdapter.SelectCommand = dbCmd;

        //        dbAdapter.Fill(dt);
        //        dt.TableName = spName;
        //    } catch(Exception exc) {
        //        Ajdb.LastError = exc;
        //        dt = new DataTable();
        //    } finally {
        //        dbCmd = null;
        //    }
        //    return dt;
        //}
        /// <summary>
        /// 执行存储过程，返回统计数量
        /// </summary>
        /// <param name="dbConn"></param>
        /// <param name="spName"></param>
        /// <param name="shopid">shopid</param>
        /// <param name="isCount"></param>
        /// <returns></returns>
        //private static int ExecuteSP(SqlConnection dbConn,string spName,int shopid,int isCount) {
        //    int recordCount = 0;
        //    SqlCommand dbCmd = new SqlCommand();
        //    try {
        //        dbCmd.Connection = dbConn;
        //        dbCmd.CommandType = CommandType.StoredProcedure;
        //        dbCmd.CommandText = spName;
        //        dbCmd.Parameters.Add("@shopid",SqlDbType.NVarChar);
        //        dbCmd.Parameters.Add("@sqlCondition",SqlDbType.NVarChar);
        //        dbCmd.Parameters.Add("@currentPage",SqlDbType.NVarChar);
        //        dbCmd.Parameters.Add("@pageSize",SqlDbType.NVarChar);
        //        dbCmd.Parameters.Add("@isCount",SqlDbType.NVarChar);

        //        dbCmd.Parameters["@shopid"].Value = shopid;
        //        dbCmd.Parameters["@sqlCondition"].Value = "";
        //        dbCmd.Parameters["@currentPage"].Value = 1;
        //        dbCmd.Parameters["@pageSize"].Value = 1;
        //        dbCmd.Parameters["@isCount"].Value = 1; // 返回统计数量

        //        recordCount = AdobeUtil.ParseInt(dbCmd.ExecuteScalar());
        //    } catch(Exception exc) {
        //        Ajdb.LastError = exc;
        //        recordCount = -1;
        //    } finally {
        //        dbCmd = null;
        //    }
        //    return recordCount;
        //}

        public static T GetItem<T>(string sqlWhere) where T : new() {
            Console.WriteLine($"{nameof(GetItem)} {typeof(T).Name} by sql {sqlWhere}");
            List<T> getList = GetList<T>(sqlWhere,"");
            if(getList.Count > 0) {
                return getList[0];
            } else {
                T item = new T();
                return item;
            }
        }
        public static T GetItem<T>(int pkValue) where T : new() {
            T item = new T();
            string pkFieldName = Ajutil.GetPkFieldName(item);
            return GetItem<T>(" where " + pkFieldName + "=" + pkValue);
        }


        public static List<T> GetList<T>(string sqlWhere,string sqlOrder) where T : new() {
            return GetList<T>(sqlWhere,sqlOrder,1,1000);
        }

        public static List<T> GetList<T>(string sqlWhere,string sqlOrder,int pageNumber,int pageCount) where T : new() {
            bool getVoContent = false;
            List<T> getList = new List<T>();
            T item = new T();
            Type voType = item.GetType();
            
            List<MethodInfo> execMethods = Ajutil.GetMethodList(voType);// SmartHtml.ParseTypeMethods(voType);

            // MethodInfo mdh_UUID = execMethods.Find(t => t.Name.Equals("set_uuid",StringComparison.CurrentCultureIgnoreCase));
            MethodInfo mdh_GetFields = execMethods.Find(t => t.Name.Equals("get_fields",StringComparison.CurrentCultureIgnoreCase));
            MethodInfo mdh_GetTableName = execMethods.Find(t => t.Name.Equals("get_tablename",StringComparison.CurrentCultureIgnoreCase));

            //object tmpFieldsValue = voType.Assembly.CreateInstance(voType.FullName);
            List<SQLField> getSQLFields = (List<SQLField>)mdh_GetFields.Invoke(item,null);

            //string selectFields = string.Empty;
            StringBuilder selectFields = new StringBuilder();
            selectFields.Append("select ");
            string sechma_Name = (string)mdh_GetTableName.Invoke(item,null);

            int fieldCount = 1;
            foreach(SQLField sqlField in getSQLFields) {
                selectFields.Append(dbPrefix).Append(sqlField.Name).Append(dbSuffix);
                if(fieldCount < getSQLFields.Count) {
                    selectFields.Append(",");
                    fieldCount++;
                }
            }

            try {
                if(_DbType == DbType.Mssql) { // mssql
                    SqlCommand dbCmd = new SqlCommand();
                    SqlDataReader dbReader = null;
                    using(SqlConnection dbConn = new SqlConnection(_DbConnectionString)) {
                        dbConn.Open();

                        dbCmd.Connection = dbConn;
                        selectFields.Append(" from ").Append(dbPrefix).Append(sechma_Name).Append(dbSuffix).Append(sqlWhere).Append(sqlOrder);
                        dbCmd.CommandText = selectFields.ToString();

                        Ajdb.CommandText = dbCmd.CommandText;
                        dbReader = dbCmd.ExecuteReader();
                        while(dbReader.Read()) {
                            T getValue = new T();

                            foreach(SQLField sqlField in getSQLFields) {
                                if(getVoContent == false && sqlField.Name.Equals("VoContent")) {
                                    continue;
                                }
                                object dbValue = dbReader[sqlField.Name];
                                MethodInfo setMethod = execMethods.Find(t => t.Name.Equals("set_" + sqlField.Name,StringComparison.CurrentCultureIgnoreCase));
                                if(dbValue == null || dbValue == DBNull.Value) {
                                } else {
                                    setMethod.Invoke(getValue,new object[] { dbValue });
                                }
                            }

                            getList.Add(getValue);
                        }
                        dbReader.Close();
                        dbReader = null;

                        dbConn.Close();
                    }
                } else { // mysql
                    MySqlCommand dbCmd = new MySqlCommand();
                    MySqlDataReader dbReader = null;
                    using(MySqlConnection dbConn = new MySqlConnection(_DbConnectionString)) {
                        dbConn.Open();  // 打开数据库连接

                        dbCmd.Connection = dbConn;

                        // 构造select xxx from xxx where xxx order by xxx
                        // 暂时只支持以上格式的sql语句，不支持group by等高级查询关键字
                        selectFields.Append(" from ").Append(dbPrefix).Append(sechma_Name).Append(dbSuffix).Append(sqlWhere).Append(sqlOrder); 
                        dbCmd.CommandText = selectFields.ToString();
                        Ajdb.CommandText = dbCmd.CommandText;

                        // 执行sql查询
                        dbReader = dbCmd.ExecuteReader();
                        while(dbReader.Read()) {    // 遍历查询结果
                            T newDBItem = new T();

                            MethodInfo clearUpdateFields = execMethods.Find(t => t.Name.Equals("set_UpdateFields",StringComparison.CurrentCultureIgnoreCase));
                            foreach(SQLField sqlField in getSQLFields) {
                                Console.WriteLine($"GetList()-----------CurrentFiled={sqlField.Name}");
                                object dbValue = dbReader[sqlField.Name];   // 数据库值
                                MethodInfo setMethod = execMethods.Find(t => t.Name.Equals("set_" + sqlField.Name,StringComparison.CurrentCultureIgnoreCase));      // 对应的set方法
                                if(dbValue == null || dbValue == DBNull.Value) {    //  判断是否为空
                                } else {    // 不为空
                                    setMethod.Invoke(newDBItem,new object[] { dbValue });    // 执行set方法对对象的属性进行赋值
                                }
                            }
                            clearUpdateFields.Invoke(newDBItem,new object[] { new List<string>() });
                            getList.Add(newDBItem);  // 添加到返回值的List
                        }
                        dbReader.Close();
                        dbReader = null;

                        dbConn.Close();
                    }
                }
            } catch(Exception exc) {
                Ajdb.ExcString = exc;
            } finally {
            }

            return getList;
        }

        /// <summary>
        /// 删除(int类型id)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete<T>(int id) where T : new() {
            bool delResult = false;
            T item = new T();
            string pkFieldName = Ajutil.GetPkFieldName(item);

            delResult = Delete<T>(" where " + pkFieldName + "=" + id);
            return delResult;
        }
        /// <summary>
        /// 删除(string类型id，需要加where关键字)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlWhere"></param>
        /// <returns></returns>
        public static bool Delete<T>(string sqlWhere) where T : new() {
            bool delResult = false;
            //hanjq update
            int queryInt = 0;
            T item = new T();
            string dbname = Ajutil.GetSechemaName(item);

            switch(_DbType) {
                case DbType.Mssql:
                    SqlCommand mscmd = new SqlCommand();
                    try {
                        using(SqlConnection msConn = new SqlConnection(_DbConnectionString)) {
                            msConn.Open();
                            mscmd.Connection = msConn;
                            mscmd.CommandText = "delete from [" + dbname + "]" + sqlWhere;

                            queryInt = mscmd.ExecuteNonQuery();
                            if(queryInt != 0) {
                                delResult = true;
                            }
                            delResult = true;
                            msConn.Close();
                        }
                    } catch(Exception exc) {
                        delResult = false;
                        Ajdb.ExcString = exc;
                    } finally {
                        mscmd = null;
                    }
                    break;
                case DbType.Mysql:
                    MySqlCommand mycmd = new MySqlCommand();
                    try {
                        using(MySqlConnection myConn = new MySqlConnection(_DbConnectionString)) {
                            myConn.Open();
                            mycmd.Connection = myConn;
                            mycmd.CommandText = "delete from `" + dbname + "`" + sqlWhere;

                            queryInt = mycmd.ExecuteNonQuery();
                            if(queryInt != 0) {
                                delResult = true;
                            }
                            myConn.Close();
                        }
                    } catch(Exception exc) {
                        delResult = false;
                        Ajdb.ExcString = exc;
                    } finally {
                        mycmd = null;
                    }
                    break;
            }

            return delResult;
        }

        /// <summary>
        /// SQLUpdate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setCondition"></param>
        /// <param name="whereCondition"></param>
        /// <returns></returns>
        public static int Update<T>(string setCondition,string whereCondition) where T : new() {
            int result = 0;

            T dbclass = new T();
            string dbname = Ajutil.GetSechemaName(dbclass);

            switch(_DbType) {
                case DbType.Mssql:
                    SqlCommand dbCmd = new SqlCommand();
                    try {
                        using(SqlConnection dbConn = new SqlConnection(_DbConnectionString)) {
                            dbConn.Open();
                            dbCmd.Connection = dbConn;
                            dbCmd.CommandText = "update " + dbname + setCondition + whereCondition;

                            result = dbCmd.ExecuteNonQuery();
                            dbConn.Close();
                        }
                    } catch(Exception exc) {
                        Ajdb.ExcString = exc;
                    } finally {
                        dbCmd = null;
                    }
                    break;
                case DbType.Mysql:
                    MySqlCommand myCmd = new MySqlCommand();
                    try {
                        using(MySqlConnection myConn = new MySqlConnection(_DbConnectionString)) {
                            myConn.Open();
                            myCmd.Connection = myConn;
                            myCmd.CommandText = "update " + dbname + setCondition + whereCondition;

                            result = myCmd.ExecuteNonQuery();
                            myConn.Close();
                        }
                    } catch(Exception exc) {
                        Ajdb.ExcString = exc;
                    } finally {
                        myCmd = null;
                    }
                    break;
            }

            return result;
        }
        ///// <summary>
        ///// SQLUpdate
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="setCondition"></param>
        ///// <param name="whereCondition"></param>
        ///// <returns></returns>
        //public static int Update(string dbname,string setCondition,string whereCondition) {
        //    int result = 0;
        //    MySqlCommand myCmd = new MySqlCommand();
        //    try {
        //        using(MySqlConnection myConn = new MySqlConnection(_DbConnectionString)) {
        //            myConn.Open();
        //            myCmd.Connection = myConn;
        //            myCmd.CommandText = "update " + dbname + setCondition + whereCondition;

        //            result = myCmd.ExecuteNonQuery();
        //            myConn.Close();
        //        }
        //    } catch(Exception exc) {
        //        Ajdb.LastError = exc;
        //    } finally {
        //        myCmd = null;
        //    }

        //    return result;
        //}



     
        /// <summary>
        /// 执行非查询SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        //public static int ExcuteSql(string sql) {
        //    int recordCount = 0;
        //    switch(_DbType) {
        //        case DbType.Mssql:    // Mssql
        //            break;
        //        case DbType.Mysql:
        //            MySqlCommand myCmd = new MySqlCommand();
        //            try {
        //                using(MySqlConnection myConn = new MySqlConnection(_DbConnectionString)) {
        //                    myConn.Open();
        //                    myCmd.CommandTimeout = 60;
        //                    myCmd.Connection = myConn;
        //                    myCmd.CommandText = sql;
        //                    recordCount = myCmd.ExecuteNonQuery();
        //                    myConn.Close();
        //                }
        //            } catch(Exception exc) {
        //                recordCount = -1;
        //                LastError = exc;
        //            } finally {
        //                myCmd = null;
        //            }
        //            break;
        //    }
        //    return recordCount;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbname">分为名，分库与主库必须使用相同用户密码</param>
        /// <param name="sql"></param>
        /// <returns></returns>
        //public static DataTable GetDataTableBySql(string dbname,string sql) {
        //    DataTable dt = new DataTable();
        //    string connStr = "";
        //    string oldDbName = _DbSchema;
        //    _DbSchema = dbname;
        //    switch(_DbType) {
        //        case DbType.Mssql:    // Mssql
        //            connStr = String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",_DbIP,_DbSchema,_DbAccount,_DbPwd);
        //            _DbSchema = oldDbName;
        //            break;
        //        case DbType.Mysql:    // Mysql  
        //            connStr = string.Format("Server={0};User Id={1};Password={2};Persist Security Info=True;Database={3};charset=utf8;Allow User Variables=True;",_DbIP,_DbAccount,_DbPwd,_DbSchema);
        //            _DbSchema = oldDbName;
        //            MySqlCommand myCmd = new MySqlCommand();
        //            myCmd.CommandTimeout = 600;
        //            try {
        //                using(MySqlConnection myConn = new MySqlConnection(connStr)) {
        //                    myConn.Open();
        //                    myCmd.Connection = myConn;
        //                    myCmd.CommandText = sql;
        //                    myCmd.CommandType = CommandType.Text;

        //                    MySqlDataAdapter dbAdapter = new MySqlDataAdapter();
        //                    dbAdapter.SelectCommand = myCmd;
        //                    dbAdapter.Fill(dt);

        //                    dt.TableName = AdobeUtil.CreateUUID();
        //                    myConn.Close();
        //                }
        //            } catch(Exception exc) {
        //                LastError = exc;
        //            } finally {
        //                myCmd = null;
        //            }
        //            break;
        //    }

        //    return dt;
        //}
        /// <summary>
        /// GetDataTable，执行默认表格查询操作，默认返回所有字段，数量1000条以内的记录（不分页）
        /// </summary>
        /// <typeparam name="T">表格vo对象</typeparam>
        /// <param name="sqlWhere">where条件，格式：" where xxx=xxx"</param>
        /// <param name="sqlOrder">order by关键字，格式：" order by xxx asc/desc"</param>
        /// <returns></returns>
        public static AjQuery Query<T>(string sqlWhere,string sqlOrder) where T : new() {
            return Query<T>(sqlWhere,sqlOrder,1,1000,AjQueryType.Query_Include,null);
        }
        /// <summary>
        /// 不分页查询返回Datatable，仅仅查询指定的字段（不查询所有字段），通过AjQueryType+sqlFields参数确定查询哪些字段（部分）
        /// </summary>
        /// <typeparam name="T">表格vo对象</typeparam>
        /// <param name="sqlWhere">where条件，格式：" where xxx=xxx"</param>
        /// <param name="sqlOrder">order by关键字，格式：" order by xxx asc/desc"</param>
        /// <param name="sqlAction">查询类型，标识后续的sqlFields字段是查询（或者不查询）</param>
        /// <param name="sqlFields">指定的字段，其作用由AjQueryType决定，如果sqlFields==null，则表示查询所有字段</param>
        /// <returns></returns>
        public static AjQuery Query<T>(string sqlWhere,string sqlOrder,AjQueryType ajQueryType,params string[] sqlFields) where T : new() {
            return Query<T>(sqlWhere,sqlOrder,1,1000,ajQueryType,sqlFields);
        }

        /// <summary>
        /// 分页查询返回Datatable，仅仅查询指定的字段（不查询所有字段），通过AjQueryType+sqlFields参数确定查询哪些字段（部分）
        /// </summary>
        /// <typeparam name="T">表格vo对象</typeparam>
        /// <param name="sqlWhere">where条件，格式：" where xxx=xxx"</param>
        /// <param name="sqlOrder">order by关键字，格式：" order by xxx asc/desc"</param>
        /// <param name="pageNumber">当前页面，Int类型</param>
        /// <param name="pageSize">每页显示记录数，Int类型</param>
        /// <param name="ajQueryType">查询类型，标识后续的sqlFields字段是查询（或者不查询）</param>
        /// <param name="sqlFields">指定的字段，其作用由AjQueryType决定，如果sqlFields==null，则表示查询所有字段</param>
        /// <returns></returns>
        public static AjQuery Query<T>(string sqlWhere,string sqlOrder,int pageNumber,int pageSize,AjQueryType ajQueryType,params string[] sqlFields) where T : new() {
            AjQuery ajQuery = new AjQuery();
            ajQuery.DataTable = new DataTable();

            T item = new T();
            string dbname = Ajutil.GetSechemaName(item);
            string selectSQLFields = "";
            if(sqlFields == null) {
                sqlFields = new string[] { };
            }

            ajQuery.RecordCount = GetCount<T>(" where 1=1");
            ajQuery.PageIndex = pageNumber;
            ajQuery.PageSize = pageSize;
            ajQuery.PageCount = ajQuery.RecordCount / pageSize;
            if(ajQuery.RecordCount % pageSize > 0) {
                ajQuery.PageCount++;
            }
            switch(ajQueryType) {
                case AjQueryType.Query_Include: // 包括字段
                    foreach(string field in sqlFields) {
                        if(string.IsNullOrEmpty(selectSQLFields) == false) {
                            selectSQLFields += ",";
                        }
                        selectSQLFields += field;
                    }
                    break;
                case AjQueryType.Query_Exclude:  // 不包括字段
                    List<SQLField> invokeFields = Ajutil.GetAllFields(item);
                    foreach(SQLField invokeField in invokeFields) {
                        bool exist = false; // 是否是不包括的字段
                        foreach(string pField in sqlFields) {
                            if(invokeField.Name.Equals(pField)) {
                                exist = true;
                                break;
                            }
                        }
                        if(exist == true) { // 忽略
                            continue;
                        }
                        if(string.IsNullOrEmpty(selectSQLFields) == false) {
                            selectSQLFields += ",";
                        }
                        selectSQLFields += invokeField.Name;
                    }
                    break;
            }


            if(string.IsNullOrEmpty(selectSQLFields)) {
                selectSQLFields = "*";
            }
            string sqlCommandText = "";

            switch(_DbType) {
                case DbType.Mssql:    // Mssql
                    SqlCommand msCmd = new SqlCommand();
                    try {
                        using(SqlConnection msConn = new SqlConnection(_DbConnectionString)) {
                            msConn.Open();
                            msCmd.Connection = msConn;
                            msCmd.CommandText = "select " + selectSQLFields + " from " + dbname + sqlWhere + sqlOrder;
                            Debug.Print(msCmd.CommandText);
                            SqlDataAdapter msAdapter = new SqlDataAdapter();
                            msAdapter.SelectCommand = msCmd;
                            msAdapter.Fill(ajQuery.DataTable);

                            ajQuery.DataTable.TableName = dbname;
                            msConn.Close();
                        }
                    } catch(Exception exc) {
                        ExcString = exc;
                    } finally {
                        msCmd = null;
                    }
                    break;
                case DbType.Mysql:    // Mysql                    
                    sqlCommandText = "select " + selectSQLFields + " from " + dbname + sqlWhere + sqlOrder;
                    if(pageSize > 0 && pageNumber > 0) {    // 分页
                        if(string.IsNullOrEmpty(sqlOrder)) {
                            ExcString = new Exception("警告：排序条件=null");
                        }
                        int startRow = (pageNumber - 1) * pageSize;
                        sqlCommandText += " limit " + startRow + "," + pageSize;
                    }

                    MySqlCommand myCmd = new MySqlCommand();
                    try {
                        using(MySqlConnection myConn = new MySqlConnection(_DbConnectionString)) {
                            myConn.Open();
                            myCmd.Connection = myConn;
                            myCmd.CommandText = sqlCommandText;
                            Debug.Print(myCmd.CommandText);

                            MySqlDataAdapter dbAdapter = new MySqlDataAdapter();
                            dbAdapter.SelectCommand = myCmd;
                            dbAdapter.Fill(ajQuery.DataTable);

                            ajQuery.DataTable.TableName = dbname;
                            myConn.Close();
                        }
                    } catch(Exception exc) {
                        ExcString = exc;
                    } finally {
                        myCmd = null;
                    }
                    break;
            }

            return ajQuery;
        }
        public static int GetCount<T>(string sqlWhere) where T : new() {
            int recordCount = -1;
            T item = new T();
            string dbname = Ajutil.GetSechemaName(item);
            switch(_DbType) {
                case DbType.Mssql:    // Mssql
                    SqlCommand msCmd = new SqlCommand();
                    try {
                        ExcString = null;
                        using(SqlConnection msConn = new SqlConnection(_DbConnectionString)) {
                            msConn.Open();
                            msCmd.Connection = msConn;
                            msCmd.CommandText = "select count(*) from " + dbname + sqlWhere;
                            recordCount = AdobeUtil.ParseInt(msCmd.ExecuteScalar());
                            msConn.Close();
                        }
                    } catch(Exception exc) {
                        recordCount = -1;
                        ExcString = exc;
                    } finally {
                        msCmd = null;
                    }
                    break;
                case DbType.Mysql:
                    MySqlCommand myCmd = new MySqlCommand();
                    try {
                        using(MySqlConnection myConn = new MySqlConnection(_DbConnectionString)) {
                            myConn.Open();
                            myCmd.Connection = myConn;
                            myCmd.CommandText = "select count(*) from " + dbname + sqlWhere;
                            recordCount = AdobeUtil.ParseInt(myCmd.ExecuteScalar());
                            myConn.Close();
                        }
                    } catch(Exception exc) {
                        Console.WriteLine(exc.ToString());
                        recordCount = -1;
                        ExcString = exc;
                    } finally {
                        myCmd = null;
                    }
                    break;
            }
            return recordCount;
        }
        //public static DataTable AddColumn(DataTable dt,params DbCellTypes[] columnList) {
        //    return AddColumn(dt,false,columnList);
        //}
        //public static DataTable InsertNullRow(DataTable dt,string valueField,string textField) {
        //    DataRow row = dt.NewRow();

        //    dt.Rows.InsertAt(row,0);
        //    foreach(DataColumn col in dt.Columns) {
        //        if(col.ColumnName.Equals(valueField)) {
        //            row[col.ColumnName] = -1;
        //        } else if(col.ColumnName.Equals(textField)) {
        //            row[col.ColumnName] = "请选择";
        //        }
        //    }
        //    return dt;
        //}
        /// <summary>
        /// 添加LinkColumn
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="includeEditColumn">是否包括编辑、删除列</param>
        /// <param name="columnList"></param>
        /// <returns></returns>
        //public static DataTable AddColumn(DataTable dt,bool includeEditColumn,params DbCellTypes[] columnList) {
        //    List<KeyValuePair<string,string>> columns = new List<KeyValuePair<string,string>>();
        //    foreach(DbCellTypes colType in columnList) {
        //        switch(colType) {
        //            case DbCellTypes.Edit_Column:
        //                columns.Add(new KeyValuePair<string,string>("edit_column","编辑"));
        //                break;
        //            case DbCellTypes.Del_Column:
        //                columns.Add(new KeyValuePair<string,string>("del_column","删除"));
        //                break;
        //            case DbCellTypes.Publish_column:
        //                columns.Add(new KeyValuePair<string,string>("publish_column","同步商城"));
        //                break;
        //            case DbCellTypes.ViewDetail_Column:
        //                columns.Add(new KeyValuePair<string,string>("viewDetail","详情"));
        //                break;
        //            case DbCellTypes.ResetPassword_Column:
        //                columns.Add(new KeyValuePair<string,string>("resetPassword_Column","重置密码"));
        //                break;
        //            case DbCellTypes.Disable_Column:
        //                columns.Add(new KeyValuePair<string,string>("disable_Column","禁用"));
        //                break;
        //            case DbCellTypes.Select_Column:
        //                columns.Add(new KeyValuePair<string,string>("select_Column","选择"));
        //                break;
        //        }
        //    }

        //    if(includeEditColumn == true) {
        //        dt = AddEditColumn(dt);
        //    }
        //    foreach(KeyValuePair<string,string> key in columns) {   // 添加列标题
        //        dt.Columns.Add(key.Key);
        //    }

        //    foreach(DataRow row in dt.Rows) {   // 添加列数据
        //        foreach(KeyValuePair<string,string> key in columns) {
        //            row[key.Key] = key.Value;
        //        }

        //    }
        //    return dt;
        //}

        //public static DataTable AddEditColumn(DataTable dt) {
        //    dt.Columns.Add("edit_column");
        //    dt.Columns.Add("del_column");

        //    foreach(DataRow row in dt.Rows) {
        //        row["edit_column"] = "修改";
        //        row["del_column"] = "删除";
        //    }

        //    return dt;
        //}

        public static Exception ExcString {
            get;
            set;
        }

        public static string CommandText {
            get;
            set;
        }
    }
}