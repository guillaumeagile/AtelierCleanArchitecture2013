using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashier.Boundaries;

namespace Cashier.Business
{
    public  class RulesFactory
    {

        public RulesFactory()
        {
            
        }
        public ICanDoCalculus GetCalculateur(string shopName)
        {
            return null;//new Cashier.Business.RecordStore;
        }
    }
}
