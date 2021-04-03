using MediatR;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Messages;

namespace NetSampleArch.Infra.CrossCutting.Bus.Interfaces.Handlers
{
    public interface IQueryHandler<TQuery, TResponse> : IHandler, IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
    }
}