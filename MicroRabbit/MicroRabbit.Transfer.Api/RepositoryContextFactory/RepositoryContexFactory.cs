using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Transfer.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MicroRabbit.Banking.Api.RepositoryContextFactory
{
    public class RepositoryContexFactory : IDesignTimeDbContextFactory<TransferDbContext>
    {
        public TransferDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();

            var builder = new DbContextOptionsBuilder<TransferDbContext>()
                .UseSqlServer(configuration.GetConnectionString("TransferDbConnection"),
                b => b.MigrationsAssembly("MicroRabbit.Transfer.Data"));

            return new TransferDbContext(builder.Options);
        }
    }
}
