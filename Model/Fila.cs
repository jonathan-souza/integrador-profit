using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Fila
    {
        public enum TipoStatus
        {
            Sucesso=1, Erro=2
        }
        public Fila()
        {
            Integracao = new Integracao();
            IntegracaoDestino = new Integracao();
        }
        public int ID { get; set; }
        public Model.Integracao Integracao { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Conteudo { get; set; }
        public string ChavePrimaria { get; set; }
        public string ChaveSecundaria { get; set; }
        public TipoStatus Status { get; set; }
        public int LogIntegracaoID { get; set; }
        public Model.Integracao IntegracaoDestino { get; set; }
        public int ContagemTentativa { get; set; }
    }
}
