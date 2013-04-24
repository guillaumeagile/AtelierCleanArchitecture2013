using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashier.Model;

namespace Cashier.UseCases
{
    public interface ICanPersistProducts
    {
        Product Get(string reference, string catalogName);
        IList<Product> GetManyHavingPriceInferior(decimal maxiPrice, string catalogName);
         IList<Product> GetAllFromCatalogNamed(string catalogName);

         bool Put(Product p, string catalogName);
         bool Delete(string reference, string catalogName);
    }
}
