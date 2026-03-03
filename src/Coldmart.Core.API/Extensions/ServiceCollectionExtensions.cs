using System.Diagnostics.CodeAnalysis;
using Coldmart.Core.Data.Extensions;
using Coldmart.Core.Extensions;
using Coldmart.Core.Services;

namespace Coldmart.Core.API.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigurarInjecaoDependencia(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        services
            .AddCoreData(configuration, environment.IsDevelopment());

        services
            .AddCoreServices(configuration);

        services.AddScoped<IAutenticacaoService, AutenticacaoService>();

        return services;
    }
}
