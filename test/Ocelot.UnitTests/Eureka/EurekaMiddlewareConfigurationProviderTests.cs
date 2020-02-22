﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Ocelot.Configuration;
using Ocelot.Configuration.Builder;
using Ocelot.Configuration.Repository;
using Ocelot.Provider.Eureka;
using Ocelot.Responses;
using Shouldly;
using Steeltoe.Common.Discovery;
using System.Threading.Tasks;
using Xunit;

namespace Ocelot.UnitTests.Eureka
{
    public class EurekaMiddlewareConfigurationProviderTests
    {
        [Fact]
        public void should_not_build()
        {
            var configRepo = new Mock<IInternalConfigurationRepository>();
            configRepo.Setup(x => x.Get())
                .Returns(new OkResponse<IInternalConfiguration>(new InternalConfiguration(null, null, null, null, null, null, null, null, null)));
            var services = new ServiceCollection();
            services.AddSingleton(configRepo.Object);
            var sp = services.BuildServiceProvider();
            var provider = EurekaMiddlewareConfigurationProvider.Get(new ApplicationBuilder(sp));
            provider.ShouldBeOfType<Task>();
        }

        [Fact]
        public void should_build()
        {
            var serviceProviderConfig = new ServiceProviderConfigurationBuilder().WithType("eureka").Build();
            var client = new Mock<IDiscoveryClient>();
            var configRepo = new Mock<IInternalConfigurationRepository>();
            configRepo.Setup(x => x.Get())
                .Returns(new OkResponse<IInternalConfiguration>(new InternalConfiguration(null, null, serviceProviderConfig, null, null, null, null, null, null)));
            var services = new ServiceCollection();
            services.AddSingleton(configRepo.Object);
            services.AddSingleton(client.Object);
            var sp = services.BuildServiceProvider();
            var provider = EurekaMiddlewareConfigurationProvider.Get(new ApplicationBuilder(sp));
            provider.ShouldBeOfType<Task>();
        }
    }
}
