using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository repo = new ProductRepository();

        public List<Product> GetProductList()
        {
            return repo.Products.ToList();
        }
    }
}
