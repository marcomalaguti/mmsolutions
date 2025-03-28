namespace MMS.Erp.Api.Handlers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using MMS.Erp.Api.Mappings;
using MMS.Erp.Api.Requests;
using MMS.Erp.Application.Features.Invoice.Queries.GetAllInvoices;

public static class CustomerHandler
{
    const string BaseUrl = "/customers";

    internal static async Task<IResult> CreateCustomer([FromServices] IMediator mediator, CreateCustomerRequest request)
    {
        var command = CustomerMapper.MapToCreateCustomerCommand(request);
        var result = await mediator.Send(command);
        return TypedResults.Created($"{BaseUrl}/{result}");
    }

    internal static async Task<IResult> GetAllCustomers([FromServices] IMediator mediator)
    {
        var result = await mediator.Send(new GetAllInvoicesQuery());
        return TypedResults.Ok();
    }
}