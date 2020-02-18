using Ocelot.Configuration.Setter;
using Rafty.FiniteStateMachine;
using Rafty.Log;
using System.Threading.Tasks;

namespace Ocelot.Provider.Rafty
{
    public class OcelotFiniteStateMachine : IFiniteStateMachine
    {
        private readonly IFileConfigurationSetter _setter;

        public OcelotFiniteStateMachine(IFileConfigurationSetter setter)
        {
            _setter = setter;
        }

        public async Task Handle(LogEntry log)
        {
            //todo - handle an error
            //hack it to just cast as at the moment we know this is the only command :P
            var hack = (UpdateFileConfiguration)log.CommandData;
            await _setter.Set(hack.Configuration);
        }
    }
}
