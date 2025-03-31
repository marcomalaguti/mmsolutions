namespace MMS.Erp.Api.Handlers;

using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MMS.Erp.Api.Requests;
using MMS.Erp.Application.Features.ExpenseReport.Commands.CreateExpenseReport;
using MMS.Erp.Application.Features.ExpenseReport.Queries.GetAllExpenseReports;

public static class ExpenseReportHandler
{
    const string BaseUrl = "/employee/{employeeId}/expense-report";

    internal static async Task<IResult> CreateExpenseReport([FromServices] ISender sender,
                                                            [FromServices] IMapper mapper,
                                                            [FromRoute] int employeeId,
                                                            CreateExpenseReportRequest request,
                                                            CancellationToken cancellationToken)
    {
        try
        {
            var command = mapper.Map<CreateExpenseReportCommand>(request);
            var result = await sender.Send(command, cancellationToken);

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

    internal static async Task<IResult> GetAllExpenseReports([FromServices] ISender sender,
                                                             CancellationToken cancellationToken)
    {
        try
        {
            var result = await sender.Send(new GetAllExpenseReportsQuery(), cancellationToken);

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