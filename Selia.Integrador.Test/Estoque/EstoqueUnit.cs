using BS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selia.Integrador.Test
{
    [TestClass]
    public class EstoqueUnit
    {
        [TestMethod]
        [TestCategory("Estoque")]
        public void Iniciar_Integracao_De_Estoque_Consultar_Produtos()
        {
            new Integracao().Executar(23);
        }

        [TestMethod]
        [TestCategory("Estoque")]
        public void Iniciar_Integracao_De_Estoque_Consultar_Estoque()
        {
            new Integracao().Executar(24);
        }

        [TestMethod]
        [TestCategory("Estoque")]
        public void Iniciar_Integracao_De_Estoque_Alterar_Estoque()
        {
            new Integracao().Executar(25);
        }
    }
}
