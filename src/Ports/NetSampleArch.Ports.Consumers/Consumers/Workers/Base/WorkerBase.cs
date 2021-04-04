using Microsoft.Extensions.Hosting;
using Serilog;

namespace NetSampleArch.Ports.Consumers.Workers.Base
{
    public abstract class WorkerBase
        : BackgroundService
    {
        protected ILogger Logger { get; }
        protected WorkerBase(ILogger logger)
        {
            Logger = logger;
        }
    }
}
