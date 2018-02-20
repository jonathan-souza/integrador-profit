using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Selia.Integrador.Utils.AutenticacaoRest
{
    public class Autenticacao
    {
        public HttpClient HttpRequest { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
