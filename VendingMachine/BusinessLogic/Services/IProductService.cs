using System.Collections.Generic;
using DataAccess.Models;

namespace BusinessLogic.Services
{
    public interface IProductService
    {
        List<Product> GetProductList();
    }
}