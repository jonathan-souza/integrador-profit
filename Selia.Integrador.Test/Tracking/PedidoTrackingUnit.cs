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
    public class PedidoTrackingUnit
    {
        [TestMethod]
        [TestCategory("Pedidos Tracking")]
        public void Listar_Pedidos_Seliaamara()
        {
            new Integracao().Executar(68);
        }

        [TestMethod]
        [TestCategory("Pedidos Tracking")]
        public void Enviar_Pedidos_BSeller()
        {
            new Integracao().Executar(69);
        }

        [TestMethod]
        [TestCategory("Pedidos Tracking")]
        public void Dados_Uma_Atualizacao_De_Estado_Atualizar_Na_Seliaamara()
        {
            new Integracao().Executar(75);
        }
    }
}
