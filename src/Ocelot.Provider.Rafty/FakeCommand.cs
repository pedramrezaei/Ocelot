using Rafty.FiniteStateMachine;

namespace Ocelot.Provider.Rafty
{
    public class FakeCommand : ICommand
    {
        public FakeCommand(string value)
        {
            this.Value = value;
        }

        public string Value { get; }
    }
}
