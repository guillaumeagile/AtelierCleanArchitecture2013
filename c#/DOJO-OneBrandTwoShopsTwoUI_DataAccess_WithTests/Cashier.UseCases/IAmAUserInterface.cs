using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cashier.UseCases
{
    public interface IAmAUserInterfaceForCalculateur
    {
        void GiveAWayToCalculate(ICanCalculate calculator);
        void Run();
    }
}
