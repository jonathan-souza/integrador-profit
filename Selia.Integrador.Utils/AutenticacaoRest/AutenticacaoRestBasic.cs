using Selia.Integrador.Utils.AutenticacaoRest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selia.Integrador.Utils.AutenticacaoRest
{
    public class AutenticacaoRestBasic : IAutenticacaoRest
    {
        public void CriarAutenticacao(Autenticacao autenticacao)
        {
            if (autenticacao != null)
            {
                if (!string.IsNullOrEmpty(autenticacao.Login) && !string.IsNullOrEmpty(autenticacao.Senha))
                {
                    //var textoParaAutenticar = string.Format("{0}:{1}", autenticacao.Login, autenticacao.Senha);

                    //byte[] byteAutenticacao = System.Text.Encoding.ASCII.GetBytes(textoParaAutenticar);

                    //var textoConvertidoBase64 = Convert.ToBase64String(byteAutenticacao);

                    //autenticacao.HttpRequest.DefaultRequestHeaders.Add("Authorization", "Basic " + textoConvertidoBase64);


                    

                }
            }
        }
    }
}
