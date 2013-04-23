using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashier.Model;

using Cashier.UI.GenericConsole;
using Cashier.UseCases;
using Cashier.Business.CafeAlma;

//using Cashier.UI.Provider;

namespace App.CafeAlmaLyon203
{
    class Program
    {
        static void Main(string[] args)
        {
            var productList = new List<Product>();
            productList.Add(new Product("tea", 0.5));
            productList.Add(new Product("egg", 0.65));
            productList.Add(new Product("cof", 0.8));

            var ui = new QuickConsole("lyon");
            
            
            var calc = new Calculateur(productList);            

            ui.Run();
        }
    }
}










//var ui = uiProvider.GetUi("lyon");
//var uiProvider = new UiFactory();


//ui.GiveAWayToCalculate(calc);