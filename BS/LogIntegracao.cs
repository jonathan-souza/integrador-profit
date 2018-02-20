using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BS
{
    public class LogIntegracao
    {
        public int Inserir(Model.LogIntegracao entLogIntegracao)
        {
            return new Selia.Integrador.DAL.LogIntegracao().Inserir(entLogIntegracao);
        }
    }
}
