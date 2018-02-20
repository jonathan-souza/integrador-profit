using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selia.Integrador.Utils
{
    public class Exceptions
    {
        public class BaseException : Exception
        {
            public BaseException(string mensagem="" , Exception inner = null):base(mensagem, inner)
            {
            }
        }

        public class HttpRestException : BaseException
        {
            public object InformacaoAdicional { get; set; }

            public string ConteudoFila { get; set; }
            public string ParamentroEnvio { get; set; }
            public string RetornoTratado { get; set; }
            public string RetornoNaoTratado { get; set; }

            public HttpRestException(string message = "", Exception inner = null, object informacaoAdicional = null, string conteudoFila = null, string paramentroEnvio = null, string retornoTratado = null, string retornoNaoTratado = null)
                : base(message, inner)
            {
                this.InformacaoAdicional = informacaoAdicional;
                this.ParamentroEnvio = paramentroEnvio;
                this.ConteudoFila = conteudoFila;
                this.RetornoTratado = retornoTratado;
                this.RetornoNaoTratado = retornoNaoTratado;
            }
        }

        public class HttpRestRetornoException : BaseException
        {
            public object InformacaoAdicional { get; set; }

            public string ConteudoFila { get; set; }
            public string ParamentroEnvio { get; set; }
            public string RetornoTratado { get; set; }
            public string RetornoNaoTratado { get; set; }

            public HttpRestRetornoException(string message = "", Exception inner = null, object informacaoAdicional = null, string conteudoFila = null, string paramentroEnvio = null, string retornoTratado = null, string retornoNaoTratado = null)
                : base(message, inner)
            {
                this.InformacaoAdicional = informacaoAdicional;
                this.ParamentroEnvio = paramentroEnvio;
                this.ConteudoFila = conteudoFila;
                this.RetornoTratado = retornoTratado;
                this.RetornoNaoTratado = retornoNaoTratado;
            }
        }
    }
}
