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
        public Int64 PrimaryKey;
        public bool IsUnique;

        public Product(string reference, double price, Int64 primaryKey)
        {
            this.Reference = reference;
            this.Price = price;
            this.PrimaryKey = primaryKey;
            //this.IsUnique = isUnique;
        }

        //public Product(string reference, double price, Int64 primaryKey, bool isUnique)
    }
}
