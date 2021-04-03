using NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Handlers;
using Serilog;

namespace NetSampleArch.Infra.CrossCutting.Bus.Handlers
{
    public abstract class BaseHandler : IHandler
    {
        protected ILogger Logger { get; }

        protected BaseHandler(ILogger logger)
        {
            Logger = logger;
        }
    }
}