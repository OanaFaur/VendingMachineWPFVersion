using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class MoneyRepository : IMoneyRepository
    {
        VendingMachineContext context = new VendingMachineContext();

        public IEnumerable<Moneys> Moneys
        {
            get
            {
                return context.Moneys.ToList();
            }
        }

        public void UpdateMoneyQuantity(Moneys m)
        {
            context.Entry(m).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
