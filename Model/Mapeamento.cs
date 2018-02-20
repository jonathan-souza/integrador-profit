using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Mapeamento
    {
        public Mapeamento()
        {
            Filhos = new List<Mapeamento>();
            ValoresDePara = new List<DePara>();
        }
        public string ElementoMult { get; set; }
        public int ID { get; set; }
        public string De { get; set; }
        public string Para { get; set; }
        private string valor=null;
        public string Valor
        {
            get
            {
                return valor;
            }
            set
            {
                valor = value;
                if (ValoresDePara.Exists(c => c.De == value))
                {
                    valor = ValoresDePara.Single(c => c.De == value).Para;
                }
            }
        }
        public bool Mult { get; set; }
        public int PaiID { get; set; }
        public string Configuracao { get; set; }
        public string TipoValor { get; set; }
        public string Acao { get; set; }

        public bool BitQueryString { get; set; }
        public bool BitMapRetorno { get; set; }
        public bool BitXmlEntrada { get; set; }

        public bool BitExcluirBranco{get;set;} 

        public List<Mapeamento> Filhos { get; set; }
        public List<DePara> ValoresDePara { get; set; }
        public List<object> ValoresMult { get; set; }

        public bool TemPai { get; set; }

        public class DePara
        {
            public int ID { get; set; }
            public string De { get; set; }
            public string Para { get; set; }
            public string InfosAdicionais { get; set; }
            public int IntegracaoId { get; set; }
        }
    }
}
