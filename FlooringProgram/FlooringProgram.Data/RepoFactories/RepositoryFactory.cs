using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Data
{
    public static class RepositoryFactory
    {
        public static IOrderRepository GetOrderRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];
            if (mode.ToUpper() == "TEST")
            {
                return new MockOrderRepository();
            }
            return new OrderRepository();
        }

        public static IProductRepository GetProductRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];
            if (mode.ToUpper() == "TEST")
            {
                return new MockProductRepository();
            }
            return new ProductRepository();
        }

        public static ITaxRepository GetTaxRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];
            if (mode.ToUpper() == "TEST")
            {
                return new MockTaxRepository();
            }
            return new TaxRepository();
        }
    }
}
