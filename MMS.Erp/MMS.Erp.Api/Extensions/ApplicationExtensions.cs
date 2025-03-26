using MMS.Erp.Application;
using MMS.Erp.Infrastructure;

namespace MMS.Erp.Api.Extensions;

public static class ApplicationExtensions
{
    public static WebApplicationBuilder AddWebApplicationBuilder(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddApplication();
        builder.Services.AddInfrastrucure();
        return builder;
    }

    public static WebApplication AddWebApplication(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.RegisterEndpoints();

        return app;
    }

    private static void RegisterEndpoints(this IEndpointRouteBuilder route)
    {

    }
}
