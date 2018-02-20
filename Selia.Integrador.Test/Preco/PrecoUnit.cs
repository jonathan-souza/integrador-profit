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
    public class PrecoUnit
    {
        [TestMethod]
        [TestCategory("Preço")]
        public void Iniciar_Integracao_De_Preco_Consultar_Produtos_Bseller()
        {
            new Integracao().Executar(43);
        }

        [TestMethod]
        [TestCategory("Preço")]
        public void Iniciar_Integracao_De_Estoque_Consultar_Estoque()
        {
           new Integracao().Executar(44);
        }

        [TestMethod]
        [TestCategory("Preço")]
        public void Iniciar_Integracao_De_Estoque_Alterar_Estoque()
        {
            new Integracao().Executar(45);
        }
    }
}
