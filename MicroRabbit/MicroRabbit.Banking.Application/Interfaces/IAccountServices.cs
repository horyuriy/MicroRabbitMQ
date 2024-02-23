using MicriRabbit.Banking.Domain.Models;
using MicroRabbit.Banking.Application.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Application.Interfaces
{
    public interface IAccountServices
    {
        IEnumerable<Account> GetAccounts();
        void Tranfer(AccoutTransfer accoutTransfer);
    }
}
