namespace MMS.Erp.Application.Mediator.Messaging;

using MediatR;
using MMS.Erp.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
