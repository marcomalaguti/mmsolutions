using MMS.Erp.Api.Endpoints;
using MMS.Erp.Application;
using MMS.Erp.Infrastructure;
using Serilog;

namespace MMS.Erp.Api.Extensions;

public static class ApplicationExtensions
{
    public static WebApplicationBuilder AddWebApplicationBuilder(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddApplication();
        builder.Services.AddInfrastrucure(builder.Configuration);

        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration.ReadFrom.Configuration(context.Configuration);
        });

        return builder;
    }

    public static WebApplication AddWebApplication(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseSerilogRequestLogging();

        app.UseHttpsRedirection();

        app.MapEndpoints();

        return app;
    }
}
