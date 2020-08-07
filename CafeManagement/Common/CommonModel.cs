using System.Collections.Generic;

namespace CafeManagement.Common
{
    public class CommonModel
    {
        public Dictionary<string, object> Values { get; set; }

        public CommonModel()
        {
            Values = new Dictionary<string, object>();
        }

        public CommonModel Add(string key, object value)
        {
            Values.Add(key, value);
            return this;
        }
    }
}