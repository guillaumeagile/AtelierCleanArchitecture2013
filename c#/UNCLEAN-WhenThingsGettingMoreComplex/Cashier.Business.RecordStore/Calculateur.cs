using System.Collections.Generic;
using System.Linq;
using Cashier.Data;

namespace Cashier.Business.RecordStore
{
    public class Calculateur : Cashier.Business.Common.Calculateur
    {

        public Calculateur(List<Product> listProd) : base (listProd)
        {
         
        }

        public override double CalculateTotal()
        {
            double total = 0;
            orderList.ToList().ForEach(entry => total = total + entry.SubTotal );
            return total;
        }
    }

  
}
