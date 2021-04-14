using Confluent.Kafka;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces;
using NetSampleArch.Infra.CrossCutting.Configuration;
using NetSampleArch.Ports.Consumers.Interfaces.Commands;
using NetSampleArch.Ports.Consumers.Models;
using Serilog;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace NetSampleArch.Ports.Consumers.Consumers.Commands
{
    public class ReplicateCreatedPersonCommandConsumer : BaseKafkaConsumer<ReplicateCreatedPersonCommandConsumer>, IReplicateCreatedPersonCommandConsumer
    {
        public ReplicateCreatedPersonCommandConsumer(ILogger logger, IBus  bus, Configuration configuration)
            : base(logger, bus, configuration) { }

        public override async Task MessageReceivedAsync(ConsumeResult<string, string> receivedMessage, CancellationToken cancellationToken)
        {
            var notification = JsonSerializer.Deserialize<BaseCDCMessage>(receivedMessage.Message?.Value);

            await Bus.SendCommandAsync<NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands.ReplicatePersonCreated.ReplicatePersonCreatedCommand, bool>(
                new NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands.ReplicatePersonCreated.ReplicatePersonCreatedCommand(
                    new Infra.CrossCutting.Messages.Internal.Commands.ReplicatePersonCreated.Models.PersonCreatedEntry
                    (
                        executionUser: nameof(ReplicateCreatedPersonCommandConsumer),
                        createdBy: notification.payload.after.CreatedBy,
                        name: notification.payload.after.Name,
                        address: notification.payload.after.Address,
                        phone: notification.payload.after.Phone
                    )
                ),
                cancellationToken
            ).ConfigureAwait(false);
        }
    }
}