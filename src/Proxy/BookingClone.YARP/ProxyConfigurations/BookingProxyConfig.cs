using Yarp.ReverseProxy.Configuration;
using Yarp.ReverseProxy.LoadBalancing;
using Yarp.ReverseProxy.Transforms;

namespace BookingClone.YARP.ProxyConfigurations;

internal sealed class BookingProxyConfig : IProxyConfigProvider
{
    private CustomMemoryConfig _config;

    public BookingProxyConfig(IConfiguration configuration)
    {
        // Load a basic configuration
        // Should be based on your application needs.
        var routeConfig = new RouteConfig
        {
            RouteId = "MainRoute",
            ClusterId = "MainCluster",
            Match = new RouteMatch
            {
                Path = "/{**catch-all}"
            }
        }
        .WithTransformResponseHeader(headerName: "Source", value: "YARP", append: true);

        var routeConfigs = new[] { routeConfig };

        var clusterConfigs = new[]
        {
            new ClusterConfig
            {
                ClusterId = "MainCluster",
                LoadBalancingPolicy = LoadBalancingPolicies.RoundRobin,
                Destinations = new Dictionary<string, DestinationConfig>
                {
                    { "destination1", new DestinationConfig { Address = configuration.GetConnectionString("Backend")! } },
                }
            }
        };

        _config = new CustomMemoryConfig(routeConfigs, clusterConfigs);
    }

    public IProxyConfig GetConfig() => _config;

    /// <summary>
    /// By calling this method from the source we can dynamically adjust the proxy configuration.
    /// Since our provider is registered in DI mechanism it can be injected via constructors anywhere.
    /// </summary>
    public void Update(IReadOnlyList<RouteConfig> routes, IReadOnlyList<ClusterConfig> clusters)
    {
        var oldConfig = _config;
        _config = new CustomMemoryConfig(routes, clusters);
        oldConfig.SignalChange();
    }
}
