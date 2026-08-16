[![](https://img.shields.io/nuget/v/soenneker.digitalocean.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.digitalocean.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.digitalocean.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.digitalocean.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.digitalocean.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.digitalocean.openapiclientutil/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.DigitalOcean.OpenApiClientUtil
### A thread-safe utility for obtaining DigitalOcean's OpenApiClient singleton.

## Installation

```
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

The client sends the token as `Authorization: Bearer <token>`.
