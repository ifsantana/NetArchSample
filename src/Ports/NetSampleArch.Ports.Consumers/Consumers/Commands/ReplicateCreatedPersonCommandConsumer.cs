using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces;
using NetSampleArch.Infra.CrossCutting.Configuration;
using NetSampleArch.Infra.CrossCutting.ExtensionMethods;
using NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands.ReplicatePersonCreated;
using NetSampleArch.Ports.Consumers.Interfaces.Commands;
using Serilog;

namespace NetSampleArch.Ports.Consumers.Consumers.Commands
{
    public class ReplicateCreatedPersonCommandConsumer
    : BaseKafkaConsumer<ReplicateCreatedPersonCommandConsumer>, IReplicateCreatedPersonCommandConsumer
    {
        public ReplicateCreatedPersonCommandConsumer(ILogger logger, IBus  bus, Configuration configuration)
            : base(logger, bus, configuration) { }

        public override async Task MessageReceivedAsync(ConsumeResult<Ignore, string> receivedMessage, CancellationToken cancellationToken)
        {
            var command = receivedMessage.Message.Value.DeserializeFromJson<ReplicatePersonCreatedCommand>();

            await Bus.SendCommandAsync<NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands.ReplicatePersonCreated.ReplicatePersonCreatedCommand, bool>(
                new NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands.ReplicatePersonCreated.ReplicatePersonCreatedCommand(
                    new Infra.CrossCutting.Messages.Internal.Commands.ReplicatePersonCreated.Models.PersonCreatedEntry
                    (
                        executionUser: nameof(ReplicateCreatedPersonCommandConsumer),
                        createdBy: command.Entry.CreatedBy,
                        name: command.Entry.Name,
                        address: command.Entry.Address,
                        phone: command.Entry.Phone
                    )
                ),
                cancellationToken
            ).ConfigureAwait(false);
        }
    }
}