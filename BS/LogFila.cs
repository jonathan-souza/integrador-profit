using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BS
{
    public class LogFila
    {
        public int Inserir(Model.LogFila entLogFila)
        {
            return new Selia.Integrador.DAL.LogFila().Inserir(entLogFila);
        }
    }
}
