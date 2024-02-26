using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private ITransferRepository _transferRepository;
        private IEventBus _bus;

        public TransferService(ITransferRepository transferRepository,IEventBus bus)
        {
            _transferRepository = transferRepository;
            _bus = bus;
        }
        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return (_transferRepository.GetTransferLogs());
        }
    }
}
