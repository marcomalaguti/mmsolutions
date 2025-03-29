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
        try
        {
            var command = CustomerMapper.MapToCreateCustomerCommand(request);
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

    internal static async Task<IResult> GetAllCustomers([FromServices] IMediator mediator)
    {
        try
        {
            var result = await mediator.Send(new GetAllInvoicesQuery());

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