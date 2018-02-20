using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BS;

namespace Selia.Integrador.Test
{
    [TestClass]
    public class IntegracaoWebServices
    {
        [TestMethod]
        public void ConsultarIntegracaoSimples()
        {
            var integracao = new Integracao().ConsultarIntegracaoSimples();
        }
    }
}
