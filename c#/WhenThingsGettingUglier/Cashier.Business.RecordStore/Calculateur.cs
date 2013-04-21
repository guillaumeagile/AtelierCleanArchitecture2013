﻿using System.Collections.Generic;
using System.Linq;
using Cashier.Data;

namespace Cashier.Business.RecordStore
{
    public class Calculateur : Cashier.Business.Common.Calculateur
    {
        public Calculateur(string s) : base(s)
        {
            DAL.AddProduct(new Product("beattles", 10, 12));
        }
       

        public override double CalculateTotal()
        {
            double total = 0;
            orderList.ToList().ForEach(entry => total = total + entry.SubTotal );
            return total;
        }
    }

  
}
