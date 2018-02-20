using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using BS;
using System.Timers;
using FC.Integrador.Utils;
using ConnectionMonitor;

namespace Consumidor
{
    public partial class ConsumidorSantaHelena : ServiceBase
    {
        private bool EmExecucao { get; set; }

        private Double ServicoTempo
        {
            get { return Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["WSConsumidorTimer"]) * 1000; }
        }

        public ConsumidorSantaHelena()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ServiceLog.LogInfo("Consumidor - Iniciando Serviço");
            this.timer.Start();
            ServiceLog.LogInfo("Consumidor - Serviço iniciado");
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
            ServiceLog.LogInfo("Consumidor - Tempo de execução atingido");
            if (!EmExecucao)
            {
                ServiceLog.LogInfo("Consumidor - Início da Execução do serviço");
                //EmExecucao = true;
                try
                {
                    Monitor.Instance.Start();
                    //new BS.Integracao().Executar(true);
                }
                finally
                {
                    EmExecucao = false;
                    ServiceLog.LogInfo("Consumidor - Final da Execução do serviço");
                }
            }
            else
            {
                ServiceLog.LogInfo("Consumidor - Serviço está em processo de execução");
            }
        }
    }
}
