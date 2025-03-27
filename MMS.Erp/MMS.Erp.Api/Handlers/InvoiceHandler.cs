namespace MMS.Erp.Api.Handlers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using MMS.Erp.Application.Features.Invoice.Queries.GetAllInvoices;

public static class InvoiceHandler
{
    internal static async Task<IResult> GetAllInvoices([FromServices] IMediator mediator)
    {
        var result = await mediator.Send(new GetAllInvoicesQuery());
        return TypedResults.Ok(result);
    }
}
