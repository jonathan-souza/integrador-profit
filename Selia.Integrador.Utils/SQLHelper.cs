using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Reflection;
using Selia.Integrador.Utils;
using Selia.Integrador.Utils.Core;

namespace Selia.Integrador.Utils
{
    public class SQLHelper : DataWorker
    {
        public IDbConnection connection;
        public IDbCommand DbCommand;

        private bool existeOutParameter;
        private string procedure;
        private List<IDbDataParameter> parameters;

        public SQLHelper(bool ExisteOutParameter, string Procedure, List<IDbDataParameter> Parameters = null)
        {
            existeOutParameter = ExisteOutParameter;
            procedure = Procedure;
            parameters = Parameters;
        }

        public DataTable DataTable()
        {
            using (connection = database.CreateConnection())
            {
                connection.Open();

                DbCommand = database.CreateStoredProcedure(procedure, connection, existeOutParameter);

                foreach (var item in parameters)
                {
                    DbCommand.Parameters.Add(database.CreateParameter(item.ParameterName, item.Value));
                }

                DbCommand.CommandType = CommandType.StoredProcedure;
                DbCommand.CommandText = procedure;

                DataTable dt = new System.Data.DataTable();
                IDataReader oDt = DbCommand.ExecuteReader();

                dt.Load(oDt);

                return dt;
            }
        }
        public int NonQuery()
        {
            using (connection = database.CreateConnection())
            {
                connection.Open();

                DbCommand = database.CreateStoredProcedure(procedure, connection, existeOutParameter);

                foreach (var item in parameters)
                {
                    DbCommand.Parameters.Add(database.CreateParameter(item.ParameterName, item.Value));
                }

                DbCommand.CommandType = CommandType.StoredProcedure;
                DbCommand.CommandText = procedure;

                int Qtd = DbCommand.ExecuteNonQuery();
                return Qtd;
            }
        }

    }
}
