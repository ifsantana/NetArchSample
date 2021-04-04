using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using NetSampleArch.Infra.CrossCutting.ExtensionMethods;

namespace NetSampleArch.Infra.CrossCutting.Kafka
{
   public class KafkaPublisher
    {
        private readonly ProducerConfig _producerConfig;

        public KafkaPublisher(string bootstrapperServers)
        {
            _producerConfig = new ProducerConfig { BootstrapServers = bootstrapperServers };
        }

        public async Task<bool> SendEventAsync<TKey, TEvent>(string topicName, TKey key, TEvent @event, CancellationToken cancellationToken)
        {
            using var producer = new ProducerBuilder<string, string>(_producerConfig).Build();

            await producer.ProduceAsync(
                topicName,
                new Message<string, string>
                {
                    Key = key.ToString(),
                    Value = @event.SerializeToJson()
                },
                cancellationToken
            ).ConfigureAwait(false);

            return true;
        }
    }
}