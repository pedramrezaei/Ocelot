using Ocelot.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Ocelot.Infrastructure.Claims.Parser;

namespace Ocelot.Authorisation
{
    public class ScopesAuthoriser : IScopesAuthoriser
    {
        private const string Scope = "scope";
        private readonly IClaimsParser _claimsParser;

        public ScopesAuthoriser(IClaimsParser claimsParser)
        {
            _claimsParser = claimsParser;
        }

        public Response<bool> Authorise(ClaimsPrincipal claimsPrincipal, List<string> routeAllowedScopes)
        {
            if (routeAllowedScopes == null || routeAllowedScopes.Count == 0)
            {
                return new OkResponse<bool>(true);
            }

            var values = _claimsParser.GetValuesByClaimType(claimsPrincipal.Claims, Scope);

            if (values.IsError)
            {
                return new ErrorResponse<bool>(values.Errors);
            }

            var userScopes = values.Data;

            var matchesScopes = routeAllowedScopes.Intersect(userScopes).ToList();

            if (matchesScopes.Count == 0)
            {
                return new ErrorResponse<bool>(
                    new ScopeNotAuthorisedError($"no one user scope: '{string.Join(",", userScopes)}' match with some allowed scope: '{string.Join(",", routeAllowedScopes)}'"));
            }

            return new OkResponse<bool>(true);
        }
    }
}
