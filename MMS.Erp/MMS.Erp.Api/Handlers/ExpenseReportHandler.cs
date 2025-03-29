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
        try
        {
            var command = ExpenseReportMapper.MapToCreateExpenseReportCommand(request);
            var result = await mediator.Send(command);            

            if (result.IsSuccess)
                return TypedResults.Created($"{BaseUrl}/{result.Value}");

            return TypedResults.BadRequest(result.Error);

        }
        catch (FluentValidation.ValidationException ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return TypedResults.UnprocessableEntity(ex.Message);
        }
    }

    internal static async Task<IResult> GetAllExpenseReports([FromServices] IMediator mediator)
    {
        try
        {
            var result = await mediator.Send(new GetAllExpenseReportsQuery());            

            if (result.IsSuccess)
                return TypedResults.Created($"{BaseUrl}/{result.Value}");

            return TypedResults.BadRequest(result.Error);
        }
        catch (FluentValidation.ValidationException ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return TypedResults.UnprocessableEntity(ex.Message);
        }
    }
}