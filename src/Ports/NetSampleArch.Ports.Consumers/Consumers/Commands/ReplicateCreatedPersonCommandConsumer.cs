using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces;
using NetSampleArch.Infra.CrossCutting.Configuration;
using NetSampleArch.Infra.CrossCutting.ExtensionMethods;
using NetSampleArch.Ports.Consumers.Interfaces.Commands;
using Serilog;

namespace NetSampleArch.Ports.Consumers.Consumers.Commands
{
    public class ReplicateCreatedPersonCommandConsumer
    : BaseKafkaConsumer<ReplicateCreatedPersonCommandConsumer>, IReplicateCreatedPersonCommandConsumer
    {
        public ReplicateCreatedPersonCommandConsumer(ILogger logger, IBus  bus, Configuration configuration)
            : base(logger, bus, configuration) { }

        public override Task MessageReceivedAsync(ConsumeResult<Ignore, string> receivedMessage, CancellationToken cancellationToken)
        {
            var command = receivedMessage.Message.Value.DeserializeFromJson<ProcessExecutionReportCommand>();
            return null;
        }
    }
}