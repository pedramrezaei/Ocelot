﻿using Ocelot.Configuration;
using Ocelot.Configuration.Repository;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.Middleware;
using Steeltoe.Discovery.Client;
using System.Threading.Tasks;

namespace Ocelot.Provider.Eureka
{
    public class EurekaMiddlewareConfigurationProvider
    {
        public static OcelotMiddlewareConfigurationDelegate Get = builder =>
        {
            var internalConfigRepo = builder.ApplicationServices.GetService<IInternalConfigurationRepository>();

            var config = internalConfigRepo.Get();

            if (UsingEurekaServiceDiscoveryProvider(config.Data))
            {
                builder.UseDiscoveryClient();
            }

            return Task.CompletedTask;
        };

        private static bool UsingEurekaServiceDiscoveryProvider(IInternalConfiguration configuration)
        {
            return configuration?.ServiceProviderConfiguration != null && configuration.ServiceProviderConfiguration.Type?.ToLower() == "eureka";
        }
    }
}
