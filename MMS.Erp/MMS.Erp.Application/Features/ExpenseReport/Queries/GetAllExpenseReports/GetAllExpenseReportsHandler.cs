namespace MMS.Erp.Application.Features.ExpenseReport.Queries.GetAllExpenseReports;

using MMS.Erp.Application.Mediator.Messaging;
using MMS.Erp.Domain.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

internal class GetAllExpenseReportsHandler : IQueryHandler<GetAllExpenseReportsQuery, object>
{
    public Task<Result<object>> Handle(GetAllExpenseReportsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
