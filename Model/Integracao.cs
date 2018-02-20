using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Integracao
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public Model.Interface Interface { get; set; }
        public Model.Adapter Adapter { get; set; }
        public List<Model.Mapeamento> Mapeamento { get; set; }

        public List<Model.Mapeamento> MapeamentoQueryString { get; set; }

        public List<Model.Mapeamento> MapeamentoRetorno { get; set; }

        public List<Model.Fila> Fila { get; set; }
        public List<Model.LogIntegracao> LogIntegracao { get; set; }
        public List<Model.LogFila> LogFila{ get; set; }
        public bool Status { get; set; }
        public bool EmUso { get; set; }
        public string ElementoRegistro { get; set; }
        public string ExecucaoHorarios { get; set; }
        public int ExecucaoMinutos { get; set; }
        public DateTime DataHoraUltimaExecucao { get; set; }
        public int DestinoID { get; set; }
        public int PaiID { get; set; }
        public Integracao Destino { get; set; }
        public string PKPrimaria { get; set; }
        public string PKSecundaria { get; set; }
        public string AcaoInicial { get; set; }
        public string AcaoFinal{ get; set; }
        public string AcaoEnfileiramento { get; set; }
        public string AcaoCabecalho { get; set; }
        public int NivelParalelismo { get; set; }

        public string AcaoReturnoErro { get; set; }
        public bool Consumidor { get; set; }
        public string ConnectionString { get; set; }
        public int QtdErros { get; set; }
        public string NodesNaoUtilizados { get; set; }
    }
}
