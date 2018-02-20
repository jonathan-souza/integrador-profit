using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BS;

namespace Selia.Integrador.Test
{
    [TestClass]
    public class PedidosStatusBSellerUnit
    {

        [TestMethod]
        [TestCategory("Pedido Status BSeller")]
        public void ConsultarPortalBSeller()
        {
            new Integracao().Executar(48);
        }

        [TestMethod]
        [TestCategory("Pedido Status BSeller")]
        public void Incluir_Ou_Atualizar_Status_Banco_Integrador()
        {
            new Integracao().Executar(54);
        }

    }
}
