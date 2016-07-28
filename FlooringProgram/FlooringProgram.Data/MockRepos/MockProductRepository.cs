using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public class MockProductRepository : IProductRepository
    {
        private readonly List<Product> products;

        public MockProductRepository()
        {
            products = new List<Product>()
            {
                new Product() {ProductType = "WOOD", CostPerSquareFoot = 20.00m, LaborCostPerSquareFoot = 10.00m},
                new Product() {ProductType = "METAL", CostPerSquareFoot = 15.00m, LaborCostPerSquareFoot = 9.50m},
                new Product() {ProductType = "TILE", CostPerSquareFoot = 25.00m, LaborCostPerSquareFoot = 15.50m},
                new Product() {ProductType = "MARBLE", CostPerSquareFoot = 50.00m, LaborCostPerSquareFoot = 20.00m},
            };
        }

        public Product GetProductByName(string name)
        {
            return products.FirstOrDefault(p => p.ProductType == name);
        }

        public List<Product> GetAllProducts(DateTime dateTime)
        {
            return products;
        }
        
    }
}
