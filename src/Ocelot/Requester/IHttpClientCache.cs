using Ocelot.Configuration;
using System;

namespace Ocelot.Requester
{
    public interface IHttpClientCache
    {
        IHttpClient Get(DownstreamReRoute key);

        void Set(DownstreamReRoute key, IHttpClient handler, TimeSpan expirationTime);
    }
}
