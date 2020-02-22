namespace Ocelot.Configuration
{
    public class ReRouteOptions
    {
        public ReRouteOptions(bool isAuthenticated, bool isAuthorised, bool isCached, bool isEnableRateLimiting, bool useServiceDiscovery)
        {
            IsAuthenticated = isAuthenticated;
            IsAuthorised = isAuthorised;
            IsCached = isCached;
            EnableRateLimiting = isEnableRateLimiting;
            UseServiceDiscovery = useServiceDiscovery;
        }

        public bool IsAuthenticated { get; }
        public bool IsAuthorised { get; }
        public bool IsCached { get; }
        public bool EnableRateLimiting { get; }
        public bool UseServiceDiscovery { get; }
    }
}
