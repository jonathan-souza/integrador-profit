using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ResultadoHttpRest
    {
        public string Conteudo { get; set; }
        public bool ConteudoJson { get; set; }
        public int HttpStatusCodeSucess { get; set; }
    }
}
