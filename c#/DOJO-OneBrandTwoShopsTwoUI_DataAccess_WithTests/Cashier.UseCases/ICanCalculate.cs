using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashier.Model;

namespace Cashier.UseCases
{
    public interface ICanCalculate
    {
        string ProcessEntry(CashierTyping info);

        double CalculateTotal();

        void GiveMeAWayToPersistData(ICanPersistProducts storage, string catalogName);
    }
}
