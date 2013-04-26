using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashier.UI.GenericConsoleWithBusiness;

namespace App.RecordStore.Paris
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Cashier.Business.RecordStore.Calculateur("record store Paris");
            
            var ui = new BasicConsole("record store Paris");
            ui.Run();
            
        }
       
    }
}
