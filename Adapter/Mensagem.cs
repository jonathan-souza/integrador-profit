using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Selia.Integrador.Adapter
{
    public class Resultado
    {
        public enum Tipo
        {
            Sucesso = 1,
            Erro = 0
        }

        public string Descricao
        {
            get
            {
                if (TipoMensagem == Tipo.Erro)
                {
                    return "Ocorreu algum erro ao tentar processar os dados.";
                }
                return "Processo executado com sucesso";
            }
        }
       


        public Resultado()
        {
            TipoMensagem = Tipo.Sucesso;
        }

        public bool MediaTypeHeaderJson { get; set; }
        public string Mensagem { get; set; }
        public Tipo TipoMensagem { get; set; }
        public string ElementoSeparador { get; set; }
        public string ParametrosEnvio { get; set; }
        public XmlDocument RespostaXmlCompleta { get; set; }
        private List<XmlElement> respostaXmlSeparada = null;
        public List<XmlElement> RespostaXmlSeparada
        {
            get
            {
                if(respostaXmlSeparada==null)
                {
                    respostaXmlSeparada = Util.RetornarListaNoPrincipal(ElementoSeparador, RespostaXmlCompleta);
                }
                return respostaXmlSeparada;
            }
            set
            {
                respostaXmlSeparada = value;
            }
        }


        public string RespostaSemTratamento { get; set; }
    }
}
