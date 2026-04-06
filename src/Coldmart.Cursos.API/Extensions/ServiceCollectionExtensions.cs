using System.Diagnostics.CodeAnalysis;
using Coldmart.Core.Extensions;
using Coldmart.Cursos.Business.Services;
using Coldmart.Cursos.Data.Extensions;

namespace Coldmart.Cursos.API.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigurarInjecaoDependencia(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddCursosData(configuration);

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<CursosService>();
        });

        services
            .AddCoreServices(configuration);

        return services;
    }
}
