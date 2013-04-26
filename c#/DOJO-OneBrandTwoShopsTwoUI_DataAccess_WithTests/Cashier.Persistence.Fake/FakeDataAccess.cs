using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


using Cashier.UseCases;
using Cashier.Model;

namespace Cashier.Persistence.Fake
{
    public class FakeDataAccess : ICanPersistProducts
    {
        IDictionary<string, Product> storeProducts;

        public FakeDataAccess()
        {
            storeProducts = new Dictionary<string, Product>();
        }

        public Model.Product Get(string reference, string catalogName)
        {
            return storeProducts[reference + "_"];
        }

        public IList<Model.Product> GetManyHavingPriceInferior(decimal maxiPrice, string catalogName)
        {
            throw new NotImplementedException();
        }

        public IList<Model.Product> GetAllFromCatalogNamed(string catalogName)
        {
            return storeProducts.Select( k => k.Value).ToList();
        }

        public bool Put(Model.Product p, string catalogName)
        {
            if (storeProducts.ContainsKey(p.Reference))
                storeProducts[p.Reference] = p;
            else
                storeProducts.Add(p.Reference, p);
            return true;
        }

        public bool Delete(string reference, string catalogName)
        {
            if (!storeProducts.ContainsKey(reference))
                return false;
            else
                storeProducts.Remove(reference);
            return true;
        }
    }
}
