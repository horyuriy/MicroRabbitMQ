using MediatR;
using MicriRabbit.Transfer.Domain.Events;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Transfer.Application.Services;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Data.Repository;
using MicroRabbit.Transfer.Domain.EventHandlers;
using MicroRabbit.Transfer.Domain.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddDbContext<TransferDbContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("TransferDbConnection"))
);
builder.Services.AddTransient<ITransferRepository, TransferRepository>();
builder.Services.AddTransient<ITransferService, TransferService>();
builder.Services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
{
    var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
    return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
});
builder.Services.AddTransient<TransferEventHandler>();
builder.Services.AddTransient<IEventHandler<MicriRabbit.Transfer.Domain.Events.TransferCreatedEvent>, MicroRabbit.Transfer.Domain.EventHandlers.TransferEventHandler>();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Transfer Microservice", Version = "v1" });
}
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transfer Microservices V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
ConfigureEventBus(app);

void ConfigureEventBus(WebApplication app)
{
    var eventBus = app.Services.GetRequiredService<IEventBus>();
    eventBus.Subscribe<TransferCreatedEvent,TransferEventHandler>();
}

app.Run();
