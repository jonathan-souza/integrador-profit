using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BS;
using Selia.Integrador.Utils;
using Selia.Integrador;
using System.Xml;
using System.Threading.Tasks;

namespace TestIntegrador
{
    public class Program
    {
        public static void Main()
        {

         
            while (true)
            {
                ////buscar os status
                //new Integracao().Executar(false, null, 48);
                //new Integracao().Executar(true, null, 54);

                ////atualizar os status
                //new Integracao().Executar(false, null, 56);
                //new Integracao().Executar(true, null, 57);
                //new Integracao().Executar(true, null, 58);

                ////mandar status para o millenium
                //new Integracao().Executar(false, null, 64);
                //new Integracao().Executar(true, null, 65);
                //new Integracao().Executar(true, null, 66);

                ////enviar pediso para a millenium
                //new Integracao().Executar(false, null, 59);
                //new Integracao().Executar(true, null, 60);
                //new Integracao().Executar(true, null, 62);
                //new Integracao().Executar(true, null, 63);

                //new Integracao().Executar(true, null, 74);                
                //new Integracao().Executar(true, null, 61);
                

                //System.Threading.Thread.Sleep(60000);

                //while (true)
                //{
                //    List<Task> tasks = new List<Task>();


                //    Console.WriteLine("ConsumidorAsync - {0}", DateTime.Now);
                //    var asyncExecutor = Executar(false);

                //    Console.WriteLine("ConsumidorAsync - {0}", DateTime.Now);
                //    var asyncConsumidor = Executar(true);

                //    tasks.Add(asyncExecutor);
                //    tasks.Add(asyncConsumidor);

                //    Task.WaitAll(tasks.ToArray());
                  
                //}

                Console.ReadKey();
            }          

        }
        //private static Task Executar(bool consumidor)
        //{
        //    Console.WriteLine("Executar - {0} - {1}", consumidor.ToString(), DateTime.Now);

        //    return Task.Factory.StartNew(() => new BS.Integracao().Executar(consumidor));
        //}

    }
}