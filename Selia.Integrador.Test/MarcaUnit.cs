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
    public class MarcaUnit
    {
        [TestMethod]
        [TestCategory("Marca")]
        public void Iniciar_Integracao_Marca_Listar_Produtos()
        {
            new Integracao().Executar(70);
        }

        [TestMethod]
        [TestCategory("Marca")]
        public void Iniciar_Integracao_Marca_Inserir_Bseller()
        {
            new Integracao().Executar(71);
        }




        [TestMethod]
        [TestCategory("Marca")]
        public void ConsultaClassificacoes()
        {
            new Integracao().Executar(76);
        }

    }
}
