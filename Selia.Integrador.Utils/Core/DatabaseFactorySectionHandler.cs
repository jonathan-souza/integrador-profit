using System;
using System.Configuration;

namespace Selia.Integrador.Utils.Core
{
    public sealed class DatabaseFactorySectionHandler : ConfigurationSection
    {

        [ConfigurationProperty("Name")]
        public string Name
        {
            get { return (string)base["Name"]; }
        }

        [ConfigurationProperty("ConnectionStringName")]
        public string ConnetionStringName
        {
            get { return (string)base["ConnectionStringName"]; }
        }

        public string ConnectionString
        {
            get
            {
                try
                {
                    return ConfigurationManager.ConnectionStrings[ConnetionStringName].ConnectionString;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Connection string: {0} não foi encontrada no web.config. Erro:{1}.",
                                                            ConnetionStringName, ex.ToString()));
                }
            }
        }
    }
}
