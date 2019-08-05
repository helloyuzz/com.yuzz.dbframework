using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace com.yuzz.dbframework
{
    [Serializable]
    public class SQLField
    {
        public SQLField()
        {
        }
        public SQLField(string name, SqlDbType dbType)
        {
            Name = name;
            MsDbType = dbType;
        }
        public SQLField(string name, SqlDbType dbType, bool identity)
        {
            Name = name;
            MsDbType = dbType;
            Identity = identity;
        }
        public SQLField(string name, SqlDbType dbType, bool identity, string remarks)
        {
            Name = name;
            MsDbType = dbType;
            Identity = identity;
            Remarks = remarks;
        }
        public SQLField(string name, MySqlDbType dbType)
        {
            Name = name;
            MyDbType = dbType;
        }
        public SQLField(string name, MySqlDbType dbType, bool identity)
        {
            Name = name;
            MyDbType = dbType;
            Identity = identity;
        }
        public SQLField(string name, MySqlDbType dbType, bool identity, string remarks)
        {
            Name = name;
            MyDbType = dbType;
            Identity = identity;
            Remarks = remarks;
        }
        public virtual string Name
        {
            get;
            set;
        }
        public virtual SqlDbType MsDbType
        {
            get;
            set;
        }
        public virtual MySqlDbType MyDbType
        {
            get;
            set;
        }
        public virtual bool Identity
        {
            get;
            set;
        }
        public virtual string Remarks
        {
            get;
            set;
        }
    }
}