using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        VendingMachineContext context = new VendingMachineContext();

        public IEnumerable<Product> Products
        {
            get
            {
                return context.Products.ToList();
            }
        }

        public void UpdateQuantity(Product p)
        {
            context.Entry(p).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
