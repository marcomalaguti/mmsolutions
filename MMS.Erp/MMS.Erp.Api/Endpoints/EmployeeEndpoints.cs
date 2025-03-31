namespace MMS.Erp.Api.Endpoints;

using MMS.Erp.Api.Handlers;

internal static class EmployeeEndpoints
{
    internal static void MapEmployeeEndpoints(this IEndpointRouteBuilder route)
    {
        var group = route.MapGroup("/employee");

        group.MapGet("/", EmployeeHandler.GetAllEmployees);
        group.MapPost("/", EmployeeHandler.CreateEmployee);

        group.MapExpenseReportEndpoints();
    }

    private static void MapExpenseReportEndpoints(this RouteGroupBuilder group)
    {
        var expenseReportGroup = group.MapGroup("/{employeeId}/expense-report");

        expenseReportGroup.MapGet("/", ExpenseReportHandler.GetByEmployeeId);
        expenseReportGroup.MapPost("/", ExpenseReportHandler.CreateExpenseReport);
    }
}
