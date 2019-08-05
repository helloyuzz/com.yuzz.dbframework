using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.yuzz.dbframework
{
    [Serializable]
    public class MultiJoin
    {
        public virtual JoinMethod joinMethod
        {
            get;
            set;
        }
        public virtual string nick1
        {
            get;
            set;
        }
        public virtual string nick2
        {
            get;
            set;
        }
        public virtual Type tb1
        {
            get;
            set;
        }
        public virtual Type tb2
        {
            get;
            set;
        }

        /// <summary>
        /// 联合查询
        /// </summary>
        /// <param name="joinMethod">联合查询方式：left join,inner join,right join</param>
        /// <param name="tb1">表1</param>
        /// <param name="nick1">别名1</param>
        /// <param name="tb2">表2</param>
        /// <param name="nick2">别名2</param>
        public MultiJoin(JoinMethod joinMethod, Type tb1, string nick1, Type tb2, string nick2)
        {
            this.joinMethod = joinMethod;
            this.tb1 = tb1;
            this.tb2 = tb2;
            this.nick1 = nick1;
            this.nick2 = nick2;
        }
        List<MultiOn> _On = null;
        /// <summary>
        /// 联合查询on条件
        /// </summary>
        public List<MultiOn> On
        {
            get
            {
                if (_On == null)
                {
                    _On = new List<MultiOn>();
                }
                return _On;
            }
        }
    }
}
