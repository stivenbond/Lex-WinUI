using Microsoft.Extensions.DependencyInjection;
using Lex_Core.Configuration;
using Lex_Core.Data;
using Lex_Core;

namespace Lex_Core.Common;

/// <summary>
/// Extension methods for setting up Lex-Core services in an <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds Lex-Core services, including DataContext, Configuration, and MediatR, to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddLexCore(this IServiceCollection services)
    {
        // 1. Register Configuration Service
        services.AddSingleton<IConfigurationService, ConfigurationService>();
        
        // 2. Register DataContext
        // Note: The DataContext itself handles its own path logic, 
        // but we could also pass the config here if desired.
        services.AddDbContext<DataContext>();

        // 3. Register MediatR
        // Scans the current assembly (Lex-Core) for Handlers, Behaviors, and Validators.
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(CoreMarker.Assembly);
        });

        return services;
    }
}
