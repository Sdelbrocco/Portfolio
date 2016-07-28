using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public class ProductRepository : IProductRepository
    {
        protected static List<Product> Products { get; private set; }

        public ProductRepository()
        {
            Products = ReadFromFile();
        }

        private List<Product> ReadFromFile()
        {
            var result = new List<Product>();
            string FILENAME = @"Datafiles\Products.txt";
            using (StreamReader sr = File.OpenText(FILENAME))
            {
                string holder;
                List<string> holders = new List<string>();
                while ((holder = sr.ReadLine()) != null)
                {
                    holders.Add(holder);
                    for (int i = 1; i < holders.Count; i++ )
                    {
                        string[] fields = holder.Split(',');
                        Product newProduct = new Product();
                        newProduct.ProductType = fields[0];
                        newProduct.CostPerSquareFoot = decimal.Parse(fields[1]);
                        newProduct.LaborCostPerSquareFoot = decimal.Parse(fields[2]);
                        result.Add(newProduct);
                    }
                }
            }
            return result;
        }

        public Product GetProductByName(string name)
        {
            var product = (Products.Where(p => name == p.ProductType)).FirstOrDefault();

            return product;
        }

        public List<Product> GetAllProducts(DateTime dateTime)
        {
            return Products;
        }
    }
}
