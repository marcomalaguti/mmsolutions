namespace MMS.Erp.Application.Features.ExpenseReport.Queries.GetAll;

using Mapster;
using MMS.Erp.Application.DTOs;
using MMS.Erp.Application.Mediator.Messaging;
using MMS.Erp.Domain.Abstractions;
using MMS.Erp.Domain.Repositories.ExpenseReport;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


internal class GetAllHandler(IExpenseReportQueriesRepository expenseReportRepository)
    : IQueryHandler<GetAllQuery, IEnumerable<ExpenseReportDto>?>
{
    public async Task<Result<IEnumerable<ExpenseReportDto>?>> Handle(GetAllQuery request,
                                                                CancellationToken cancellationToken)
    {
        var queryResult = await expenseReportRepository.GetAllAsync(cancellationToken);

        var expenseReports = queryResult.Adapt<List<ExpenseReportDto>>();

        foreach (var expenseReport in expenseReports)
        {
            var records = await expenseReportRepository.GetExpenseRecordsByReportIdAsync(expenseReport.Id,
                                                                                    cancellationToken);
            if (records.Any())
                expenseReport.Records = records.Adapt<List<ExpenseRecordDto>>();
        }

        return Result<IEnumerable<ExpenseReportDto>?>.Success(expenseReports);
    }
}