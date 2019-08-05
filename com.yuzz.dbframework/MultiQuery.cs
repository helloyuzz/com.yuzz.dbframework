using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.yuzz.dbframework
{
    [Serializable]
    public class MultiQuery
    {
        List<MultiJoin> _joinList = null;
        MultiSelectField _selectFields = null;
        string _sqlWhere = "";
        string _sqlOrder = "";

        public virtual string sqlOrder
        {
            get
            {
                return _sqlOrder;
            }
        }
        public virtual string sqlWhere
        {
            get
            {
                return _sqlWhere;
            }
        }
        public void AddWhere(string sqlWhere)
        {
            _sqlWhere = sqlWhere;
        }
        public void AddOrder(string sqlOrder)
        {
            _sqlOrder = sqlOrder;
        }
        public virtual List<MultiJoin> JoinList
        {
            get
            {
                if (_joinList == null)
                {
                    _joinList = new List<MultiJoin>();
                }
                return _joinList;
            }
        }
        /// <summary>
        /// 定义查询字段，必须手工指定，禁止使用“select *“的方式
        /// </summary>
        public virtual MultiSelectField SelectFields
        {
            get
            {
                if (_selectFields == null)
                {
                    _selectFields = new MultiSelectField();
                }
                return _selectFields;
            }
            set
            {
                _selectFields = value;
            }
        }

        List<MultiSchema> _schemaList = null;
        public virtual List<MultiSchema> SchemaList
        {
            get
            {
                if (_schemaList == null)
                {
                    _schemaList = new List<MultiSchema>();
                }
                return _schemaList;
            }
        }
        public void AddFrom(Type schemaType, string nick)
        {
            MultiSchema schema = new MultiSchema();
            schema.SchemaType = schemaType;
            schema.Nickname = nick;

            this.SchemaList.Add(schema);
        }
    }
}