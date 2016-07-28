using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Data;
using FlooringProgram.Models;

namespace FlooringProgram.BLL
{
    public class ProductManager
    {
        private readonly IProductRepository _productRepo;

        public ProductManager()
        {
            _productRepo = RepositoryFactory.GetProductRepo();
        }

        public ProductResponse GetProductByType(string type)
        {
            var response = new ProductResponse();
            var product = _productRepo.GetProductByName(type);

            try
            {
                if (product == null)
                {
                    response.Success = false;
                    response.Message = "Invalid product type, try again...";
                }
                else
                {
                    response.Success = true;
                    response.ProductList = new List<Product>();
                }
            }
            catch
            {
                response.Success = false;
                response.Message = "Something terrible went wrong, lets go back...";
            }

            return response;
        }

        public ProductResponse GetAllProducts()
        {
            ProductResponse result = new ProductResponse();

            return result;
        }

        public Product GetProductBy(string name)
        {
            return _productRepo.GetProductByName(name);
        }

    }
}
