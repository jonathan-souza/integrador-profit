using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Selia.Integrador.Utils;
using Selia.Integrador.Utils.Core;

namespace Selia.Integrador.DAL
{
    public class LogIntegracao : DataWorker
    {
        public List<Model.LogIntegracao> ConsultaQtdMaiorZero(int IntegracaoID)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_IntegracaoID", IntegracaoID));
            return Preencher(new SQLHelper(true, "SP_INT_SEL_LogIntegracaoQtd", lst).DataTable());
        }
        public List<Model.LogIntegracao> Consultar(int IntegracaoID)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_IntegracaoID", IntegracaoID));
            return Preencher(new SQLHelper(true, "SP_INT_SEL_LogIntegracao", lst).DataTable());
        }
        public List<Model.LogIntegracao> ConsultarSimples(int IntegracaoID)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_IntegracaoID", IntegracaoID));
            return PreencherSimples(new SQLHelper(true, "SP_INT_SEL_LogIntegracao", lst).DataTable());
        }
        public int Inserir(Model.LogIntegracao entLogIntegracao)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_integracaoID", entLogIntegracao.Integracao.ID));
            lst.Add((IDbDataParameter)database.CreateParameter("p_quantidadeRegistros", entLogIntegracao.QtdRegistros));
            lst.Add((IDbDataParameter)database.CreateParameter("p_conteudo", entLogIntegracao.Conteudo));
            lst.Add((IDbDataParameter)database.CreateParameter("p_dataCriacao", DateTime.Now));
            lst.Add((IDbDataParameter)database.CreateParameter("p_status", entLogIntegracao.Status));
            DataTable dt = new SQLHelper(true, "SP_INT_INS_LogIntegracao", lst).DataTable();
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        public List<Model.LogIntegracao> PreencherSimples(DataTable dt)
        {
            List<Model.LogIntegracao> lst = new List<Model.LogIntegracao>();
            foreach (DataRow row in dt.Rows)
            {
                Model.LogIntegracao ent = new Model.LogIntegracao();

                if (row["ID"] != DBNull.Value)
                {
                    ent.ID = Convert.ToInt32(row["ID"]);
                }
                if (row["Conteudo"] != DBNull.Value)
                {
                    ent.Conteudo = row["Conteudo"].ToString();
                }
                if (row["DataCriacao"] != DBNull.Value)
                {
                    ent.DataCriacao = Convert.ToDateTime(row["DataCriacao"].ToString());
                }
                if (row["IntegracaoID"] != DBNull.Value)
                {
                    ent.Integracao = new Model.Integracao();
                    ent.Integracao.ID = Convert.ToInt32(row["IntegracaoID"].ToString());
                }
                if (row["QtdRegistros"] != DBNull.Value)
                {
                    ent.QtdRegistros = Convert.ToInt32(row["QtdRegistros"].ToString());
                }

                lst.Add(ent);
            }
            return lst;
        }
        public List<Model.LogIntegracao> Preencher(DataTable dt)
        {
            List<Model.LogIntegracao> lst = new List<Model.LogIntegracao>();
            foreach (DataRow row in dt.Rows)
            {
                Model.LogIntegracao ent = new Model.LogIntegracao();

                if (row["ID"] != DBNull.Value)
                {
                    ent.ID = Convert.ToInt32(row["ID"]);
                }
                if (row["Conteudo"] != DBNull.Value)
                {
                    ent.Conteudo = row["Conteudo"].ToString();
                }
                if (row["DataCriacao"] != DBNull.Value)
                {
                    ent.DataCriacao = Convert.ToDateTime(row["DataCriacao"].ToString());
                }
                if (row["IntegracaoID"] != DBNull.Value)
                {
                    ent.Integracao = new Model.Integracao();
                    ent.Integracao.ID = Convert.ToInt32(row["IntegracaoID"].ToString());
                }
                if (row["QtdRegistros"] != DBNull.Value)
                {
                    ent.QtdRegistros = Convert.ToInt32(row["QtdRegistros"].ToString());
                }
                ent.LogFila = new Selia.Integrador.DAL.LogFila().Consultar(ent.Integracao.ID);

                lst.Add(ent);
            }
            return lst;
        }
    }
}
