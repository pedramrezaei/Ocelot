using Ocelot.Configuration;
using Ocelot.DownstreamRouteFinder.UrlMatcher;
using System.Collections.Generic;

namespace Ocelot.DownstreamRouteFinder
{
    public class DownstreamRoute
    {
        public DownstreamRoute(List<PlaceholderNameAndValue> templatePlaceholderNameAndValues, ReRoute reRoute)
        {
            TemplatePlaceholderNameAndValues = templatePlaceholderNameAndValues;
            ReRoute = reRoute;
        }

        public List<PlaceholderNameAndValue> TemplatePlaceholderNameAndValues { get; }
        public ReRoute ReRoute { get; }
    }
}
