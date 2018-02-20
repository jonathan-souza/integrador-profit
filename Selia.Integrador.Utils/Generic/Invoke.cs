using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Selia.Integrador.Utils.Generic
{
    public class Invoke
    {       
        public object Exec(string ClassName, string MethodName, List<object> Parametros = null, string ConnectionString=null)
        {
            try
            {
                var type = Type.GetType(ClassName);
                var objClass = Activator.CreateInstance(Type.GetType(ClassName), null);
                PropertyInfo propConnectionString = objClass.GetType().GetProperty("ConnectionString");
                if (propConnectionString != null && !string.IsNullOrEmpty(ConnectionString))
                {
                    propConnectionString.SetValue(objClass, ConnectionString, null);
                }


                object Result = new object();
                if (!string.IsNullOrEmpty(MethodName))
                {
                    MethodInfo methodInfo = objClass.GetType().GetMethod(MethodName);

                    Result = methodInfo.Invoke(objClass, (objClass.GetType().GetMethod(MethodName).GetParameters().Length == 0 ? null : Parametros.ToArray()));

                }

                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
