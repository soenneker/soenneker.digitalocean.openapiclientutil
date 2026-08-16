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
    ValueTask<DigitalOceanOpenApiClient> Get(CancellationToken cancellationToken = default);
}
