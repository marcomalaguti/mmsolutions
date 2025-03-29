namespace MMS.Erp.Api.Handlers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using MMS.Erp.Api.Mappings;
using MMS.Erp.Api.Requests;
using MMS.Erp.Application.Features.Employee.Queries.GetAllEmployees;

public static class EmployeeHandler
{
    const string BaseUrl = "/employee";

    internal static async Task<IResult> CreateEmployee([FromServices] ISender sender, CreateEmployeeRequest request)
    {
        try
        {
            var command = EmployeeMapper.MapToCreateEmployeeCommand(request);
            var result = await sender.Send(command);

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

    internal static async Task<IResult> GetAllEmployees([FromServices] IMediator mediator)
    {
        try
        {
            var result = await mediator.Send(new GetAllEmployeesQuery());

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