using Ocelot.Configuration.File;
using Ocelot.Configuration.Setter;
using Rafty.Concensus.Node;
using Rafty.Infrastructure;
using System.Threading.Tasks;

namespace Ocelot.Provider.Rafty
{
    public class RaftyFileConfigurationSetter : IFileConfigurationSetter
    {
        private readonly INode _node;

        public RaftyFileConfigurationSetter(INode node)
        {
            _node = node;
        }

        public async Task<Responses.Response> Set(FileConfiguration fileConfiguration)
        {
            var result = await _node.Accept(new UpdateFileConfiguration(fileConfiguration));

            if (result.GetType() == typeof(ErrorResponse<UpdateFileConfiguration>))
            {
                return new Responses.ErrorResponse(new UnableToSaveAcceptCommand($"unable to save file configuration to state machine"));
            }

            return new Responses.OkResponse();
        }
    }
}
