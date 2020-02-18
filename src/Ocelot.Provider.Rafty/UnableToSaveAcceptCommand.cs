using Ocelot.Errors;

namespace Ocelot.Provider.Rafty
{
    public class UnableToSaveAcceptCommand : Error
    {
        public UnableToSaveAcceptCommand(string message)
            : base(message, OcelotErrorCode.UnknownError)
        {
        }
    }
}
