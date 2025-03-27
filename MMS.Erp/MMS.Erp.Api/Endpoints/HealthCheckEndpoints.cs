namespace MMS.Erp.Api.Endpoints;

internal static class HealthCheckEndpoints
{
    internal static void MapHealthCheckEndpoint(this IEndpointRouteBuilder route)
    {
        route.MapGet("/health", async context =>
        {
            await context.Response.WriteAsync("Healthy");
        });
    }
}