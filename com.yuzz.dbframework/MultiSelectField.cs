using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.yuzz.dbframework
{
    [Serializable]
    public class MultiSelectField : List<MultiField>
    {
        public MultiSelectField()
        {

        }

        public void Append(string tbNickName, params string[] fields)
        {
            MultiField multiField = new MultiField();
            multiField.nickname = tbNickName;

            foreach (string field in fields)
            {
                multiField.Fields.Add(field);
            }
            Add(multiField);
        }
    }
}
