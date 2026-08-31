[![](https://img.shields.io/nuget/v/soenneker.digitalocean.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.digitalocean.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.digitalocean.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.digitalocean.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.digitalocean.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.digitalocean.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.digitalocean.openapiclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.digitalocean.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.DigitalOcean.OpenApiClientUtil

Provides a lazily created, cached DigitalOcean API client backed by the configured DigitalOcean HTTP provider.

## Installation

```bash
dotnet add package Soenneker.DigitalOcean.OpenApiClientUtil
```

## Configuration

```json
{
  "DigitalOcean": {
    "AccessToken": "your-personal-access-token"
  }
}
```

Store the token in user secrets, environment-backed configuration, or a secret manager rather than source control.

## Registration

```csharp
using Soenneker.DigitalOcean.OpenApiClientUtil.Registrars;

services.AddDigitalOceanOpenApiClientUtilAsScoped();
```

The scoped registration creates one cached generated client per dependency-injection scope while retaining the underlying DigitalOcean HTTP client as a singleton. Disposing the util at the end of a scope does not destroy that shared transport.

Use `AddDigitalOceanOpenApiClientUtilAsSingleton()` when the generated-client holder should also live for the application lifetime.

## Usage

```csharp
using Soenneker.DigitalOcean.OpenApiClient;
using Soenneker.DigitalOcean.OpenApiClient.Models;
using Soenneker.DigitalOcean.OpenApiClientUtil.Abstract;

public sealed class DropletReader(IDigitalOceanOpenApiClientUtil clientUtil)
{
    public async Task<IReadOnlyList<Droplet>> GetPage(
        int page,
        CancellationToken cancellationToken)
    {
        DigitalOceanOpenApiClient client = await clientUtil.Get(cancellationToken);

        AllDropletsResponse? response = await client.V2.Droplets.GetAsync(
            request =>
            {
                request.QueryParameters.Page = page;
                request.QueryParameters.PerPage = 50;
            },
            cancellationToken);

        return response?.Droplets ?? [];
    }
}
```

`Get` returns the same generated client for the lifetime of the util. Pass cancellation tokens to both `Get` and API operations. Pagination remains explicit; inspect response links or metadata and request additional pages as needed.

DigitalOcean error responses are surfaced through the generated client’s Kiota error models. Handle authentication failures, rate limiting, and transient transport errors according to the caller’s retry policy.

Optional `DigitalOcean:ClientBaseUrl`, `DigitalOcean:AuthHeaderName`, and `DigitalOcean:AuthHeaderValueTemplate` settings are supported by the transport package. Treat them as trusted configuration because they determine where and how credentials are sent.
