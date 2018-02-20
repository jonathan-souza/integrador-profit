using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using BS;
using FC.Integrador.Utils;
using ConnectionMonitor;
namespace Executor
{
    public partial class ExecutorSantaHelena : ServiceBase
    {
        private bool EmExecucao { get; set; }

        private Double ServicoTempo
        {
            get { return Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["WSExecutorTimer"]) * 1000; }
        }

        public ExecutorSantaHelena()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ServiceLog.LogInfo("Executor - Iniciando Serviço");
            this.timer.Start();
            ServiceLog.LogInfo("Executor - Serviço iniciado");
        }

        protected override void OnStop()
        {
        }

        public void Start()
        {
            this.timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ServiceLog.LogInfo("Executor - Início da Execução do serviço");
            EmExecucao = true;
            try
            {
                Monitor.Instance.Start();
                //new BS.Integracao().Executar(false);
            }
            finally
            {
                EmExecucao = false;
                ServiceLog.LogInfo("Executor - Final da Execução do serviço");
            }
        }
    }
}
