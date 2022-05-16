using Yarp.ReverseProxy.Configuration;

namespace Gate.Filters;

public class TyeFilters : IProxyConfigFilter
{
    public TyeFilters(IConfiguration configuration) => _configuration = configuration;
    private IConfiguration _configuration { get; }
    public ValueTask<ClusterConfig> ConfigureClusterAsync(ClusterConfig origCluster, CancellationToken cancel)
    {
        var serviceEndpoint = _configuration.GetServiceUri(origCluster.ClusterId);
        if (serviceEndpoint is not null)
        {
            return new ValueTask<ClusterConfig>(origCluster with
            {
                Destinations = new Dictionary<string, DestinationConfig>(StringComparer.OrdinalIgnoreCase){
                    {"tye-endpoint", new DestinationConfig { Address = serviceEndpoint.ToString()}}
                }
            });
        }
        return new ValueTask<ClusterConfig>(origCluster);
    }

    public ValueTask<RouteConfig> ConfigureRouteAsync(RouteConfig route,ClusterConfig cluster,CancellationToken cancel) 
        => new ValueTask<RouteConfig>(route);

}
