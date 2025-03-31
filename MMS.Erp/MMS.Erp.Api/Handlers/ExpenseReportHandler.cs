namespace MMS.Erp.Api.Handlers;

using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MMS.Erp.Api.Requests;
using MMS.Erp.Application.Features.ExpenseReport.Commands.CreateExpenseReport;
using MMS.Erp.Application.Features.ExpenseReport.Queries.GetByEmployeeId;

public static class ExpenseReportHandler
{
    public static string BaseUrl = "/expense-report";

    internal static async Task<IResult> CreateExpenseReport([FromServices] ISender sender,
                                                            [FromServices] IMapper mapper,
                                                            [FromRoute] int employeeId,
                                                            CreateExpenseReportRequest request,
                                                            CancellationToken cancellationToken)
    {
        try
        {
            var command = mapper
                .From(request)
                .AddParameters("EmployeeId", employeeId)
                .AdaptToType<CreateExpenseReportCommand>();

            var result = await sender.Send(command, cancellationToken);

            if (result.IsSuccess)
            {
                var returnUrl = $"{EmployeeHandler.BaseUrl}/{employeeId}/{BaseUrl}/{result.Value}";
                return TypedResults.Created(returnUrl);
            }

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

    internal static async Task<IResult> GetByEmployeeId([FromServices] ISender sender,
                                                        [FromRoute] int employeeId,
                                                        CancellationToken cancellationToken)
    {
        try
        {
            var result = await sender.Send(new GetByEmployeeIdQuery(employeeId), cancellationToken);

            if (result.IsSuccess)
                return TypedResults.Ok(result.Value);

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