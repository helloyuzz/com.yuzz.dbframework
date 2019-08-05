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

namespace com.yuzz.dbframework
{
    public static class SmartDB
    {
        static InitType _DbType
        {
            get; set;
        }
        static string _DbIP
        {
            get; set;
        }
        static string _DbSchema
        {
            get; set;
        }
        static object _DbAccount
        {
            get; set;
        }
        static object _DbPwd
        {
            get; set;
        }
        static string dbPrefix_Left
        {
            get
            {
                return _DbType == InitType.Mssql ? "[" : "`";
            }
        }
        static string dbPrefix_Right
        {
            get
            {
                return _DbType == InitType.Mssql ? "]" : "`";
            }
        }

        public static string _SmartDbConnectionString
        {
            get
            {
                if (_DbType == InitType.Mssql)
                {
                    return String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", _DbIP, _DbSchema, _DbAccount, _DbPwd);
                }
                else
                {
                    return string.Format("Server={0};User Id={1};Password={2};Persist Security Info=True;Database={3};charset=utf8;Allow User Variables=True;default command timeout=120;Connection Timeout=120;", _DbIP, _DbAccount, _DbPwd, _DbSchema);
                }
            }
        }

        public static void Init(InitType dbType, string dbip, string dbschema, string dbaccount, string dbpwd)
        {
            _DbType = dbType;
            _DbIP = dbip;
            _DbSchema = dbschema;
            _DbAccount = dbaccount;
            _DbPwd = dbpwd;
        }
        /// <summary>
        /// 保存数据库
        /// </summary>
        /// <param name="valueObject"></param>
        /// <returns></returns>
        public static SaveResult Save(object valueObject)
        {
            return Save(valueObject, SaveAction.Auto);
        }
        /// <summary>
        /// 保存数据库对象，系统会自动判断是添加或修改操作
        /// </summary>
        /// <param name="valueObject">也就是VO，注意是有值的VO</param>
        /// <param name="dbConn">SqlConnection</param>
        /// <returns></returns>
        public static SaveResult Save(object valueObject, SaveAction saveAction)
        {
            SaveResult saveResult = new SaveResult();

            object pk_Value = 0;
            bool isIntPk = false;
            bool pkIsNull = false;
            string sechma_Name = string.Empty;
            List<SQLField> sqlFields = null;

            Type getType = valueObject.GetType();

            List<MethodInfo> ary_Methods = SmartHtml.ParseTypeMethods(valueObject.GetType());

            MethodInfo mdh_GetPkFiledName = ary_Methods.Find(t => t.Name.Equals("get_pkfieldname", StringComparison.CurrentCultureIgnoreCase));
            string pk_FieldName = (string)mdh_GetPkFiledName.Invoke(valueObject, null);

            // 查找最常用的UUID的get、set方法
            MethodInfo mdh_GetPkFieldValue = ary_Methods.Find(t => t.Name.Equals("get_" + pk_FieldName, StringComparison.CurrentCultureIgnoreCase));            // Get方法是为了获取修改时的UUID
            MethodInfo mdh_SetUUID = ary_Methods.Find(t => t.Name.Equals("set_uuid", StringComparison.CurrentCultureIgnoreCase));            // Set方法是为了在添加时设置UUID
            MethodInfo mdh_GetTableName = ary_Methods.Find(t => t.Name.Equals("get_tablename", StringComparison.CurrentCultureIgnoreCase));  // 获取表格名称的方法
            MethodInfo mdh_GetFields = ary_Methods.Find(t => t.Name.Equals("get_fields", StringComparison.CurrentCultureIgnoreCase));        // 获取表格所有字段的方法

            // 取得表名
            if (mdh_GetTableName != null)
            {
                sechma_Name = (string)mdh_GetTableName.Invoke(valueObject, null);
            }
            // 取得字段列表
            if (mdh_GetFields != null)
            {
                sqlFields = (List<SQLField>)mdh_GetFields.Invoke(valueObject, null);
            }

            // 是否为int型主键
            isIntPk = mdh_GetPkFieldValue.ReturnType.Equals(typeof(int)) ? true : false;

            // 取得pkValue            
            if (isIntPk == true)
            {
                pk_Value = (int)mdh_GetPkFieldValue.Invoke(valueObject, null);
                pkIsNull = (int)pk_Value <= 0 ? true : false;
            }
            else
            {
                pk_Value = (string)mdh_GetPkFieldValue.Invoke(valueObject, null);
                pkIsNull = string.IsNullOrEmpty(SmartUtil.IngoreNull(pk_Value));
            }

            string execSQLString = string.Empty;

            saveResult.SchemaName = sechma_Name;
            try
            {
                int index = 0;
                if (_DbType == InitType.Mssql)
                {
                    using (SqlConnection dbConn = new SqlConnection(_SmartDbConnectionString))
                    {
                        dbConn.Open();
                        SqlCommand mssqlCmd = new SqlCommand();
                        mssqlCmd.Connection = dbConn;
                        mssqlCmd.CommandText = ParseSaveSQLString(sechma_Name, pk_FieldName, sqlFields, ary_Methods, valueObject, pkIsNull, saveAction);
                        SmartDB.CommandText = mssqlCmd.CommandText;

                        // 构造实际的参数
                        mssqlCmd.Parameters.Clear();
                        index = 0;
                        foreach (SQLField sqlField in sqlFields)
                        {
                            if (sqlField.Identity == true)
                            { // 主键
                                continue;
                            }
                            string getMethodName = "get_" + sqlField.Name;
                            MethodInfo sqlMethod = ary_Methods.Find(t => t.Name.Equals(getMethodName, StringComparison.CurrentCultureIgnoreCase));
                            object getValue = sqlMethod.Invoke(valueObject, null);

                            mssqlCmd.Parameters.Add("@Arg" + index, sqlField.MsDbType).Value = ParseSQLFiledValues(sqlField, getValue);
                            index++;
                        }
                        if (pkIsNull == false)
                        {
                            if (isIntPk == true)
                            {
                                mssqlCmd.Parameters.Add("@Arg" + index, SqlDbType.Int).Value = pk_Value;
                            }
                            else
                            {
                                mssqlCmd.Parameters.Add("@Arg" + index, SqlDbType.VarChar).Value = pk_Value;
                            }
                        }

                        if (mssqlCmd.ExecuteNonQuery() > 0)
                        {
                            if (isIntPk == true)
                            {
                                if (pkIsNull == false)
                                {   // 修改
                                    saveResult.Pk_Int = (int)pk_Value;
                                }
                                else
                                {
                                    mssqlCmd.CommandText = "select max(" + pk_FieldName + ") from " + sechma_Name;
                                    saveResult.Pk_Int = SmartUtil.ParseInt(mssqlCmd.ExecuteScalar());
                                }
                            }
                            else
                            {
                                saveResult.Pk_UUID = pk_Value.ToString();
                            }
                        }
                        dbConn.Close();
                        mssqlCmd = null;
                    }
                }
                else
                {
                    using (MySqlConnection dbConn = new MySqlConnection(_SmartDbConnectionString))
                    {
                        dbConn.Open();
                        MySqlCommand mysqlCmd = new MySqlCommand();
                        mysqlCmd.Connection = dbConn;
                        mysqlCmd.CommandText = ParseSaveSQLString(sechma_Name, pk_FieldName, sqlFields, ary_Methods, valueObject, pkIsNull, saveAction);
                        SmartDB.CommandText = mysqlCmd.CommandText;

                        // 构造实际的参数
                        mysqlCmd.Parameters.Clear();
                        index = 0;
                        foreach (SQLField sqlField in sqlFields)
                        {
                            /* 在非强制更新主键时，忽略对主键的处理，譬如：
                             * insert主键自动增长
                             * update xxx={xxx} where pk={pk}
                            */
                            if (sqlField.Identity == true && saveAction != SaveAction.Insert)
                            { // 主键，非强制更新
                                continue;
                            }
                            string getMethodName = "get_" + sqlField.Name;
                            MethodInfo sqlMethod = ary_Methods.Find(t => t.Name.Equals(getMethodName, StringComparison.CurrentCultureIgnoreCase));
                            object getValue = sqlMethod.Invoke(valueObject, null);

                            mysqlCmd.Parameters.Add("@Arg" + index, sqlField.MyDbType).Value = ParseSQLFiledValues(sqlField, getValue);
                            index++;
                        }
                        /*
                         * 自动：
                         *      无PK-》新增
                         *              ingore
                         *      有PK-》修改
                         *              set
                         * 新增：
                         *      带PK-》强制新增
                         *              set
                         *      不带PK-》默认新增
                         *              ingore
                         * 修改：
                         *      带PK-》修改
                         *              set
                         */

                        if (saveAction == SaveAction.Update)
                        {
                            if (isIntPk == true)
                            {
                                mysqlCmd.Parameters.Add("@Arg" + index, MySqlDbType.Int32).Value = pk_Value;
                            }
                            else
                            {
                                mysqlCmd.Parameters.Add("@Arg" + index, MySqlDbType.VarChar).Value = pk_Value;
                            }
                        }

                        if (mysqlCmd.ExecuteNonQuery() > 0)
                        {                        // 执行sql
                            if (isIntPk == true)
                            {                                   // int主键
                                if (pkIsNull == false)
                                {                             // 主键不为空，修改操作
                                    saveResult.Pk_Int = (int)pk_Value;              // 返回最新的主键值
                                }
                                else
                                {                                            // 主键为空，一般为新增操作，返回max(int)主键
                                    mysqlCmd.CommandText = "select max(" + pk_FieldName + ") from " + sechma_Name;
                                    saveResult.Pk_Int = SmartUtil.ParseInt(mysqlCmd.ExecuteScalar());
                                }
                            }
                            else
                            {                    // varchar类型主键
                                if (pkIsNull == true)
                                {  // 主键为空，一般为新增操作

                                }
                                else
                                {                // 主键不为空，一般为修改操作
                                    saveResult.Pk_UUID = pk_Value.ToString();
                                }
                            }
                        }
                        mysqlCmd = null;
                    }
                }
            }
            catch (Exception exc)
            {
                SmartDB.LastError = exc;
                saveResult.Pk_Int = -1;
                saveResult.Msg = exc.Message;
            }
            finally
            {
            }

            return saveResult;
        }

        private static string ParseSaveSQLString(string sechma_Name, string pk_FieldName, List<SQLField> sqlFields, List<MethodInfo> ary_Methods, object valueObject, bool pkIsNull, SaveAction saveAction)
        {
            string execSQLString = "";
            string getCondFields = string.Empty;
            string getCondValues = string.Empty;
            switch (saveAction)
            {
                case SaveAction.Insert:
                    pkIsNull = true;
                    break;
                case SaveAction.Update:
                    pkIsNull = false;
                    break;
            }
            // 构造Fields
            int index = 0;
            if (pkIsNull == true)
            {
                foreach (SQLField sqlField in sqlFields)
                {
                    if (sqlField.Identity == true && saveAction != SaveAction.Insert)
                    { // 主键
                        continue;
                    }
                    if (string.IsNullOrEmpty(getCondFields))
                    {
                        getCondFields = dbPrefix_Left + sqlField.Name + dbPrefix_Right;
                        getCondValues = "@Arg" + index;
                    }
                    else
                    {
                        getCondFields += "," + dbPrefix_Left + sqlField.Name + dbPrefix_Right;
                        getCondValues += ",@Arg" + index;
                    }
                    index++;
                }

                // 构造SQL代码，格式为：insert into [DBName](Fields) values(@ArgList,@ArgList,@ArgList);
                execSQLString = "insert into " + dbPrefix_Left + sechma_Name + dbPrefix_Right + "(" + getCondFields + ") values(" + getCondValues + ")";

            }
            else
            {
                List<SQLField> checkRepeat = new List<SQLField>();  // 过滤重复
                // 构造Update代码
                foreach (SQLField sqlField in sqlFields)
                {
                    // 不更新主键
                    if (sqlField.Identity == true)
                    {
                        continue;
                    }

                    // 过滤重复
                    if (checkRepeat.Find(t => t.Name.Equals(sqlField.Name)) != null)
                    {
                        continue;
                    }
                    else
                    {
                        checkRepeat.Add(sqlField);
                    }

                    // 组装Update SQL String
                    if (string.IsNullOrEmpty(execSQLString))
                    {
                        execSQLString = dbPrefix_Left + sqlField.Name + dbPrefix_Right + "=@Arg" + index;
                    }
                    else
                    {
                        execSQLString += "," + dbPrefix_Left + sqlField.Name + dbPrefix_Right + "=@Arg" + index;
                    }

                    index++;
                }

                execSQLString = "update " + dbPrefix_Left + sechma_Name + dbPrefix_Right + " set " + execSQLString + " where " + pk_FieldName + " = @Arg" + index;
            }
            return execSQLString;
        }

        /// <summary>
        /// 获取dbCmd.Parameters.Add(...) = 的值
        /// </summary>
        /// <param name="sqlField"></param>
        /// <param name="getValue"></param>
        /// <returns></returns>
        private static object ParseSQLFiledValues(SQLField sqlField, object getValue)
        {
            object tmp = "";

            if (_DbType == InitType.Mssql)
            {
                switch (sqlField.MsDbType)
                {
                    case SqlDbType.Text:
                    case SqlDbType.NText:
                    case SqlDbType.NVarChar:
                        tmp = SmartUtil.IngoreNull(getValue);
                        break;
                    case SqlDbType.DateTime:
                        if (sqlField.Name.Equals("ModifyTime", StringComparison.CurrentCultureIgnoreCase))
                        {
                            tmp = DateTime.Now;
                        }
                        else
                        {
                            DateTime tmpDateTime = SmartUtil.ParseDateTime(getValue);

                            if (tmpDateTime < DateTime.Parse("1989-12-31 23:59:59"))
                            {
                                tmp = DBNull.Value;//DateTime.Parse("1989-12-31 00:00:00");
                            }
                            else
                            {
                                tmp = tmpDateTime;
                            }
                        }
                        break;
                    case SqlDbType.Money:
                    case SqlDbType.Real:
                        tmp = SmartUtil.ParseFloat(getValue, 2);
                        break;
                    case SqlDbType.Int:
                        tmp = SmartUtil.ParseInt(getValue);
                        break;
                    case SqlDbType.Bit:
                        tmp = SmartUtil.ParseBool(getValue);
                        break;
                    case SqlDbType.Decimal:
                        tmp = SmartUtil.ParseDecimal(getValue);
                        break;
                    case SqlDbType.BigInt:
                        tmp = SmartUtil.ParseBigInt(getValue);
                        break;
                }
            }
            else
            {
                switch (sqlField.MyDbType)
                {
                    case MySqlDbType.Text:
                    case MySqlDbType.VarChar:
                        tmp = SmartUtil.IngoreNull(getValue);
                        break;
                    case MySqlDbType.DateTime:
                        if (sqlField.Name.Equals("ModifyTime", StringComparison.CurrentCultureIgnoreCase))
                        {
                            tmp = DateTime.Now;
                        }
                        else
                        {
                            DateTime tmpDateTime = SmartUtil.ParseDateTime(getValue);

                            if (tmpDateTime < DateTime.Parse("1989-12-31 23:59:59"))
                            {
                                tmp = DBNull.Value;//DateTime.Parse("1989-12-31 00:00:00");
                            }
                            else
                            {
                                tmp = tmpDateTime;
                            }
                        }
                        break;
                    case MySqlDbType.Float:
                    case MySqlDbType.Double:
                        tmp = SmartUtil.ParseFloat(getValue, 2);
                        break;
                    case MySqlDbType.Int32:
                        tmp = SmartUtil.ParseInt(getValue);
                        break;
                    case MySqlDbType.Bit:
                        tmp = SmartUtil.ParseBool(getValue);
                        break;
                    case MySqlDbType.Decimal:
                        tmp = SmartUtil.ParseDecimal(getValue);
                        break;
                    case MySqlDbType.Int64:
                        tmp = SmartUtil.ParseBigInt(getValue);
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
        private static DataTable ExecuteSP(SqlConnection dbConn, string spName, int shopid, string sqlCondition, int pageSize, int currentPage)
        {
            DataTable dt = new DataTable();
            SqlCommand dbCmd = new SqlCommand();
            try
            {
                dbCmd.Connection = dbConn;
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = spName;
                dbCmd.Parameters.Add("@shopid", SqlDbType.NVarChar);
                dbCmd.Parameters.Add("@sqlCondition", SqlDbType.NVarChar);
                dbCmd.Parameters.Add("@currentPage", SqlDbType.NVarChar);
                dbCmd.Parameters.Add("@pageSize", SqlDbType.NVarChar);
                dbCmd.Parameters.Add("@isCount", SqlDbType.NVarChar);

                dbCmd.Parameters["@shopid"].Value = shopid;
                dbCmd.Parameters["@sqlCondition"].Value = sqlCondition;
                dbCmd.Parameters["@currentPage"].Value = currentPage;
                dbCmd.Parameters["@pageSize"].Value = pageSize;
                dbCmd.Parameters["@isCount"].Value = 0;

                SqlDataAdapter dbAdapter = new SqlDataAdapter();
                dbAdapter.SelectCommand = dbCmd;

                dbAdapter.Fill(dt);
                dt.TableName = spName;
            }
            catch
            {
            }
            finally
            {
                dbCmd = null;
            }
            return dt;
        }

        /// <summary>
        /// 执行存储过程，返回执行结果
        /// </summary>
        /// <param name="dbConn"></param>
        /// <param name="spResult"></param>
        /// <param name="shopid"></param>
        /// <param name="sqlConditions"></param>
        /// <returns></returns>
        private static DataTable ExecuteSP(SqlConnection dbConn, string spName, int shopid, List<SpCondition> spConditions)
        {
            // DataTable dt = null;
            DataTable dt = new DataTable();
            SqlCommand dbCmd = new SqlCommand();
            try
            {
                dbCmd.Connection = dbConn;
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = spName;

                dbCmd.Parameters.Add("@shopid", SqlDbType.NVarChar);
                dbCmd.Parameters["@shopid"].Value = shopid;

                foreach (SpCondition spCondition in spConditions)
                {
                    dbCmd.Parameters.Add("@" + spCondition.Key, SqlDbType.NVarChar);
                    dbCmd.Parameters["@" + spCondition.Key].Value = spCondition.Value;
                }

                SqlDataAdapter dbAdapter = new SqlDataAdapter();
                dbAdapter.SelectCommand = dbCmd;

                dbAdapter.Fill(dt);
                dt.TableName = spName;
            }
            catch (Exception exc)
            {
                SmartDB.LastError = exc;
                dt = new DataTable();
            }
            finally
            {
                dbCmd = null;
            }
            return dt;
        }
        /// <summary>
        /// 执行存储过程，返回统计数量
        /// </summary>
        /// <param name="dbConn"></param>
        /// <param name="spName"></param>
        /// <param name="shopid">shopid</param>
        /// <param name="isCount"></param>
        /// <returns></returns>
        private static int ExecuteSP(SqlConnection dbConn, string spName, int shopid, int isCount)
        {
            int recordCount = 0;
            SqlCommand dbCmd = new SqlCommand();
            try
            {
                dbCmd.Connection = dbConn;
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = spName;
                dbCmd.Parameters.Add("@shopid", SqlDbType.NVarChar);
                dbCmd.Parameters.Add("@sqlCondition", SqlDbType.NVarChar);
                dbCmd.Parameters.Add("@currentPage", SqlDbType.NVarChar);
                dbCmd.Parameters.Add("@pageSize", SqlDbType.NVarChar);
                dbCmd.Parameters.Add("@isCount", SqlDbType.NVarChar);

                dbCmd.Parameters["@shopid"].Value = shopid;
                dbCmd.Parameters["@sqlCondition"].Value = "";
                dbCmd.Parameters["@currentPage"].Value = 1;
                dbCmd.Parameters["@pageSize"].Value = 1;
                dbCmd.Parameters["@isCount"].Value = 1; // 返回统计数量

                recordCount = SmartUtil.ParseInt(dbCmd.ExecuteScalar());
            }
            catch (Exception exc)
            {
                SmartDB.LastError = exc;
                recordCount = -1;
            }
            finally
            {
                dbCmd = null;
            }
            return recordCount;
        }

        public static T GetItem<T>(string sqlWhere) where T : new()
        {
            Console.WriteLine($"{nameof(GetItem)} {typeof(T).Name} by sql {sqlWhere}");
            List<T> getList = GetList<T>(sqlWhere, "");
            if (getList.Count > 0)
            {
                return getList[0];
            }
            else
            {
                T item = new T();
                return item;
            }
        }
        public static T GetItem<T>(int pkValue) where T : new()
        {
            T item = new T();
            string pkFieldName = InvokePkFieldName(item);
            return GetItem<T>(" where " + pkFieldName + "=" + pkValue);
        }

        public static List<T> GetList<T>(string sqlWhere, string sqlOrder) where T : new()
        {
            bool getVoContent = false;
            List<T> getList = new List<T>();
            T item = new T();
            Type voType = item.GetType();

            List<MethodInfo> execMethods = SmartHtml.ParseTypeMethods(voType);

            // MethodInfo mdh_UUID = execMethods.Find(t => t.Name.Equals("set_uuid",StringComparison.CurrentCultureIgnoreCase));
            MethodInfo mdh_GetFields = execMethods.Find(t => t.Name.Equals("get_fields", StringComparison.CurrentCultureIgnoreCase));
            MethodInfo mdh_GetTableName = execMethods.Find(t => t.Name.Equals("get_tablename", StringComparison.CurrentCultureIgnoreCase));

            //object tmpFieldsValue = voType.Assembly.CreateInstance(voType.FullName);
            List<SQLField> getSQLFields = (List<SQLField>)mdh_GetFields.Invoke(item, null);

            //string selectFields = string.Empty;
            StringBuilder selectFields = new StringBuilder();
            selectFields.Append("select ");
            string sechma_Name = (string)mdh_GetTableName.Invoke(item, null);

            int fieldCount = 1;
            foreach (SQLField sqlField in getSQLFields)
            {
                selectFields.Append(dbPrefix_Left).Append(sqlField.Name).Append(dbPrefix_Right);
                if (fieldCount < getSQLFields.Count)
                {
                    selectFields.Append(",");
                    fieldCount++;
                }
            }

            try
            {
                if (_DbType == InitType.Mssql)
                { // mssql
                    SqlCommand dbCmd = new SqlCommand();
                    SqlDataReader dbReader = null;
                    using (SqlConnection dbConn = new SqlConnection(_SmartDbConnectionString))
                    {
                        dbConn.Open();

                        dbCmd.Connection = dbConn;
                        selectFields.Append(" from ").Append(dbPrefix_Left).Append(sechma_Name).Append(dbPrefix_Right).Append(sqlWhere).Append(sqlOrder);
                        dbCmd.CommandText = selectFields.ToString();

                        SmartDB.CommandText = dbCmd.CommandText;
                        dbReader = dbCmd.ExecuteReader();
                        while (dbReader.Read())
                        {
                            T getValue = new T();

                            foreach (SQLField sqlField in getSQLFields)
                            {
                                if (getVoContent == false && sqlField.Name.Equals("VoContent"))
                                {
                                    continue;
                                }
                                object dbValue = dbReader[sqlField.Name];
                                MethodInfo setMethod = execMethods.Find(t => t.Name.Equals("set_" + sqlField.Name, StringComparison.CurrentCultureIgnoreCase));
                                if (dbValue == null || dbValue == DBNull.Value)
                                {
                                }
                                else
                                {
                                    setMethod.Invoke(getValue, new object[] { dbValue });
                                }
                            }

                            getList.Add(getValue);
                        }
                        dbReader.Close();
                        dbReader = null;

                        dbConn.Close();
                    }
                }
                else
                { // mysql
                    MySqlCommand dbCmd = new MySqlCommand();
                    MySqlDataReader dbReader = null;
                    using (MySqlConnection dbConn = new MySqlConnection(_SmartDbConnectionString))
                    {
                        dbConn.Open();

                        dbCmd.Connection = dbConn;
                        selectFields.Append(" from ").Append(dbPrefix_Left).Append(sechma_Name).Append(dbPrefix_Right).Append(sqlWhere).Append(sqlOrder);
                        dbCmd.CommandText = selectFields.ToString();

                        SmartDB.CommandText = dbCmd.CommandText;
                        dbReader = dbCmd.ExecuteReader();
                        while (dbReader.Read())
                        {
                            T getValue = new T();

                            foreach (SQLField sqlField in getSQLFields)
                            {
                                SmartDB.CurrentFiled = sqlField.Name;
                                object dbValue = dbReader[sqlField.Name];
                                MethodInfo setMethod = execMethods.Find(t => t.Name.Equals("set_" + sqlField.Name, StringComparison.CurrentCultureIgnoreCase));
                                if (dbValue == null || dbValue == DBNull.Value)
                                {
                                }
                                else
                                {
                                    setMethod.Invoke(getValue, new object[] { dbValue });
                                }
                            }

                            getList.Add(getValue);
                        }
                        dbReader.Close();
                        dbReader = null;

                        dbConn.Close();
                    }
                }
            }
            catch (Exception exc)
            {
                SmartDB.LastError = exc;
            }
            finally
            {
            }

            return getList;
        }

        public static List<T> GetListBySql<T>(string sql) where T : new()
        {
            List<T> result = new List<T>();
            List<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            switch (_DbType)
            {
                case InitType.Mssql:
                    break;
                case InitType.Mysql:
                    MySqlDataReader dbReader = null;
                    using (MySqlConnection dbConn = new MySqlConnection(_SmartDbConnectionString))
                    {
                        dbConn.Open();

                        MySqlCommand dbCmd = new MySqlCommand(sql, dbConn);
                        dbCmd.CommandText = sql;

                        SmartDB.CommandText = dbCmd.CommandText;
                        dbReader = dbCmd.ExecuteReader();
                        while (dbReader.Read())
                        {
                            T getValue = new T();

                            foreach (PropertyInfo i in properties)
                            {
                                try
                                {
                                    object dbValue = dbReader[i.Name];
                                    if (dbValue != null && dbValue != DBNull.Value)
                                    {
                                        i.SetValue(getValue, dbValue, null);
                                    }
                                }
                                catch(Exception ex) { UseException(ex); }
                            }
                            result.Add(getValue);
                        }
                        dbReader.Close();
                        dbReader = null;

                        dbConn.Close();
                    }

                    break;
                default:
                    break;
            }
            return result;
        }

        private static void UseException(Exception ex)
        {
        }

        /// <summary>
        /// 删除(int类型id)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete<T>(int id) where T : new()
        {
            bool delResult = false;
            T item = new T();
            string pkFieldName = InvokePkFieldName(item);

            delResult = Delete<T>(" where " + pkFieldName + "=" + id);
            return delResult;
        }
        /// <summary>
        /// 删除(string类型id，需要加where关键字)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlWhere"></param>
        /// <returns></returns>
        public static bool Delete<T>(string sqlWhere) where T : new()
        {
            bool delResult = false;
            //hanjq update
            int queryInt = 0;
            T item = new T();
            string dbname = InvokeDbName(item);

            switch (_DbType)
            {
                case InitType.Mssql:
                    SqlCommand mscmd = new SqlCommand();
                    try
                    {
                        using (SqlConnection msConn = new SqlConnection(_SmartDbConnectionString))
                        {
                            msConn.Open();
                            mscmd.Connection = msConn;
                            mscmd.CommandText = "delete from [" + dbname + "]" + sqlWhere;

                            queryInt = mscmd.ExecuteNonQuery();
                            if (queryInt != 0)
                            {
                                delResult = true;
                            }
                            delResult = true;
                            msConn.Close();
                        }
                    }
                    catch (Exception exc)
                    {
                        delResult = false;
                        SmartDB.LastError = exc;
                    }
                    finally
                    {
                        mscmd = null;
                    }
                    break;
                case InitType.Mysql:
                    MySqlCommand mycmd = new MySqlCommand();
                    try
                    {
                        using (MySqlConnection myConn = new MySqlConnection(_SmartDbConnectionString))
                        {
                            myConn.Open();
                            mycmd.Connection = myConn;
                            mycmd.CommandText = "delete from `" + dbname + "`" + sqlWhere;

                            queryInt = mycmd.ExecuteNonQuery();
                            if (queryInt != 0)
                            {
                                delResult = true;
                            }
                            myConn.Close();
                        }
                    }
                    catch (Exception exc)
                    {
                        delResult = false;
                        SmartDB.LastError = exc;
                    }
                    finally
                    {
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
        public static int Update<T>(string setCondition, string whereCondition) where T : new()
        {
            int result = 0;

            T item = new T();
            string dbname = InvokeDbName(item);

            switch (_DbType)
            {
                case InitType.Mssql:
                    SqlCommand dbCmd = new SqlCommand();
                    try
                    {
                        using (SqlConnection dbConn = new SqlConnection(_SmartDbConnectionString))
                        {
                            dbConn.Open();
                            dbCmd.Connection = dbConn;
                            dbCmd.CommandText = "update " + dbname + setCondition + whereCondition;

                            result = dbCmd.ExecuteNonQuery();
                            dbConn.Close();
                        }
                    }
                    catch (Exception exc)
                    {
                        SmartDB.LastError = exc;
                    }
                    finally
                    {
                        dbCmd = null;
                    }
                    break;
                case InitType.Mysql:
                    MySqlCommand myCmd = new MySqlCommand();
                    try
                    {
                        using (MySqlConnection myConn = new MySqlConnection(_SmartDbConnectionString))
                        {
                            myConn.Open();
                            myCmd.Connection = myConn;
                            myCmd.CommandText = "update " + dbname + setCondition + whereCondition;

                            result = myCmd.ExecuteNonQuery();
                            myConn.Close();
                        }
                    }
                    catch (Exception exc)
                    {
                        SmartDB.LastError = exc;
                    }
                    finally
                    {
                        myCmd = null;
                    }
                    break;
            }

            return result;
        }
        /// <summary>
        /// SQLUpdate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setCondition"></param>
        /// <param name="whereCondition"></param>
        /// <returns></returns>
        public static int Update(string dbname, string setCondition, string whereCondition)
        {
            int result = 0;
            MySqlCommand myCmd = new MySqlCommand();
            try
            {
                using (MySqlConnection myConn = new MySqlConnection(_SmartDbConnectionString))
                {
                    myConn.Open();
                    myCmd.Connection = myConn;
                    myCmd.CommandText = "update " + dbname + setCondition + whereCondition;

                    result = myCmd.ExecuteNonQuery();
                    myConn.Close();
                }
            }
            catch (Exception exc)
            {
                SmartDB.LastError = exc;
            }
            finally
            {
                myCmd = null;
            }

            return result;
        }
        /// <summary>
        /// 解析object数据库表名
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private static string InvokeDbName(object item)
        {
            List<MethodInfo> execMethods = SmartHtml.ParseTypeMethods(item.GetType());
            MethodInfo mdh_GetTableName = execMethods.Find(t => t.Name.Equals("get_tablename", StringComparison.CurrentCultureIgnoreCase));
            string dbname = (string)mdh_GetTableName.Invoke(item, null);
            return dbname;
        }

        /// <summary>
        /// 解析object主键字段名称
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private static string InvokePkFieldName(object item)
        {
            List<MethodInfo> execMethods = SmartHtml.ParseTypeMethods(item.GetType());
            MethodInfo mdh_GetTableName = execMethods.Find(t => t.Name.Equals("get_PkFieldName", StringComparison.CurrentCultureIgnoreCase));
            string pkFieldName = (string)mdh_GetTableName.Invoke(item, null);
            return pkFieldName;
        }

        /// <summary>
        /// 解析object所有字段
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private static List<SQLField> InvokeFieldList(object item)
        {
            List<MethodInfo> execMethods = SmartHtml.ParseTypeMethods(item.GetType());
            MethodInfo mdh_GetFields = execMethods.Find(t => t.Name.Equals("get_fields", StringComparison.CurrentCultureIgnoreCase));
            List<SQLField> sqlFields = (List<SQLField>)mdh_GetFields.Invoke(item, null);
            return sqlFields;
        }
        /// <summary>
        /// 获取查询总数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int CountBySql(string sql)
        {
#if DEBUG
            Debug.Print("=====================CountBySql====================");
            Debug.Print(sql);
            Debug.Print("---------------------------------------------------");
#endif
            int recordCount = 0;
            switch (_DbType)
            {
                case InitType.Mssql:    // Mssql
                    break;
                case InitType.Mysql:
                    MySqlCommand myCmd = new MySqlCommand();
                    try
                    {
                        using (MySqlConnection myConn = new MySqlConnection(_SmartDbConnectionString))
                        {
                            myConn.Open();
                            myCmd.CommandTimeout = 60;
                            myCmd.Connection = myConn;
                            myCmd.CommandText = sql;
                            recordCount = SmartUtil.ParseInt(myCmd.ExecuteScalar());
                            myConn.Close();
                        }
                    }
                    catch (Exception exc)
                    {
                        recordCount = -1;
                        LastError = exc;
                    }
                    finally
                    {
                        myCmd = null;
                    }
                    break;
            }
            return recordCount;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbname">分库名，必须与主库登录用户密码相同</param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int CountBySql(string dbname, string sql)
        {
            int recordCount = 0;
            string connStr = "";
            string oldDbName = _DbSchema;
            _DbSchema = dbname;
            switch (_DbType)
            {
                case InitType.Mssql:    // Mssql
                    connStr = String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", _DbIP, _DbSchema, _DbAccount, _DbPwd);
                    _DbSchema = oldDbName;
                    break;
                case InitType.Mysql:
                    connStr = string.Format("Server={0};User Id={1};Password={2};Persist Security Info=True;Database={3};charset=utf8;Allow User Variables=True;", _DbIP, _DbAccount, _DbPwd, _DbSchema);
                    _DbSchema = oldDbName;
                    MySqlCommand myCmd = new MySqlCommand();
                    try
                    {
                        using (MySqlConnection myConn = new MySqlConnection(connStr))
                        {
                            myConn.Open();
                            myCmd.CommandTimeout = 60;
                            myCmd.Connection = myConn;
                            myCmd.CommandText = sql;
                            recordCount = SmartUtil.ParseInt(myCmd.ExecuteScalar());
                            myConn.Close();
                        }
                    }
                    catch (Exception exc)
                    {
                        recordCount = -1;
                        LastError = exc;
                    }
                    finally
                    {
                        myCmd = null;
                    }
                    break;
            }

            return recordCount;
        }
        /// <summary>
        /// 执行非查询SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExcuteSql(string sql)
        {
            int recordCount = 0;
            switch (_DbType)
            {
                case InitType.Mssql:    // Mssql
                    break;
                case InitType.Mysql:
                    MySqlCommand myCmd = new MySqlCommand();
                    try
                    {
                        using (MySqlConnection myConn = new MySqlConnection(_SmartDbConnectionString))
                        {
                            myConn.Open();
                            myCmd.CommandTimeout = 60;
                            myCmd.Connection = myConn;
                            myCmd.CommandText = sql;
                            recordCount = myCmd.ExecuteNonQuery();
                            myConn.Close();
                        }
                    }
                    catch (Exception exc)
                    {
                        recordCount = -1;
                        LastError = exc;
                    }
                    finally
                    {
                        myCmd = null;
                    }
                    break;
            }
            return recordCount;
        }
        public static DataTable GetDataTableBySql(string sql)
        {
#if DEBUG
            if (!sql.StartsWith("select username as 'UserAccount',name as 'CnName',role as 'RoleId',lockkey as 'LockKey',activate as 'Active'"))
            {
                Debug.Print("=================GetDataTableBySql=================");
                Debug.Print(sql);
                Debug.Print("---------------------------------------------------");
            }
#endif
            DataTable dt = new DataTable();
            switch (_DbType)
            {
                case InitType.Mssql:    // Mssql

                    break;
                case InitType.Mysql:    // Mysql                    
                    MySqlCommand myCmd = new MySqlCommand();
                    myCmd.CommandTimeout = 600;
                    try
                    {
                        LastError = null;
                        using (MySqlConnection myConn = new MySqlConnection(_SmartDbConnectionString))
                        {
                            myConn.Open();
                            myCmd.Connection = myConn;
                            myCmd.CommandText = sql;
                            myCmd.CommandType = CommandType.Text;

                            MySqlDataAdapter dbAdapter = new MySqlDataAdapter();
                            dbAdapter.SelectCommand = myCmd;
                            dbAdapter.Fill(dt);

                            dt.TableName = SmartUtil.CreateUUID();
                            myConn.Close();
                        }
                    }
                    catch (Exception exc)
                    {
                        LastError = exc;
                    }
                    finally
                    {
                        myCmd = null;
                    }
                    break;
            }
            return dt;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbname">分为名，分库与主库必须使用相同用户密码</param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetDataTableBySql(string dbname, string sql)
        {
            DataTable dt = new DataTable();
            string connStr = "";
            string oldDbName = _DbSchema;
            _DbSchema = dbname;
            switch (_DbType)
            {
                case InitType.Mssql:    // Mssql
                    connStr = String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", _DbIP, _DbSchema, _DbAccount, _DbPwd);
                    _DbSchema = oldDbName;
                    break;
                case InitType.Mysql:    // Mysql  
                    connStr = string.Format("Server={0};User Id={1};Password={2};Persist Security Info=True;Database={3};charset=utf8;Allow User Variables=True;", _DbIP, _DbAccount, _DbPwd, _DbSchema);
                    _DbSchema = oldDbName;
                    MySqlCommand myCmd = new MySqlCommand();
                    myCmd.CommandTimeout = 600;
                    try
                    {
                        using (MySqlConnection myConn = new MySqlConnection(connStr))
                        {
                            myConn.Open();
                            myCmd.Connection = myConn;
                            myCmd.CommandText = sql;
                            myCmd.CommandType = CommandType.Text;

                            MySqlDataAdapter dbAdapter = new MySqlDataAdapter();
                            dbAdapter.SelectCommand = myCmd;
                            dbAdapter.Fill(dt);

                            dt.TableName = SmartUtil.CreateUUID();
                            myConn.Close();
                        }
                    }
                    catch (Exception exc)
                    {
                        LastError = exc;
                    }
                    finally
                    {
                        myCmd = null;
                    }
                    break;
            }

            return dt;
        }
        /// <summary>
        /// GetDataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlWhere"></param>
        /// <param name="sqlOrder"></param>
        /// <returns></returns>
        public static DataTable GetDataTable<T>(string sqlWhere, string sqlOrder) where T : new()
        {
            return GetDataTable<T>(sqlWhere, sqlOrder, SqlAction.Default, "*");
        }

        public static DataTable GetDataTable<T>(string sqlWhere, string sqlOrder, SqlAction sqlAction, params string[] sqlFields) where T : new()
        {
            return GetDataTable<T>(sqlWhere, sqlOrder, sqlAction, -1, -1, sqlFields);
        }

        public static DataTable GetDataTable<T>(string sqlWhere, string sqlOrder, int pageNumber, int pageSize) where T : new()
        {
            return GetDataTable<T>(sqlWhere, sqlOrder, SqlAction.Default, pageNumber, pageSize, null);
        }

        public static DataTable GetDataTable<T>(string sqlWhere, string sqlOrder, int pageNumber, int pageSize, params string[] sqlFields) where T : new()
        {
            return GetDataTable<T>(sqlWhere, sqlOrder, SqlAction.Default, pageNumber, pageSize, sqlFields);
        }
        public static int GetCount<T>(string sqlWhere) where T : new()
        {
            int recordCount = -1;
            T item = new T();
            string dbname = InvokeDbName(item);
            switch (_DbType)
            {
                case InitType.Mssql:    // Mssql
                    SqlCommand msCmd = new SqlCommand();
                    try
                    {
                        LastError = null;
                        using (SqlConnection msConn = new SqlConnection(_SmartDbConnectionString))
                        {
                            msConn.Open();
                            msCmd.Connection = msConn;
                            msCmd.CommandText = "select count(*) from " + dbname + sqlWhere;
                            recordCount = SmartUtil.ParseInt(msCmd.ExecuteScalar());
                            msConn.Close();
                        }
                    }
                    catch (Exception exc)
                    {
                        recordCount = -1;
                        LastError = exc;
                    }
                    finally
                    {
                        msCmd = null;
                    }
                    break;
                case InitType.Mysql:
                    MySqlCommand myCmd = new MySqlCommand();
                    try
                    {
                        using (MySqlConnection myConn = new MySqlConnection(_SmartDbConnectionString))
                        {
                            myConn.Open();
                            myCmd.Connection = myConn;
                            myCmd.CommandText = "select count(*) from " + dbname + sqlWhere;
                            recordCount = SmartUtil.ParseInt(myCmd.ExecuteScalar());
                            myConn.Close();
                        }
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine(exc.ToString());
                        recordCount = -1;
                        LastError = exc;
                    }
                    finally
                    {
                        myCmd = null;
                    }
                    break;
            }
            return recordCount;
        }
        /// <summary>
        /// GetDataTable，支持分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereCondition"></param>
        /// <param name="orderCondition"></param>
        /// <param name="sqlAction"></param>
        /// <param name="pageSize">-1：表示查询所有</param>
        /// <param name="pageNumber">-1：表示查询所有</param>
        /// <param name="sqlFields"></param>
        /// <returns></returns>
        public static DataTable GetDataTable<T>(string whereCondition, string orderCondition, SqlAction sqlAction, int pageNumber, int pageSize, params string[] sqlFields) where T : new()
        {
            DataTable dt = new DataTable();
            T item = new T();
            string dbname = InvokeDbName(item);
            string selectSQLFields = "";
            if (sqlFields == null)
            {
                sqlFields = new string[] { };
            }
            switch (sqlAction)
            {
                case SqlAction.Default: // 包括字段
                    foreach (string field in sqlFields)
                    {
                        if (string.IsNullOrEmpty(selectSQLFields) == false)
                        {
                            selectSQLFields += ",";
                        }
                        selectSQLFields += field;
                    }
                    break;
                case SqlAction.NotInclude:  // 不包括字段
                    List<SQLField> invokeFields = InvokeFieldList(item);
                    foreach (SQLField invokeField in invokeFields)
                    {
                        bool exist = false; // 是否是不包括的字段
                        foreach (string pField in sqlFields)
                        {
                            if (invokeField.Name.Equals(pField))
                            {
                                exist = true;
                                break;
                            }
                        }
                        if (exist == true)
                        { // 忽略
                            continue;
                        }
                        if (string.IsNullOrEmpty(selectSQLFields) == false)
                        {
                            selectSQLFields += ",";
                        }
                        selectSQLFields += invokeField.Name;
                    }
                    break;
            }


            if (string.IsNullOrEmpty(selectSQLFields))
            {
                selectSQLFields = "*";
            }
            string sqlCommandText = "";

            switch (_DbType)
            {
                case InitType.Mssql:    // Mssql
                    SqlCommand msCmd = new SqlCommand();
                    try
                    {
                        using (SqlConnection msConn = new SqlConnection(_SmartDbConnectionString))
                        {
                            msConn.Open();
                            msCmd.Connection = msConn;
                            msCmd.CommandText = "select " + selectSQLFields + " from " + dbname + whereCondition + orderCondition;
                            Debug.Print(msCmd.CommandText);
                            SqlDataAdapter msAdapter = new SqlDataAdapter();
                            msAdapter.SelectCommand = msCmd;
                            msAdapter.Fill(dt);

                            dt.TableName = dbname;
                            msConn.Close();
                        }
                    }
                    catch (Exception exc)
                    {
                        LastError = exc;
                    }
                    finally
                    {
                        msCmd = null;
                    }
                    break;
                case InitType.Mysql:    // Mysql                    
                    sqlCommandText = "select " + selectSQLFields + " from " + dbname + whereCondition + orderCondition;
                    if (pageSize > 0 && pageNumber > 0)
                    {    // 分页
                        if (string.IsNullOrEmpty(orderCondition))
                        {
                            LastError = new Exception("警告：排序条件=null");
                        }
                        int startRow = (pageNumber - 1) * pageSize;
                        sqlCommandText += " limit " + startRow + "," + pageSize;
                    }

                    MySqlCommand myCmd = new MySqlCommand();
                    try
                    {
                        using (MySqlConnection myConn = new MySqlConnection(_SmartDbConnectionString))
                        {
                            myConn.Open();
                            myCmd.Connection = myConn;
                            myCmd.CommandText = sqlCommandText;
                            Debug.Print(myCmd.CommandText);

                            MySqlDataAdapter dbAdapter = new MySqlDataAdapter();
                            dbAdapter.SelectCommand = myCmd;
                            dbAdapter.Fill(dt);

                            dt.TableName = dbname;
                            myConn.Close();
                        }
                    }
                    catch (Exception exc)
                    {
                        LastError = exc;
                    }
                    finally
                    {
                        myCmd = null;
                    }
                    break;
            }

            return dt;
        }
        public static DataTable AddColumn(DataTable dt, params ColumnTypes[] columnList)
        {
            return AddColumn(dt, false, columnList);
        }
        public static DataTable InsertNullRow(DataTable dt, string valueField, string textField)
        {
            DataRow row = dt.NewRow();

            dt.Rows.InsertAt(row, 0);
            foreach (DataColumn col in dt.Columns)
            {
                if (col.ColumnName.Equals(valueField))
                {
                    row[col.ColumnName] = -1;
                }
                else if (col.ColumnName.Equals(textField))
                {
                    row[col.ColumnName] = "请选择";
                }
            }
            return dt;
        }
        /// <summary>
        /// 添加LinkColumn
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="includeEditColumn">是否包括编辑、删除列</param>
        /// <param name="columnList"></param>
        /// <returns></returns>
        public static DataTable AddColumn(DataTable dt, bool includeEditColumn, params ColumnTypes[] columnList)
        {
            List<KeyValuePair<string, string>> columns = new List<KeyValuePair<string, string>>();
            foreach (ColumnTypes colType in columnList)
            {
                switch (colType)
                {
                    case ColumnTypes.Edit_Column:
                        columns.Add(new KeyValuePair<string, string>("edit_column", "编辑"));
                        break;
                    case ColumnTypes.Del_Column:
                        columns.Add(new KeyValuePair<string, string>("del_column", "删除"));
                        break;
                    case ColumnTypes.Publish_column:
                        columns.Add(new KeyValuePair<string, string>("publish_column", "同步商城"));
                        break;
                    case ColumnTypes.ViewDetail_Column:
                        columns.Add(new KeyValuePair<string, string>("viewDetail", "详情"));
                        break;
                    case ColumnTypes.ResetPassword_Column:
                        columns.Add(new KeyValuePair<string, string>("resetPassword_Column", "重置密码"));
                        break;
                    case ColumnTypes.Disable_Column:
                        columns.Add(new KeyValuePair<string, string>("disable_Column", "禁用"));
                        break;
                    case ColumnTypes.Select_Column:
                        columns.Add(new KeyValuePair<string, string>("select_Column", "选择"));
                        break;
                }
            }

            if (includeEditColumn == true)
            {
                dt = AddEditColumn(dt);
            }
            foreach (KeyValuePair<string, string> key in columns)
            {   // 添加列标题
                dt.Columns.Add(key.Key);
            }

            foreach (DataRow row in dt.Rows)
            {   // 添加列数据
                foreach (KeyValuePair<string, string> key in columns)
                {
                    row[key.Key] = key.Value;
                }

            }
            return dt;
        }

        public static DataTable AddEditColumn(DataTable dt)
        {
            dt.Columns.Add("edit_column");
            dt.Columns.Add("del_column");

            foreach (DataRow row in dt.Rows)
            {
                row["edit_column"] = "修改";
                row["del_column"] = "删除";
            }

            return dt;
        }

        public static Exception LastError
        {
            get;
            set;
        }

        public static string CommandText
        {
            get;
            set;
        }
        public static string AjaxDataTable()
        {
            return "";
        }
        /// <summary>
        /// 多表联合查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static DataTable MultiQuery(MultiQuery query)
        {
            return MultiQuery(query, -1, -1);
        }
        /// <summary>
        /// 多表联合查询
        /// </summary>
        /// <param name="query">MultiQuery</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        public static DataTable MultiQuery(MultiQuery query, int pageNumber, int pageSize)
        {
            if (query.JoinList.Count <= 0)
            {
                throw new Exception("查询表不能为空");
            }
            else
            {
                foreach (MultiJoin join in query.JoinList)
                {
                    if (join.On == null)
                    {
                        throw new Exception("联合查询on不能为空");
                    }
                }
            }
            if (query.SelectFields.Count <= 0)
            {
                throw new Exception("选择字段不能为空。注意：选择字段为手动指定，禁止使用“select *”的查询");
            }

            DataTable dt = new DataTable();
            string selectSql = "";
            string fromSql = "";
            string onSql = "";
            string dtName = "";

            //List<SQLField> sqlFields1 = null;
            //List<SQLField> sqlFields2 = null;
            foreach (MultiJoin join in query.JoinList)
            {
                List<MethodInfo> ary_Methods1 = SmartHtml.ParseTypeMethods(join.tb1);
                List<MethodInfo> ary_Methods2 = SmartHtml.ParseTypeMethods(join.tb2);

                object obj1 = System.Activator.CreateInstance(join.tb1);
                object obj2 = System.Activator.CreateInstance(join.tb2);

                MethodInfo mdh_GetTableName1 = ary_Methods1.Find(t => t.Name.Equals("get_tablename", StringComparison.CurrentCultureIgnoreCase));
                MethodInfo mdh_GetTableName2 = ary_Methods2.Find(t => t.Name.Equals("get_tablename", StringComparison.CurrentCultureIgnoreCase));

                string sechma_Name1 = "";
                string sechma_Name2 = "";

                if (mdh_GetTableName1 != null)
                {
                    sechma_Name1 = (string)mdh_GetTableName1.Invoke(obj1, null);
                }
                if (mdh_GetTableName2 != null)
                {
                    sechma_Name2 = (string)mdh_GetTableName2.Invoke(obj2, null);
                }
                dtName = sechma_Name1 + "_" + sechma_Name2;
                // fromSql
                if (string.IsNullOrEmpty(fromSql) == false)
                {
                    fromSql += ",";
                }
                fromSql += sechma_Name1 + " as " + join.nick1;
                switch (join.joinMethod)
                {
                    case JoinMethod.Left:
                        fromSql += " Left Join ";
                        break;
                    case JoinMethod.Inner:
                        fromSql += " Inner Join ";
                        break;
                    case JoinMethod.Right:
                        fromSql += " Right Join ";
                        break;
                }
                fromSql += sechma_Name2 + " as " + join.nick2;

                // onSql 
                if (string.IsNullOrEmpty(onSql) == false)
                {
                    onSql += ",";
                }
                foreach (MultiOn subOn in join.On)
                {
                    onSql += subOn.t1_field + "=" + subOn.t2_field;
                }

                foreach (MultiField selectField in query.SelectFields)
                {
                    foreach (string fieldName in selectField.Fields)
                    {
                        if (string.IsNullOrEmpty(selectSql) == false)
                        {
                            selectSql += ",";
                        }
                        selectSql += selectField.nickname + ".`" + fieldName + "`";
                    }
                }
            }

            selectSql = "select " + selectSql + " from " + fromSql + " on " + onSql;

            if (string.IsNullOrEmpty(query.sqlWhere) == false)
            {
                selectSql += " " + query.sqlWhere;
            }
            if (string.IsNullOrEmpty(query.sqlOrder) == false)
            {
                selectSql += " " + query.sqlOrder;
            }
            switch (_DbType)
            {
                case InitType.Mssql:    // Mssql

                    break;
                case InitType.Mysql:    // Mysql                                        
                    if (pageSize > 0 && pageNumber > 0)
                    {    // 分页
                        if (string.IsNullOrEmpty(query.sqlOrder))
                        {
                            LastError = new Exception("警告：排序条件=null");
                        }
                        int startRow = (pageNumber - 1) * pageSize;
                        selectSql += " limit " + startRow + "," + pageSize;
                    }

                    MySqlCommand myCmd = new MySqlCommand();
                    try
                    {
                        using (MySqlConnection myConn = new MySqlConnection(_SmartDbConnectionString))
                        {
                            myConn.Open();
                            myCmd.Connection = myConn;
                            myCmd.CommandText = selectSql;
                            SmartDB.CommandText = myCmd.CommandText;

                            MySqlDataAdapter dbAdapter = new MySqlDataAdapter();
                            dbAdapter.SelectCommand = myCmd;
                            dbAdapter.Fill(dt);

                            dt.TableName = dtName;
                            myConn.Close();
                        }
                    }
                    catch (Exception exc)
                    {
                        LastError = exc;
                    }
                    finally
                    {
                        myCmd = null;
                    }
                    break;
            }

            return dt;
        }

        public static string CurrentFiled
        {
            get;
            set;
        }
    }
}