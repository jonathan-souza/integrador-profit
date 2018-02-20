using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class LogFila
    {
        public LogFila()
        {
            LogIntegracao = new LogIntegracao();
        }
        public int ID { get; set; }
        public LogIntegracao LogIntegracao { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Conteudo { get; set; }
        public string ChavePrimaria { get; set; }
        public string ChaveSecundaria { get; set; }
        public string ConteudoRetorno { get; set; }
        public string ConteudoFila { get; set; }
        public int FilaID { get; set; }

        public string RespostaSemTratamento { get; set; }

        public int IntegracaoID { get; set; }
    }
}