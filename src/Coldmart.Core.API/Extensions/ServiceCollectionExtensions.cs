using System.Diagnostics.CodeAnalysis;
using Coldmart.Core.Data.Extensions;
using Coldmart.Core.Extensions;
using Coldmart.Core.Services;

namespace Coldmart.Core.API.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigurarInjecaoDependencia(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddCoreData(configuration);

        services
            .AddCoreServices(configuration)
            .AddCoreSeeder();

        services.AddScoped<IAutenticacaoService, AutenticacaoService>();

        return services;
    }
}
