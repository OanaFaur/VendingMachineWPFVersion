using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MoneyRepository : IMoneyRepository
    {
        VendingMachineContext context = new VendingMachineContext();

        // public IEnumerable<Moneys> Moneys => throw new NotImplementedException();

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
