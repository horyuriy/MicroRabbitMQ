using MediatR;
using MicriRabbit.Banking.Domain.Commands;
using MicriRabbit.Banking.Domain.Events;
using MicroRabbit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicriRabbit.Banking.Domain.CommandHandlers
{
    public class TranferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {
        private IEventBus _bus;

        public TranferCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new TransferCreatedEvent(request.From, request.To, request.Amount));
            // publish event to RabbbitMQ
            return Task.FromResult(true);
        }
    }
}
