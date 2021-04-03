using MediatR;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Messages;

namespace NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Handlers
{
     public interface ICommandHandler<TCommand, TResponse> : IHandler, IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
    }
}