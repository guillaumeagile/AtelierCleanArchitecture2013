using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashier.Model;
//using Cashier.UI.GenericConsole;
using Cashier.UseCases;
using Cashier.Business.CafeAlma;
using Cashier.UI.Provider;

using Cashier.Persistence.SQLserver;  //  BAD, please use a Dependance Injector

namespace App.CafeAlmaToulouse
{
    class Program
    {
        static void Main(string[] args)
        {
            var productList = new List<Product>();
            productList.Add(new Product("tea", 0.5));
            productList.Add(new Product("egg", 0.65));
            productList.Add(new Product("cof", 0.8));

            //var ui = new BasicConsole("toulouse");
            var uiProvider = new UiFactory();
            var ui = uiProvider.GetUi("toulouse");

            ICanCalculate calc = new Calculateur(productList);

            ICanPersistProducts persistance; //GOOD
            persistance = new SqlDataAccess(); // BAD: defer the choice of implementation to a factory or a DI 

            calc.GiveMeAWayToPersistData(persistance, "toulouse");

            ui.GiveAWayToCalculate(calc);

            ui.Run();
        }
    }
}
