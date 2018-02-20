using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Selia.Integrador.Adapter
{
    public class DynamicObj : DynamicObject
    {
        public Dictionary<string, object> properties = new Dictionary<string, object>();

        public void AddProperty(string property, object value)
        {
            if (!properties.ContainsKey(property))
            {
                properties.Add(property, value);               
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return properties.TryGetValue(binder.Name, out result);
        }

        public bool Contains(string key)
        {
            return properties.ContainsKey(key);
        }

        public object Get(string key)
        {
            return properties[key];
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            properties[binder.Name] = value;
            return true;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return properties.Keys;
        }
    }
}
