using Ocelot.Configuration;
using Ocelot.Middleware;
using Ocelot.Responses;
using System.Collections.Generic;

namespace Ocelot.Headers
{
    public interface IHttpResponseHeaderReplacer
    {
        Response Replace(DownstreamContext context, List<HeaderFindAndReplace> fAndRs);
    }
}
