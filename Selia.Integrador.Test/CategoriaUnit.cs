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
    public class CategoriaUnit
    {
        [TestMethod]
        [TestCategory("Categoria")]
        public void Iniciar_Integracao_Categoria_Listar_Produtos()
        {
            new Integracao().Executar(72);
        }

        [TestMethod]
        [TestCategory("Categoria")]
        public void Iniciar_Integracao_Categoria_Inserir_Produtos()
        {
            new Integracao().Executar(73);
        }

    }
}
