using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashier.Model;
using Cashier.UseCases;

namespace Cashier.Business.CafeAlma
{
    public class Calculateur : ICanCalculate
    {
        List<CashEntry> orderList;
        List<Product> ListProd;

        public Calculateur(List<Product> listProd)
        {
            orderList = new List<CashEntry>();
            this.ListProd = listProd;
        }       

        /// <summary>
        /// enregistre une ligne tapée et la mémorie si elle est trouvée dans la liste des produits
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public string ProcessEntry(CashierTyping info)
        {
            if (ListProd.Contains(info.Reference))
            {
                var entry = new CashEntry();
                entry.SubTotal = ListProd.GetPrice(info.Reference) * info.Number;
                orderList.Add(entry);
                return string.Empty; 
            }
            else
                return "product unknown";
        }

        public double CalculateTotal()
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
