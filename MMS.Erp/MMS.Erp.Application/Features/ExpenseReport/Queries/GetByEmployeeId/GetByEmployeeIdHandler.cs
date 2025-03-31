namespace MMS.Erp.Application.Features.ExpenseReport.Queries.GetByEmployeeId;

using Mapster;
using MMS.Erp.Application.DTOs;
using MMS.Erp.Application.Mediator.Messaging;
using MMS.Erp.Domain.Abstractions;
using MMS.Erp.Domain.Repositories.ExpenseReport;
using System.Threading;
using System.Threading.Tasks;

internal class GetByEmployeeIdHandler(IExpenseReportQueriesRepository expenseReportRepository)
    : IQueryHandler<GetByEmployeeIdQuery, IEnumerable<ExpenseReportDto>?>
{
    public async Task<Result<IEnumerable<ExpenseReportDto>?>> Handle(GetByEmployeeIdQuery request,
                                                                CancellationToken cancellationToken)
    {
        var queryResult = await expenseReportRepository.GetExpenseReportsByEmployeeIdAsync(request.EmployeeId,
                                                                                      cancellationToken);

        var expenseReports = queryResult.Adapt<IEnumerable<ExpenseReportDto>>();

        foreach (var expenseReport in expenseReports)
        {
            var records = await expenseReportRepository.GetExpenseRecordsByReportIdAsync(expenseReport.Id,
                                                                                    cancellationToken);

            if (records.Any())
            {
                expenseReport.Records = records.Adapt<IEnumerable<ExpenseRecordDto>>();
            }
        }

        return Result<IEnumerable<ExpenseReportDto>?>.Success(expenseReports);
    }
}