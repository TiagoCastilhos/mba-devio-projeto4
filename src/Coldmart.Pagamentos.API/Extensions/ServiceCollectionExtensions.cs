using System.Diagnostics.CodeAnalysis;
using Coldmart.Auth.Data.Extensions;
using Coldmart.Core.Extensions;
using Coldmart.Pagamentos.Business.Services;
using Coldmart.Pagamentos.Data.Extensions;

namespace Coldmart.Pagamentos.API.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigurarInjecaoDependencia(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuthData(configuration)
            .AddPagamentosData(configuration);

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<PagamentosService>();
        });

        services
            .AddCoreServices(configuration);

        return services;
    }
}
