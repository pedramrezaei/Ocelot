using Ocelot.Responses;
using System.Security.Claims;
using System.Collections.Generic;

namespace Ocelot.Authorisation
{
    public interface IScopesAuthoriser
    {
        Response<bool> Authorise(ClaimsPrincipal claimsPrincipal, List<string> routeAllowedScopes);
    }
}
