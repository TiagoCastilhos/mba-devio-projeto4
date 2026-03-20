using Coldmart.Core.Data.Contexts;
using Coldmart.Core.Data.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Coldmart.Core.API.Extensions;

public static class WebApplicationExtensions
{
    public static async Task<WebApplication> AplicarMigracoesAsync(this WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();

        var coreDbContext = scope.ServiceProvider.GetRequiredService<ICoreDbContext>();
        await coreDbContext.Database.MigrateAsync(CancellationToken.None);

        return app;
    }

    public static async Task SeedBancoDeDadosAsync(this WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();

        var seeder = scope.ServiceProvider.GetRequiredService<IDbSeeder>();

        await seeder.SeedAsync(CancellationToken.None);
    }
}