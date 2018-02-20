using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BS;

namespace Selia.Integrador.Test
{
    [TestClass]
    public class Pedido
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

        [TestMethod]
        [TestCategory("Atualizar Status")]
        public void Listar_Status_Banco_Seliaamara()
        {
            new Integracao().Executar(64);
        }

        [TestMethod]
        [TestCategory("Atualizar Status")]
        public void Enviar_Status_Millenium_Banco()
        {
            new Integracao().Executar(65);
        }

        [TestMethod]
        [TestCategory("Atualizar Status")]
        public void Incluir_Alterar_Pedido_Seliaamara()
        {
            new Integracao().Executar(66);
        }

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

    }
}
