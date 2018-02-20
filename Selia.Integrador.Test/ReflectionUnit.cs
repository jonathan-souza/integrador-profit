using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Selia.Integrador.Test
{
    [TestClass]
    public class ReflectionUnit
    {
        [TestMethod]
        public void Consultar()
        {
            var assembly = "Selia.Integrador.BSeller.AcaoRetornoErro,Selia.Integrador.BSeller";
            new Selia.Integrador.Utils.Generic.Invoke().Exec(assembly, "ProdutoNaoEncontrado", null, null);

        }
    }
}
