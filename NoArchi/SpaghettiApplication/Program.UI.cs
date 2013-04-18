using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace Application
{
    class ProgramUI
    {
        static void Main(string[] args)
        {
            var orderList =  new List<CashEntry>();
            var productList = new Dictionary<string, double>();
            productList.Add("tea", 1);
            productList.Add("egg", 1.3);
            productList.Add("cof", 1.6);

            Console.WriteLine("cashier machine ready (type = to stop)");
            string line = string.Empty;
            do
            {
                line = Console.ReadLine();
                if (line == "=")
                    break;
                var listOfMatches = Regex.Matches(line, @"(\d+) ([a-zA-Z]+)");
                if (listOfMatches.Count == 0)
                    Console.WriteLine("syntax err");
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
                }
            } while (line != "=");

            double total = 0;
            orderList.ToList().ForEach(entry => total =  total + entry.SubTotal);
            Console.WriteLine("total amount : {0}", total);
            Console.ReadLine();
        }
    }
}
