namespace MMS.Erp.Application.Features.ExpenseReport.Queries.DownloadExpenseReport;

using MMS.Erp.Application.Mediator.Messaging;

public class DownloadExpenseReportQuery : IQuery<DownloadExpenseReportResponse>
{
    public int ExpenseReportId { get; set; }

    public DownloadExpenseReportQuery(int expenseReportId)
    {
        ExpenseReportId = expenseReportId;
    }
}