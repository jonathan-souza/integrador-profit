using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BS;
using System.Configuration;

namespace Selia.Integrador.MDias
{
    public class AcaoRetornoErro
    {
        //Retorno Erro REST - PriceId Nulo
        public void AlteraDestinoPriceIdNulo(int filaId, Model.Fila fila, string InformacaoAdicional)
        {
            var msgErro = ConfigurationManager.AppSettings["AlteraDestinoPriceIdNulo"].ToUpper();
            var index = InformacaoAdicional.ToUpper().IndexOf(msgErro);
            if (index >=0)
            new Fila().AtualizarDestino(8, filaId);
        }
    }
}
