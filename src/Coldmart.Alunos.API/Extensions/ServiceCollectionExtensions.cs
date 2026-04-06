using System.Diagnostics.CodeAnalysis;
using Coldmart.Alunos.Business.Services;
using Coldmart.Alunos.Data.Extensions;
using Coldmart.Core.Extensions;

namespace Coldmart.Alunos.API.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigurarInjecaoDependencia(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAlunosData(configuration);

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<AlunosService>();
        });

        services
            .AddCoreServices(configuration);

        return services;
    }
}
