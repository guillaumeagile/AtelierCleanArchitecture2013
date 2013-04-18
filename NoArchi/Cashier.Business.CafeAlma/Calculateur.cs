using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cashier.Business.CafeAlma
{
    public class Calculateur
    {
        List<CashEntry> orderList;
        Dictionary<string, double> productList;

        public Calculateur()
        {
            orderList = new List<CashEntry>();
            productList = new Dictionary<string, double>();
            productList.Add("tea", 1);
            productList.Add("egg", 1.3);
            productList.Add("cof", 1.6);
        }

        public string ProcessEntry(string line)
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

                if (productList.ContainsKey(entry.Reference))
                {
                    entry.SubTotal = productList[entry.Reference] * entry.Number;
                    orderList.Add(entry);
                }
                else return "product unknown";
            }
            return "next article (or = to finish)";
        }

        public double CalculateTotal()
        {
            double total = 0;
            orderList.ToList().ForEach(entry => total = total + entry.SubTotal);
            return total;
        }
    }
}
