using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Cashier.Model;

using Cashier.UseCases;

namespace Cashier.UI.GenericConsole
{
    public class BasicConsole : IAmAUserInterfaceForCalculateur
    {
        string ShopName;
        public BasicConsole(string shopName)
        {
            ShopName = shopName;
        }

        ICanCalculate Calculateur;

        public void GiveAWayToCalculate(ICanCalculate calculator)
        {
            this.Calculateur = calculator;
        }

        public void Run()
        {
           
            Console.WriteLine("{0} cashier machine ready (type = to stop)", ShopName);
            string line = string.Empty;
            do
            {
                line = Console.ReadLine();
                if (line == "=")
                    break;
                Console.WriteLine(ProcessLine(line));

            } while (line != "=");

            Console.WriteLine("total amount : {0}", Calculateur.CalculateTotal());
            Console.ReadLine();
        }


        /// <summary>
        /// lit une ligne qui vient de la console, décortique le contenu et informe s'il y a une erreur ou pas
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public string ProcessLine(string line)
        {
            var listOfMatches = Regex.Matches(line, @"(\d+) ([a-zA-Z]+)");
            if (listOfMatches.Count == 0)
                return ("syntax err");
            else
            {
                var typing = new CashierTyping
                {
                    Number = int.Parse(listOfMatches[0].Groups[1].Value),
                    Reference = listOfMatches[0].Groups[2].Value
                };
                Calculateur.ProcessEntry(typing);

            }
            return "next article (or = to finish)";
        }

        
    }
}
