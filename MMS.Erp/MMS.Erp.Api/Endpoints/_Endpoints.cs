namespace MMS.Erp.Api.Endpoints;

public static class Endpoints
{
    public static void MapEndpoints(this IEndpointRouteBuilder route)
    {
        route.MapHealthCheckEndpoint();

        route.MapInvoiceEndpoints();
        
        route.MapCustomerEndpoints();

        route.MapEmployeeEndpoints();
    }
}
