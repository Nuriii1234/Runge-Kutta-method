using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runge_Kutta_method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var TRunge_Kutta_method = new TRunge_Kutta_method();
            TRunge_Kutta_method.Start();
            Console.ReadKey();
        }
    }
}
