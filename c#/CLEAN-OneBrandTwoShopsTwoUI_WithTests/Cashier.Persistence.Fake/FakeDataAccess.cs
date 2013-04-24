using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashier.UseCases;

namespace Cashier.Persistence.Fake
{
    public class FakeDataAccess : ICanPersistProducts
    {
        public Model.Product Get(string reference, string catalogName)
        {
            throw new NotImplementedException();
        }

        public IList<Model.Product> GetManyHavingPriceInferior(decimal maxiPrice, string catalogName)
        {
            throw new NotImplementedException();
        }

        public IList<Model.Product> GetAllFromCatalogNamed(string catalogName)
        {
            throw new NotImplementedException();
        }

        public bool Put(Model.Product p, string catalogName)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string reference, string catalogName)
        {
            throw new NotImplementedException();
        }
    }
}
