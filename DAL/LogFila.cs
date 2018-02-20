using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Selia.Integrador.Utils;
using Selia.Integrador.Utils.Core;

namespace Selia.Integrador.DAL
{
    public class LogFila : DataWorker
    {
        public List<Model.LogFila> Consultar(int IntegracaoID)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_IntegracaoID", IntegracaoID));
            return Preencher(new SQLHelper(true, "SP_INT_SEL_LogFila", lst).DataTable());
        }
        public int ConsultarQtdErros(int IntegracaoID)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_IntegracaoID", IntegracaoID));
            var dtRetorno = new SQLHelper(true, "SP_INT_SEL_QtdErros", lst).DataTable();
            
            var retorno = 0;

            if (dtRetorno.Rows.Count > 0 && !string.IsNullOrEmpty(dtRetorno.Rows[0][0].ToString()))
                retorno = dtRetorno.Rows.Count;

            return retorno;
        }
        public int Inserir(Model.LogFila entLogFila)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_logIntegracaoID", entLogFila.LogIntegracao.ID));
            lst.Add((IDbDataParameter)database.CreateParameter("p_dataCriacao", DateTime.Now));
            lst.Add((IDbDataParameter)database.CreateParameter("p_conteudo", entLogFila.Conteudo));
            lst.Add((IDbDataParameter)database.CreateParameter("p_conteudofila", entLogFila.ConteudoFila));
            lst.Add((IDbDataParameter)database.CreateParameter("p_chavePrimaria", entLogFila.ChavePrimaria));
            lst.Add((IDbDataParameter)database.CreateParameter("p_chaveSecundaria", entLogFila.ChaveSecundaria));
            lst.Add((IDbDataParameter)database.CreateParameter("p_conteudoRetorno", entLogFila.ConteudoRetorno));
            lst.Add((IDbDataParameter)database.CreateParameter("p_conteudoRetornoSemTratamento", entLogFila.RespostaSemTratamento));
            lst.Add((IDbDataParameter)database.CreateParameter("p_integracaoID", entLogFila.IntegracaoID));
            lst.Add((IDbDataParameter)database.CreateParameter("p_FilaID", entLogFila.FilaID));

            return new SQLHelper(false, "SP_INT_INS_LogFila", lst).NonQuery();
        }
        public List<Model.LogFila> Preencher(DataTable dt)
        {
            List<Model.LogFila> lst = new List<Model.LogFila>();
            foreach (DataRow row in dt.Rows)
            {
                Model.LogFila ent = new Model.LogFila();

                if (row["ID"] != DBNull.Value)
                {
                    ent.ID = Convert.ToInt32(row["ID"].ToString());
                }
                if (row["Conteudo"] != DBNull.Value)
                {
                    ent.Conteudo = row["Conteudo"].ToString();
                }
                if (row["ConteudoFila"] != DBNull.Value)
                {
                    ent.ConteudoFila = row["ConteudoFila"].ToString();
                }
                if (row["DataCriacao"] != DBNull.Value)
                {
                    ent.DataCriacao = Convert.ToDateTime(row["DataCriacao"]);
                }
                if (row["ChavePrimaria"] != DBNull.Value)
                {
                    ent.ChavePrimaria = row["ChavePrimaria"].ToString();
                }
                if (row["ChaveSecundaria"] != DBNull.Value)
                {
                    ent.ChaveSecundaria = row["ChaveSecundaria"].ToString();
                }
                if (row["LogIntegracaoID"] != DBNull.Value)
                {
                    ent.LogIntegracao.ID = Convert.ToInt32(row["LogIntegracaoID"].ToString());
                }
                if (row["ConteudoRetorno"] != DBNull.Value)
                {
                    ent.ConteudoRetorno = row["ConteudoRetorno"].ToString();
                }
                if (row["FilaID"] != DBNull.Value)
                {
                    ent.FilaID = Convert.ToInt32(row["FilaID"].ToString());
                }

                lst.Add(ent);
            }
            
            var agrupado = from lista in lst
                           group lista by new
                           {
                               Conteudo = lista.Conteudo,
                               ChavePrimaria = lista.ChavePrimaria,
                               ChaveSecundaria = lista.ChaveSecundaria,
                               ConteudoRetorno = lista.ConteudoRetorno,
                               ConteudoFila = lista.ConteudoFila,
                               FilaID = lista.FilaID
                           }
                               into resultado
                               select new
                               {
                                   resultado.Key.ChavePrimaria,
                                   resultado.Key.ChaveSecundaria,
                                   resultado.Key.Conteudo,
                                   resultado.Key.ConteudoFila,
                                   resultado.Key.ConteudoRetorno,
                                   resultado.Key.FilaID,
                                   ID = resultado.Max(a => a.ID),
                                   DataCriacao = resultado.Max(b => b.DataCriacao)
                               };

            lst = new List<Model.LogFila>();

            foreach (var item in agrupado.ToList())
            {
                lst.Add(new Model.LogFila
                {
                    ChavePrimaria = item.ChavePrimaria,
                    ChaveSecundaria = item.ChaveSecundaria,
                    Conteudo = item.Conteudo,
                    ConteudoFila = item.ConteudoFila,
                    ConteudoRetorno = item.ConteudoRetorno,
                    DataCriacao = item.DataCriacao,
                    FilaID = item.FilaID,
                    ID = item.ID
                });
            }

            return lst;
        }
    }
}