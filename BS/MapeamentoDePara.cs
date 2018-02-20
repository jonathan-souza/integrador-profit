using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selia.Integrador.BS
{
    public class MapeamentoDePara
    {

        public List<Model.Mapeamento.DePara> Consultar(int MapeamentoID)
        {
            return new Selia.Integrador.DAL.MapeamentoDePara().Consultar(MapeamentoID);
        }

        public List<Model.Mapeamento.DePara> ConsultarPorIntegracao(int IntegracaoID)
        {
            return new Selia.Integrador.DAL.MapeamentoDePara().ConsultarPorIntegracao(IntegracaoID);
        }
    }
}
