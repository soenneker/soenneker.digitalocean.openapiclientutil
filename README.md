[![](https://img.shields.io/nuget/v/soenneker.digitalocean.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.digitalocean.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.digitalocean.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.digitalocean.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.digitalocean.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.digitalocean.openapiclientutil/)

# Soenneker.DigitalOcean.OpenApiClientUtil

Exposes a cached OpenAPI client instance.

## Install

```bash
dotnet add package Soenneker.DigitalOcean.OpenApiClientUtil
```

## Quick start

```csharp
using Soenneker.DigitalOcean.OpenApiClientUtil.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddDigitalOceanOpenApiClientUtilAsSingleton();
```

Adds `DigitalOceanOpenApiClientUtil` as a singleton service.

## What you get

- `IDigitalOceanOpenApiClientUtil` — Exposes a cached OpenAPI client instance.
- `DigitalOceanOpenApiClientUtilRegistrar` — Registers the OpenAPI client utility for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `DigitalOceanOpenApiClientUtilRegistrar.AddDigitalOceanOpenApiClientUtilAsSingleton(services)` | Adds `DigitalOceanOpenApiClientUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `DigitalOceanOpenApiClientUtilRegistrar.AddDigitalOceanOpenApiClientUtilAsScoped(services)` | Adds `DigitalOceanOpenApiClientUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Dispose instances you own when their scope ends so held resources can be released.
