using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BS;

namespace Selia.Integrador.Test
{
    [TestClass]
    public class IntegracoesRestUnit
    {

        [TestMethod]
        [TestCategory("Excecutor")]
        public void Consultar_uma_pessoa_utilizando_o_verbo_get_api_local()
        {   
            new Integracao().Executar(1);

        }


        [TestMethod]
        [TestCategory("Consumidor")]
        public void Dado_uma_pessoa_alterar_com_o_verbo_post_api_local()
        {
            new Integracao().Executar(2);
        }

        [TestMethod]
        [TestCategory("Consumidor")]
        public void Dado_uma_fila_de_pessoas_consultar_somente_uma_com_o_verbo_get_api_local()
        {
            new Integracao().Executar(27);
        }
    }
}
