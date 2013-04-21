using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Cashier.Model;
using Cashier.Business.CafeAlma;
using Cashier.UseCases;

namespace Cashier.UI.GenericConsole
{
    public class QuickConsole : IAmAUserInterfaceForCalculateur
    {
        string ShopName;
        public QuickConsole(string shopName)
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
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("{0} running", ShopName);
            string line = string.Empty;
            do
            {
                line = Console.ReadLine();
                if (line == "")
                    break;
                Console.WriteLine(ProcessLine(line));

            } while (line != "");

            Console.WriteLine("{0} EUR", Calculateur.CalculateTotal());
            Console.ReadLine();
        }


        /// <summary>
        /// lit une ligne qui vient de la console, décortique le contenu et informe s'il y a une erreur ou pas
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public string ProcessLine(string line)
        {
            var typing = new CashierTyping();
            var listOfMatches = Regex.Matches(line, @"(\d+) ([a-zA-Z]+)");
            if (listOfMatches.Count == 0)
            {
                typing.Number = 1;
                typing.Reference = line;
            }
            else
            {
                typing.Number = int.Parse(listOfMatches[0].Groups[1].Value);
                typing.Reference = listOfMatches[0].Groups[2].Value;
            }
            
            Calculateur.ProcessEntry(typing);
            return "";
        }


    }
}
