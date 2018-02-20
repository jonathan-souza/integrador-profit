using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selia.Integrador.Utils.AutenticacaoRest
{
    public interface IAutenticacaoRest
    {
        void CriarAutenticacao(AutenticacaoRest.Autenticacao autenticacao);
    }
}
