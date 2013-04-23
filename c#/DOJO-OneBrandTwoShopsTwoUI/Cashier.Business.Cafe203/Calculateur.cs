using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashier.Model;
//using Cashier.UseCases;

namespace Cashier.Business.Cafe203
{
    public class Calculateur : Cashier.Business.CafeCommon.Calculateur
    {
       
        

        public Calculateur(List<Product> listProd)
            : base(listProd)
        {

        }    

       
        public override double CalculateTotal()
        {
            double total = 0;
            orderList.ToList().ForEach(entry => total = total + entry.SubTotal / 2);
            return total;
        }
    }

   
}
