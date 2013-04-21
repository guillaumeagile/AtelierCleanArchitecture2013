using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Cashier.Data;
using Cashier.DataAccess;

namespace Cashier.Business.Common
{
    public abstract class Calculateur 
    {
       protected List<CashEntry> orderList;
       protected List<Product> ListProd;
       protected Cashier.DataAccess.Library DAL;

       public Calculateur(string shopName)
        {
            orderList = new List<CashEntry>();
             DAL = new Cashier.DataAccess.Library();
             this.ListProd = DAL.Init(shopName);
        }

       public virtual Product ProcessEntry(string line)
        {
            var listOfMatches = Regex.Matches(line, @"(\d+) ([a-zA-Z]+)");
            if (listOfMatches.Count == 0)
                return (new Product("error", 0,0));
            else
            {
                var entry = new CashEntry
                {
                    Number = int.Parse(listOfMatches[0].Groups[1].Value),
                    Reference = listOfMatches[0].Groups[2].Value
                };

                if (ListProd.Contains(entry.Reference))
                {
                    var product = ListProd.GetProduct(entry.Reference);
                    entry.SubTotal = product.Price * entry.Number;
                    orderList.Add(entry);
                    return product;
                }
                else
                    return new Product("unknown", 0,0) ;
            }
           // return new Product("next article (or = to finish)", 0, 0);
        }

        public virtual  double CalculateTotal()
        {
            double total = 0;
            orderList.ToList().ForEach(entry => total = total + entry.SubTotal);
            return total;
        }
    }

    public static class Extensions
    {
        public static bool Contains(this List<Product> lp, string reference)
        {
            return (lp.Where(p => p.Reference == reference).Count() == 1);            
        }

        public static Product GetProduct(this List<Product> lp, string reference)
        {
            return lp.Where(p => p.Reference == reference).First();
        }
    }
}
