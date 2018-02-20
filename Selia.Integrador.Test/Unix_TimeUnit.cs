using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Selia.Integrador.Test
{
    [TestClass]
    public class Unix_TimeUnit
    {
        [TestMethod]
        public void Converter()
        {
            var data = new DateTime(2014, 12, 16, 18, 59, 39);
            var epochEsperado = 1418756379;
            double epochEsperadoRetornado1;

            long epochEsperadoRetornado2;


            epochEsperadoRetornado1 = Converter1(data);
            //Assert.AreEqual(epochEsperado, epochEsperadoRetornado1);


            //usar a 2
            epochEsperadoRetornado2 = Converter2(data);
            
        }

        public double Converter1(DateTime data)
        {
            var epoch = (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            return epoch;
        }

        public long Converter2(DateTime data)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((data.ToUniversalTime() - epoch).TotalSeconds);
        }
    }
}
