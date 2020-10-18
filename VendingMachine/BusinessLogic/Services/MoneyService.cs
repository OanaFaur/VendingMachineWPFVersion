using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class MoneyService : IMoneyService
    {
        private IMoneyRepository repo = new MoneyRepository();

        public List<Moneys> GetMoneyList()
        {
            return repo.Moneys.ToList();
        }
    }
}
