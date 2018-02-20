using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BS;

namespace Selia.Integrador.Test
{
    [TestClass]
    public class PedidosStatusAcao1Unit
    {

        [TestMethod]
        [TestCategory("Pedido Status Ação 1")]
        public void Consultar_status_banco_de_dados_integrador()
        {
            new Integracao().Executar(59);
        }

        [TestMethod]
        [TestCategory("Pedido Status Ação 1")]
        public void Dado_Um_idpedido_consulta_no_na_bseller()
        {
            new Integracao().Executar(60);
        }

        [TestMethod]
        [TestCategory("Pedido Status Ação 1")]
        public void Dado_Um_pedido_buscar_o_cliente_na_Bseller()
        {
            new Integracao().Executar(62);
        }


        [TestMethod]
        [TestCategory("Pedido Status Ação 1")]
        public void Dado_Um_cliente_inserir_na_millennium()
        {
            new Integracao().Executar(63);
        }

        [TestMethod]
        [TestCategory("Pedido Status Ação 1")]
        public void Dado_Um_Pedido_da_Millenium_Consultar_Na_BSeller()
        {
            new Integracao().Executar(74);
        }

        [TestMethod]
        [TestCategory("Pedido Status Ação 1")]
        public void Dado_Um_pedido_enviar_para_a_millennium()
        {
            new Integracao().Executar(61);
        }

      

        [TestMethod]
        public void Teste()
        {
             new Integracao().Executar(59);
             new Integracao().Executar(60);
             new Integracao().Executar(61);
        }
        


    }
}
