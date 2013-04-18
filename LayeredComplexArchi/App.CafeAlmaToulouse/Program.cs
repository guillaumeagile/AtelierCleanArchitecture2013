using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashier.Data;
using Cashier.UI.GenericConsole;

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

            var ui = new BasicConsole("toulouse");
            ui.Run(productList);
        }
    }
}
