using System.Diagnostics.CodeAnalysis;
using Coldmart.Core.Data.Extensions;
using Coldmart.Core.Data.Seeders;
using Coldmart.Cursos.Data.Contexts;
using Coldmart.Cursos.Data.Seeders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Coldmart.Cursos.Data.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCursosData(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ICursosDbContext, CursosDbContext>(options =>
        {
            options.ConfigureDbContextOptions(configuration);
        });

        services.AddScoped<IDbSeeder, DbSeeder>();
        services.AddScoped<IDbContextSeeder, CursosDbContextSeeder>();

        return services;
    }
}
