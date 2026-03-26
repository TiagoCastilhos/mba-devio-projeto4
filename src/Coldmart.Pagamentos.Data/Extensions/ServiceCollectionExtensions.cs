using System.Diagnostics.CodeAnalysis;
using Coldmart.Core.Data.Extensions;
using Coldmart.Core.Data.Seeders;
using Coldmart.Pagamentos.Data.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Coldmart.Pagamentos.Data.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPagamentosData(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IPagamentosDbContext, PagamentosDbContext>(options =>
        {
            options.ConfigureDbContextOptions(configuration);
        });

        services.AddScoped<IDbSeeder, DbSeeder>();

        return services;
    }
}
