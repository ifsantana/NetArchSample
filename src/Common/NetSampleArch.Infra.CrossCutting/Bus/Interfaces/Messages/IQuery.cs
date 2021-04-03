using MediatR;

namespace NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Messages
{
    public interface IQuery<out TReturn> : IMessage, IRequest<TReturn>
    {

    }
}