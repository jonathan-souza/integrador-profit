using System;
using System.Configuration;
using System.Reflection;

namespace Selia.Integrador.Utils.Core
{
    public sealed class DatabaseFactory
    {
        public static DatabaseFactorySectionHandler sectionHandler = null;

        private DatabaseFactory() { }

        public static Database CreateDatabase(string nameDataBase = null, string connectionString = null)
        {
            string connection;
            string databaseName;

            if (string.IsNullOrEmpty(nameDataBase) && string.IsNullOrEmpty(connectionString))
            {
                sectionHandler = (DatabaseFactorySectionHandler)ConfigurationManager.GetSection("DatabaseFactoryConfiguration");

                databaseName = sectionHandler.Name;
                connection = sectionHandler.ConnectionString;

                if (sectionHandler.Name.Length == 0)
                {
                    throw new Exception("Nome do banco de dados não está definido no Web.config.");
                }
            }
            else
            {
                databaseName = nameDataBase;
                connection = connectionString;
            }

            try
            {
                //Find the class
                Type database = Type.GetType(databaseName);

                //Get it's contructor
                ConstructorInfo constructor = database.GetConstructor(new Type[] { });

                //Invoke it's constructor, whitch returns an instance.
                Database createObject = (Database)constructor.Invoke(null);

                //Initialize the connection String property for the database
                createObject.ConnectionString = connection;

                //Pass back the instance as a Database
                return createObject;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
