using MicriRabbit.Banking.Domain.Interfaces;
using MicriRabbit.Banking.Domain.Models;
using MicroRabbit.Banking.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private BankingDbContext _context;

        public AccountRepository(BankingDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Account> GetAccounts()
        {
            return _context.Accounts;

        }
    }
}
