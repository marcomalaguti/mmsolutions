namespace MMS.Erp.Api.Handlers;

using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MMS.Erp.Api.Requests;
using MMS.Erp.Application.Features.Invoice.Commands.CreateInvoice;
using MMS.Erp.Application.Features.Invoice.Queries.GetAllInvoices;

public static class InvoiceHandler
{
    const string BaseUrl = "/invoices";

    internal static async Task<IResult> CreateInvoice([FromServices] ISender sender,
                                                      [FromServices] IMapper mapper,
                                                      CreateInvoiceRequest request,
                                                      CancellationToken cancellationToken)
    {
        var command = mapper.Map<CreateInvoiceCommand>(request);
        var result = await sender.Send(command, cancellationToken);
        return TypedResults.Created($"{BaseUrl}/{result}");
    }

    internal static async Task<IResult> GetAllInvoices([FromServices] ISender sender,
                                                       CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetAllInvoicesQuery(), cancellationToken);
        return TypedResults.Ok(result);
    }
}
