using Soenneker.DigitalOcean.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Soenneker.DigitalOcean.OpenApiClientUtil.Abstract;
/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IDigitalOceanOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured digital Ocean OpenAPI Client used by the Digital Ocean OpenAPI Client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested digital Ocean OpenAPI Client.</returns>
    ValueTask<DigitalOceanOpenApiClient> Get(CancellationToken cancellationToken = default);
}
