using NetSampleArch.Infra.CrossCutting.Bus.Handlers;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Messages;
using NetSampleArch.Infra.CrossCutting.Configuration;
using NetSampleArch.Infra.CrossCutting.Kafka;
using Serilog;

namespace NetSampleArch.Adapters.Kafka.Handlers
{
   public abstract class BaseKafkaHandler<TEvent>
        : BaseEventHandler<TEvent>
        where TEvent : IEvent
    {
        protected KafkaPublisher KafkaPublisher { get; }
        protected Configuration Config { get; }

        protected BaseKafkaHandler(ILogger logger, Configuration config) 
            : base(logger)
        {
            Config = config;
            KafkaPublisher = new KafkaPublisher(config.KafkaConfig.BootstrapServers);
        }
    }
}