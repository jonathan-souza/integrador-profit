using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Selia.Integrador.Utils;

namespace BS
{
    public class Integracao
    {
        public void Executar(int integracaoId)
        {
            Executar(integracaoId, false);
        }

        private static Object lockObject = new Object();
        public void Executar(int integracaoId, bool ignoreTime)
        {
            Model.Integracao ent = null;
            lock (lockObject)
            {
                ent = ConsultarUnicaIntegracaoParaExecucao(integracaoId);
                System.Threading.Thread.Sleep(50);
            }

            if (ent != null)
            {
                if (ignoreTime || ExecucaoNoHorario(ent))
                {
                    //ServiceLog.LogInfo(String.Format("Iniciando: {0}", ent.Nome));

                    try
                    {
                        if (ent.Interface.Item.GetType() == typeof(Model.Interface.ArquivoTexto))
                        {
                            new Interface.ArquivoText().Executar(ent);
                        }
                        else if (ent.Interface.Item.GetType() == typeof(Model.Interface.WebService))
                        {
                            new Interface.WebService().Executar(ent);
                        }
                        else if (ent.Interface.Item.GetType() == typeof(Model.Interface.DB))
                        {
                            new Interface.DB().Executar(ent);
                        }
                        else if (ent.Interface.Item.GetType() == typeof(Model.Interface.Rest))
                        {
                            new Interface.Rest().Executar(ent);
                        }
                    }
                    catch (Exception ex)
                    {
                        //ServiceLog.LogError(String.Format("Erro: {0} - Message: {1}", ent.Nome, ex.ToString()));
                    }

                    ent.DataHoraUltimaExecucao = DateTime.Now;
                    AtualizarHorarioDeExecucao(ent);
                    //ServiceLog.LogInfo(String.Format("Finalizando: {0}", ent.Nome));
                }
                this.EmUso(integracaoId, false);
            }
        }

        public List<Model.Integracao> ConsultarIntegracaoSimples()
        {
            List<Model.Integracao> lst = new Selia.Integrador.DAL.Integracao().ConsultarIntegracaoSimples();
            //List<Model.Integracao> lstFiltrado = lst.Where(c => c.LogIntegracao==null ? false : c.LogIntegracao.Count(d => d.LogFila.Count > 0) > 0).ToList();
            return lst;
        }

        public bool ExecucaoNoHorario(Model.Integracao integracao)
        {
            bool Retorno = false;
            if (integracao.ExecucaoMinutos > 0)
            {
                //ServiceLog.LogWarning(String.Format("{0} - Execução minutos:{1}. {2}", integracao.Nome, integracao.ExecucaoMinutos, DateTime.Now.ToString()));

                if (integracao.DataHoraUltimaExecucao == null || integracao.DataHoraUltimaExecucao.AddMinutes(Convert.ToDouble(integracao.ExecucaoMinutos)) < DateTime.Now)
                {
                    Retorno = true;
                }
            }
            else if (integracao.ExecucaoHorarios != null)
            {
                string[] horarios = integracao.ExecucaoHorarios.Split(Char.Parse(";"));

                //ServiceLog.LogWarning(String.Format("{0} - Execução horários:{1}. {2}", integracao.Nome, integracao.ExecucaoHorarios, DateTime.Now.ToString()));

                foreach (string item in horarios)
                {
                    if (!string.IsNullOrEmpty(item.Trim()))
                    {
                        string[] horario = item.Split(char.Parse(":"));
                        int hora = int.Parse(horario[0]);
                        int minutos = 00;

                        if (horario.Length > 1)
                        {
                            minutos = int.Parse(horario[1]);
                        }

                        DateTime dtaExecucao = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + hora + ":" + minutos);

                        //ServiceLog.LogWarning(String.Format("{0} - Data Execução:{1}. {2}. Data última execução:{3}", integracao.Nome, dtaExecucao, DateTime.Now.ToString(), integracao.DataHoraUltimaExecucao.ToString()));

                        if ((integracao.DataHoraUltimaExecucao <= dtaExecucao) && (DateTime.Now >= dtaExecucao))
                        {
                            //ServiceLog.LogWarning(String.Format("{0} - Dentro do IF - Data Execução:{1}. {2}. Data última execução:{3}", integracao.Nome, dtaExecucao, DateTime.Now.ToString(), integracao.DataHoraUltimaExecucao.ToString()));

                            Retorno = true;
                        }

                        if (Retorno)
                        {
                            break;
                        }
                    }
                }
            }
            return Retorno;
        }

        public List<Model.Integracao> ConsultarIntegracaoParaExecucao(bool consumidor)
        {
            return new Selia.Integrador.DAL.Integracao().ConsultarIntegracaoParaExecucao(consumidor);
        }

        public Model.Integracao ConsultarIntegracaoPorID(int entID)
        {
            return new Selia.Integrador.DAL.Integracao().ConsultarIntegracaoID(entID);
        }

        public List<int> ConsultarIdsParaExecucao(bool consumidor)
        {
            return new Selia.Integrador.DAL.Integracao().ConsultarIdsParaExecucao(consumidor);
        }

        public Model.Integracao ConsultarUnicaIntegracaoParaExecucao(int entID)
        {
            return new Selia.Integrador.DAL.Integracao().ConsultarUnicaIntegracaoParaExecucao(entID);
        }

        public int AtualizarHorarioDeExecucao(Model.Integracao entIntegracao)
        {
            return new Selia.Integrador.DAL.Integracao().AtualizarHorarioDeExecucao(entIntegracao);
        }

        public bool EmUso(int IntegracaoID, bool Tipo)
        {
            return new Selia.Integrador.DAL.Integracao().EmUso(IntegracaoID, Tipo) > 0;
        }

        public void PrepararEmUsoInicial()
        {
            new Selia.Integrador.DAL.Integracao().PrepararEmUsoInicial();
        }
    }
}
