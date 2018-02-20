
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selia.Integrador.Utils.Generic
{
    public class Parse
    {
        public static object Invoke(Type Type, object Value)
        {

            if (Value != null && Value != System.DBNull.Value)
            {
                var method = Type.GetMethod("Parse", new Type[] { typeof(string) });
                if (method != null)
                {
                    if (Type == typeof(bool) && Value.GetType() != typeof(bool))
                    {
                        return Value.ToString().Contains("1") || Value.ToString().ToLower().Contains("true") ? true : false;
                    }
                    if (Type == typeof(DateTime) && Value.GetType() != typeof(DateTime))
                    {
                        return DateTime.Parse(Value.ToString()).ToString("yyyy-MM-ddThh:mm:ss.000");
                    }
                    var ValueConvertido = method.Invoke(null, new object[] { Convert.ToString(Value) });
                    return ValueConvertido;
                }
                else
                {
                    var PropInfo = Type.GetProperty("Value");
                    if (PropInfo != null)
                    {
                        return Invoke(PropInfo.PropertyType, Value);
                    }
                    else
                    {
                        if (Type.BaseType == typeof(Enum))
                        {
                            return Enum.Parse(Type, Value.ToString());
                        }
                        return Convert.ToString(Value);
                    }
                }
            }
            else
            {
                return null;
            }
        }
    }
}
