namespace MMS.Erp.Api.Endpoints;

using MMS.Erp.Api.Handlers;

internal static class CustomerEndpoints
{
    internal static void MapCustomerEndpoints(this IEndpointRouteBuilder route)
    {
        var group = route.MapGroup("/customers");

        group.MapGet("/", CustomerHandler.GetAllCustomers);
        group.MapPost("/", CustomerHandler.CreateCustomer);
    }
}
