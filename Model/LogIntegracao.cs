using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class LogIntegracao
    {
        public int ID { get; set; }
        public Model.Integracao Integracao { get; set; }
        public int QtdRegistros { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataCriacao { get; set; }
        public List<Model.LogFila> LogFila { get; set; }
        public int Status { get; set; }
    }
}
