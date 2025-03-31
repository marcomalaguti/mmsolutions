namespace MMS.Erp.Application.Features.ExpenseReport.Queries.DownloadExpenseReport;
public class DownloadExpenseReportResponse
{
    public byte[]? File { get; set; }
    public string? Name { get; set; }
    public string? ContentType { get; set; }
}
