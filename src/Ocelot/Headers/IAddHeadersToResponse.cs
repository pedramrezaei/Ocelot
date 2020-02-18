using Ocelot.Middleware;
using Ocelot.Configuration.Creator;
using System.Collections.Generic;

namespace Ocelot.Headers
{
    public interface IAddHeadersToResponse
    {
        void Add(List<AddHeader> addHeaders, DownstreamResponse response);
    }
}
