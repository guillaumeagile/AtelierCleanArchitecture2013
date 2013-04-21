using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cashier.Data;

namespace Cashier.DataAccess
{
    public class Library
    {
        List<Product> productList;

        public Library()
        {
             productList = new List<Product>();
        }

        public List<Product> Init(string shopName)
        {
           
            if (shopName == "record store Paris")
            {
                productList.Add(new Product("bowie", 7.5, 1));
                productList.Add(new Product("glass", 6.65, 2));
                productList.Add(new Product("moby", 8, 3));

            }
            if (shopName == "café Alma Paris")
            {
                productList.Add(new Product("tea", 1, 4));
                productList.Add(new Product("egg", 1.3, 5));
                productList.Add(new Product("cof", 1.6, 6));
            }
            else
            {
                productList.Add(new Product("tea", 0.5, 7));
                productList.Add(new Product("egg", 0.65, 8));
                productList.Add(new Product("cof", 0.8, 9));
            }
            return productList;
        }

        public void AddProduct(Product p)
        {
            productList.Add(p);
        }

        public List<Product> Get()
        {
            return productList;
        }
    }
}
