using Ocelot.Configuration.File;
using Rafty.FiniteStateMachine;

namespace Ocelot.Provider.Rafty
{
    public class UpdateFileConfiguration : ICommand
    {
        public UpdateFileConfiguration(FileConfiguration configuration)
        {
            Configuration = configuration;
        }

        public FileConfiguration Configuration { get; }
    }
}
