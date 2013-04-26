using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashier.Model;
using Cashier.UseCases;
using Cashier.Persistence.SQLserver;

namespace Cashier.Business.CafeAlma
{
    public class Calculateur : ICanCalculate
    {
        List<CashEntry> orderList;
        IList<Product> ListProd;

        //public Calculateur(List<Product> listProd) : this()
        //{            
        //    this.ListProd = listProd;
        //}

        public Calculateur()
        {
            orderList = new List<CashEntry>();
            var dal = new SqlDataAccess();
            this.ListProd = dal.GetAllFromCatalogNamed("foo");
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


        ICanPersistProducts Storage;

        public void GiveMeAWayToPersistData(ICanPersistProducts storage, string catalogName)
        {
            Storage = storage;
            ListProd = Storage.GetAllFromCatalogNamed(catalogName);
        }
    }






    public static class Extensions
    {
        public static bool Contains(this IList<Product> lp, string reference)
        {
            return (lp.Where(p => p.Reference == reference).Count() == 1);            
        }

        public static double GetPrice(this IList<Product> lp, string reference)
        {
            return lp.Where(p => p.Reference == reference).First().Price;
        }
    }
}
