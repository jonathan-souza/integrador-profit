using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Selia.Integrador.Utils
{
    public static class Extensions
    {
        #region Extension for System.Object
        //public static string Serialize(this object obj)
        //{
        //    return Json.Serialize(obj);
        //}    

        public static XmlDocument DeserializeXmlNode(this string json)
        {
            return Json.DeserializeXmlNode(json);
        }

        private static Expected GetAttributeValue<T, Expected>(this Enum enumeration, Func<T, Expected> expression)
       where T : Attribute
        {
            T attribute =
              enumeration
                .GetType()
                .GetMember(enumeration.ToString())
                .Where(member => member.MemberType == MemberTypes.Field)
                .FirstOrDefault()
                .GetCustomAttributes(typeof(T), false)
                .Cast<T>()
                .SingleOrDefault();

            if (attribute == null)
                return default(Expected);

            return expression(attribute);
        }

        public static string GetAtributoContentType(this Enum contentyType)
        {
            string description = contentyType.GetAttributeValue<ContentTypeDescricaoAttribute, string>(x => x.content);

            return description;
        }

        public static int ToInt(this string obj)
        {
            int ret = 0;
            int.TryParse(obj, out ret);
            return ret;
        }

        public static Int64 ToInt64(this string obj)
        {
            Int64 ret = 0;
            Int64.TryParse(obj, out ret);
            return ret;
        }

        public static decimal ToDecimal(this string obj)
        {
            decimal ret = 0.0M;
            decimal.TryParse(obj, out ret);
            return ret;
        }

        public static double ToDouble(this string obj)
        {
            double ret = 0.0;
            double.TryParse(obj, out ret);
            return ret;
        }

        public static bool ToBoolean(this string obj)
        {
            bool ret = false;
            bool.TryParse(obj ,out ret);
            return ret;
        }

        public static DateTime? ToDateTimeNull(this string obj)
        {
            DateTime? ret = null;
            DateTime aux = DateTime.MinValue;
            if (DateTime.TryParseExact(obj, Selia.Integrador.Utils.Constants.DateFormats, Selia.Integrador.Utils.Constants.Culture, System.Globalization.DateTimeStyles.None, out aux))
            {
                ret = aux;
            }
            return ret;
        }

        public static string SerializeXML<T>(this object obj) where T : class
        {
            try
            {

                System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(((T)obj).GetType());

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Encoding = System.Text.Encoding.UTF8;

                System.Xml.Serialization.XmlSerializerNamespaces myNamespaces = new System.Xml.Serialization.XmlSerializerNamespaces();


                using (StringWriterUtf8 textWriter = new StringWriterUtf8())
                {

                    using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                    {
                        xml.Serialize(xmlWriter, obj, myNamespaces);
                    }
                    return textWriter.ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static string RetornarValorNoXml(this XmlDocument xml, string no)
        {
            bool Exists = true;
            string valor = string.Empty;
            XmlNode NodeClone = xml.Clone();
            foreach (string Nome in no.Split('/'))
            {
                NodeClone = NodeClone[Nome];
                if (NodeClone == null)
                {
                    NodeClone = xml.Clone();
                    Exists = false;
                }
                else
                {
                    Exists = true;
                }
            }
            valor = Exists ? NodeClone.InnerText : "";

            return valor;
        
        }

        #endregion
    }
}
