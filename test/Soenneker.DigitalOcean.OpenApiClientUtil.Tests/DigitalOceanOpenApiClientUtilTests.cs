using Soenneker.DigitalOcean.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.DigitalOcean.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class DigitalOceanOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IDigitalOceanOpenApiClientUtil _openapiclientutil;

    public DigitalOceanOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IDigitalOceanOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
