using MediatR;

namespace NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Messages
{
    public interface ICommand<out TResponse> : IMessage, IRequest<TResponse>
    {
    }
}