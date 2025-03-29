namespace MMS.Erp.Api.Handlers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using MMS.Erp.Api.Mappings;
using MMS.Erp.Api.Requests;
using MMS.Erp.Application.Features.ExpenseReport.Queries.GetAllExpenseReports;

public static class ExpenseReportHandler
{
    const string BaseUrl = "/employee/{employeeId}/expense-report";

    internal static async Task<IResult> CreateExpenseReport([FromServices] IMediator mediator, CreateExpenseReportRequest request)
    {
        var command = ExpenseReportMapper.MapToCreateExpenseReportCommand(request);
        var result = await mediator.Send(command);
        return TypedResults.Created($"{BaseUrl}/{result}");
    }

    internal static async Task<IResult> GetAllExpenseReports([FromServices] IMediator mediator)
    {
        var result = await mediator.Send(new GetAllExpenseReportsQuery());
        return TypedResults.Ok();
    }
}