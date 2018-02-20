using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selia.Integrador.Utils
{
    public static class Constants
    {
        public static string[] DateFormats
        {
            get
            {
                string[] ret = { "dd/MM/yyyy" };
                string aux = Constants.AppSettings.Date.Formats;
                if (!string.IsNullOrWhiteSpace(aux))
                {
                    ret = aux.Split('|');
                }
                return ret;
            }
        }

        public static System.Globalization.CultureInfo Culture
        {
            get
            {
                System.Globalization.CultureInfo ret = new System.Globalization.CultureInfo(Constants.AppSettings.Culture);
                return ret;
            }
        }

        public static class AppSettings
        {
            public static class Email
            {
                public static string Body
                {
                    get
                    {
                        return System.Configuration.ConfigurationManager.AppSettings["Constants:AppSettings:Email:Body"];

                    }
                }
            }

            public static class Date
            {
                public static string Formats
                {
                    get
                    {
                        return System.Configuration.ConfigurationManager.AppSettings["Constants:AppSettings:Date:Formats"];
                    }
                }
            }

            public static class HttpStatusCode
            {
                public static string Sucesso
                {
                    get
                    {
                        return System.Configuration.ConfigurationManager.AppSettings["Constants:AppSettings:HttpStatusCode:Sucesso"];
                    }
                }
            }

            public static string Culture
            {
                get
                {
                    return System.Configuration.ConfigurationManager.AppSettings["Constants:AppSettings:Culture"];
                }
            }

            public static string MediaTypeHeaderJson
            {
                get
                {

                    return GetAppSettings("Constants:AppSettings:MediaTypeHeaderJson");
                }
            }

            internal static string GetAppSettings(string value)
            {
                return System.Configuration.ConfigurationManager.AppSettings[value].ToString();

            }
        }
    }
}
