namespace MMS.Erp.Api.Handlers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using MMS.Erp.Api.Mappings;
using MMS.Erp.Api.Requests;
using MMS.Erp.Application.Features.Invoice.Queries.GetAllInvoices;

public static class InvoiceHandler
{
    const string InvoiceBaseUrl = "/invoices";

    internal static async Task<IResult> CreateInvoice([FromServices] IMediator mediator, CreateInvoiceRequest request)
    {
        var command = InvoiceMapper.MapToCreateInvoiceCommand(request);
        var result = await mediator.Send(command);
        return TypedResults.Created($"{InvoiceBaseUrl}/{result}");
    }

    internal static async Task<IResult> GetAllInvoices([FromServices] IMediator mediator)
    {
        var result = await mediator.Send(new GetAllInvoicesQuery());
        return TypedResults.Ok(result);
    }
}
