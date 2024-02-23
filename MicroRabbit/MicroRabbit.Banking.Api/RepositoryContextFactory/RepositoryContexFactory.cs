using MicroRabbit.Banking.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MicroRabbit.Banking.Api.RepositoryContextFactory
{
    public class RepositoryContexFactory : IDesignTimeDbContextFactory<BankingDbContext>
    {
        public BankingDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();

            var builder = new DbContextOptionsBuilder<BankingDbContext>()
                .UseSqlServer(configuration.GetConnectionString("BankingDbConnection"),
                b => b.MigrationsAssembly("MicroRabbit.Banking.Api"));

            return new BankingDbContext(builder.Options);
        }
    }
}
