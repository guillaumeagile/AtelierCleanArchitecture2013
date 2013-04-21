using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashier.UI.GenericConsole;
using Cashier.Boundaries;
using Cashier.Data;


namespace App.RecordStore.Paris
{
    class Program
    {
        static void Main(string[] args)
        {
            var productList = new List<Product>();
            productList.Add(new Product("bowie", 7.5));
            productList.Add(new Product("glass", 6.65));
            productList.Add(new Product("moby", 8));

            ICanDoCalculus calc = (ICanDoCalculus) new Cashier.Business.RecordStore.Calculateur(productList);
            
            var ui = new BasicConsole("record store Paris", calc);
            ui.Run();
            
        }
       
    }
}
