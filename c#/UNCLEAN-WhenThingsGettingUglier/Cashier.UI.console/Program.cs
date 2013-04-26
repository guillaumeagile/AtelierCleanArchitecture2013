using System.Collections.Generic;
using Cashier.UI.GenericConsoleWithBusiness;
using Cashier.Business;

namespace App.CafeAlmaParis
{
    class Program
    {
        static void Main(string[] args)
        {           
            var calc = new Cashier.Business.CafeAlma.Calculateur("café Alma Paris");

            var ui = new BasicConsole("café Alma Paris");
            ui.Run();
        }
    }
}
