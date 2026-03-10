using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PSQL.Infrastructure.DbContexts;

namespace PSQL.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPSQLInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var currencyConnectionString = configuration.GetConnectionString("CurrencyConnection");

            services.AddDbContext<CurrencyDbContext>(options =>
                options.UseNpgsql(currencyConnectionString, npgsql =>
                {
                    npgsql.MigrationsAssembly(typeof(CurrencyDbContext).Assembly.FullName);
                }));

            return services;
        }
    }
}
