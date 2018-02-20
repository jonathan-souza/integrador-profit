using BS;
using Selia.Integrador.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selia.Integrador
{
    public partial class Service : ServiceBase
    {
        private int ThreadSleepMilliseconds
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["ThreadSleepMilliseconds"]);
            }
        }

        private int ThreadMaxCount
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["ThreadMaxCount"]);
            }
        }

        private int CurrentThreadCount { get; set; }
        private bool Executar { get; set; }
        private List<int> Integracoes { get; set; }
        private Integracao IntegracaoService { get; set; }
        public Service()
        {
            InitializeComponent();
            CurrentThreadCount = 0;
            IntegracaoService = new Integracao();
            Integracoes = new List<int>();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                Integracoes = ConsultarIdsParaExecucao();

                ServicePointManager.Expect100Continue = false;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                ConnectionMonitor.Monitor.Instance.Start();
            }
            catch (Exception ex)
            {
                ////ServiceLog.LogError(ex.ToString());
            }

            Task.Run(() =>
            {
                IniciarLoopExecucao();
            });
        }

        public void IniciarLoopExecucao()
        {
            try
            {
#if DEBUG
                Integracoes = ConsultarIdsParaExecucao();
#endif
                Executar = true;
                IntegracaoService.PrepararEmUsoInicial();
            }
            catch (Exception e)
            {
                //ServiceLog.LogError("Erro preparando integrações para iniciar >>> \r\n" + e.ToString());
                throw new Exception("Erro preparando integrações para iniciar", e);
            }

            if (Integracoes == null || Integracoes.Count == 0)
            {
                //ServiceLog.LogError("Lista de integrações está vazia");
                throw new Exception("Lista de integrações está vazia");
            }

            while (Executar)
            {
                foreach (var integracaoId in Integracoes)
                {
                    if (CurrentThreadCount < ThreadMaxCount)
                    {
                        CurrentThreadCount++;

                        Task.Run(() =>
                        {
                            try
                            {
                                IntegracaoService.Executar(integracaoId);
                            }
                            finally
                            {
                                CurrentThreadCount--;
                            }
                        });

                        Thread.Sleep(ThreadSleepMilliseconds);
                    }
                }
            }
        }

        protected override void OnPause()
        {
            base.OnPause();
            this.Executar = false;
        }

        protected override void OnContinue()
        {
            base.OnContinue();
            IniciarLoopExecucao();
        }

        protected override void OnStop()
        {
            Executar = false;
        }

        private List<int> ConsultarIdsParaExecucao()
        {
            return ConsultarIdsParaExecucao(null);
        }

        private List<int> ConsultarIdsParaExecucao(bool? consumidor)
        {
            return new Selia.Integrador.DAL.Integracao().ConsultarIdsParaExecucao(consumidor);
        }
    }
}
