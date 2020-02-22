namespace Ocelot.Errors
{
    public abstract class Error
    {
        protected Error(string message, OcelotErrorCode code)
        {
            Message = message;
            Code = code;
        }

        public string Message { get; }
        public OcelotErrorCode Code { get; }

        public override string ToString()
        {
            return Message;
        }
    }
}
