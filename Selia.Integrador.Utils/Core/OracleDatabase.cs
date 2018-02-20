using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Selia.Integrador.Utils.Core
{
    public class OracleDatabase : Database
    {
        public override IDbConnection CreateConnection()
        {
            return new OracleConnection(ConnectionString);
        }

        public override IDbConnection CreateOpenConnection()
        {
            OracleConnection connection = (OracleConnection)CreateConnection();

            connection.Open();

            return connection;
        }

        public override IDbCommand CreateCommand()
        {
            return new OracleCommand();
        }

        public override IDbCommand CreateCommand(string commandText, IDbConnection connection)
        {
            OracleCommand command = (OracleCommand)CreateCommand();

            command.CommandText = commandText;
            command.Connection = (OracleConnection)connection;
            command.CommandType = CommandType.Text;
            command.InitialLONGFetchSize = -1;

            return command;
        }

        public override IDbCommand CreateStoredProcedure(string spName, IDbConnection connection, bool ExisteOutParameter)
        {
            OracleCommand command = (OracleCommand)CreateCommand();

            if (ExisteOutParameter)
            {
                command.Parameters.Add(this.CreateParameter("cv_1", null, true));
            }

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = spName;
            command.Connection = (OracleConnection)connection;
            command.InitialLONGFetchSize = -1;

            return command;
        }

        public override IDataParameter CreateParameter(string parameterName, object parameterValue)
        {
            return CreateParameter(parameterName, parameterValue, false);
        }

        public override IDataParameter CreateParameter(string parameterName, object parameterValue, bool isOutParameter)
        {
            if (isOutParameter)
            {
                return new OracleParameter(parameterName, OracleDbType.RefCursor, ParameterDirection.Output);
            }

            return new OracleParameter(parameterName, parameterValue);
        }
    }
}
