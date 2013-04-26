using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashier.Business.CafeAlma;
using Cashier.UI.Provider;
using Cashier.Model;
using Cashier.UseCases;

namespace App.CafeAlmaParis
{
    class Program
    {
        static void Main(string[] args)
        {
            var productList = new List<Product>();
            productList.Add(new Product("tea", 1));
            productList.Add(new Product("egg", 2));
            productList.Add(new Product("cof", 3));

            var uiProvider = new UiFactory();
            
            var ui = uiProvider.GetUi("paris");

            ICanCalculate calc = new Calculateur(productList);
            ui.GiveAWayToCalculate(calc);

            ui.Run();
        }
    }
}
