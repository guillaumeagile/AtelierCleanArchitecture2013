using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cashier.Boundaries
{
    public interface ICanDoCalculus
    {
        double CalculateTotal();
        string ProcessEntry(string line);
    }
}
