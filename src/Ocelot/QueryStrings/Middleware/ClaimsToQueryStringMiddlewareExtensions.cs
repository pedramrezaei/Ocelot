using Microsoft.AspNetCore.Builder;
using Ocelot.Middleware.Pipeline;

namespace Ocelot.QueryStrings.Middleware
{
    public static class ClaimsToQueryStringMiddlewareExtensions
    {
        public static IOcelotPipelineBuilder UseClaimsToQueryStringMiddleware(this IOcelotPipelineBuilder builder)
        {
            return builder.UseMiddleware<ClaimsToQueryStringMiddleware>();
        }
    }
}
