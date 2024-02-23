using MicriRabbit.Banking.Domain.Commands;
using MicriRabbit.Banking.Domain.Interfaces;
using MicriRabbit.Banking.Domain.Models;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.ModelsDTO;
using MicroRabbit.Domain.Core.Bus;

namespace MicroRabbit.Banking.Application.Services
{
    public class AccountServices : IAccountServices
    {
        private IAccountRepository _accountRepository;
        private IEventBus _bus;

        public AccountServices(IAccountRepository accountRepository,IEventBus bus)
        {
            _accountRepository = accountRepository;
            _bus = bus;
        }
        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Tranfer(AccoutTransfer accoutTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                accoutTransfer.FromAccount, 
                accoutTransfer.ToAccount,
                accoutTransfer.TransferAmount);
            _bus.SendCommand(createTransferCommand);
        }
    }
}
