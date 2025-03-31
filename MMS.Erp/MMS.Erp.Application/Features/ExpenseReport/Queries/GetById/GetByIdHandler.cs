namespace MMS.Erp.Application.Features.ExpenseReport.Queries.GetById;

using Mapster;
using MMS.Erp.Application.DTOs;
using MMS.Erp.Application.Mediator.Messaging;
using MMS.Erp.Domain.Abstractions;
using MMS.Erp.Domain.Errors;
using MMS.Erp.Domain.Repositories.ExpenseReport;
using System.Threading;
using System.Threading.Tasks;

internal class GetByIdHandler(IExpenseReportQueriesRepository expenseReportRepository)
    : IQueryHandler<GetByIdQuery, ExpenseReportDto?>
{
    public async Task<Result<ExpenseReportDto?>> Handle(GetByIdQuery request,
                                                        CancellationToken cancellationToken)
    {
        var queryResult = await expenseReportRepository.GetByIdAsync(request.ExpenseReportId,
                                                                     cancellationToken);

        var expenseReport = queryResult.Adapt<ExpenseReportDto?>();

        if(expenseReport is null)
        {
            return Result<ExpenseReportDto?>.Failure(ExpenseReportErrors.NotFound);
        }

        var records = await expenseReportRepository.GetExpenseRecordsByReportIdAsync(expenseReport.Id,
                                                                                     cancellationToken);

        if (records.Any())
        {
            expenseReport.Records = records.Adapt<List<ExpenseRecordDto>>();
        }

        return Result<ExpenseReportDto?>.Success(expenseReport);
    }
}