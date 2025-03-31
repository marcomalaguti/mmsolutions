namespace MMS.Erp.Api.Endpoints;

using MMS.Erp.Api.Handlers;

internal static class ExpenseReportEndpoints
{
    internal static void MapExpenseReportEndpoints(this IEndpointRouteBuilder route)
    {
        var group = route.MapGroup("/expense-report");

        group.MapGet("/", ExpenseReportHandler.GetAll);
        
        group.MapGet("/{expenseReportId}", ExpenseReportHandler.GetById);

        group.MapGet("/{expenseReportId}/download", ExpenseReportHandler.DownloadExpenseReport);
    }
}
