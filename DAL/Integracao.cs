using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Selia.Integrador.Utils;
using Selia.Integrador.Utils.Core;

namespace Selia.Integrador.DAL
{
    public class Integracao : DataWorker
    {
        public List<Model.Integracao> ConsultarIntegracaoParaExecucao(bool consumidor)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_consumidor", Convert.ToInt32(consumidor)));
            return Preencher(new SQLHelper(true, "SP_INT_SEL_IntegracaoExecucao", lst).DataTable());
        }
        public Model.Integracao ConsultarIntegracaoID(int IntegracaoID)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_integracaoID", IntegracaoID));
            return Preencher(new SQLHelper(true, "SP_INT_SEL_IntegracaoByID", lst).DataTable())[0];
        }
        public int AtualizarHorarioDeExecucao(Model.Integracao entIntegracao)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_integracaoID", entIntegracao.ID));
            lst.Add((IDbDataParameter)database.CreateParameter("p_hora", entIntegracao.DataHoraUltimaExecucao));
            return new SQLHelper(false, "SP_INT_UP_HORABYINTEGRACAOID", lst).NonQuery();
        }

        public int EmUso(int IntegracaoID, bool Tipo)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_EmUso", Convert.ToInt32(Tipo)));
            lst.Add((IDbDataParameter)database.CreateParameter("p_integracaoID", IntegracaoID));
            return new SQLHelper(false, "SP_INT_UP_EmUsoByIntegracaoID", lst).NonQuery();
        }
        public List<Model.Integracao> ConsultarIntegracaoSimples()
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            List<Model.Integracao> lstIntegracao = PreencherSimples(new SQLHelper(true, "SP_INT_SEL_Integracao", lst).DataTable());
            return lstIntegracao;
        }
        public Model.Integracao ConsultarIntegracaoSimples(int IntegracaoID)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_integracaoID", IntegracaoID));
            return PreencherSimples(new SQLHelper(true, "SP_INT_SEL_IntegracaoByID", lst).DataTable())[0];
        }
        public List<Model.Integracao> PreencherSimples(DataTable dt)
        {
            List<Model.Integracao> lst = new List<Model.Integracao>();
            foreach (DataRow row in dt.Rows)
            {
                Model.Integracao ent = new Model.Integracao();

                if (row["ID"] != DBNull.Value)
                {
                    ent.ID = Convert.ToInt32(row["ID"].ToString());
                }
                if (row["AdapterID"] != DBNull.Value)
                {
                    ent.Adapter = new Model.Adapter();
                    ent.Adapter.ID = Convert.ToInt32(row["AdapterID"].ToString());
                }
                if (row["DataHoraUltimaExecucao"] != DBNull.Value)
                {
                    ent.DataHoraUltimaExecucao = Convert.ToDateTime(row["DataHoraUltimaExecucao"].ToString());
                }
                if (row["EmUso"] != DBNull.Value)
                {
                    ent.EmUso = row["EmUso"].ToString() == "0" ? false : true;
                }
                if (row["ExecucaoHorarios"] != DBNull.Value)
                {
                    ent.ExecucaoHorarios = row["ExecucaoHorarios"].ToString();
                }
                if (row["ExecucaoMinutos"] != DBNull.Value)
                {
                    ent.ExecucaoMinutos = Convert.ToInt32(row["ExecucaoMinutos"]);
                }


                if (row["Nome"] != DBNull.Value)
                {
                    ent.Nome = row["Nome"].ToString();
                }

                if (row["ElementoRegistro"] != DBNull.Value)
                {
                    ent.ElementoRegistro = row["ElementoRegistro"].ToString();
                }

                if (row["PKPrimaria"] != DBNull.Value)
                {
                    ent.PKPrimaria = row["PKPrimaria"].ToString();
                }
                if (row["PKSecundaria"] != DBNull.Value)
                {
                    ent.PKSecundaria = row["PKSecundaria"].ToString();
                }
                if (row["Status"] != DBNull.Value)
                {
                    ent.Status = row["Status"].ToString() == "0" ? false : true;
                }
                if (row["AcaoInicial"] != DBNull.Value)
                {
                    ent.AcaoInicial = row["AcaoInicial"].ToString();
                }

                if (row["AcaoFinal"] != DBNull.Value)
                {
                    ent.AcaoFinal = row["AcaoFinal"].ToString();
                }

                if (row["AcaoEnfileiramento"] != DBNull.Value)
                {
                    ent.AcaoEnfileiramento = row["AcaoEnfileiramento"].ToString();
                }

                if (row["DestinoID"] != DBNull.Value)
                {
                    ent.DestinoID = Convert.ToInt32(row["DestinoID"].ToString());
                    ent.Destino = new Model.Integracao();
                    ent.Destino = new Selia.Integrador.DAL.Integracao().ConsultarIntegracaoSimples(Convert.ToInt32(row["DestinoID"]));
                    ent.Destino.LogIntegracao = new Selia.Integrador.DAL.LogIntegracao().ConsultarSimples(ent.ID).Where(c => c.Status == 1).ToList();
                    ent.Destino.QtdErros = new Selia.Integrador.DAL.LogFila().ConsultarQtdErros(ent.ID);
                    ent.Destino.PaiID = ent.ID;

                }
                else
                {
                    ent.Destino = new Model.Integracao();
                    var LogIntegracoes = new Selia.Integrador.DAL.LogIntegracao().ConsultarSimples(ent.ID).Where(c => c.Status == 1);
                    if (LogIntegracoes.ToList().Count > 0)
                    {
                        ent.Destino.LogIntegracao = LogIntegracoes.ToList();
                    }
                    ent.Destino.QtdErros = new Selia.Integrador.DAL.LogFila().ConsultarQtdErros(ent.ID);
                    ent.Destino.PaiID = ent.ID;
                }
                if (row["Consumidor"] != DBNull.Value)
                {
                    ent.Consumidor = row["Consumidor"].ToString() == "0" ? false : true;
                }


                if (ent.LogIntegracao == null)
                {
                    ent.LogIntegracao = new List<Model.LogIntegracao>();
                }
                if (ent.LogFila == null)
                {
                    ent.LogFila = new List<Model.LogFila>();
                }

                lst.Add(ent);
            }
            return lst;
        }
        public List<Model.Integracao> Preencher(DataTable dt)
        {
            List<Model.Integracao> lst = new List<Model.Integracao>();
            foreach (DataRow row in dt.Rows)
            {
                Model.Integracao ent = new Model.Integracao();

                if (row["ID"] != DBNull.Value)
                {
                    ent.ID = Convert.ToInt32(row["ID"].ToString());
                }
                if (row["AdapterID"] != DBNull.Value)
                {
                    ent.Adapter = new Model.Adapter();
                    ent.Adapter.ID = Convert.ToInt32(row["AdapterID"].ToString());
                }
                if (row["DataHoraUltimaExecucao"] != DBNull.Value)
                {
                    ent.DataHoraUltimaExecucao = Convert.ToDateTime(row["DataHoraUltimaExecucao"].ToString());
                }
                if (row["EmUso"] != DBNull.Value)
                {
                    ent.EmUso = row["EmUso"].ToString() == "0" ? false : true;
                }
                if (row["ExecucaoHorarios"] != DBNull.Value)
                {
                    ent.ExecucaoHorarios = row["ExecucaoHorarios"].ToString();
                }
                if (row["ExecucaoMinutos"] != DBNull.Value)
                {
                    ent.ExecucaoMinutos = Convert.ToInt32(row["ExecucaoMinutos"]);
                }

                //consultar no objeto para não alterar a procedure, menos impacto
                var mapeamento = new Selia.Integrador.DAL.Mapeamento().Consultar(ent.ID);

                ent.Mapeamento = mapeamento.Where(w => w.BitMapRetorno == false && w.BitQueryString==false).ToList();

                ent.MapeamentoQueryString = mapeamento.Where(w => w.BitMapRetorno == false && w.BitQueryString == true).ToList();

                ent.MapeamentoRetorno = mapeamento.Where(w => w.BitMapRetorno == true).ToList();

                if (row["InterfaceID"] != DBNull.Value)
                {
                    ent.Interface = new Model.Interface();
                    if (ent.Adapter.Tipo == Model.Adapter.TipoAdapter.DB)
                    {
                        ent.Interface.Item = new Selia.Integrador.DAL.Interface.DB().Consultar(Convert.ToInt32(row["InterfaceID"].ToString()));
                    }
                    else if (ent.Adapter.Tipo == Model.Adapter.TipoAdapter.ArquivoTexto)
                    {
                        ent.Interface.Item = new Selia.Integrador.DAL.Interface.ArquivoTexto().Consultar(Convert.ToInt32(row["InterfaceID"].ToString()));
                    }
                    else if (ent.Adapter.Tipo == Model.Adapter.TipoAdapter.WebService)
                    {
                        ent.Interface.Item = new Selia.Integrador.DAL.Interface.WebService().Consultar(Convert.ToInt32(row["InterfaceID"].ToString()));
                    }
                    else if (ent.Adapter.Tipo == Model.Adapter.TipoAdapter.Rest)
                    {
                        ent.Interface.Item = new Selia.Integrador.DAL.Interface.Rest().Consultar(Convert.ToInt32(row["InterfaceID"].ToString()));
                    }
                }

                
                if (row["Nome"] != DBNull.Value)
                {
                    ent.Nome = row["Nome"].ToString();
                }

                if (row["ElementoRegistro"] != DBNull.Value)
                {
                    ent.ElementoRegistro = row["ElementoRegistro"].ToString();
                }

                if (row["PKPrimaria"] != DBNull.Value)
                {
                    ent.PKPrimaria = row["PKPrimaria"].ToString();
                }
                if (row["PKSecundaria"] != DBNull.Value)
                {
                    ent.PKSecundaria = row["PKSecundaria"].ToString();
                }
                if (row["Status"] != DBNull.Value)
                {
                    ent.Status = row["Status"].ToString() == "0" ? false : true;
                }
                if (row["AcaoInicial"] != DBNull.Value)
                {
                    ent.AcaoInicial = row["AcaoInicial"].ToString();
                }

                if (row["AcaoFinal"] != DBNull.Value)
                {
                    ent.AcaoFinal = row["AcaoFinal"].ToString();
                }

                if (row["AcaoEnfileiramento"] != DBNull.Value)
                {
                    ent.AcaoEnfileiramento = row["AcaoEnfileiramento"].ToString();
                }

                if (row["ACAOCABECALHO"] != DBNull.Value)
                {
                    ent.AcaoCabecalho = row["ACAOCABECALHO"].ToString();
                }

                if (row["ACAORETURNOERRO"] != DBNull.Value)
                {
                    ent.AcaoReturnoErro = row["ACAORETURNOERRO"].ToString();
                }

                if (row["DestinoID"] != DBNull.Value)
                {
                    ent.DestinoID = Convert.ToInt32(row["DestinoID"].ToString());
                    ent.Destino = new Model.Integracao();
                    ent.Destino = new Selia.Integrador.DAL.Integracao().ConsultarIntegracaoID(Convert.ToInt32(row["DestinoID"]));
                    //ent.Destino.LogIntegracao = new Selia.Integrador.DAL.LogIntegracao().Consultar(ent.ID);
                }
                if (row["Consumidor"] != DBNull.Value)
                {
                    ent.Consumidor = row["Consumidor"].ToString() == "0" ? false : true;
                }

                if (row["NODESNAOUTILIZADOS"] != DBNull.Value)
                {
                    ent.NodesNaoUtilizados = row["NODESNAOUTILIZADOS"].ToString();
                }

                if (row["NivelParalelismo"] != DBNull.Value)
                {
                    ent.NivelParalelismo = Convert.ToInt32(row["NivelParalelismo"]);
                }
                else
                {
                    ent.NivelParalelismo = 1;
                }

                if (ent.Adapter.Tipo == Model.Adapter.TipoAdapter.DB)
                {
                    ent.ConnectionString = ((Model.Interface.DB)ent.Interface.Item).ConnectionString;
                }

                if (ent.LogIntegracao == null)
                {
                    ent.LogIntegracao = new List<Model.LogIntegracao>();
                }
                ent.Fila = new Selia.Integrador.DAL.Fila().ConsultarByStatus(ent.ID, 1);

                lst.Add(ent);
            }

            return lst;
        }

        public Model.Integracao ConsultarUnicaIntegracaoParaExecucao(int entID)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();
            lst.Add((IDbDataParameter)database.CreateParameter("p_integracaoID", entID));
            var integracao = Preencher(new SQLHelper(true, "SP_INT_SEL_IntegracaoParaExecutar", lst).DataTable());
            return (integracao.Count > 0) ? integracao[0] : null;
        }

        public void PrepararEmUsoInicial()
        {
            new SQLHelper(false, "SP_INT_UPD_ZerarFlagsEmUso", new List<IDbDataParameter>()).NonQuery();
        }

        public List<int> ConsultarIdsParaExecucao(bool? consumidor)
        {
            List<IDbDataParameter> lst = new List<IDbDataParameter>();

            if (consumidor.HasValue)
                lst.Add((IDbDataParameter)database.CreateParameter("p_consumidor", Convert.ToInt32(consumidor)));
            else
                lst.Add((IDbDataParameter)database.CreateParameter("p_consumidor", DBNull.Value));

            List<int> ids = new List<int>();
            foreach (DataRow row in new SQLHelper(true, "SP_INT_SEL_IntegracaoExecucaoIDS", lst).DataTable().Rows)
                ids.Add(int.Parse(row["id"].ToString()));

            return ids;
        }
    }
}
