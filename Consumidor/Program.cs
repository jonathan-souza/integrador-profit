using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace Consumidor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            #if DEBUG

            var consumidor = new ConsumidorSantaHelena();
            consumidor.Start();

            while (true)
            {

            }

            #else

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
	        { 
		        new ConsumidorSantaHelena()
	        };
            ServiceBase.Run(ServicesToRun);

            #endif
        }
    }
}
