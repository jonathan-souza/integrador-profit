using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BS;

namespace Selia.Integrador.Test
{
    [TestClass]
    public class PedidosStatusBSellerAtualizarUnit
    {

        [TestMethod]
        [TestCategory("Pedido Status BSeller Atualizar")]
        public void Consultar_status_banco_de_dados_integrador()
        {
            new Integracao().Executar(56);
        }

        [TestMethod]
        [TestCategory("Pedido Status BSeller Atualizar")]
        public void Visualizar_Pedido_BSeller_Por_IdPedido()
        {
            new Integracao().Executar(57);
        }

        [TestMethod]
        [TestCategory("Pedido Status BSeller Atualizar")]
        public void Dado_um_pedido_atualizar_banco_de_dados_do_integrador()
        {
            new Integracao().Executar(58);
        }

    }
}
