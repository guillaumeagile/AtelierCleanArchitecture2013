using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Cashier.Data;
using Cashier.Boundaries;

namespace Cashier.Business.Common
{
    public abstract class Calculateur : ICanDoCalculus
    {
       protected List<CashEntry> orderList;
       protected List<Product> ListProd;

        public Calculateur(List<Product> listProd)
        {
            orderList = new List<CashEntry>();
            this.ListProd = listProd;
        }

        public virtual string ProcessEntry(string line)
        {
            var listOfMatches = Regex.Matches(line, @"(\d+) ([a-zA-Z]+)");
            if (listOfMatches.Count == 0)
                return ("syntax err");
            else
            {
                var entry = new CashEntry
                {
                    Number = int.Parse(listOfMatches[0].Groups[1].Value),
                    Reference = listOfMatches[0].Groups[2].Value
                };

                if (ListProd.Contains(entry.Reference))
                {
                    entry.SubTotal = ListProd.GetPrice(entry.Reference) * entry.Number;
                    orderList.Add(entry);
                }
                else
                    return "product unknown";
            }
            return "next article (or = to finish)";
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

        public static double GetPrice(this List<Product> lp, string reference)
        {
            return lp.Where(p => p.Reference == reference).First().Price;
        }
    }
}
