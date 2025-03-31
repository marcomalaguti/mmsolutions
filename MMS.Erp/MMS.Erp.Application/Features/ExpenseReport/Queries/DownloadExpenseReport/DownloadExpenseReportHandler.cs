namespace MMS.Erp.Application.Features.ExpenseReport.Queries.DownloadExpenseReport;

using MMS.Erp.Application.Mediator.Messaging;
using MMS.Erp.Application.Services.ExpenseReport;
using MMS.Erp.Domain.Abstractions;
using MMS.Erp.Domain.Enums;
using MMS.Erp.Domain.Errors;
using MMS.Erp.Domain.Repositories.Employee;
using MMS.Erp.Domain.Repositories.ExpenseReport;
using System.Threading;
using System.Threading.Tasks;

internal class DownloadExpenseReportHandler(IExpenseReportQueriesRepository expenseQueriesRepository,
                                            IEmployeeQueriesRepository employeeQueriesRepository,
                                            IExpenseReportService expenseReportService)
    : IQueryHandler<DownloadExpenseReportQuery, DownloadExpenseReportResponse>
{
    public async Task<Result<DownloadExpenseReportResponse>> Handle(DownloadExpenseReportQuery request,
                                                                    CancellationToken cancellationToken)
    {
        var expenseReport = await expenseQueriesRepository.GetByIdAsync(request.ExpenseReportId,
                                                                                     cancellationToken);

        if (expenseReport is null)
            return Result<DownloadExpenseReportResponse>.Failure(ExpenseReportErrors.NotFound);

        var employee = await employeeQueriesRepository.GetByIdAsync(expenseReport.EmployeeId, cancellationToken);

        if (employee is null)
            return Result<DownloadExpenseReportResponse>.Failure(ExpenseReportErrors.EmployeeNotFound);

        var records = await expenseQueriesRepository.GetExpenseRecordsByReportIdAsync(request.ExpenseReportId,
                                                                                      cancellationToken);

        var ret = new DownloadExpenseReportResponse();

        ret.File = expenseReportService
                        .GenerateExpenseReportExcel(employee,
                                                    expenseReport,
                                                    records.Where(x => x.TypeId == ExpenseRecordTypeEnum.Travel),
                                                    records.Where(x => x.TypeId == ExpenseRecordTypeEnum.GenericRefund));

        ret.Name = $"{employee.LastName}_NotaSpese_{expenseReport.Date.ToString("yyyyMM")}.xlsx";

        await expenseReportService.UploadExpenseReportOnBlob(ret.File, ret.Name, expenseReport.Date.Month);

        return Result<DownloadExpenseReportResponse>.Success(ret);
    }
}