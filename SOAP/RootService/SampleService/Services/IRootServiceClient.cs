using RootServiceNamespace;

namespace SampleService.Services;

public interface IRootServiceClient
{
    public RootServiceNamespace.RootServiceClient RootServiceClient { get; }

    public Task<IEnumerable<WeatherForecast>> Get();
}