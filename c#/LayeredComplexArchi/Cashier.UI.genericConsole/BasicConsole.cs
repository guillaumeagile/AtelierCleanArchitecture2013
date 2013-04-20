using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashier.Data;

using Cashier.Business.CafeAlma;

namespace Cashier.UI.GenericConsole
{
    public class BasicConsole
    {
        string ShopName;
        public BasicConsole(string shopName)
        {
            ShopName = shopName;
        }
        public void Run(List<Product> listProd)
        {
            var calculateur = new Calculateur(listProd);
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
