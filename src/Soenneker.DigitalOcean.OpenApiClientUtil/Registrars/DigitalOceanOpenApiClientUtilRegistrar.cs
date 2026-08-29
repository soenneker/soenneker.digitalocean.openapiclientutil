using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.DigitalOcean.HttpClients.Registrars;
using Soenneker.DigitalOcean.OpenApiClientUtil.Abstract;

namespace Soenneker.DigitalOcean.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class DigitalOceanOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="DigitalOceanOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddDigitalOceanOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddDigitalOceanOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IDigitalOceanOpenApiClientUtil, DigitalOceanOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="DigitalOceanOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddDigitalOceanOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddDigitalOceanOpenApiHttpClientAsSingleton()
                .TryAddScoped<IDigitalOceanOpenApiClientUtil, DigitalOceanOpenApiClientUtil>();

        return services;
    }
}
