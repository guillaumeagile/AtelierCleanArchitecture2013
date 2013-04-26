using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashier.UseCases;
using Cashier.Model;
using System.Threading;

namespace Cashier.Persistence.SQLserver
{
    public class SqlDataAccess : ICanPersistProducts
    {
        IDictionary<string, Product> storeProducts;

        public SqlDataAccess()
        {
            Thread.Sleep(2000);
            storeProducts = new Dictionary<string, Product>();
        }

        public Model.Product Get(string reference, string catalogName)
        {
            Thread.Sleep(2000);
            return storeProducts[reference];
        }

        public IList<Model.Product> GetManyHavingPriceInferior(decimal maxiPrice, string catalogName)
        {
            throw new NotImplementedException();
        }

        public IList<Model.Product> GetAllFromCatalogNamed(string catalogName)
        {
            Thread.Sleep(2000);
            return storeProducts.Select(k => k.Value).ToList();
        }

        public bool Put(Model.Product p, string catalogName)
        {
            Thread.Sleep(2000);
            if (storeProducts.ContainsKey(p.Reference))
                storeProducts[p.Reference] = p;
            else
                storeProducts.Add(p.Reference, p);
            return true;
        }

        public bool Delete(string reference, string catalogName)
        {
            Thread.Sleep(2000);
            if (!storeProducts.ContainsKey(reference))
                return false;
            else
                storeProducts.Remove(reference);
            return true;
        }
    }
}
