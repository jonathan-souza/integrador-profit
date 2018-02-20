using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Selia.Integrador.Utils.Core
{
    public abstract class Database
    {
        public string ConnectionString;

        public abstract IDbConnection CreateConnection();
        public abstract IDbConnection CreateOpenConnection();
        public abstract IDbCommand CreateCommand();
        public abstract IDbCommand CreateCommand(string commandText, IDbConnection connection);
        public abstract IDbCommand CreateStoredProcedure(string spName, IDbConnection connection, bool ExisteOutParameter);
        public abstract IDataParameter CreateParameter(string parameterName, object parameterValue);
        public abstract IDataParameter CreateParameter(string parameterName, object parameterValue, bool isOutParameter);
    }
}