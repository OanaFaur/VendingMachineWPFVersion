using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public interface IMoneyRepository
    {
        IEnumerable<Moneys> Moneys { get; }
        void UpdateMoneyQuantity(Moneys m);
    }
}
