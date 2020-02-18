using Ocelot.Configuration.Builder;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Ocelot.Configuration;
using Ocelot.Logging;
using Ocelot.Provider.Consul;
using Shouldly;
using System;
using Xunit;

namespace Ocelot.UnitTests.Consul
{
    public class ProviderFactoryTests
    {
        private readonly IServiceProvider _provider;

        public ProviderFactoryTests()
        {
            var services = new ServiceCollection();
            var loggerFactory = new Mock<IOcelotLoggerFactory>();
            var logger = new Mock<IOcelotLogger>();
            loggerFactory.Setup(x => x.CreateLogger<Provider.Consul.Consul>()).Returns(logger.Object);
            loggerFactory.Setup(x => x.CreateLogger<PollConsul>()).Returns(logger.Object);
            var consulFactory = new Mock<IConsulClientFactory>();
            services.AddSingleton(consulFactory.Object);
            services.AddSingleton(loggerFactory.Object);
            _provider = services.BuildServiceProvider();
        }

        [Fact]
        public void should_return_ConsulServiceDiscoveryProvider()
        {
            var reRoute = new DownstreamReRouteBuilder()
                .WithServiceName("")
                .Build();

            var provider = ConsulProviderFactory.Get(_provider, new ServiceProviderConfiguration(string.Empty, string.Empty, 1, string.Empty, string.Empty, 1), reRoute);
            provider.ShouldBeOfType<Provider.Consul.Consul>();
        }

        [Fact]
        public void should_return_PollingConsulServiceDiscoveryProvider()
        {
            var stopsPollerFromPolling = 10000;

            var reRoute = new DownstreamReRouteBuilder()
                .WithServiceName("")
                .Build();

            var provider = ConsulProviderFactory.Get(_provider, new ServiceProviderConfiguration("pollconsul", string.Empty, 1, string.Empty, string.Empty, stopsPollerFromPolling), reRoute);
            var pollProvider = provider as PollConsul;
            pollProvider.ShouldNotBeNull();
            pollProvider.Dispose();
        }
    }
}
