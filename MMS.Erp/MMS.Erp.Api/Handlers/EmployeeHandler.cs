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
        var command = EmployeeMapper.MapToCreateEmployeeCommand(request);
        var result = await sender.Send(command);
        return TypedResults.Created($"{BaseUrl}/{result}");
    }

    internal static async Task<IResult> GetAllEmployees([FromServices] IMediator mediator)
    {
        var result = await mediator.Send(new GetAllEmployeesQuery());
        return TypedResults.Ok();
    }
}