using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Selia.Integrador.Utils
{
    public static class Json
    {
        public static string Serialize(dynamic obj, bool isNullValueHandling=true)
        {
            NullValueHandling nullValue = NullValueHandling.Include;

            if (!isNullValueHandling)
                nullValue = Newtonsoft.Json.NullValueHandling.Ignore;

            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, new Newtonsoft.Json.JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore, MaxDepth = 20, NullValueHandling = nullValue });
        }
        public static T Deserialize<T>(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }

        public static object Deserialize(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject(json);
        }

        public static dynamic DeserializeDynamic<T>(string json, T t)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeAnonymousType<T>(json, t);
        }

        public static XmlDocument DeserializeXmlNode(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeXmlNode(json);
        }
    }
}
