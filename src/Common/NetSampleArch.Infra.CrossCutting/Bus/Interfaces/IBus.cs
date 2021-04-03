using System.Threading;
using System.Threading.Tasks;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Messages;

namespace NetSampleArch.Infra.CrossCutting.Bus.Interfaces
{
     public interface IBus
    {
        Task<TResponse> SendCommandAsync<TCommand, TResponse>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand<TResponse>;
        Task<bool> SendEventAsync<TEvent>(TEvent @event, CancellationToken cancellationToken) where TEvent : IEvent;
        Task<TResponse> SendQueryAsync<TQuery, TResponse>(TQuery query, CancellationToken cancellationToken) where TQuery : IQuery<TResponse>;
    }
}