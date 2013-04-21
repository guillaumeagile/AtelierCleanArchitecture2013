using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashier.UseCases;

namespace Cashier.UI.Provider
{
    public class UiFactory
    {
        public IAmAUserInterfaceForCalculateur GetUi(string shopName)
        {
            if (shopName.Contains("toulouse"))
                return new Cashier.UI.GenericConsole.QuickConsole(shopName);
            if (shopName.Contains("lyon"))
                return new Cashier.UI.GenericWindowComponent.UserControl1(shopName);
            else
             return new Cashier.UI.GenericConsole.BasicConsole(shopName);
        }
    }
}
