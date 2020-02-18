using Ocelot.Configuration.Setter;
using Ocelot.DependencyInjection;
using Rafty.Concensus.Node;
using Rafty.FiniteStateMachine;
using Rafty.Infrastructure;
using Rafty.Log;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Ocelot.Provider.Rafty
{
    public static class OcelotAdministrationBuilderExtensions
    {
        public static IOcelotAdministrationBuilder AddRafty(this IOcelotAdministrationBuilder builder)
        {
            var settings = new InMemorySettings(4000, 6000, 100, 10000);
            builder.Services.RemoveAll<IFileConfigurationSetter>();
            builder.Services.AddSingleton<IFileConfigurationSetter, RaftyFileConfigurationSetter>();
            builder.Services.AddSingleton<ILog, SqlLiteLog>();
            builder.Services.AddSingleton<IFiniteStateMachine, OcelotFiniteStateMachine>();
            builder.Services.AddSingleton<ISettings>(settings);
            builder.Services.AddSingleton<IPeersProvider, FilePeersProvider>();
            builder.Services.AddSingleton<INode, Node>();
            builder.Services.Configure<FilePeers>(builder.ConfigurationRoot);
            return builder;
        }
    }
}
