using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashier.Business.CafeAlma;
using Cashier.UI.GenericConsole;
using Cashier.Data;

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

            var ui = new BasicConsole("paris");
            ui.Run(productList);
        }
    }
}
