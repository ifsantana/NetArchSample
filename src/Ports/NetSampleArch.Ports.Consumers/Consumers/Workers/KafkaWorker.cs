
using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces;
using NetSampleArch.Infra.CrossCutting.Configuration;
using NetSampleArch.Ports.Consumers.Interfaces;
using NetSampleArch.Ports.Consumers.Workers.Base;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetSampleArch.Ports.Consumers.Workers
{
    public class KafkaWorker : WorkerBase
    {
        private readonly Task[] _kafkaConsumerArray;

        private readonly IServiceProvider _serviceProvider;
        private readonly Configuration _config;
        private readonly KafkaWorkerConfig _kafkaWorkerConfig;

        protected IBus Bus { get; }

        public KafkaWorker(ILogger logger, IServiceProvider serviceProvider, Configuration config, KafkaWorkerConfig kafkaWorkerConfig
        ) : base(logger)
        {
            _serviceProvider = serviceProvider;
            _config = config;
            _kafkaWorkerConfig = kafkaWorkerConfig;
            _kafkaConsumerArray = new Task[_kafkaWorkerConfig.ConsumersConfig.Length];
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Logger.Warning("Initializing KafkaWorker");

            for (int i = 0; i < _kafkaWorkerConfig.ConsumersConfig.Length; i++)
            {
                var kafkaConsumerConfig = _kafkaWorkerConfig.ConsumersConfig[i];
                _kafkaConsumerArray[i] = Task.Run(async () =>
                {
                    Logger.Warning($"Initializing Kafka Consumer [TopicName: {kafkaConsumerConfig.TopicName}]");
                    using var consumer = new ConsumerBuilder<Ignore, string>(new ConsumerConfig
                    {
                        GroupId = kafkaConsumerConfig.ConsumerGroupId,
                        BootstrapServers = _config.KafkaConfig.BootstrapServers,
                        AutoOffsetReset = AutoOffsetReset.Earliest
                    }).Build();

                    Logger.Warning($"Topic Subscribe [TopicName: {kafkaConsumerConfig.TopicName}]");

                    try
                    {
                        consumer.Subscribe(kafkaConsumerConfig.TopicName);

                        while (true)
                        {
                            try
                            {
                                var message = consumer.Consume(stoppingToken);

                                if (message != null)
                                {
                                    using var scope = _serviceProvider.CreateScope();
                                    var scopedProcessingService = (IKafkaConsumer)scope.ServiceProvider.GetRequiredService(kafkaConsumerConfig.Type);

                                    await scopedProcessingService.MessageReceivedAsync(message, stoppingToken).ConfigureAwait(false);
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Error($"Fail do receive and process message. [server: {_config.KafkaConfig.BootstrapServers} - topic: {kafkaConsumerConfig.TopicName} - Ex.: {ex}]");
                            }
                        }
                    }
                    catch (OperationCanceledException ex)
                    {
                        Logger.Error($"OperationCanceledException {ex.ToString()}");
                        consumer.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.ToString());
                    }
                });
            }

            return Task.CompletedTask;
        }
    }
}
