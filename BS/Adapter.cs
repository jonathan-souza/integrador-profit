using Selia.Integrador.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selia.Integrador.BS
{
    /// <summary>
    /// Não foi usado um AutoMapper, para seguir no mesmo modelo da arquitetura
    /// </summary>
    public static class Adapter
    {
        public static Selia.Integrador.Adapter.Rest.Config IntegracaoParaRest(this Model.Integracao integracao)
        {
            var ret = new Selia.Integrador.Adapter.Rest.Config();

            var rest = ((Model.Interface.Rest)integracao.Interface.Item);
            ret.Rest = rest;
            ret.AcaoFinal = integracao.AcaoFinal;
            ret.AcaoInicial = integracao.AcaoInicial;
            ret.ElementoSeparador = integracao.ElementoRegistro;
            ret.AcaoCabecalho = integracao.AcaoCabecalho;
            ret.NodesNaoUtilizados = integracao.NodesNaoUtilizados;

            return ret;
        }

        public static List<Util.Mapeamento.Entidade> ParaMapeamento(this List<Model.Interface.Rest.ParametroRest> parametrosRest)
        {
            var ret = new List<Util.Mapeamento.Entidade>();

            foreach (Model.Interface.Rest.ParametroRest Param in parametrosRest)
            {
                ret.Add(new Selia.Integrador.Adapter.Util.Mapeamento.Entidade() { Para = Param.De, Valor = Param.Para });
            }

            return ret;
        }
    }
}
