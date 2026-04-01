using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Coldmart.Core.Data.Extensions;

[ExcludeFromCodeCoverage]
public static class DbContextOptionsExtensions
{
    public static void ConfigureDbContextOptions(
        this DbContextOptionsBuilder options,
        IConfiguration configuration,
        IHostEnvironment environment)
    {
        options.UseLazyLoadingProxies();

        if (environment.IsDevelopment())
        {
            options.UseSqlite(configuration.GetConnectionString("ColdmartDb"));
        }
        else
        {
            options.UseSqlServer(configuration.GetConnectionString("ColdmartDb"));
        }
    }
}
