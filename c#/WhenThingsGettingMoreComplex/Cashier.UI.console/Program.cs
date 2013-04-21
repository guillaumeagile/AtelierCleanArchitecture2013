using System.Collections.Generic;
using Cashier.UI.GenericConsole;
using Cashier.Data;
using Cashier.Business;
using Cashier.Boundaries;

namespace App.CafeAlmaParis
{
    class Program
    {
        static void Main(string[] args)
        {
            var productList = new List<Product>();
            productList.Add(new Product("tea", 1));
            productList.Add(new Product("egg", 1.3));
            productList.Add(new Product("cof", 1.6));

            ICanDoCalculus calc = (ICanDoCalculus)new Cashier.Business.CafeAlma.Calculateur(productList);

            var ui = new BasicConsole("café Alma Paris", calc);
            ui.Run();
        }
    }
}
