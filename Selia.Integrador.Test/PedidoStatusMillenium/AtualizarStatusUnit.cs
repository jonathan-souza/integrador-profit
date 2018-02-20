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
    public class AtualizarStatusUnit
    {
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
    }
}
