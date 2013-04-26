using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashier.Business.CafeAlma;

namespace Cashier.UI.console
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculateur = new Calculateur();
            Console.WriteLine("cashier machine ready (type = to stop)");
            string line = string.Empty;
            do
            {
                line = Console.ReadLine();
                if (line == "=")
                    break;
                Console.WriteLine(calculateur.ProcessEntry(line));
                
            } while (line != "=");


            Console.WriteLine("total amount : {0}", calculateur.CalculateTotal());
            Console.ReadLine();
        }
    }
}
