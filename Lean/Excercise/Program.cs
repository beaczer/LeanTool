using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Excercise
{   class Program
    {
        static void Main(string[] args)
            {
            Console.WriteLine("Based WCF Host");
            Console.ReadLine();
            using (ServiceHost serviceHost= new ServiceHost(typeof(MagicEightBallService)))
            {
                serviceHost.Open();
                Console.WriteLine("The service is ready");
                Console.WriteLine("press the key to terminate");
                Console.ReadLine();
                
            }
            }
        }
    }
