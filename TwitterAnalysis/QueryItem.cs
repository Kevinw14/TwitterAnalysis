using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterAnalysis
{
    public class QueryItem
    {
        private string key;
        private string value;

        public string Key
        {
            get
            {
                return key;
            }
        }

        public string Value
        {
            get
            {
                return value;
            }
        }
        public QueryItem(string key, string value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
