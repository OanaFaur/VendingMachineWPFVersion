using System.Collections.Generic;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        void UpdateQuantity(Product p);
    }
}