using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashier.UI.GenericConsoleWithBusiness;
using Cashier.Business;
namespace App.CafeAlmaToulouse
{
    class Program
    {
        static void Main(string[] args)
        {           
            var calc = new Cashier.Business.CafeAlma.Calculateur("café Alma Toulouse");

            var ui = new BasicConsole("café Alma Toulouse");
            ui.Run();
        }
    }
}
