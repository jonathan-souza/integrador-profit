using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Selia.Integrador.Utils;
using Selia.Integrador.Utils.Core;

namespace Selia.Integrador.DAL
{
    public class Interface : DataWorker
    {
        public class DB
        {
            public Model.Interface.DB Consultar(int ID)
            {
                List<IDbDataParameter> lst = new List<IDbDataParameter>();
                lst.Add((IDbDataParameter)database.CreateParameter("p_adapterID", (int)Model.Adapter.TipoAdapter.DB));
                lst.Add((IDbDataParameter)database.CreateParameter("p_interfaceID", ID));
                return Preencher(new Selia.Integrador.Utils.SQLHelper(true, "SP_INT_SEL_InterfaceByIDAdpID", lst).DataTable())[0];
            }
            public List<Model.Interface.DB> Preencher(DataTable dt)
            {
                List<Model.Interface.DB> lstDB = new List<Model.Interface.DB>();
                foreach (DataRow row in dt.Rows)
                {
                    Model.Interface.DB entDB = new Model.Interface.DB();

                    if (row["ID"] != DBNull.Value)
                    {
                        entDB.ID = Convert.ToInt32(row["ID"].ToString());
                    }
                    if (row["Nome"] != DBNull.Value)
                    {
                        entDB.Nome = row["Nome"].ToString();
                    }
                    if (row["StoredProcedure"] != DBNull.Value)
                    {
                        entDB.StoredProcedure = row["StoredProcedure"].ToString();
                    }
                    if (row["ConnectionString"] != DBNull.Value)
                    {
                        entDB.ConnectionString = row["ConnectionString"].ToString();
                    }
                    if (row["SistemaID"] != DBNull.Value)
                    {
                        entDB.Sistema = new Model.Sistema();
                        entDB.Sistema.ID = Convert.ToInt32(row["SistemaID"].ToString());
                    }
                    if (row["DATABASENAMEFACTORY"] != DBNull.Value)
                    {
                        entDB.DataBaseNameFactory = row["DATABASENAMEFACTORY"].ToString();
                    }

                    entDB.Parametros = ConsultarParametros(entDB.ID);

                    lstDB.Add(entDB);
                }
                return lstDB;
            }
            public List<Model.Interface.DB.ParametroDB> ConsultarParametros(int InterfaceID)
            {
                List<IDbDataParameter> lst = new List<IDbDataParameter>();
                lst.Add((IDbDataParameter)database.CreateParameter("p_interfaceID", InterfaceID));
                return PreencherParametros(new Selia.Integrador.Utils.SQLHelper(true, "SP_INT_SEL_PARADBBYINTERID", lst).DataTable());
            }
            public List<Model.Interface.DB.ParametroDB> PreencherParametros(DataTable dt)
            {
                List<Model.Interface.DB.ParametroDB> lst = new List<Model.Interface.DB.ParametroDB>();
                foreach (DataRow row in dt.Rows)
                {
                    Model.Interface.DB.ParametroDB ent = new Model.Interface.DB.ParametroDB();

                    if (row["ID"] != DBNull.Value)
                    {
                        ent.ID = Convert.ToInt32(row["ID"].ToString());
                    }

                    if (row["De"] != DBNull.Value)
                    {
                        ent.De = row["De"].ToString();
                    }
                    if (row["Para"] != DBNull.Value)
                    {
                        ent.Para = row["Para"].ToString();
                    }
                    if (row["Retorno"] != DBNull.Value)
                    {
                        ent.Retorno = row["Retorno"].ToString();
                    }
                    if (row["InterfaceDBID"] != DBNull.Value)
                    {
                        ent.InterfaceWebServiceID = Convert.ToInt32(row["InterfaceDBID"].ToString());
                    }
                    if (row["PaiID"] != DBNull.Value)
                    {
                        ent.PaiID = Convert.ToInt32(row["PaiID"].ToString());
                    }

                    lst.Add(ent);
                }
                return lst;
            }
        }
        public class WebService
        {
            public Model.Interface.WebService Consultar(int ID)
            {
                List<IDbDataParameter> lst = new List<IDbDataParameter>();
                lst.Add((IDbDataParameter)database.CreateParameter("p_adapterID", (int)Model.Adapter.TipoAdapter.WebService));
                lst.Add((IDbDataParameter)database.CreateParameter("p_interfaceID", ID));
                return Preencher(new Selia.Integrador.Utils.SQLHelper(true, "SP_INT_SEL_InterfaceByIDAdpID", lst).DataTable())[0];
            }
            public List<Model.Interface.WebService.ParametroWS> ConsultarParametros(int InterfaceID)
            {
                List<IDbDataParameter> lst = new List<IDbDataParameter>();
                lst.Add((IDbDataParameter)database.CreateParameter("p_interfaceID", InterfaceID));
                return PreencherParametros(new Selia.Integrador.Utils.SQLHelper(true, "SP_INT_SEL_PARAWSBYINTERID", lst).DataTable());
            }
            public List<Model.Interface.WebService.ParametroWS> PreencherParametros(DataTable dt)
            {
                List<Model.Interface.WebService.ParametroWS> lst = new List<Model.Interface.WebService.ParametroWS>();
                foreach (DataRow row in dt.Rows)
                {
                    Model.Interface.WebService.ParametroWS ent = new Model.Interface.WebService.ParametroWS();

                    if (row["ID"] != DBNull.Value)
                    {
                        ent.ID = Convert.ToInt32(row["ID"].ToString());
                    }

                    if (row["De"] != DBNull.Value)
                    {
                        ent.De = row["De"].ToString();
                    }
                    if (row["Para"] != DBNull.Value)
                    {
                        ent.Para = row["Para"].ToString();
                    }
                    if (row["Retorno"] != DBNull.Value)
                    {
                        ent.Retorno = row["Retorno"].ToString();
                    }
                    if (row["InterfaceWebServiceID"] != DBNull.Value)
                    {
                        ent.InterfaceWebServiceID = Convert.ToInt32(row["InterfaceWebServiceID"].ToString());
                    }
                    if (row["PaiID"] != DBNull.Value)
                    {
                        ent.PaiID = Convert.ToInt32(row["PaiID"].ToString());
                    }

                    lst.Add(ent);
                }
                return lst;
            }
            public List<Model.Interface.WebService> Preencher(DataTable dt)
            {
                List<Model.Interface.WebService> lst = new List<Model.Interface.WebService>();
                foreach (DataRow row in dt.Rows)
                {
                    Model.Interface.WebService ent = new Model.Interface.WebService();

                    if (row["ID"] != DBNull.Value)
                    {
                        ent.ID = Convert.ToInt32(row["ID"].ToString());
                    }

                    if (row["Nome"] != DBNull.Value)
                    {
                        ent.Nome = row["Nome"].ToString();
                    }
                    if (row["SistemaID"] != DBNull.Value)
                    {
                        ent.Sistema = new Model.Sistema();
                        ent.Sistema.ID = Convert.ToInt32(row["SistemaID"].ToString());
                    }
                    if (row["Login"] != DBNull.Value)
                    {
                        ent.Login = row["Login"].ToString();
                    }
                    if (row["Metodo"] != DBNull.Value)
                    {
                        ent.Metodo = row["Metodo"].ToString();
                    }
                    if (row["Action"] != DBNull.Value)
                    {
                        ent.Action = row["Action"].ToString();
                    }
                    if (row["Senha"] != DBNull.Value)
                    {
                        ent.Senha = row["Senha"].ToString();
                    }
                    if (row["Url"] != DBNull.Value)
                    {
                        ent.Url = row["Url"].ToString();
                    }
                    ent.Parametros = ConsultarParametros(ent.ID);

                    lst.Add(ent);
                }
                return lst;
            }
        }
        public class ArquivoTexto
        {
            public Model.Interface.ArquivoTexto Consultar(int ID)
            {
                List<IDbDataParameter> lst = new List<IDbDataParameter>();
                lst.Add((IDbDataParameter)database.CreateParameter("p_adapterID", (int)Model.Adapter.TipoAdapter.ArquivoTexto));
                lst.Add((IDbDataParameter)database.CreateParameter("p_interfaceID", ID));
                return Preencher(new Selia.Integrador.Utils.SQLHelper(true, "SP_INT_SEL_InterfaceByIDAdpID", lst).DataTable())[0];
            }
            public List<Model.Interface.ArquivoTexto> Preencher(DataTable dt)
            {
                List<Model.Interface.ArquivoTexto> lst = new List<Model.Interface.ArquivoTexto>();
                foreach (DataRow row in dt.Rows)
                {
                    Model.Interface.ArquivoTexto ent = new Model.Interface.ArquivoTexto();

                    if (row["ID"] != DBNull.Value)
                    {
                        ent.ID = Convert.ToInt32(row["ID"].ToString());
                    }
                    if (row["Nome"] != DBNull.Value)
                    {
                        ent.Nome = row["Nome"].ToString();
                    }
                    if (row["FTP"] != DBNull.Value)
                    {
                        ent.FTP = row["FTP"].ToString();
                    }
                    if (row["SistemaID"] != DBNull.Value)
                    {
                        ent.Sistema = new Model.Sistema();
                        ent.Sistema.ID = Convert.ToInt32(row["SistemaID"].ToString());
                    }
                    if (row["Login"] != DBNull.Value)
                    {
                        ent.Login = row["Login"].ToString();
                    }
                    if (row["Senha"] != DBNull.Value)
                    {
                        ent.Senha = row["Senha"].ToString();
                    }
                    if (row["Url"] != DBNull.Value)
                    {
                        ent.Url = row["Url"].ToString();
                    }
                    if (row["Delimitador"] != DBNull.Value)
                    {
                        ent.Delimitador = row["Delimitador"].ToString();
                    }
                    if (dt.Columns["Diretorio"] != null)
                    {
                        if (row["Diretorio"] != DBNull.Value)
                        {
                            ent.Diretorio = row["Diretorio"].ToString();
                        }
                    }
                    if (dt.Columns["Encoding"] != null)
                    {
                        if (row["Encoding"] != DBNull.Value)
                        {
                            ent.Encoding = row["Encoding"].ToString();
                        }
                    }
                    lst.Add(ent);
                }
                return lst;
            }
        }
        public class Rest
        {
            public Model.Interface.Rest Consultar(int ID)
            {
                List<IDbDataParameter> lst = new List<IDbDataParameter>();
                lst.Add((IDbDataParameter)database.CreateParameter("p_adapterID", (int)Model.Adapter.TipoAdapter.Rest));
                lst.Add((IDbDataParameter)database.CreateParameter("p_interfaceID", ID));
                return Preencher(new Selia.Integrador.Utils.SQLHelper(true, "SP_INT_SEL_InterfaceByIdAdpID", lst).DataTable())[0];
            }
            public List<Model.Interface.Rest> Preencher(DataTable dt)
            {
                List<Model.Interface.Rest> lst = new List<Model.Interface.Rest>();

                foreach (DataRow row in dt.Rows)
                {
                    Model.Interface.Rest ent = new Model.Interface.Rest();

                    if (row["ID"] != DBNull.Value)
                        ent.Id = Convert.ToInt32(row["ID"].ToString());

                    if (row["Nome"] != DBNull.Value)
                        ent.Nome = row["Nome"].ToString();

                    if (row["Url"] != DBNull.Value)
                        ent.Url = row["Url"].ToString();

                    if (row["LOGIN"] != DBNull.Value)
                        ent.Login = row["LOGIN"].ToString();

                    if (row["SENHA"] != DBNull.Value)
                        ent.Senha = row["SENHA"].ToString();

                    if (row["VERBOHTTPID"] != DBNull.Value)
                        ent.VerboHttp = Convert.ToInt32(row["VERBOHTTPID"].ToString());

                    if (row["TIPOAUTENTICACAOID"] != DBNull.Value)
                        ent.TipoAutenticacaoId = Convert.ToInt32(row["TIPOAUTENTICACAOID"].ToString());

                    if (row["SISTEMAID"] != DBNull.Value)
                    {
                        ent.Sistema = new Model.Sistema();
                        ent.Sistema.ID = Convert.ToInt32(row["SistemaID"].ToString());
                    }

                    if (row["RETURNROOTELEMENTPAI"] != DBNull.Value)
                    {
                        ent.ReturnRootElementPai = row["RETURNROOTELEMENTPAI"].ToString();
                    }

                    if (row["RETURNROOTELEMENTLISTA"] != DBNull.Value)
                    {
                        ent.ReturnRootElementLista = row["RETURNROOTELEMENTLISTA"].ToString();
                    }

                    if (row["CONTENTTYPE"] != DBNull.Value)
                    {
                        ent.ContentType = (Model.Interface.Rest.ContentyType)Enum.Parse(typeof(Model.Interface.Rest.ContentyType), row["CONTENTTYPE"].ToString());
                    }

                    //ent.ParametrosRest = ConsultarParametros(ent.Id);
                    ent.CabecalhosHttpRest= ConsultarParametrosCabecalho(ent.Id);

                    lst.Add(ent);
                }

                return lst;
            }
            public List<Model.Interface.Rest.ParametroRest> ConsultarParametros(int interfaceID)
            {
                List<IDbDataParameter> lst = new List<IDbDataParameter>();
                lst.Add((IDbDataParameter)database.CreateParameter("p_interfaceID", interfaceID));
                return PreencherParametrosRest(new Selia.Integrador.Utils.SQLHelper(true, "SP_INT_SEL_PARAMETROSREST", lst).DataTable());
            }
            public List<Model.Interface.Rest.ParametroRest> PreencherParametrosRest(DataTable dt)
            {
                var lst = new List<Model.Interface.Rest.ParametroRest>();

                foreach (DataRow row in dt.Rows)
                {
                    var ent = new Model.Interface.Rest.ParametroRest();

                    if (row["ID"] != DBNull.Value)
                        ent.Id = Convert.ToInt32(row["ID"].ToString());

                    if (row["INTERFACERESTID"] != DBNull.Value)
                        ent.InterfaceRestId = Convert.ToInt32(row["INTERFACERESTID"].ToString());

                    if (row["DE"] != DBNull.Value)
                        ent.De = row["DE"].ToString();

                    if (row["PARA"] != DBNull.Value)
                        ent.Para = row["PARA"].ToString();

                    if (row["bitXML"] != DBNull.Value)
                        ent.isXML = row["bitXML"].ToString() == "1";

                    if (row["bitQueryString"] != DBNull.Value)
                        ent.isQueryString = row["bitQueryString"].ToString() == "1";

                    lst.Add(ent);
                }

                return lst;
            }
            public List<Model.Interface.Rest.CabecalhoHttpRest> ConsultarParametrosCabecalho(int interfaceID)
            {
                List<IDbDataParameter> lst = new List<IDbDataParameter>();
                lst.Add((IDbDataParameter)database.CreateParameter("p_interfaceID", interfaceID));
                return PreencherParametrosCabecalhoRest(new Selia.Integrador.Utils.SQLHelper(true, "SP_INT_SEL_CABECALHOSREST", lst).DataTable());
            }
            public List<Model.Interface.Rest.CabecalhoHttpRest> PreencherParametrosCabecalhoRest(DataTable dt)
            {
                var lst = new List<Model.Interface.Rest.CabecalhoHttpRest>();

                foreach (DataRow row in dt.Rows)
                {
                    var ent = new Model.Interface.Rest.CabecalhoHttpRest();

                    if (row["ID"] != DBNull.Value)
                        ent.Id = Convert.ToInt32(row["ID"].ToString());

                    if (row["INTERFACERESTID"] != DBNull.Value)
                        ent.InterfaceRestId = Convert.ToInt32(row["INTERFACERESTID"].ToString());

                    if (row["NOME"] != DBNull.Value)
                        ent.Nome = row["NOME"].ToString();

                    if (row["VALOR"] != DBNull.Value)
                        ent.Valor = row["VALOR"].ToString();

                    lst.Add(ent);
                }

                return lst;
            }
        }
    }
}
