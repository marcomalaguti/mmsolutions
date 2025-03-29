namespace MMS.Erp.Application.Mediator.Messaging;

using MediatR;
using MMS.Erp.Domain.Abstractions;

internal interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
