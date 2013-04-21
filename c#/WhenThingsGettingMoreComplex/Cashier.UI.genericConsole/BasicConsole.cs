using System;

using Cashier.Boundaries;

namespace Cashier.UI.GenericConsole
{
    public class BasicConsole
    {
        string ShopName;        
        ICanDoCalculus calculateur;

        public BasicConsole(string shopName, ICanDoCalculus calc)
        {
            ShopName = shopName;
            calculateur = calc;
        }

        public void Run()
        {          

            Console.WriteLine("{0} cashier machine ready (type = to stop)", ShopName);
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
