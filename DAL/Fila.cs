using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Selia.Integrador.Utils;
using Selia.Integrador.Utils.Core;

namespace Selia.Integrador.DAL
{
    public class Fila : DataWorker
    {
        public List<Model.Fila> Consultar(int IntegracaoID)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_destinoID", IntegracaoID));
            return Preencher(new SQLHelper(true, "SP_INT_SEL_Fila", lst).DataTable());
        }

        public List<Model.Fila> ConsultarByStatus(int IntegracaoID, int status)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_destinoID", IntegracaoID));
            lst.Add((IDbDataParameter)database.CreateParameter("p_statusID", status));
            return Preencher(new SQLHelper(true, "SP_INT_SEL_FilaByStatusID", lst).DataTable());
        }

        public List<Model.Fila> ConsultarByChavePrimaria(int IntegracaoID, string chavePrimaria, string secondaryKey)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_destinoID", IntegracaoID));
            lst.Add((IDbDataParameter)database.CreateParameter("p_chavePrimaria", chavePrimaria));
            if (secondaryKey != null)
                lst.Add((IDbDataParameter)database.CreateParameter("p_chaveSecundaria", secondaryKey));
            return Preencher(new SQLHelper(true, "SP_INT_SEL_FilaByChavePrimaria", lst).DataTable());
        }

        public bool AtualizarStatusParaSucesso(int FilaID)
        {
            return AtualizarStatus(1, FilaID) > -1;
        }

        public int Excluir(int FilaID)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_filaID", FilaID));
            return new SQLHelper(false, "SP_INT_DEL_FilaID", lst).NonQuery();
        }
        public int AtualizarStatus(int StatusID, int FilaID)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_statusID", StatusID));
            lst.Add((IDbDataParameter)database.CreateParameter("p_filaID", FilaID));
            return new SQLHelper(false, "SP_INT_UP_FilaByStatusID", lst).NonQuery();

        }

        public int AtualizarDestino(int DestinoID, int FilaID)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_destinoID", DestinoID));
            lst.Add((IDbDataParameter)database.CreateParameter("p_filaID", FilaID));
            return new SQLHelper(false, "SP_INT_UP_FILABYDESTINOID", lst).NonQuery();

        }

        public int Inserir(Model.Fila fila)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_integracaoID", fila.Integracao.ID));
            lst.Add((IDbDataParameter)database.CreateParameter("p_dataCriacao", DateTime.Now));
            lst.Add((IDbDataParameter)database.CreateParameter("p_conteudo", fila.Conteudo));
            lst.Add((IDbDataParameter)database.CreateParameter("p_chavePrimaria", fila.ChavePrimaria));
            lst.Add((IDbDataParameter)database.CreateParameter("p_chaveSecundaria", fila.ChaveSecundaria));
            lst.Add((IDbDataParameter)database.CreateParameter("p_statusID", (int)fila.Status));
            lst.Add((IDbDataParameter)database.CreateParameter("p_logIntegracaoID", (int)fila.LogIntegracaoID));
            lst.Add((IDbDataParameter)database.CreateParameter("p_destinoID", (int)fila.IntegracaoDestino.ID));
            SQLHelper SQL = new SQLHelper(false, "SP_INT_INS_Fila", lst);
            return SQL.NonQuery();
        }
        public List<Model.Fila> Preencher(DataTable dt)
        {
            List<Model.Fila> lst = new List<Model.Fila>();
            foreach (DataRow row in dt.Rows)
            {
                Model.Fila ent = new Model.Fila();

                if (row["ID"] != DBNull.Value)
                {
                    ent.ID = Convert.ToInt32(row["ID"].ToString());
                }
                if (row["ChavePrimaria"] != DBNull.Value)
                {
                    ent.ChavePrimaria = row["ChavePrimaria"].ToString();
                }
                if (row["ChaveSecundaria"] != DBNull.Value)
                {
                    ent.ChaveSecundaria = row["ChaveSecundaria"].ToString();
                }
                if (row["Conteudo"] != DBNull.Value)
                {
                    ent.Conteudo = row["Conteudo"].ToString();
                }
                if (row["DataCriacao"] != DBNull.Value)
                {
                    ent.DataCriacao = Convert.ToDateTime(row["DataCriacao"].ToString());
                }
                if (row["StatusID"] != DBNull.Value)
                {
                    if ((int)Model.Fila.TipoStatus.Erro == Convert.ToInt32(row["StatusID"].ToString()))
                    {
                        ent.Status = Model.Fila.TipoStatus.Erro;
                    }
                    else if ((int)Model.Fila.TipoStatus.Sucesso == Convert.ToInt32(row["StatusID"].ToString()))
                    {
                        ent.Status = Model.Fila.TipoStatus.Sucesso;
                    }
                }
                if (row["LogIntegracaoID"] != DBNull.Value)
                {
                    ent.LogIntegracaoID = Convert.ToInt32(row["LogIntegracaoID"].ToString());
                }
                if (row["DestinoID"] != DBNull.Value)
                {
                    ent.IntegracaoDestino.ID = Convert.ToInt32(row["DestinoID"].ToString());
                }

                lst.Add(ent);
            }
            return lst;
        }


        public int AlterarFila(int idFila, int idDestino)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_idFila", idFila));
            lst.Add((IDbDataParameter)database.CreateParameter("p_idIntegracao", idDestino));
            return new SQLHelper(false, "SP_BSELLER_ALTERAR_FILA_INSERIR_PRODUTO_MILLENIUM", lst).NonQuery();

        }
    }
}
