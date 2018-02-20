using System;
using System.Configuration;

namespace Selia.Integrador.Utils.Core
{
    public class DataWorker
    {
        private static Database _database = null;

        static DataWorker()
        {
            try
            {
                _database = DatabaseFactory.CreateDatabase();
            }
            catch (ConfigurationErrorsException ex2)
            {
                throw ex2;
            }
            catch (ConfigurationException ex)
            {
                throw ex;
            }
            catch (Exception ex3)
            {
                throw ex3;
            }
        }

        public static Database database
        {
            get { return _database; }
        }
    }
}
