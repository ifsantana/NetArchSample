namespace NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands
{
    public abstract class BaseCommand
    {
        public string ExecutionUser { get; }

        protected BaseCommand(string executionUser)
        {
            ExecutionUser = executionUser;
        }
    }
}