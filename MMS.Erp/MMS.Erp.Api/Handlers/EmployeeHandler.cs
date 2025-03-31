namespace MMS.Erp.Api.Handlers;

using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MMS.Erp.Api.Requests;
using MMS.Erp.Application.Features.Employee.Commands.CreateEmployee;
using MMS.Erp.Application.Features.Employee.Queries.GetAllEmployees;

public static class EmployeeHandler
{
    public static string BaseUrl = "/employee";

    internal static async Task<IResult> CreateEmployee([FromServices] ISender sender,
                                                       [FromServices] IMapper mapper,
                                                       CreateEmployeeRequest request,
                                                       CancellationToken cancellationToken)
    {
        try
        {
            var command = mapper.Map<CreateEmployeeCommand>(request);
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

    internal static async Task<IResult> GetAllEmployees([FromServices] ISender mediator,
                                                        CancellationToken cancellationToken)
    {
        try
        {
            var result = await mediator.Send(new GetAllEmployeesQuery(), cancellationToken);

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