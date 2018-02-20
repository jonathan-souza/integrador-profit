using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BS
{
    public class Mapeamento
    {
        public List<Model.Mapeamento> Consultar(int IntegracaoID)
        {
            return new Selia.Integrador.DAL.Mapeamento().Consultar(IntegracaoID);
        }

    }
}
