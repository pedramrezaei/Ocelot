using Ocelot.DownstreamRouteFinder.UrlMatcher;
using Ocelot.Responses;
using System.Security.Claims;
using System.Collections.Generic;

namespace Ocelot.Authorisation
{
    public interface IClaimsAuthoriser
    {
        Response<bool> Authorise(
            ClaimsPrincipal claimsPrincipal,
            Dictionary<string, string> routeClaimsRequirement,
            List<PlaceholderNameAndValue> urlPathPlaceholderNameAndValues
        );
    }
}
