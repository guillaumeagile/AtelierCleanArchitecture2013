using System;

using Cashier.Business.Common;

namespace Cashier.UI.GenericConsoleWithBusiness
{
    public class BasicConsole
    {
        string ShopName;
        Calculateur calculateur;

        public BasicConsole(string shopName)
        {
            ShopName = shopName;
            
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
                var produitEnregistre = calculateur.ProcessEntry(line);
                Console.WriteLine("{0} = {1}", produitEnregistre.Reference, produitEnregistre.Price);

            } while (line != "=");


            Console.WriteLine("total amount : {0}", calculateur.CalculateTotal());
            Console.ReadLine();
        }
    }
}
