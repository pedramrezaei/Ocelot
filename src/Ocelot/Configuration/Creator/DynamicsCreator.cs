using Ocelot.Configuration.Builder;
using Ocelot.Configuration.File;
using System.Collections.Generic;
using System.Linq;

namespace Ocelot.Configuration.Creator
{
    public class DynamicsCreator : IDynamicsCreator
    {
        private readonly IRateLimitOptionsCreator _rateLimitOptionsCreator;

        public DynamicsCreator(IRateLimitOptionsCreator rateLimitOptionsCreator)
        {
            _rateLimitOptionsCreator = rateLimitOptionsCreator;
        }

        public List<ReRoute> Create(FileConfiguration fileConfiguration)
        {
            return fileConfiguration.DynamicReRoutes
                .Select(dynamic => SetUpDynamicReRoute(dynamic, fileConfiguration.GlobalConfiguration))
                .ToList();
        }

        private ReRoute SetUpDynamicReRoute(FileDynamicReRoute fileDynamicReRoute, FileGlobalConfiguration globalConfiguration)
        {
            var rateLimitOption = _rateLimitOptionsCreator
                .Create(fileDynamicReRoute.RateLimitRule, globalConfiguration);

            var downstreamReRoute = new DownstreamReRouteBuilder()
                .WithEnableRateLimiting(rateLimitOption.EnableRateLimiting)
                .WithRateLimitOptions(rateLimitOption)
                .WithServiceName(fileDynamicReRoute.ServiceName)
                .Build();

            var reRoute = new ReRouteBuilder()
                .WithDownstreamReRoute(downstreamReRoute)
                .Build();

            return reRoute;
        }
    }
}
