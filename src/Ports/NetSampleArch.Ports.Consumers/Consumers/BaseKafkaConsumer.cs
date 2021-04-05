using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces;
using NetSampleArch.Infra.CrossCutting.Configuration;
using NetSampleArch.Infra.CrossCutting.Kafka;
using NetSampleArch.Ports.Consumers.Interfaces;
using Serilog;

namespace NetSampleArch.Ports.Consumers.Consumers
{
     public abstract class BaseKafkaConsumer<T> : IKafkaConsumer
    {
	    protected KafkaPublisher KafkaPublisher { get; }
        protected ILogger Logger { get; }
        protected IBus Bus { get; }
        public Type Type => typeof(T);

        protected BaseKafkaConsumer(ILogger logger, IBus bus, Configuration config)
        {
            Logger = logger;
            Bus = bus;
            KafkaPublisher = new KafkaPublisher(config.KafkaConfig.BootstrapServers);
        }

        public abstract Task MessageReceivedAsync(ConsumeResult<Ignore, string> receivedMessage, CancellationToken cancellationToken);
    }
}