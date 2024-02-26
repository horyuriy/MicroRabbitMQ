using MediatR;
using MicriRabbit.Banking.Domain.CommandHandlers;
using MicriRabbit.Banking.Domain.Commands;
using MicriRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Transfer.Application.Services;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Data.Repository;
using MicroRabbit.Transfer.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Infra.IoC
{
    public  class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {

            //Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

            
            //Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand,bool>, TranferCommandHandler>();
            
            //Application Services
            services.AddTransient<IAccountServices,AccountServices>();
            
            
            
            //Domain Services
            services.AddTransient<IAccountRepository, AccountRepository>();
           

            //Data
           ///services.AddTransient<BankingDbContext>();
            ///services.AddTransient<TransferDbContext>();

        
        }
    }
}
