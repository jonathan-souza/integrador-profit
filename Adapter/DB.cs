using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Selia.Integrador.Utils;
using Selia.Integrador.Utils.Core;

namespace Selia.Integrador.Adapter
{
    public class DB
    {

        public class Config
        {
            public Config()
            {
                Mapeamentos = new List<Util.Mapeamento.Entidade>();
            }
            public string ElementoSeparador { get; set; }

            public string StoredProcedure { get; set; }
            public string ConnectionString { get; set; }
            public string DataBaseNameFactory { get; set; }
            public List<Util.Mapeamento.Entidade> Mapeamentos { get; set; }
            public string ExecucaoInicial { get; set; }
            public string ExecucaoFinal { get; set; }
            public string ExecucaoEnfileiramento { get; set; }
        }
        public Resultado Executar(Config objConfig, string XmlFila, bool temDestinoID = false)
        {
            Resultado objResultado = new Resultado();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(XmlFila);
                objResultado = Executar(objConfig, doc, temDestinoID);
            }
            catch (Exception ex)
            {
                objResultado = new Resultado() { Mensagem = ex.Message + " <br><br>  " + ex.StackTrace, TipoMensagem = Resultado.Tipo.Erro };
            }
            return objResultado;
        }
        public Resultado Executar(Config entConfig, XmlDocument XmlFila = null, bool temDestinoID = false)
        {
            Resultado entResultado = new Resultado();
            try
            {
                if (XmlFila == null)
                {
                    if (!string.IsNullOrEmpty(entConfig.ExecucaoInicial))
                    {
                        List<object> lst = new List<object>();
                        lst.Add(entConfig);
                        entConfig = (Config)new Integrador.Utils.Generic.Invoke().Exec(entConfig.ExecucaoInicial.Split(';')[0], entConfig.ExecucaoInicial.Split(';')[1], lst, entConfig.ConnectionString);
                    }

                    DataSet ds = new SQLHelper(true, entConfig).DataSet();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(ds.GetXml());

                    if (!string.IsNullOrEmpty(entConfig.ExecucaoFinal))
                    {
                        List<object> lst = new List<object>();
                        lst.Add(ds);
                        lst.Add(doc);
                        doc = (XmlDocument)new Integrador.Utils.Generic.Invoke().Exec(entConfig.ExecucaoFinal.Split(';')[0], entConfig.ExecucaoFinal.Split(';')[1], lst, entConfig.ConnectionString);
                    }

                    entResultado = new Resultado() { Mensagem = "DB executado com sucesso.", ElementoSeparador = entConfig.ElementoSeparador, RespostaXmlCompleta = doc, TipoMensagem = Resultado.Tipo.Sucesso };
                }
                else
                {
                    if (!string.IsNullOrEmpty(entConfig.ExecucaoInicial))
                    {
                        List<object> lst = new List<object>();
                        lst.Add(XmlFila);
                        lst.Add(entConfig);
                        entConfig = (Config)new Integrador.Utils.Generic.Invoke().Exec(entConfig.ExecucaoInicial.Split(';')[0], entConfig.ExecucaoInicial.Split(';')[1], lst, entConfig.ConnectionString);
                    }
                    foreach (Adapter.Util.Mapeamento.Entidade map in entConfig.Mapeamentos)
                    {
                        map.Valor = new Adapter.Util.Mapeamento().ObterValorNodeXml(map, XmlFila);
                    }

                    Selia.Integrador.Adapter.DB.SQLHelper entSQLHelper = new Selia.Integrador.Adapter.DB.SQLHelper(false, entConfig);
                    
                    if (temDestinoID)
                    {
                        DataSet ds = new SQLHelper(true, entConfig).DataSet();
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(ds.GetXml());

                        if (!string.IsNullOrEmpty(entConfig.ExecucaoFinal))
                        {
                            List<object> lst = new List<object>();
                            lst.Add(doc);
                            lst.Add(XmlFila);
                            doc = (XmlDocument)new Integrador.Utils.Generic.Invoke().Exec(entConfig.ExecucaoFinal.Split(';')[0], entConfig.ExecucaoFinal.Split(';')[1], lst, entConfig.ConnectionString);
                        }

                        entResultado = new Resultado() { Mensagem = "DB executado com sucesso.", ElementoSeparador = entConfig.ElementoSeparador, RespostaXmlCompleta = doc, TipoMensagem = Resultado.Tipo.Sucesso };
                    }
                    else
                    {
                        entSQLHelper.NonQuery();
                        entResultado = new Resultado() { Mensagem = "DB executado com sucesso.", TipoMensagem = Resultado.Tipo.Sucesso };
                    }
                }
            }
            catch (Exception ex)
            {
                entResultado = new Resultado() { Mensagem = ex.Message + " <br><br>  " + ex.StackTrace, TipoMensagem = Resultado.Tipo.Erro, ElementoSeparador = entConfig.ElementoSeparador };
                //ServiceLog.LogError(String.Format("Erro: Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace));
            }
            return entResultado;
        }

        public class SQLHelper
        {
            public IDbConnection connection;
            public IDbCommand DbCommand;

            public SQLHelper(bool ExisteOutParameter, Config entConfig)
            {
                Database database = DatabaseFactory.CreateDatabase(entConfig.DataBaseNameFactory, entConfig.ConnectionString);

                connection = database.CreateConnection();
                connection.Open();

                DbCommand = database.CreateStoredProcedure(entConfig.StoredProcedure, connection, ExisteOutParameter);
                //DbCommand = connection.CreateCommand();
                if (DbCommand.Parameters.Count == 0)
                {
                    entConfig.StoredProcedure = entConfig.StoredProcedure.ToUpper();

                    string command = "";
                    foreach (Util.Mapeamento.Entidade map in entConfig.Mapeamentos)
                    {
                        DbCommand.Parameters.Add((IDbDataParameter)database.CreateParameter(map.Para, map.Valor));
                        command += map.Para + " = " + map.Valor + ", \n";
                    }
                    command = entConfig.StoredProcedure + " " + command;
                }
                if (entConfig.StoredProcedure.Contains(" "))
                {
                    DbCommand.Prepare();
                    DbCommand.CommandType = CommandType.Text;
                }
                //else
                //{
                //    DbCommand = database.CreateStoredProcedure(entConfig.StoredProcedure, connection, ExisteOutParameter);
                //}
                DbCommand.CommandText = entConfig.StoredProcedure;

            }
            public DataSet DataSet()
            {
                DataSet ds = new System.Data.DataSet("Integrador");
                DataTable dt = new System.Data.DataTable("Item");

                IDataReader oDt = DbCommand.ExecuteReader();
                dt.Load(oDt);
                ds.Tables.Add(dt);
                connection.Close();

                return ds;
            }
            public DataTable DataTable()
            {
                DataTable dt = new System.Data.DataTable("Itens");
                IDataReader oDt = DbCommand.ExecuteReader();
                dt.Load(oDt);

                connection.Close();
                return dt;
            }
            public int NonQuery()
            {
                int Qtd = DbCommand.ExecuteNonQuery();
                connection.Close();
                return Qtd;
            }
        }
    }
}
