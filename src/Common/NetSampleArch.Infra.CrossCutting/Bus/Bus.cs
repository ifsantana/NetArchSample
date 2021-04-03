using MediatR;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace NetSampleArch.Infra.CrossCutting.Bus
{
    public class Bus : IBus
    {
        private readonly IMediator _mediator;

        public Bus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResponse> SendCommandAsync<TCommand, TResponse>(TCommand command, CancellationToken cancellationToken)
            where TCommand : ICommand<TResponse>
        {
            return await _mediator.Send(command, cancellationToken).ConfigureAwait(false);
        }
        public async Task<bool> SendEventAsync<TEvent>(TEvent @event, CancellationToken cancellationToken)
            where TEvent : IEvent
        {
            await _mediator.Publish(@event, cancellationToken).ConfigureAwait(false);
            return true;
        }
        public async Task<TResponse> SendQueryAsync<TQuery, TResponse>(TQuery query, CancellationToken cancellationToken) where TQuery : IQuery<TResponse>
        {
            return await _mediator.Send(query, cancellationToken).ConfigureAwait(false);
        }
    }
}