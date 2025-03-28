namespace MMS.Erp.Api.Endpoints;

using MMS.Erp.Api.Handlers;

internal static class InvoiceEndpoints
{
    internal static void MapInvoiceEndpoints(this IEndpointRouteBuilder route)
    {
        var group = route.MapGroup("/invoices");

        group.MapGet("/", InvoiceHandler.GetAllInvoices);
        group.MapPost("/", InvoiceHandler.CreateInvoice);
    }
}
