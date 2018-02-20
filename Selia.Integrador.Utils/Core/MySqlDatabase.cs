
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Selia.Integrador.Utils.Core
{
    public class MySqlDatabase : Database
    {
        public override IDbConnection CreateConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public override IDbConnection CreateOpenConnection()
        {
            MySqlConnection connection = (MySqlConnection)CreateConnection();

            connection.Open();

            return connection;
        }

        public override IDbCommand CreateCommand()
        {
            return new MySqlCommand();
        }

        public override IDbCommand CreateCommand(string commandText, IDbConnection connection)
        {
            MySqlCommand command = (MySqlCommand)CreateCommand();

            command.CommandText = commandText;
            command.CommandType = CommandType.Text;
            command.Connection = (MySqlConnection)connection;

            return command;
        }

        public override IDbCommand CreateStoredProcedure(string spName, IDbConnection connection, bool ExisteOutParameter)
        {
            MySqlCommand command = (MySqlCommand)CreateCommand();

            command.CommandText = spName;
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = (MySqlConnection)connection;

            return command;
        }

        public override IDataParameter CreateParameter(string parameterName, object parameterValue)
        {
            return new MySqlParameter(parameterName, parameterValue);
        }

        public override IDataParameter CreateParameter(string parameterName, object parameterValue, bool isOutParameter)
        {
            return new MySqlParameter(parameterName, parameterValue);  
        }
    }
}
