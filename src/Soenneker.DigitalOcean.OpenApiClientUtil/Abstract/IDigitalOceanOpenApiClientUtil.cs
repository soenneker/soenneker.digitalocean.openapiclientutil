using Soenneker.DigitalOcean.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Soenneker.DigitalOcean.OpenApiClientUtil.Abstract;
/// <summary>
/// Provides access to a cached, configured DigitalOcean OpenAPI client.
/// </summary>
public interface IDigitalOceanOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured DigitalOcean OpenAPI client for this utility's lifetime.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested digital Ocean OpenAPI Client.</returns>
    ValueTask<DigitalOceanOpenApiClient> Get(CancellationToken cancellationToken = default);
}
