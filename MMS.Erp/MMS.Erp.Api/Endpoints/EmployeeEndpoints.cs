namespace MMS.Erp.Api.Endpoints;

using MMS.Erp.Api.Handlers;
using MMS.Erp.Api.Requests;

internal static class EmployeeEndpoints
{
    internal static void MapEmployeeEndpoints(this IEndpointRouteBuilder route)
    {
        var group = route.MapGroup("/employee");

        group.MapGet("/", EmployeeHandler.GetAllEmployees);

        group.MapPost("/", EmployeeHandler.CreateEmployee);

        group.MapExpenseReportEndpoints();

        group.MapPayCheckEndpoints();
    }

    private static void MapExpenseReportEndpoints(this RouteGroupBuilder group)
    {
        var expenseReportGroup = group.MapGroup("/{employeeId}/expense-report");

        expenseReportGroup.MapGet("/", ExpenseReportHandler.GetByEmployeeId);

        expenseReportGroup.MapPost("/", ExpenseReportHandler.CreateExpenseReport);

        expenseReportGroup.MapPost("/{expenseReportId}", ExpenseReportHandler.CreateExpenseRecord)
            .Accepts<CreateExpenseRecordRequest>("multipart/form-data")
            .DisableAntiforgery();

        expenseReportGroup.MapPost("/{expenseReportId}/submit", ExpenseReportHandler.SubmitExportReport);

        expenseReportGroup.MapDelete("/{expenseReportId}/expense-record/{expenseRecordId}", ExpenseReportHandler.DeleteExpenseRecord);

    }

    private static void MapPayCheckEndpoints(this RouteGroupBuilder group)
    {
        var payCheckGroup = group.MapGroup("/{employeeId}/pay-check");

        payCheckGroup.MapPost("/", PayCheckHandler.CreatePayCheck)
            .Accepts<CreateExpenseRecordRequest>("multipart/form-data")
            .DisableAntiforgery();

    }
}
