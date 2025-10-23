using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using UchetOnline.Infrastructure.Data;

namespace UchetOnline.Infrastructure.Extensions;

/// <summary>
///     Extension helpers for configuring infrastructure services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    ///     Adds the EF Core context configured for PostgreSQL.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <param name="configuration">Application configuration.</param>
    /// <returns>Service collection for chaining.</returns>
    public static IServiceCollection AddUchetOnlineDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default")
                               ?? configuration["Database:ConnectionString"]
                               ?? "Host=localhost;Port=5432;Database=uchetonline;Username=postgres;Password=postgres";

        services.AddDbContextPool<UchetOnlineContext>(options =>
        {
            options.UseNpgsql(connectionString, builder =>
            {
                builder.MigrationsAssembly(typeof(UchetOnlineContext).Assembly.FullName);
                builder.EnableRetryOnFailure();
            });
            options.EnableSensitiveDataLogging(false);
        });

        services.AddLogging(loggingBuilder =>
        {
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .WriteTo.File("logs/uchetonline.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog(logger, dispose: true);
        });

        return services;
    }
}
