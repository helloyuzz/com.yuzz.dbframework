using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Globalization;
using System.Data;
using System.Reflection;
using System.Collections;
using System.Threading;
using com.yuzz.dbframework.util;

namespace com.yuzz.dbframework {
    static public class AdobeUtil {
        /// <summary>
        /// 处理null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string IngoreNull(object value) {
            if(value == null || value == DBNull.Value) {
                return "";
            }
            return value.ToString();
        }
        /// <summary>
        /// 将对象序列化为XML字符串
        /// </summary>
        /// <param name="dbItem"></param>
        /// <returns></returns>
        public static string SerializeObject(object value) {
            string getXMLString = string.Empty;
            try {
                XmlSerializer xmls = new XmlSerializer(value.GetType());
                StringWriter sw = new StringWriter();
                xmls.Serialize(sw,value);
                getXMLString = sw.ToString();
                sw.Close();
                sw = null;

                xmls = null;
            } catch {
                getXMLString = "";
            }
            return getXMLString;
        }
        /// <summary>
        /// 将XML字符串解析为对象
        /// </summary>
        /// <param name="xmlString"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object DeserializeObject(string xmlString,Type type) {
            object obj = null;
            try {
                XmlSerializer xml = new XmlSerializer(type);
                XmlReader getXMLString = XmlReader.Create(new StringReader(xmlString));
                obj = xml.Deserialize(getXMLString);

                getXMLString.Close();
                getXMLString = null;
                xml = null;
            } catch {
                obj = null;
            }
            return obj;
        }
        public static bool SaveFile(string filePath,string xmlString) {
            bool result = false;

            try {
                StreamWriter txt = new StreamWriter(filePath);
                txt.Write(xmlString);
                txt.Flush();
                txt.Close();
            } catch {
                result = false;
            }

            return result;
        }
        public static string LoadFile(string filePath) {
            string xmlString = "";

            if(File.Exists(filePath) == true) {
                StreamReader txt = new StreamReader(filePath);
                xmlString = txt.ReadToEnd();
                txt.Close();
            }

            return xmlString;
        }
        /// <summary>
        /// 判断对象是否为空
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(object obj) {
            bool result = false;
            if(obj == null || obj == DBNull.Value || string.IsNullOrEmpty(obj.ToString()) || "NULL".Equals(obj.ToString())) {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// 判断对象是否不为空
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty(object obj) {
            return !IsNullOrEmpty(obj);
        }
        /// <summary>
        /// 转换Int类型
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int ParseInt(object p) {
            int intValue = 0;

            if(IsNotNullOrEmpty(p)) {
                int.TryParse(p.ToString(),out intValue);
            }
            return intValue;
        }

        public static long ParseBigInt(object getValue) {
            long value = 0;
            if(getValue != null) {
                long.TryParse(getValue.ToString(),out value);
            }
            return value;
        }
        /// <summary>
        /// 解析日期对象
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static DateTime ParseDateTime(object p) {
            DateTime dt = DateTime.Now;
            if(IsNotNullOrEmpty(p)) {
                DateTime.TryParse(p.ToString(),out dt);
            }
            return dt;
        }
        /// <summary>
        /// 解析日期对象，如果解析失败，则返回默认的defaultValue
        /// </summary>
        /// <param name="get出生日期"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime ParseDateTime(string getValue,DateTime defaultValue) {
            DateTime dt = DateTime.Now;

            bool tryResult = DateTime.TryParse(getValue,out dt);
            if(tryResult == false) {
                dt = defaultValue;
            }

            return dt;
        }
        /// <summary>
        /// 获取当前日期是第几周
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        //public static int GetWeekOfYear(DateTime dt) {
        //    int weeknum = 0;
        //    DateTime tmpdate = DateTime.Parse(dt.Year.ToString() + "-1" + "-1");
        //    DayOfWeek firstweek = tmpdate.DayOfWeek;
        //    //if(firstweek) 
        //    for(int i = (int)firstweek + 1;i <= dt.DayOfYear;i = i + 7) {
        //        weeknum = weeknum + 1;
        //    }
        //    return weeknum;
        //}
        /// <summary>
        /// 1月1日是该年第一周的开始
        /// </summary>
        public static int GetWeekOfYear(this DateTime dt) {
            return new GregorianCalendar().GetWeekOfYear(dt,CalendarWeekRule.FirstDay,DayOfWeek.Monday);
        }
        /// <summary>
        /// 获取当前第几季度
        /// </summary>
        public static int GetJiDuOfYear(this DateTime dt) {
            return (int)Math.Ceiling((double)dt.Month / 3);
        }
        /// <summary>
        /// 获取当前日期所在周的第一天（一般为周一），1月1号默认为该年第一周的第一天
        /// </summary>
        public static DateTime GetFirstDayOfWeek(this DateTime dt) {
            while(dt.DayOfWeek != DayOfWeek.Monday) {
                if(dt.Month == 1 && dt.Day == 1) {//1月1号默认为该年第一周的开始,如：2012年1月1日为周日，那2012年第一周就一天
                    break;
                }
                dt = dt.AddDays(-1);
            }
            return dt;
        }
        /// <summary>
        /// 获取当前日期所在周的最后一天（一般为周日）,12月31号默认为该年最后一周的最后一天
        /// </summary>
        public static DateTime GetLastDayOfWeek(this DateTime dt) {
            while(dt.DayOfWeek != DayOfWeek.Sunday) {
                if(dt.Month == 12 && dt.Day == 31) {
                    break;
                }
                dt = dt.AddDays(1);
            }
            return dt;
        }
        /// <summary>
        /// 获取时间所在月的最后一天
        /// </summary>
        public static DateTime GetLastDayOfMonth(this DateTime dt) {
            DateTime dateTime = new DateTime(dt.Year,dt.AddMonths(1).Month,1);
            return dateTime.AddDays(-1);
        }
        /// <summary>
        /// 获取时间所在月的第一天
        /// </summary>
        public static DateTime GetFirstDayOfMonth(this DateTime dt) {
            DateTime dateTime = new DateTime(dt.Year,dt.Month,1);
            return dateTime;
        }
        /// <summary>
        /// 获取时间所在季度的最后一天
        /// </summary>
        public static DateTime GetLastDayOfJidu(this DateTime dt) {
            DateTime dateTime = new DateTime(dt.Year,dt.GetJiDuOfYear() * 3,1).GetLastDayOfMonth();
            return dateTime;
        }
        /// <summary>
        /// 获取时间所在季度的第一天
        /// </summary>
        public static DateTime GetFirstDayOfJidu(this DateTime dt) {
            DateTime dateTime = new DateTime(dt.Year,dt.GetJiDuOfYear() * 3 - 2,1);
            return dateTime;
        }
        /// <summary>
        /// 获取时间所在年的最后一天
        /// </summary>
        public static DateTime GetLastDayOfYear(this DateTime dt) {
            DateTime dateTime = new DateTime(dt.Year,12,31);
            return dateTime;
        }
        /// <summary>
        /// 获取时间所在年的第一天
        /// </summary>
        public static DateTime GetFirstDayOfYear(this DateTime dt) {
            DateTime dateTime = new DateTime(dt.Year,1,1);
            return dateTime;
        }
        public static float ParseFloat(object p) {
            return ParseFloat(p,1);
        }
        /// <summary>
        /// 解析Float类型，同时保留指定的小数位位数
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <returns></returns>
        public static float ParseFloat(object p,int p_2) {
            float temp = 0F;
            if(IsNotNullOrEmpty(p)) {
                float.TryParse(p.ToString(),out temp);

                temp = (float)Math.Round(temp,2);
            }
            return temp;
        }
        /// <summary>
        /// 解析float类型，如果解析失败，则返回默认的defalutValue，同时保留指定的小数位位数
        /// </summary>
        /// <param name="get积分"></param>
        /// <param name="p"></param>
        /// <param name="p_3"></param>
        /// <returns></returns>
        public static float ParseFloat(string getText,float defaultValue,int p_3) {
            float getValue = 0F;

            bool tryResult = float.TryParse(getText,out getValue);
            if(tryResult == false) {
                getValue = defaultValue;
            } else {
                getValue = (float)Math.Round(getValue,p_3);
            }

            return getValue;
        }
        public static double ParseDouble(object p,int p_2 = 2) {
            double getValue = 0F;
            if(IsNotNullOrEmpty(p) && p != DBNull.Value) {
                double.TryParse(Convert.ToString(p),out getValue);
            }

            getValue = Math.Round(getValue,p_2);

            return getValue;
        }
        public static decimal ParseDecimal(object p) {
            decimal d = 0;
            try {
                d = Convert.ToDecimal(p);
            } catch {
            }
            return d;
        }
        /// <summary>
        /// 格式化编码字符串，补足前导0
        /// </summary>
        /// <param name="getCode"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string FormatZeroCodeString(int getCode,int length) {
            string getFormatCode = "000000";
            try {
                getFormatCode = getFormatCode.Substring(0,length - getCode.ToString().Length) + getCode;
            } catch {
                getFormatCode = "";
            }
            return getFormatCode;
        }

        /// <summary>
        /// ParseBool
        /// </summary>
        /// <param name="getValue"></param>
        /// <returns></returns>
        public static bool ParseBool(object getValue) {
            bool parseValue = false;
            if(getValue != null) {
                bool.TryParse(getValue.ToString(),out parseValue);
            }

            return parseValue;
        }
        /// <summary>
        /// 根据文本解析bool类型
        /// </summary>
        /// <param name="getText"></param>
        /// <returns></returns>
        public static bool ParseBoolWithText(string getText) {
            if(getText.Equals("是") || getText.Equals("true",StringComparison.CurrentCultureIgnoreCase)) {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 生成UUID
        /// </summary>
        /// <returns></returns>
        public static string CreateUUID() {
            return Guid.NewGuid().ToString().Replace("-","");
        }
        /// <summary>
        /// 获取时间对象
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="dateTime_2"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(DateTime dateTime,DateTime dateTime_2) {
            if(dateTime < dateTime_2) {
                return dateTime_2;
            }
            return dateTime;
        }

        public static string GetHTMLString(System.Data.DataTable dt) {
            StringBuilder htmlString = new StringBuilder();

            htmlString.Append("{Items:[");
            int index = 0;
            foreach(DataRow getRow in dt.Rows) {
                string getId = AdobeUtil.IngoreNull(getRow["Id"]);
                string getText = AdobeUtil.IngoreNull(getRow["Text"]);
                if(index++ > 0) {
                    htmlString.Append(",");
                }
                htmlString.Append("{'UUID':'" + getId + "','DisplayText':'" + getText + "'}");
            }
            htmlString.Append("]}");
            return htmlString.ToString();
        }


        /// <summary>
        /// 生成时间格式的序列号，格式为：yyyyMMddxxx
        /// </summary>
        /// <param name="getCount"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string GetDateTimeFlowString(int getCount,int length) {
            return DateTime.Now.ToString("yyyyMMdd") + FormatZeroCodeString(getCount,length);
        }

        public static string ParseChineseDayOfWeek(DayOfWeek dayOfWeek) {
            string getText = "";
            switch(dayOfWeek) {
                case DayOfWeek.Monday:
                    getText = "星期一";
                    break;
                case DayOfWeek.Friday:
                    getText = "星期五";
                    break;
                case DayOfWeek.Saturday:
                    getText = "星期六";
                    break;
                case DayOfWeek.Sunday:
                    getText = "星期日";
                    break;
                case DayOfWeek.Thursday:
                    getText = "星期四";
                    break;
                case DayOfWeek.Tuesday:
                    getText = "星期二";
                    break;
                case DayOfWeek.Wednesday:
                    getText = "星期三";
                    break;
            }
            return getText;
        }


        public static string ListTOSQL(List<string> getUUIDList) {
            string temp = "";

            foreach(string getItem in getUUIDList) {
                if(string.IsNullOrEmpty(temp) == false) {
                    temp += "','";
                }
                temp += getItem;
            }

            return temp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="halfTime"></param>
        /// <returns></returns>
        public static string GetSubscribeTime(int n,bool halfTime) {
            string temp = AdobeUtil.FormatZeroCodeString(n,2);
            if(halfTime == false) {
                temp += ":00 ~ " + temp + ":30";
            } else {
                string addtemp = AdobeUtil.FormatZeroCodeString(n + 1,2);
                if(n >= 23) {
                    addtemp = "00";
                }
                temp += ":30 ~ " + addtemp + ":00";
            }
            return temp;
        }

        public static bool IsFemaleSex(string getValue) {
            bool checkResult = false;

            if("男".Equals(getValue)) {
                checkResult = true;
            }

            return checkResult;
        }

        /// <summary>
        /// 获取公共静态类方法的值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetPublicClassValueByKey(Type type,string key) {
            string tmp = string.Empty;

            FieldInfo field = type.GetField(key);
            if(field != null) {
                tmp = IngoreNull(field.GetValue(null));
            }

            return tmp;
        }

        public static bool IsBooleanTrueValue(string txt) {
            if(txt.Equals("true",StringComparison.CurrentCultureIgnoreCase)) {
                return true;
            }
            return false;
        }

        public static string ParseBooleanText(bool booleanValue) {
            if(booleanValue) {
                return "true";
            }
            return "false";
        }


        public static DataTable ToDataTable(this IList list) {
            DataTable result = new DataTable();
            if(list.Count > 0) {
                System.Reflection.PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach(System.Reflection.PropertyInfo pi in propertys) {
                    result.Columns.Add(pi.Name,pi.PropertyType);
                }

                for(int i = 0;i < list.Count;i++) {
                    ArrayList tempList = new ArrayList();
                    foreach(System.Reflection.PropertyInfo pi in propertys) {
                        object obj = pi.GetValue(list[i],null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array,true);
                }
            }
            return result;
        }

        public static string IngoreZeroToString(float getValue) {
            if(getValue == 0) {
                return "";
            }
            return getValue.ToString();
        }

        /// <summary>
        /// 获取百分比
        /// </summary>
        /// <param name="value"></param>
        /// <param name="precent"></param>
        /// <returns></returns>
        public static float ParsePrecent(float value,float precent) {
            float getPrecent = value * precent;
            getPrecent = getPrecent / 100;
            return getPrecent;
        }

        /// <summary>
        /// ParseDateTimeString
        /// </summary>
        /// <param name="time"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ParseDateTimeString(DateTime time,string format) {
            return time.ToString(format);
        }
        public static string ParsePkFieldName(Type type) {
            string pkFieldName = string.Empty;

            List<MethodInfo> ary_Methods = Ajutil.GetMethodList(type);
            MethodInfo mdh_GetUUID = ary_Methods.Find(t => t.Name.Equals("get_pkfieldname",StringComparison.CurrentCultureIgnoreCase));

            if(mdh_GetUUID != null) {
                pkFieldName = (string)mdh_GetUUID.Invoke(type.Assembly.CreateInstance(type.FullName),null);
            }

            return pkFieldName;
        }

        public static string GetVoTypeString(string dbname) {
            return "com.cgWorkstudio.BIMP.Client.vo." + dbname + ",bimp_CloudPro";
        }
        /// <summary>
        /// null,dbnull转换字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ParseObjToString(object obj) {
            string str = "";
            if(!IsNullOrEmpty(obj) && obj != DBNull.Value) {
                str = Convert.ToString(obj);
            }
            return str;
        }

        internal static string ParseSelectSql(string dbname) {
            StringBuilder sql = new StringBuilder();
            string typeString = "com.cgWorkstudio.BIMP.Client.vo." + dbname + ",bimp_CloudPro";
            Type getType = Type.GetType(typeString);
            List<MethodInfo> ary_Methods = Ajutil.GetMethodList(getType);

            MethodInfo mdh_GetFields = ary_Methods.Find(t => t.Name.Equals("get_fields",StringComparison.CurrentCultureIgnoreCase));

            List<SQLField> sqlFields = (List<SQLField>)mdh_GetFields.Invoke(getType.Assembly.CreateInstance(getType.FullName),null);
            foreach(SQLField sqlField in sqlFields) {
                //if(sqlField.DbType == SqlDbType.NText) {    // 不查询大数据类型
                //    continue;
                //}
                switch(sqlField.Name.ToUpper()) {
                    case "ISDELETE":
                    case "ISVALID":
                    case "ISUSED":
                        //case "PID":
                        continue;
                }
                if(sql.Length > 0) {
                    sql.Append(",");
                }
                sql.Append(sqlField.Name);
                // 是否显示字段中文备注
                //if(string.IsNullOrEmpty(sqlField.Remarks) == false) {
                //    sql.Append(" as '" + sqlField.Remarks + "'");
                //}
            }
            return sql.ToString();
        }
        public static bool CheckDirectory(string mLocalTempDir) {
            if(Directory.Exists(mLocalTempDir) == false) {
                Directory.CreateDirectory(mLocalTempDir);
            }

            return Directory.Exists(mLocalTempDir);
        }
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Md5(string key) {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(key,"MD5").ToLower();
        }
    }
}