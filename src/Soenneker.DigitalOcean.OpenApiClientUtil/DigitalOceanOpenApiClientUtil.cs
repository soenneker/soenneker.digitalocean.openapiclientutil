using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.DigitalOcean.HttpClients.Abstract;
using Soenneker.DigitalOcean.OpenApiClientUtil.Abstract;
using Soenneker.DigitalOcean.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.DigitalOcean.OpenApiClientUtil;

public sealed class DigitalOceanOpenApiClientUtil : IDigitalOceanOpenApiClientUtil
{
    private readonly AsyncSingleton<DigitalOceanOpenApiClient> _client;

    public DigitalOceanOpenApiClientUtil(IDigitalOceanOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<DigitalOceanOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("DigitalOcean:AccessToken");
            string authHeaderName = configuration["DigitalOcean:AuthHeaderName"] ?? "Authorization";
            string authHeaderValueTemplate = configuration["DigitalOcean:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerName: authHeaderName, headerValue: authHeaderValue),
                httpClient: httpClient);

            return new DigitalOceanOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<DigitalOceanOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
