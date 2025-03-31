namespace MMS.Erp.Api.Handlers;

using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MMS.Erp.Api.Requests;
using MMS.Erp.Application.Features.Customer.Commands.CreateCustomer;
using MMS.Erp.Application.Features.Invoice.Queries.GetAllInvoices;

public static class CustomerHandler
{
    const string BaseUrl = "/customers";

    internal static async Task<IResult> CreateCustomer([FromServices] ISender sender,
                                                       [FromServices] IMapper mapper,
                                                       CreateCustomerRequest request,
                                                       CancellationToken cancellationToken)
    {
        try
        {
            var command = mapper.Map<CreateCustomerCommand>(request);
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

    internal static async Task<IResult> GetAllCustomers([FromServices] ISender sender,
                                                        CancellationToken cancellationToken)
    {
        try
        {
            var result = await sender.Send(new GetAllInvoicesQuery(), cancellationToken);

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