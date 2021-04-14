using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace NetSampleArch.Ports.Consumers.Interfaces
{
    public interface IKafkaConsumer
    {
        Type Type { get; }
        Task MessageReceivedAsync(ConsumeResult<string, string> receivedMessage, CancellationToken cancellationToken);
    }
}