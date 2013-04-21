using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cashier.Data
{
   public  class Product
    {
        public string Reference;
        public double Price;

        public Product(string reference, double price)
        {
            this.Reference = reference;
            this.Price = price;
        }
    }
}
