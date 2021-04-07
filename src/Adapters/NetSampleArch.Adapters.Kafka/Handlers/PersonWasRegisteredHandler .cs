using System.Threading;
using System.Threading.Tasks;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Handlers;
using NetSampleArch.Infra.CrossCutting.Configuration;
using NetSampleArch.Infra.CrossCutting.Messages.Internal.Events.PersonWasRegistered.Interfaces;
using Serilog;

namespace NetSampleArch.Adapters.Kafka.Handlers
{
    public class PersonWasRegisteredHandler
        : BaseKafkaHandler<IPersonWasRegisteredEvent>, IEventHandler<IPersonWasRegisteredEvent>
    {
        public PersonWasRegisteredHandler(ILogger logger, Configuration config) 
            : base(logger, config) { }

        public async override Task Handle(IPersonWasRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // await KafkaPublisher.SendEventAsync(
            //     topicName: "",
            //     key: "",
            //     @event: null,
            //     cancellationToken
            // ).ConfigureAwait(false);
        }
    }
}