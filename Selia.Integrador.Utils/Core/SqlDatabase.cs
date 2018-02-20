using System.Data;
using System.Data.SqlClient;

namespace Selia.Integrador.Utils.Core
{
    public class SqlDatabase : Database
    {
        public override IDbConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public override IDbConnection CreateOpenConnection()
        {
            SqlConnection connection = (SqlConnection)CreateConnection();

            connection.Open();

            return connection;
        }

        public override IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        public override IDbCommand CreateCommand(string commandText, IDbConnection connection)
        {
            SqlCommand command = (SqlCommand)CreateCommand();

            command.CommandText = commandText;
            command.CommandType = CommandType.Text;
            command.Connection = (SqlConnection)connection;

            return command;
        }

        public override IDbCommand CreateStoredProcedure(string spName, IDbConnection connection, bool ExisteOutParameter)
        {
            SqlCommand command = (SqlCommand)CreateCommand();

            command.CommandText = spName;
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = (SqlConnection)connection;

            return command;
        }

        public override IDataParameter CreateParameter(string parameterName, object parameterValue)
        {
            return new SqlParameter(parameterName, parameterValue);
        }

        public override IDataParameter CreateParameter(string parameterName, object parameterValue, bool isOutParameter)
        {
            return new SqlParameter(parameterName, parameterValue);
        }
    }
}
