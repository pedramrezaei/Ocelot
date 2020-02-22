using Ocelot.Configuration.File;
using Ocelot.Values;
using System.Collections.Generic;
using System.Net.Http;

namespace Ocelot.Configuration
{
    public class ReRoute
    {
        public ReRoute(List<DownstreamReRoute> downstreamReRoute,
            List<AggregateReRouteConfig> downstreamReRouteConfig,
            List<HttpMethod> upstreamHttpMethod,
            UpstreamPathTemplate upstreamTemplatePattern,
            string upstreamHost,
            string aggregator)
        {
            UpstreamHost = upstreamHost;
            DownstreamReRoute = downstreamReRoute;
            DownstreamReRouteConfig = downstreamReRouteConfig;
            UpstreamHttpMethod = upstreamHttpMethod;
            UpstreamTemplatePattern = upstreamTemplatePattern;
            Aggregator = aggregator;
        }

        public UpstreamPathTemplate UpstreamTemplatePattern { get; }
        public List<HttpMethod> UpstreamHttpMethod { get; }
        public string UpstreamHost { get; }
        public List<DownstreamReRoute> DownstreamReRoute { get; }
        public List<AggregateReRouteConfig> DownstreamReRouteConfig { get; }
        public string Aggregator { get; }
    }
}
