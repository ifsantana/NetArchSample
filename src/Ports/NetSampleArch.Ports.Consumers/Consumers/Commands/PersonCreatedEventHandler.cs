using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces;
using NetSampleArch.Infra.CrossCutting.Configuration;
using NetSampleArch.Ports.Consumers.Interfaces.Commands;
using Serilog;

namespace NetSampleArch.Ports.Consumers.Consumers.Commands
{
    public class PersonCreatedEventHandler
    : BaseKafkaConsumer<PersonCreatedEventHandler>, IPersonCreatedEventHandler
    {
        public PersonCreatedEventHandler(ILogger logger, IBus  bus, Configuration configuration)
            : base(logger, bus, configuration)
        {
            
        }

        public override Task MessageReceivedAsync(ConsumeResult<Ignore, string> receivedMessage, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}