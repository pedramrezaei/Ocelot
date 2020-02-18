﻿using Ocelot.Configuration;
using Ocelot.Responses;
using System.Threading.Tasks;

namespace Ocelot.LoadBalancer.LoadBalancers
{
    public interface ILoadBalancerFactory
    {
        Task<Response<ILoadBalancer>> Get(DownstreamReRoute reRoute, ServiceProviderConfiguration config);
    }
}
