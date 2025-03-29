namespace MMS.Erp.Application.Mediator.Messaging;

using MediatR;
using MMS.Erp.Domain.Abstractions;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}