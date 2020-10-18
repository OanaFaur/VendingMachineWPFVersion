using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IMoneyRepository
    {
        IEnumerable<Moneys> Moneys { get; }
        void UpdateMoneyQuantity(Moneys p);
    }
}
