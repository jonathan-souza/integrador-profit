using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selia.Integrador.Utils
{
    public static class ServiceLog
    {
        public static void LogError(string Message)
        {
            if (System.Configuration.ConfigurationManager.AppSettings["ServiceLogError"] == null || System.Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["ServiceLogError"]))
            {
                System.Diagnostics.EventLog.WriteEntry("WS-Integrador", Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        public static void LogInfo(string Message)
        {
            if (System.Configuration.ConfigurationManager.AppSettings["ServiceLogDebug"] == null || System.Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["ServiceLogDebug"]))
            {
                System.Diagnostics.EventLog.WriteEntry("WS-Integrador", Message, System.Diagnostics.EventLogEntryType.Information);
            }
        }

        public static void LogWarning(string Message)
        {
            if (System.Configuration.ConfigurationManager.AppSettings["ServiceLogWarning"] == null || System.Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["ServiceLogWarning"]))
            {
                System.Diagnostics.EventLog.WriteEntry("WS-Integrador", Message, System.Diagnostics.EventLogEntryType.Warning);
            }
        }
    }
}
