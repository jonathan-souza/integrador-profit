using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace Executor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            #if DEBUG

            var executor = new ExecutorSantaHelena();
            executor.Start();

            while (true)
            {
                    
            }

            #else
            
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
			    new ExecutorSantaHelena() 
			};
            ServiceBase.Run(ServicesToRun);
            
            #endif
        }
    }
}
